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
[스테가노그래피(Steganography)
 - 비밀 정보를 이미지, 오디오 등의 매체에 은닉하여 그 정보의 존재 자체를 감추는 보안 기술
 - 예제는 이미지에 데이터를 숨기는 알고리즘
#이벤트 핸들러
 - 열기OToolStripMenuItem_Click(object sender, EventArgs e) : [열기] 이미지를 pbImgView 컨트롤에 출력
 - btnEncrypt_Click(object sender, EventArgs e) : [암호화] 데이터를 암호화하여 이미지에 숨겨 파일로 저장
 - btnDecrypt_Click(object sender, EventArgs e) : [복호화] 이미지에 숨겨진 데이터를 찾아 txtData 컨트롤에 나타냄
 - 종료XToolStripMenuItem_Click(object sender, EventArgs e) : [종료] 폼 종료
*/
namespace mook_Steganography
{
    public partial class Form1 : Form
    {
        Bitmap ImgBmp = null;
        SteganographyConvert stgpcvt = new SteganographyConvert();

        public Form1()
        {
            InitializeComponent();
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
