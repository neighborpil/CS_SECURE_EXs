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
namespace mook_FileWipe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
