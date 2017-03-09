using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : [폼로드], IP를 가져오는 작업
 - tsbtnStart_Click(object sender, EventArgs e) : [Start], Socket을 열어 네트워크 패킷을 스니핑하는 작업 수행
 - tsbtnStop_Click(object sender, EventArgs e) : [Stop], Socket을 닫아 네트워크 패킷 스니핑을 종료
 - lvReceivedPackets_Click(object sender, EventArgs e) : IP, TCP, UDP 상세 정보를 tvPacketDetail 컨트롤에 나타냄
*/
namespace mook_PacketSniffer
{
    public partial class Form1 : Form
    {
        private Socket mainSocket;
        private byte[] byteData = new byte[4096];
        private bool bContinueCapturing = false;

        private int PacketNum = 1;
        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// tscbIp 컨트롤에 네트워크 패킷을 모니터링 할 IP 주소를 나타냄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.tscbNum.Text = "100";

            string strIP = null;

            IPHostEntry HostEntry = Dns.GetHostEntry((Dns.GetHostName())); //로컬 컴퓨터의 IP정보를 검색하기 위하여 로컬 컴퓨터의 호스트 이름을 지정하고
                                                                           //IP 컬렉션 정보를 IPHostEntry클래스 개체에 저장

            if(HostEntry.AddressList.Length > 0) 
            {
                foreach(IPAddress ip in HostEntry.AddressList) //HostEntry.AddressList속성을 통해 가져온 로컬 컴퓨터의 IP 정보를 IPAddress 클래스 개체인 ip에 저장
                {
                    strIP = ip.ToString();
                    this.tscbIp.Items.Add(strIP);
                }
            }
        }

        /// <summary>
        /// 로컬 컴퓨터의 네트워크 패킷을 스니핑
        /// </summary>
        private void tsbtnStart_Click(object sender, EventArgs e)
        {
            if(this.tscbIp.Text == "")
            {
                MessageBox.Show("캡처할 네트워크 인터페이스를 선택하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!bContinueCapturing)
                {
                    this.tsbtnStart.Enabled = false;
                    this.tsbtnStop.Enabled = true;

                    bContinueCapturing = true;

                    mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP); 
                                //소켓 생성, SocketType.Raw : 내부 전송 프로토콜에 대한 액세스 지원

                    mainSocket.Bind(new IPEndPoint(IPAddress.Parse(this.tscbIp.Text), 0)); //Bind()메소드로 txt컨트롤의 주소 연결
                                //IPEndPoint 생성자의 두번째 매개변수 port : address와 연결된 포트 번호이거나, 사용할 수 있는 포트를 지정할 경우 0

                    mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
                                //.SetSocketOption()스니핑할 프로토콜 자원(TCP, UDP, IP)의 수준로 그룹화
                    byte[] byTrue = new byte[4] { 1, 0, 0, 0 };
                    byte[] byOut = new byte[4] { 1, 0, 0, 0 };

                    mainSocket.IOControl(IOControlCode.ReceiveAll, byTrue, byOut);

                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnStop_Click(object sender, EventArgs e)
        {

        }

        private void lvReceivedPackets_Click(object sender, EventArgs e)
        {

        }
    }

    
}
