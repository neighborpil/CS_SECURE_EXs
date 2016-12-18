using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[파일 해시값 알아보기]
#MD5(Message-Digest Algorithm 5) : 128비트 암호하 해시 함수, 프로그램이나 파일이 원본 그대로인지 확인하는 무결성 검사에 사용
#SHA(Secure Hash Algorithm, 안전한 해시 알고리즘) : 서로 관련된 암호학적 해시 함수들의 모임
 - 해시 함수의 기초가 되는 알고리즘
 - MD5와 SHA-1에 대한 공격법은 이미 발견되어서 다른 해시 알고리즘 사용을 권장
 - 다른 해시 알고리즘도 매우 유사하기 때문에 이 예제로 연습

#이벤트 핸들러
btnOpen_Click(object sender, EventArgs e) : [Open File] 버튼 이벤트 핸들러, 선택한 파일에 대한 MD5와 SHA-1 해시 값을 구함
btnClear_Click(object sender, EventArgs e) : [Clear] 버튼 이벤트 핸들러, 입력 컨트롤에 문자를 초기화
*/
namespace mook_FileHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //[Open File] 이벤트 핸들러, HashConvert 클래스의 GetMD5Hash()와 GetSHA1Hash()메서드 호출
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.ofdFile.FileName;

                try
                {
                    this.txtMD5.Text = HashConvert.GetMD5Hash(this.ofdFile.FileName); //지정된 파일의 MD5 해시값 구하기
                }
                catch { return; }

                try
                {
                    this.txtSHA.Text = HashConvert.GetSHA1Hash(this.ofdFile.FileName); //지정된 파일의 SHA-1 해시값 구하기
                }
                catch { return; }
            }
        }

        //txt창 초기화
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPath.Text = "";
            txtMD5.Text = "";
            txtSHA.Text = "";
        }
    }
}
