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
 - 네트워크 패킷을 분석하기 위한 분석 도구
 - 내부 네트워크의 패킷을 모니터링 하기 위하여도 사용
 - 내부에서 지나다니는 패킷을 한 컴퓨터에 모이게 한 다음, 네트워크 패킷 스티핑 프로그램으로 패킷을 분석하면 그 안에 비밀번호등 중요 정보 획득
 - 해커들은 해킹을 위한 준비작업으로 네트워크 패킷을 분석하는 작업을 거치는데 이러한 패킷 스니핑 프로그램을 사용

#예제의 특징
 - 패킷을 상세히 분석하지는 않음
 - IP, TCP, UDP 등 프로토콜을 구분하여 다양한 정보를 나타내 준다
 - 패킷을 상세히 분석하기 위해서는 TCP/IP, UDP 프로토콜에 대한 사전 지식 습득이 필요
*/
namespace mook_PacketSniffer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
