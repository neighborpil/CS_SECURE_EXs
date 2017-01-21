using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[Wifi Scanner]
 - ManagedWifi.dll 어셈블리를 이용하여 무선 Wifi를 검색하고 해당하는 Wifi에 대해 정보를 가져와 출력하는 어플리케이션
 - 무선 wifi해킹 시도시 먼저 비밀번호를 사용하지 않는 AP 또는 비밀번호를 사용하더라도 취약한 암호방식을 사용하는 AP를 찾아내는 것이 중요, 따라서 무선 인터넷 해킹 도구에 자주 포함
 - 방법1 : 로컬 컴퓨터의 무선랜카드가 검색한 결과 값을 WMI 쿼리를 이용하여 검색하는 방법
 - 방법2 : ManageWifi.dll 어셈블리의 ManagedWiFi 라이브러리에 있는 함수를 이용하여 구현하는 방법(예제 방법)

#외부 라이브러리 참조추가가 필요
 - ManagedFifi.dll
 - 예제의 ./dll폴더에 있음
 - using NativeWifi; 추가

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : Wifi를 검색하는 스레드를 생성
 - Form1_FormClosing(object sender, FormClosingEventArgs e) : 스레드 종료
*/
namespace mook_WifiScanner
{
    public partial class Form1 : Form
    {
        WlanClient wlanClient = new WlanClient();
        Thread thrAP;

        public Form1()
        {
            InitializeComponent();
        }

        //Wifi를 검색하기 위한 스레드 생성
        private void Form1_Load(object sender, EventArgs e)
        {
            thrAP = new Thread(ThreadList);
            thrAP.Start();
        }

        //while반복문을 수행하면서 Wifi를 검색하여 해당 정보를 lvAP 컨트롤에 출력
        private void ThreadList()
        {
            while (true)
            {
                this.lvAP.Items.Clear();
                Wlan.WlanAvailableNetwork[] wlanBssEntries = wlanClient.Interfaces[0].GetAvailableNetworkList(0);
                foreach(Wlan.WlanAvailableNetwork network in wlanBssEntries)
                {
                    var lvt = new ListViewItem(new string[]
                    {
                        GetStringForSSID(network.dot11Ssid),
                        network.wlanSignalQuality.ToString(),
                        network.securityEnabled.ToString(),
                        GetMacChanel(1, ConvertToMAC(network.dot11Ssid.SSID)),
                        network.dot11DefaultCipherAlgorithm.ToString(),
                        network.dot11DefaultAuthAlgorithm.ToString(),
                        GetMacChanel(2, ConvertToMAC(network.dot11Ssid.SSID))
                    });

                    this.lvAP.Items.Add(lvt);
                }
                Thread.Sleep(10000);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
