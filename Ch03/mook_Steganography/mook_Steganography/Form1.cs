using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        //[열기] : 이미지를 선택하고 pbImgView 컨트롤에 출력
        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                this.pbImgView.Image = Image.FromFile(this.ofdFile.FileName);
                this.btnEncrypt.Enabled = true;
                this.btnDecrypt.Enabled = true;
            }
        }

        //[암호화] : txtData 컨트롤에 입력된 문자열을 암호화하여 이미지에 숨기고 이미지파일로 저장
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = "Result : 0개이 픽셀이 변경되었습니다";
            if(this.pbImgView.Image == null)
            {
                MessageBox.Show("이미지를 선택해 주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ImgBmp = (Bitmap)this.pbImgView.Image;
            string HiddenText = this.txtData.Text;
            if (HiddenText.Equals(""))
            {
                MessageBox.Show("이미지에 숨길 문자열을 입력하세요");
                this.txtData.Focus();
                return;
            }
            else
                HiddenText = Crypto.EncryptStringAES(HiddenText, this.txtKey.Text);

            stgpcvt.runNum += new SteganographyConvert.ProcessEventHandler(StegaStatus);
            ImgBmp = stgpcvt.embedText(HiddenText, ImgBmp);
            if(this.sfdFile.ShowDialog() == DialogResult.OK)
            {
                switch (this.sfdFile.FilterIndex)
                {
                    case 0:
                        {
                            ImgBmp.Save(this.sfdFile.FileName, ImageFormat.Png);
                        }break;
                    case 1:
                        {
                            ImgBmp.Save(this.sfdFile.FileName, ImageFormat.Bmp);
                        }break;
                }
            }

            ControlClearAll();
        }

        //각 컨트롤 초기화
        private void ControlClearAll()
        {
            this.pbImgView.Image = null;
            this.txtData.Clear();
            this.txtKey.Clear();
            this.btnEncrypt.Enabled = false;
            this.btnDecrypt.Enabled = false;
        }

        //[복호화] : 이미지에 암호화되어 숨겨진 문자열을 추출하여 txtData 컨트롤에 나타내는 작업 수행
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            this.lblResult.Text = "Result : 0개의 픽셀이 변경되었습니다";
            ImgBmp = (Bitmap)this.pbImgView.Image;

            stgpcvt.runNum += new SteganographyConvert.ProcessEventHandler(StegaStatus);
            string ExtractedText = stgpcvt.ExtractText(ImgBmp);

            try
            {
                ExtractedText = Crypto.DecryptStringAES(ExtractedText, this.txtKey.Text);
            }
            catch
            {
                MessageBox.Show("비밀키가 일치하지 않습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtKey.Focus();
                return;
            }
            this.txtData.Text = ExtractedText;
        }

        private void StegaStatus(int Current)
        {
            this.lblResult.Text = "Result : " + Current.ToString() + "개의 픽셀이 변경되었습니다";
            Application.DoEvents();
        }
        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
