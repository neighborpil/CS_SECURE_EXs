using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[RSA User 디자인 및 구동 개념]
(※RSA 서버 참조)

#이벤트 핸들러
 - publicKeyLoadToolStripMenuItem_Click(object sender, EventArgs e) : [Public Key Load] 메뉴, 공개키 로드
 - exitEToolStripMenuItem_Click(object sender, EventArgs e) : [Exit(X)] 메뉴, 폼을 종료
 - btnEncrypt_Click(object sender, EventArgs e) : [암호화], 공개키 데이터를 암호화
 - btnSave_Click(object sender, EventArgs e) : [내보내기], 암호화된 데이터를 테긋트 파일 형태로 RSA Server에 전달
*/
namespace mook_RSAUser
{    
    public partial class Form1 : Form
    {
        string fileString = null;
        public delegate void UpdateTextDelegate(string inputText);

        public Form1()
        {
            InitializeComponent();
        }

        //[Public Key Load] 메뉴 : RSA Server에서 전달받은 공개키를 로드하는 작업
        private void publicKeyLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Public Key Document(*.pke)|*.pke" })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName, true);
                    //파일 경로, detectEncodingFromByteOrderMarks : 파일의 시작 부분에서 바이트 순서 표시를 찾을지 여부를 나타냅니다.
                    fileString = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        //[Exit(X)] 메뉴, 폼을 종료
        private void exitEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //[암호화] : RSA 암호화 알고리즘으로 문자열을 암호화하는 작업 수행
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if(fileString != null)
            {
                UpdateTextDelegate updateTextDelegate = new UpdateTextDelegate(UpdateText);
                int bitNum = 1024;

                try
                {
                    EncryptionThread encThread = new EncryptionThread();
                    Thread encryptThread = new Thread(encThread.Encrypt);
                    encryptThread.IsBackground = true;
                    encThread.Start(new Object[] { this, updateTextDelegate, this.txtMessage.Text, bitNum, fileString });
                }
                catch(Exception ex)
                {
                    MessageBox.Show("에러발생 : " + ex.Message);
                }
            }
        }

        //델리게이트의 대리자 메서드, 암호화된 데이터를 txtEncrypt 컨트롤에 나타내는 작업
        private void UpdateText(string inputText)
        {
            this.txtEncrypt.Text = inputText;
        }

        //[내보내기] : StreamWriter 클래스의 streamWriter.Write() 메서드를 이용하여 
        //암호화된 데이터를 테긋트 파일 형태로 RSA Server에 전달
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { ValidateNames = true, Filter = "Text File(*.txt)|*.txt" })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                        //매개변수 : 파일 경로, 파일을 추가하려면 true, 파일을 덮어쓰려면 false
                        if (this.txtEncrypt.Text != null)
                            streamWriter.Write(this.txtEncrypt.Text);
                        streamWriter.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
