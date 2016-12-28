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
[Rijndael 암&복호화]
 - 대칭키 알고리즘
 - AES 후보 기술
 - 3가지 키 크기(128bit, 192bit, 256bit) 지원
 - 새로운 대칭 블록 암호
 - 서로 다른 다양한 컴퓨터 환경에서도 우수한 성능
 - 메모리 적게 차지해 스마트카드 등 메모리 용량이 작은 장치에서도 손쉽게 쓸 수 있는 강력한 암&복호화 알고리즘

#이벤트 핸들러
btnFile_Click(object sender, EventArgs e) : [File Open] 버튼, [열기] 대화상자를 오픈
btnConvert_Click(object sender, EventArgs e) : [Decrypt] 버튼, 암호화된 문자를 복호화
btnSave_Click(object sender, EventArgs e) : [File Save] 버튼, 일기를 암호화하여 저장
*/
namespace mook_Rijndael
{
    public partial class Form1 : Form
    {
        //private string FilePath = null;
        byte[] privateKey = null; //16, 24, 32중
        byte[] privateIV = null; //16자리

        public Form1()
        {
            InitializeComponent();
        }

        //[열기] 대화상자를 열고 파일을 선택하여 일기 내용을 txtDiary 컨트롤에 출력
        private void btnFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "Text|*.txt" })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    StreamReader sr = new StreamReader(filePath, Encoding.Default);
                    this.txtDiary.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        //[Decrypt], txtDiary 컨트롤에 나타난 암호화된 문자열을 복호화
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if(this.txtPrivateKey.Text == "" || this.txtPrivateKey.Text.Length < 8)
            {
                MessageBox.Show("PrivateKey 입력이 올바르지 않습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrivateKey.Text = "";
                this.txtPrivateKey.Focus();
                return;
            }

            //비밀키 생성 구문, 비밀키는 192비트 32개의 문자로 이뤄진다, 여기서는 txtPrivate 컨트롤에 입력된 8자리 문자를 4번 반복한다
            string strkey = this.txtPrivateKey.Text + this.txtPrivateKey.Text + this.txtPrivateKey.Text + this.txtPrivateKey.Text;
            privateKey = Encoding.ASCII.GetBytes(strkey); //byte배열로 변환
            //초기화 벡터는 비밀키가 192비트일때는 16개의 문자 96비트이다, txtPrivateKey를 2번하여 byte배열로 만들고 reverse한다
            byte[] arrIv = Encoding.ASCII.GetBytes(this.txtPrivateKey.Text + this.txtPrivateKey.Text); 
            Array.Reverse(arrIv);
            privateIV = arrIv;

            try
            {
                MemoryStream msDecrypt = null;
                CryptoStream csDecrypt = null;
                StreamReader srDecrypt = null;
                RijndaelManaged aesAlg = null;
                string plaintext = null;

                aesAlg = new RijndaelManaged();
                aesAlg.Key = privateKey; //Rijndael 암&복호화 알고리즘의 대칭 알고리즘에 대한 비밀키 설정
                aesAlg.IV = privateIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV); //CryptoStream의 두번째 매개변수인 스트림에 대해 수행될 암호화 변형값
                byte[] cipherText = Convert.FromBase64String(this.txtDiary.Text);//text를 byte배열로 변환
                msDecrypt = new MemoryStream(cipherText); //byte배열을 memorystream에 넣고
                csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read); //그것을 다시 CryptoStream에 ICryptoTransform 객체와 함께 넣고
                srDecrypt = new StreamReader(csDecrypt); //streamReader에 넣어서
                plaintext = srDecrypt.ReadToEnd(); //끝까지 읽는다

                if (srDecrypt != null) srDecrypt.Close();
                if (csDecrypt != null) csDecrypt.Close();
                if (msDecrypt != null) msDecrypt.Close();
                if (aesAlg != null) aesAlg.Clear();

                this.txtDiary.Text = plaintext;
            }
            catch
            {
                MessageBox.Show("복호화에 장애가 발생하였습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //암호화된 txtDialog 컨트롤의 문자열을 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
           if(this.txtPrivateKey.Text == "" || this.txtPrivateKey.Text.Length < 8)
            {
                MessageBox.Show("PrivateKey 입력이 올바르지 않습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtPrivateKey.Text = "";
                this.txtPrivateKey.Focus();
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { ValidateNames = true, Filter = "TEXT|*.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string saveFilePath = sfd.FileName;
                    StreamWriter sw = new StreamWriter(saveFilePath, false, Encoding.Default);
                    sw.Write(StringEncrypt()); //암호화된 string을 streamWriter에 넣어서 쓰기
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        private string StringEncrypt()
        {
            string strkey = this.txtPrivateKey.Text + this.txtPrivateKey.Text + this.txtPrivateKey.Text + this.txtPrivateKey.Text;
            privateKey = Encoding.ASCII.GetBytes(strkey);
            //초기화 벡터를 여기서는 동일하게 사용하였지만 실제로는 랜덤하게 사용해야 한다
            byte[] arrIv = Encoding.ASCII.GetBytes(this.txtPrivateKey.Text + this.txtPrivateKey.Text);
            Array.Reverse(arrIv);
            privateIV = arrIv;

            MemoryStream msEncrypt = null;
            CryptoStream csEncrypt = null;
            StreamWriter swEncrypt = null;
            RijndaelManaged aesAlg = null;

            aesAlg = new RijndaelManaged();
            aesAlg.Key = privateKey;
            aesAlg.IV = privateIV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            msEncrypt = new MemoryStream();
            csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write(this.txtDiary.Text);

            if (swEncrypt != null) swEncrypt.Close();
            if (csEncrypt != null) csEncrypt.Close();
            if (msEncrypt != null) msEncrypt.Close();
            if (aesAlg != null) aesAlg.Clear();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }
}
