using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[RSA]
 - 비대칭키 암호화 알고리즘
 - 수신자의 공개키를 가져와서 암호화하고, 수신자는 자신의 비밀키로 복호화한다
 - 대칭키 방식이 비밀키를 전달 중 해킹 당할 위험이 있지만 그에 비해 안전
 - 대칭키 방식에 비해 10~1000배 느리다
 - 따라서 비번 같이 중요한 것은 비대칭키 방식, 일반 데이터 전송은 대칭키 방식 주로 사용

#RSA
 - 종류 : 블록
 - 키의 크기 : 512, 1024 2048
 - 가장 많이 사용, 2000년도 특허 만료
 - 전자서명 가능 최초 알고리즘

#예제 구성
 1. 수신자(mook_Server.exe(RSA Server))
  - 공개키(*.pke)와 비밀키(*.kez)를 생성
  - 공개키를 내보내는 기능
  - 송신자에게 암호화된 통신문을 가져오는 기능
 2. 송신자(mook_RSA.exe(RSA User))
  - 수신자의 공개키를 가져와 데이터를 암호화
  - 암호화 데이터 파일을 내보내기

#이벤트 핸들러
publicKey ToolStripMenuItem_Click(object sender, EventArgs e) : [Public Key], 공개키 생성
privateKey ToolStripMenuItem_Click(object sender, EventArgs e) : [Private Key], 비밀키 생성
btnSave_Click(object sender, EventArgs e) : [내보내기], 공개키 저장
btnGetFile_Click(object sender, EventArgs e) : [가져오기], 암호화된 텍스트 파일을 가져오는 작업
btnDecrypt_Click(object sender, EventArgs e) : [복호화], 암호화된 데이터를 복호화
exitXToolStripMenuItem_Click(object sender, EventArgs e) : [Exit] 메뉴 클릭, 어플 종료

#직렬화, 비직렬화
 - C#의 복합 데이터 형식을 스트림에 읽고 쓰게 해주는 메커니즘

1. 직렬화(Serialization)
 - SerializableAttribute를 클래스/구조체/열거형/델리게이트에 적용해 사용
 - 직렬화된 개체를 스트림에서 읽고 쓰는 것(네트워크로 전송하거나 파일에 읽고 쓰는 것이 가능)이 가능

2. 비직렬화(DeSerialization)
 - 특정 멤버에 NonSerializedAttribute를 적용해 주면 해당 멤버는 직렬하가 불가능
 - 직렬화를 원하지 않는 멤버에 적용할 용도의 속성
 - 직렬화가 불가능한 멤버에는 반드시 이 속성 적용
*/

//RSA 서버
namespace mook_RSA
{
    public partial class Form1 : Form
    {
        public delegate void UpdateTextDelegate(string inputText);
        RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(1024); //RSACryptoServiceProvider 클래스의
                    //개체인 RSAProvider를 생성하는 구문, 지정된 키의 크기(1024)를 사용하여 CSP(암호화 서비스 공급자)가
                    //제공한 RSA 알고리즘 구현을 사용하여 비대칭 암호화와 해독을 수행

        public Form1()
        {
            InitializeComponent();
        }

        //[Public Key] : 공개키를 생성
        private void publicKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdFile.Filter = "Public Key Document(*.pke)|*.pke";
            if(sfdFile.ShowDialog() == DialogResult.OK)
            {

                #region ToXmlString(false) 메소드
                /*
                    #ToXmlString(false) : 공개키
                     - ToXmlString에 인수값을 false로 전달하면 XML 형식의 공개키만을 포함하는 문자열을 생성하고 반환한다
                     - XML 문자열은 .Net Framework의 내부 메커니즘을 통해 생성된다
                     - 형식
                        <RSAKeyValue>
                            <Modulus> ... </Modulus>
                            <Exponent> ... </Exponent>
                        </RSAKeyValue>
                */
                #endregion

                string PrivateKeys = RSAProvider.ToXmlString(false); //현재 RSA 개체의 공개키가 들어 있는 XML문자열 생성
                try
                {
                    StreamWriter streamWriter = new StreamWriter(sfdFile.FileName, false);

                    if (PrivateKeys != null)
                        streamWriter.Write(PrivateKeys);
                    streamWriter.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //[Private Key] 메뉴 : 비밀키 생성
        private void privateKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfdFile.Filter = "Private Keys Document(*.kez)|*.kez";
            if(sfdFile.ShowDialog() == DialogResult.OK)
            {


                #region ToXmlString(true) 메소드
                /*
                    #ToXmlString(true) : 비밀키
                     - ToXmlString에 인수값을 true 전달하면 XML 형식의 공개 및 비밀 RSA키를 포함하는 문자열을 생성하고 반환한다
                     - XML 문자열은 .Net Framework의 내부 메커니즘을 통해 생성된다
                     - 형식
                        <RSAKeyValue>
                            <Modulus> ... </Modulus>
                            <Exponent> ... </Exponent>
                            <P> ... </P>
                            <Q> ... </Q>
                            <DP> ... </DP>
                            <DQ> ... </DQ>
                            <InverseQ> ... </InverseQ>
                            <D> ... </D>
                        </RSAKeyValue>
                */
                #endregion

                string PrivateKeys = RSAProvider.ToXmlString(true); //RSA 개체의 비밀키가 들어 있는 XML 문자열 생성
                try
                {
                    StreamWriter streamWriter = new StreamWriter(sfdFile.FileName, false);
                    //StreamWriter(파일 경로, true이면 데이터를 추가하고 false이면 새로 or 덮어쓰기)
                    if (PrivateKeys != null)
                        streamWriter.Write(PrivateKeys);
                    streamWriter.Close();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        //[Exit] : Close() 메소드 호출하여 어플 종료
        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //[내보내기] : 공개키 파일(*.pke)을 송신자에게 전달
        private void btnSave_Click(object sender, EventArgs e)
        {
            ofdFile.Filter = "Public Key Document(*.pke)|*.pke"; //먼저 OpenFileDialog로 Public Key를 읽어들인다
            if(ofdFile.ShowDialog() == DialogResult.OK)
            {
                sfdFile.Filter = "Public Key Document(*.pke)|*.pke"; //읽어들인 Public Key를 다시 SaveFileDialog를 생성하여 복사한다
                if(sfdFile.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(this.ofdFile.FileName);
                    fi.CopyTo(this.sfdFile.FileName); //지정된 파일 경로에 파일 복사하여 생성
                }
            }
        }

        //[가져오기] : 송신자가 생성한 암호화된 Text파일을 읽는 작업
        private void btnGetFile_Click(object sender, EventArgs e)
        {
            ofdFile.Filter = "Text File(*.txt)|*.txt";
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader
                }
            }
        }
    }
}
