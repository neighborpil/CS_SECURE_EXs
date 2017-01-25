using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[TDES 암&복호화]
 - DES 암&복호화 알고리즘의 취약점 때문에 DES보다 비교적 안전한 Triple DES(TDES) tkdyd
 - 각 데이터 블록에 데이터 암호화 알고리즘(DES)을 세번 적용한 트리플 데이터 암호화 알고리즘

#암호화 과정
 1. UTF-8 방식의 바이트 배열성성
 2. CreateEncryptor() 메서드 이용 암호화
 3. Base64 숫자로 인코딩
            
#복호화 과정
 1. Base64 숫자 인코딩 후 바이트 배열생성
 2. CreateDecrytor()메서드 이용 복호화
 3. Base64 복호화 된 데이터를 문자열타입으로 변환

#이벤트 핸들러
btnEncrypt_Click(object sender, EventArgs e) : 문자열을 바이트 단위로 불러와 TDES 방식으로 암호화
btnDecrypt_Click(object sender, EventArgs e) : TDES 방식으로 암호화 되어 있는 문자열을 복호화
*/
namespace mook_TDES
{
    public partial class Form1 : Form
    {
        private TripleDESCryptoServiceProvider Tdes = new TripleDESCryptoServiceProvider();
        //TripleDES 알고리즘에 대한 비밀키를 설정, 한번에 64비트씩 증가하는 128~192비트까지의 키의 길이 지원,
        //여기서는 192비트 즉 24byte 비밀키 값을 갖도록 지정
        private byte[] PrivateKey = new byte[] {98, 45, 125, 56, 1, 60, 11, 38, 123, 54, 234, 9,
            76, 20, 44, 7, 12, 223, 219, 95, 48, 156, 32, 239 };
        //대칭 알고리즘에 대한 초기화 벡터(IV)를 설정, 64비트(8byte)로 구성, 이 구성 값은 1byte가 가질 수 있는 0~255 중 임의의 숫자로 구성
        private byte[] PrivateIV = new byte[] { 67, 12, 3, 41, 66, 78, 34, 123 };

        public Form1()
        {
            InitializeComponent();

            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < PrivateKey.Length; i++)
            //{
            //    char c = (char)PrivateKey[i];

            //    sb.Append(c);
            //}
            //Console.WriteLine(sb.ToString());
        }

        //문자열을 암호화하여 나타내주는 작업 수행
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (this.txtOriginal.Text != "")
                this.txtEncrypt.Text = Encrypt(this.txtOriginal.Text);
        }

        //입력된 문자열을 UTF-8 인코딩을 통해 바이트 배열 저장 후 이를 바이트 단위로 암호화
        private string Encrypt(string strEncrypt)
        {
            string encrypted = null;
            byte[] code = UTF8Encoding.UTF8.GetBytes(strEncrypt); //입력된 문자열을 byte시퀀스로 인코딩
            //byte배열로 만들어진 문자열을 CreateEncryptor() 메서드를 이용하여 암호화
            encrypted = Convert.ToBase64String(Tdes.CreateEncryptor(PrivateKey, PrivateIV).TransformFinalBlock(code, 0, code.Length));
            /*
            #des.CreateEncryptor(enrgbkey, enrgbiv) : 지정된 키와 초기화 벡터를 사용하여 대칭 TripleDES encryptor 개체를 만들고
                                                     이 개체를 사용하여 데이터 암호화
             - enrgbkey : 대칭 알고리즘에 사용할 비밀 키
             - enrgbiv : 대칭 알고리즘에 사용할 초기화 벡터
             ※ 비밀키와 초기화 벡터는 암복호화 할 때 같은 값
            
            #TransformFinalBlock(Code, 0, Code.Length) : 지정된 바이트 배열의 지정된 영역에 대해 데이터의 암호화 변한을 수행한 뒤 바이트배열 반환
             - Code : 암호화 할 바이트 배열 데이터
             - 0 : 시작 할 바이트 배령의 오프셋
             - Code.Length : 바이트 배열의 바이트 수

            #Convert.ToBase64String(바이트 배열) : 8비트 부호 없는 정수로 구성된 배열의 값을 Base64 숫자로 인코딩된 해당하는 문자열 표현으로 변환
            */

            return encrypted;
        }

        //암호화 된 데이터 복호화
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (this.txtEncrypt.Text != "")
                this.txtDecrypt.Text = Decrypt(this.txtEncrypt.Text);
        }

        //복호화 메소드, Encrypt() 코드의 순서를 반대로
        private string Decrypt(string strDecrypt)
        {
            string decrypted = null;
            byte[] code = Convert.FromBase64String(strDecrypt);
            //byte배열 code를 이용하여 복호화
            decrypted = UTF8Encoding.UTF8.GetString(Tdes.CreateDecryptor(PrivateKey, PrivateIV).TransformFinalBlock(code, 0, code.Length));
            /*
            #암호화 과정
             1. UTF-8 방식의 바이트 배열성성
             2. CreateEncryptor() 메서드 이용 암호화
             3. Base64 숫자로 인코딩
            
            #복호화 과정
             1. Base64 숫자 인코딩 후 바이트 배열생성
             2. CreateDecrytor()메서드 이용 복호화
             3. Base64 복호화 된 데이터를 문자열타입으로 변환
            */
            return decrypted;
        }
    }
}
