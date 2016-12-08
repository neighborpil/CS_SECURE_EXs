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

            }
        }
    }
}
