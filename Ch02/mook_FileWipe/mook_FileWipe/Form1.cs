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
#Anti Forensic : 디지털 포렌식 방해 기법
 - 데이터 파괴
 - 데이터 암호화
 - 데이터 은닉 : 데이터를 쉽게 탐지할 수 없도록 데이터를 숨기는 기법(ex. 스테가노그래피, 파일 시스템 구조에서 낭비되는 영역에 데이터 숨기기)
 - 데이터 조작 : 데이터를 조작해서 감추기(ex. 파일 시스템의 시간 정보를 조작하는 방법 : 존재를 들키지 않고 오래 남아있어야
                하는 악성코드는 시간정보 조작하여 정상파일로 위장, 로그를 조적하여 정상적인 행위로 위장)
 - 분석시간 증가 : 분석하기 어렵게 만드는 법(ex. 코드 난독화(Code Obfuscation), 실행 압축(Packing), 래핑(Wrapping))
                  해당 기법을 반복 또는 조합하거나 공개된 방법 이외에 자신만의 방법도 사용

*/
/*
btnPath_Click(object sender, EventArgs e) : [...]버튼을 눌렀을 때 발생하는 이벤트 핸들러, [열기] 대화상자를 호출하고 파일의 경로 설정
btnWipe_Click(object sender, EventArgs e) : [Wipe]버튼을 눌렀을 때 발생하는 이벤트 핸들러, 파일을 삭제
cbWipe_SelectIndexChanged(object sender, EventArgs e) : cbWipe 컨트롤의 Items 선택시 발생하는 이벤트 핸들러, 삭제 알고리즘 선택
*/
namespace mook_FileWipe
{
    public partial class Form1 : Form
    {
        FileDelete fd = null; //파일을 삭제하는데 사용되는 메소드와 속성을 지원하는 개체

        public Form1()
        {
            InitializeComponent();
        }

        //[...]버튼 클릭, openFileDialog를 호출하고 파일의 경로 설정
        private void btnPath_Click(object sender, EventArgs e)
        {
            if(ofdFile.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = ofdFile.FileName;
            }
        }

        //[Wipe] 버튼 : FileDelete 클래스의 인스턴스를 이용하여 선택된 파일을 삭제
        private void btnWipe_Click(object sender, EventArgs e)
        {
            if(this.cbWipe.Text == "")
            {
                MessageBox.Show("Wipe 방법을 선택해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbWipe.Focus();
                return;
            }
            else if(this.txtPath.Text == "")
            {
                MessageBox.Show("삭제할 파일을 선택하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnPath.Focus();
                return;
            }

            //British HMG IS5(Base Line)
            //British HMG IS5(Enhanced)
            //British HMG IS5 (Base Line)
            //British HMG IS5(Enhanced)

            switch (this.cbWipe.Text)
            {

                case "British HMG IS5 (Base Line)":
                    fd = new FileDelete(this.txtPath.Text);
                    fd.runPer += new FileDelete.ProcessEventHandler(WipeStatus); //FileDelete에서 델리게이트를 만들어 놓고 거기에 Form1의 메소드를 집어 넣는다
                    fd.British_HMG_IS5_BaseLine(this.txtPath.Text);              //그럼 FileDelete가 종료될 때 Form1에 값을 반환한다!!!!!!!!!!!!!드뎌 찾았다!!!
                    break;
                case "British HMG IS5 (Enhanced)":
                    fd = new FileDelete(this.txtPath.Text);
                    fd.runPer += new FileDelete.ProcessEventHandler(WipeStatus);
                    fd.British_HMG_IS5_Enhanced(this.txtPath.Text);
                    break;
            }
        }

        //삭제 진행률을 나타내는 이벤트 처리기로 lblPer컨트롤에 파일을 삭제하는 진행상태를 나타내는 작업
        private void WipeStatus(int Current)
        {
            switch (Current)
            {
                case 0:
                    this.lblPer.Text = "진행률 : " + Current + "%";
                    break;
                default:
                    this.lblPer.Text = "진행률 : " + Current + "%";
                    if(Current == 100)
                        this.txtPath.Text = "";
                    break;
            }
            Application.DoEvents(); //현재 메세지 큐에 있는 모든 Windows 메세지를 처리,
                                    //이벤트가 발생할 때 델리게이트에 설정된 이벤트 처리기가 호출되어 진행률이 올라가는데 자연스러운 숫자 변경을 위한 구문
        }

        private void cbWipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbWipe.Text)
            {
                case "British HMG IS5 (Base Line)":
                    this.lblTotal.Text = "Level : 1";
                    break;
                case "British HMG IS5 (Enhanced)":
                    this.lblTotal.Text = "Level : 3";
                    break;
            }
        }
    }
}
