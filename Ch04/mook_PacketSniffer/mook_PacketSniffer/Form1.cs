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
                    /*
                    #Socket.IOControl
                     - IOControlCode열거형으로 컨트롤 코드를 지정하여 소켓의 하위 패킷을 제어하기 위하여 운영 모드 설정
                     - 매개변수
                       1. IOControlCode : 수행할 작업의 컨트롤 코드를 지정하는 IOControlCode값
                          - ReceiveAll : 모든 IPv4 패킷을 받는다
                       2. optionValue : 해당 작업에 필요한 입력 데이터를 포함하는 Byte형식의 배열
                       3. optionOutValue : 해당 작업에서 반환된 출력 데이터를 포함하는 Byte형식 배열
                    */

                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                        //BeginReceive()메서드로 소켓에서 데이터를 비동기적으로 받는다, 들어오면 비동기적으로 OnReceive메소드 호출
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Socket에 비동기적으로 데이터가 수신 되었을 때 호출되는 메소드
        /// ParseDat()메서드를 호출하여 패킷을 분석
        /// </summary>
        /// <param name="ar"></param>
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar); //비동기 작업에 대한 상태 정보 및 사용자 정의 데이터를 저장한 개체를 매개변수를 선언하여
                    //비동기 읽기 작업을 완료하고 바이트 수를 변수에 저장
                    //Socket을 가져온 다음 EndReceive()메서드를 호출하여 성공적으로 읽기 작업을 마친 후 읽은 바이트수를 반환
                ParseData(byteData, nReceived); // Socket에 있는 데이터를 분석하는 작업을 수행, 
                            //매개변수에 비동기로 받은 바이트 배열(byteDat), 바이트 수(nReceived)를 지정

                if (bContinueCapturing)
                {
                    byteData = new byte[4096];
                    mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
                }
            }
            catch (ObjectDisposedException) { }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 비동기로 받은 데이터를 분석
        /// </summary>
        private void ParseData(byte[] byteData, int nReceived)
        {
            if(PacketNum == Convert.ToInt32(this.tscbNum.Text))
            {
                PacketNum = 1;
                this.lvReceivedPackets.Items.Clear();
            }
            IPHeader ipHeader = new IPHeader(byteData, nReceived);
        }

        private void tsbtnStop_Click(object sender, EventArgs e)
        {

        }

        private void lvReceivedPackets_Click(object sender, EventArgs e)
        {

        }
    }

    
}
