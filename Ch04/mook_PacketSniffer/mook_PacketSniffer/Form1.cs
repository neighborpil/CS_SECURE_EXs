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
[네트워크 패킷 스니핑]
 - 네트워크 패킷을 분석하기 위한 분석도구로 사용
 - 내부 네트워크의 패킷을 모니터링하기 위해 사용
 - 지나다니는 패킷을 한 컴퓨터에 모이게 한 다음 네트워크 패킷 스니핑 프로그램으로 분석하면 비밀번호등 중요 정보 추출 가능

#예제
 - 패킷 상세 분석X
 - IP, TCP, UDP 등 프로토콜을 구분하여 다양한 정보 추출
*/
namespace mook_PacketSniffer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
