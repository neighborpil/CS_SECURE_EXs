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
[DES 암호화, 복호화]
 - DES(Data Encryption Standard) : 블ㄹ고 암호의 일종
 - 미국 NBS(National Bureau of Standard, 현 NIST)에서 국가 표준으로 정한 알고리즘
 - 대칭키 암호화 방식으로 56비트 키를 사용하여 데이터를 암호화
 - 현재는 취약한것으로 알려짐(너무 짧아서 현재 컴퓨터 성능)
 - Triple-DES : 취약점 보완 위해 DES를 세번 반복하는 방법

#DES 암, 복호화 프로그램
 - .NET Framework에서 기본으로 제공하는 DES 암, 복호화 클래스 이용하여 문자열 암, 복호화 어플리케이션 구현

#암호화
 - 8자리의 스트링을 바이트배열로 바꾸고 그것을 Key로 하여 MemoryStream개체를 CryptoStream개체에 담고 이것을 이용해 다시 StreamWriter개체를 만든다
   이 StreamWriter개체에 원하는 텍스트를 넣어서 쓰고 이것을 다시 Base64String으로 만들어서 보낸다
#복호화
 - bas64로된 string을 읽어 byte배열로 변환
 - byte 배열을 MemoryStream에 넣어서 객체 생성
 - 복호화에 사용할 ICryptoTransform 객체 생성, DesKey.CreateDecryptor()메서드를 이용
 - CryptoStream 객체 생성, MemoryStream과 ICryptoTransform를 넣어서 Read모드로 생성
 - StreamReader객체 생성, CryptoStream객체 넣음
 - StreamReader.ReadToEnd() 메서드로 끝까지 읽어 Textbox에 저장

#이벤트 핸들러
btnEcrypt_Click(object sender, EventArgs e) : 문자열을 DES 알고리즘을 이용하여 암호화
btnDecrypt_Click(object sender, EventArgs e) : 문자열을 DES 알고리즘을 이용하여 복호화
*/
namespace mook_DES
{
    public partial class Form1 : Form
    {
        string DESKey = null;
        string DESIV = null;

        public Form1()
        {
            InitializeComponent();
        }

        //문자열을 DES 알고리즘을 이용하여 암호화
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if(this.txtPrivate.Text == "" || this.txtPrivate.Text.Length < 8)
            {
                MessageBox.Show("PrivateKey 입력이 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPrivate.Focus();
                return;
            }
            if(this.txtOrig.Text == "")
            {
                MessageBox.Show("암호화 할 문자열 입력이 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtOrig.Focus();
                return;
            }
            PrivateKeyCreate(this.txtPrivate.Text); //대칭 알고리즘에 대한 초기화 벡터(IV) 및 DES 알고리즘의 비밀키 설정

            DESCryptoServiceProvider DesKey = new DESCryptoServiceProvider(); //DESCryptoServiceProvider클래스 : 하위 메서드 및 속성 사용하여 문자열 암호화
            DesKey.Key = Encoding.Default.GetBytes(DESKey);  //DesKey.Key 속성 이용하여 대칭키 알고리즘에 대한 비밀키 설정, txtPrivate 컨트롤에 입력된 8자리 문자를 바이트로 인코딩
                                                             //각 8개의 문자를 10진수 값으로 대칭키 알고리즘에 대한 비밀키에 설정, 암&복호화시 일치해야 정상적으로 진행됨
            DesKey.IV = Encoding.Default.GetBytes(DESIV);  //DEsKey.IV 속성을 이용하여 대칭키 알고리즘에 대한 초기화 벡터(IV)를 설정하는 구문, txtPrivate 컨트롤에 입력된
                                                           //8자리 역순의 모든 문자가 바이트로 인코딩되면서 초기화 벡터(IV)를 설정, 암&복호화시 일치해야 정상적으로 진행됨

            MemoryStream ms = new MemoryStream(); //확장 가능한 용량을 사용 할 수 있도록 메모리 스트림을 만드는 작업
            CryptoStream encStream = new CryptoStream(ms, DesKey.CreateEncryptor(), CryptoStreamMode.Write); //데이터 스트림을 암호화 변환에 연결하는 작업
                                                           //이때 DesKey.CreateEncryptor() 메서드를 이용하여 ms메모리 스트림에 암호화하여 저장하기 위한 작업 수행
            StreamWriter sw = new StreamWriter(encStream); //CrytpoStream 클래스의 개체인 encStream을 이용하여 개체를 생성

            sw.Write(this.txtOrig.Text);
            sw.Close();
            encStream.Close();

            this.txtEncrypt.Text = Convert.ToBase64String(ms.ToArray());
            ms.Close();
        }

        //txtPrivate 컨트롤에 입력된 8자리 문자열을 이용하여 초기화 벡터(IV) 및 비밀키를 생성하는 구문
        private void PrivateKeyCreate(string strKey)
        {
            
            DESKey = strKey;  //DES 알고리즘 비밀키 설정하는 구문, DESKey 변수에 8자리 문자를 저장
            byte[] tempK = Encoding.ASCII.GetBytes(strKey); //입력된 8자리 문자를 바이트 단위로 인코딩, 이는 DES알고리즘의 비밀키의 역순 값을 초기화 벡터(IV)값으로 만들기 위한 작업
            System.Array.Reverse(tempK); //배열요소의 순서를 역순으로 나열

            string tempI = Encoding.ASCII.GetString(tempK); //GetString()메서드를 이용하여 바이트 인코딩된 값을 문자값으로 변경
            DESIV = tempI;
        }

        //DES 알고리즘을 통해 암호화한 문자를 복호화
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (this.txtPrivate.Text == "" || this.txtPrivate.Text.Length < 8)
            {
                MessageBox.Show("PrivateKey 입력이 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPrivate.Focus();
                return;
            }
            if (this.txtEncrypt.Text == "")
            {
                MessageBox.Show("복호화 암호화 데이터 입력이 올바르지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtOrig.Focus();
                return;
            }

            PrivateKeyCreate(this.txtPrivate.Text);
            DESCryptoServiceProvider DesKey = new DESCryptoServiceProvider();
            DesKey.Key = Encoding.Default.GetBytes(this.DESKey);
            DesKey.IV = Encoding.Default.GetBytes(this.DESIV);

            byte[] buffer = Convert.FromBase64String(this.txtEncrypt.Text); //FromBase64STring 메서드를 이용하여 Base64 숫자의 이진 데이터를 해당하는 8비트 부호 없는 정수배열로
                                                                            //인코딩하는 방식으로 지정된 문자열 변환
            MemoryStream ms = new MemoryStream(buffer);
            ICryptoTransform ct = DesKey.CreateDecryptor(); //DesKey.CreateDecryptor() 메서드 이용하여 ICryptoTransform개체 생성,
                                                            //암호화된 문자를 복호화 하는 작업을 수행하기 위한 Tramsform 생성
            CryptoStream encStream = new CryptoStream(ms, ct, CryptoStreamMode.Read); //암호화된 MemoryStream을 읽어서 복호화 수행
            StreamReader sr = new StreamReader(encStream);

            this.txtDecrypt.Text = sr.ReadToEnd();
            sr.Close();
            encStream.Close();
            ms.Close();
        }
    }
}
