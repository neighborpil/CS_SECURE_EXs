using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[네트워크 스캐너]
 - 내부 네트워크에 연결된 컴퓨터를 스캔하는데 지정된 IP에 따라 검색
 - 내부 공간이 분리되어 있고 사용자 컴퓨터에 정확히 IP가 부여되어 사용되지 않는 환경에서 어떤 IP가 사용되는지 쉽게 검색 가능
 - 내부 네트워크에 연결된 컴퓨터를 검색하기 위하여 iphlpapi.dll 어셈블리를 이용

#이벤트 핸들러
 - btnSearch_Click(object sender, EventArgs e) : [검색], 네트워크에 연결된 컴퓨터를 찾는 작업을 수행
 - Form1_FormClosing(object sender, FormClosingEventArgs e) : 스레드 종료
*/
namespace mook_NetworkScanner
{
    public partial class Form1 : Form
    {
        Thread NetworkScan = null;

        //SendARP() ; LAN에서 네트워크 카드에 ARP 메시지를 보내기 위한 메서드
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

        public Form1()
        {
            InitializeComponent();
        }

        //[검색] : 네트워크를 검색하는 메서드 실행
        private void btnSearch_Click(object sender, EventArgs e)
        {
            NetworkScan = new Thread(NetworkCheck);
            NetworkScan.Start();
        }

        //지정된 IP 대역에 연결된 컴퓨터를 검색하여 lvScan 컨트롤에 나타내는 작업
        private void NetworkCheck()
        {
            CheckForIllegalCrossThreadCalls = false;

            try
            {
                this.lvScan.Items.Clear();

                Application.DoEvents();

                IPAddress ip = IPAddress.Parse(this.txtStart.Text);
                IPAddress ip2 = IPAddress.Parse(this.txtEnd.Text);
                IPAddress ipScan = null;
                string hostName = null;

                int[] aa = new int[4], bb = new int[4];

                aa[0] = Convert.ToInt32(ip.GetAddressBytes()[0]);
                aa[1] = Convert.ToInt32(ip.GetAddressBytes()[1]);
                aa[2] = Convert.ToInt32(ip.GetAddressBytes()[2]);
                aa[3] = Convert.ToInt32(ip.GetAddressBytes()[3]);

                bb[0] = Convert.ToInt32(ip2.GetAddressBytes()[0]);
                bb[1] = Convert.ToInt32(ip2.GetAddressBytes()[1]);
                bb[2] = Convert.ToInt32(ip2.GetAddressBytes()[2]);
                bb[3] = Convert.ToInt32(ip2.GetAddressBytes()[3]);

                this.pgrScan.Minimum = Convert.ToInt32(ip.GetAddressBytes()[3]);
                this.pgrScan.Maximum = Convert.ToInt32(ip2.GetAddressBytes()[3]);
                this.pgrScan.Value = Convert.ToInt32(ip.GetAddressBytes()[3]);

                for (int a = aa[0]; a <= bb[0]; a++)
                {
                    for (int b = aa[1]; b <= bb[1]; b++)
                    {
                        for (int c = aa[2]; c <= bb[2]; c++)
                        {
                            for (int d = aa[3]; d <= bb[3]; d++)
                            {
                                this.pgrScan.Value = d;
                                ipScan = IPAddress.Parse(a.ToString() + "." + b.ToString() + "." + c.ToString() + "." + d.ToString());
                                Ping pingSender = new Ping();
                                PingOptions options = new PingOptions();
                                options.DontFragment = true;
                                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                                byte[] buffer = Encoding.ASCII.GetBytes(data);
                                int timeout = 150;
                                PingReply reply = pingSender.Send(ipScan, timeout, buffer, options);
                                hostName = null;
                                string macAddr = null;
                                if(reply.Status == IPStatus.Success)
                                {
                                    hostName = GetHostName(ipScan);
                                    macAddr = GetMacUsingARP(ipScan.ToString());
                                    ListViewItem itm = new ListViewItem();
                                    itm.Text = ipScan.ToString();
                                    itm.SubItems.Add(hostName);
                                    itm.SubItems.Add(macAddr);
                                    this.lvScan.Items.Add(itm);
                                }

                                if (d == this.pgrScan.Maximum)
                                    MessageBox.Show("네트워크 스캔을 완료하였습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                NetworkScan.Abort();
            }
        }

        //파리미터로 IP 주소를 전달받아 호스트 이름을 반환
        private string GetHostName(IPAddress pAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(pAddress); //호스트의 주소정보를 포함하는 IPHostEntry 개체 반환
                #region IPHostEntry 속성
                /*
                #IPHostEntry 속성
                 - AddressList : 호스트와 연결된 IP 주소 목록을 가져오거나 설정
                 - Aliases : 호스트와 연결된 별칭 목록을 가져오거나 반환
                 - HostName : 호스트의 DNS 이름을 가져오거나 반환
                */
                #endregion
                return entry.HostName; //호스트의 이름 반환
            }
            catch (Exception)
            {
                return pAddress.ToString();
            }
        }
        
        //파라미터로 IP를 전달받아 해당하는 시스템의 MAC 주소반환
        private string GetMacUsingARP(string IPAddr)
        {
            IPAddress IP = IPAddress.Parse(IPAddr);
            byte[] macAddr = new byte[6];
            uint macAddrLen = (uint)macAddr.Length;
            if (SendARP((int)IP.Address, 0, macAddr, ref macAddrLen) != 0) //iphlpapi.dll파일에 정의된 SendARP()메서드 호출하여 
                return "ARP command failed";                               //반환값이 0이면 'ARP'가 성공한 것이고 그외의 반환값은 실패
                                                                //바이트 배열 타입의 매개변수인 macAddr에 해당 시스템의 MAC주소가
                                                                //참조타칩 매개변수(ref)인 macAddrLen에 바이트 배열의 길이가 저장
            string[] str = new string[(int)macAddrLen];
            for (int i = 0; i < macAddrLen; i++)
                str[i] = macAddr[i].ToString("x2"); //16진수의 두자리로 저장
            return string.Join(":", str); //string배열의 각요소 사이에 ":" 삽입
        }

        //스레드 종료
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NetworkScan != null)
                NetworkScan.Abort();
        }
    }
}
