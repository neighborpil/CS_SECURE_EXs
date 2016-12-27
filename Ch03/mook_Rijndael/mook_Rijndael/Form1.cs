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
[Rijndael 암&복호화]
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
        byte[] privateVI = null; //16자리

        public Form1()
        {
            InitializeComponent();
        }

        //[열기] 대화상자를 열고 파일을 선택하여 일기 내용을 txtDiary 컨트롤에 출력
        private void btnFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "JPEG|*.jpg" })
            {
                if
            }
        }
    }
}
