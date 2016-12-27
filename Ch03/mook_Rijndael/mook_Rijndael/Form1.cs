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
*/
namespace mook_Rijndael
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
