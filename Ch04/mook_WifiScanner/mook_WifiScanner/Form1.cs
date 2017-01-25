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


        public delegate void LvItemClearDelegate();
        public LvItemClearDelegate LvItemClearDele;

        public delegate void LvItemAddDelegate(ListViewItem lvt);
        public LvItemAddDelegate LvItemAddDele;
        
        //while반복문을 수행하면서 Wifi를 검색하여 해당 정보를 lvAP 컨트롤에 출력
        private void ThreadList()
        {
            while (true)
            {
                LvItemClearDele = new LvItemClearDelegate(LvItemClear);

                Invoke(LvItemClearDele);
                //this.lvAP.Items.Clear();

                Wlan.WlanAvailableNetwork[] wlanBssEntries = wlanClient.Interfaces[0].GetAvailableNetworkList(0);
                    //로컬 컴퓨터의 무선 랜카드를 컨트롤하여 얻은 wifi 정보를 Wlan.WlanAvailableNetwork  배열에 반환
                foreach(Wlan.WlanAvailableNetwork network in wlanBssEntries)
                {
                    var lvt = new ListViewItem(new string[]
                    {
                        GetStringForSSID(network.dot11Ssid), //network.dot11Ssid 속성을 이용하여 lvt 개체에 저장, 
                                                             //network.dot11Ssid 속성은 아스키이므로 GetStringForSSID메서드로 문자로 변환
                        network.wlanSignalQuality.ToString(), //wifi신호 강도
                        network.securityEnabled.ToString(), //wifi 암호화 여부 정보
                        GetMacChanel(1, ConvertToMac(network.dot11Ssid.SSID)), //GetMacChanel() 메서드를 호출하여 채널 정보를 가져와 lvt에 저장
                        network.dot11DefaultCipherAlgorithm.ToString(), //wifi 암호화 방식
                        network.dot11DefaultAuthAlgorithm.ToString(), //wifi 인증 방식
                        GetMacChanel(2, ConvertToMac(network.dot11Ssid.SSID)) //mac 주소
                    });

                    LvItemAddDele = new LvItemAddDelegate(LvItemAdd);

                    Invoke(LvItemAddDele, lvt);

                    //this.lvAP.Items.Add(lvt);
                }
                Thread.Sleep(10000);
            }
        }

        public void LvItemAdd(ListViewItem lvt)
        {
            this.lvAP.Items.Add(lvt);
        }

        public void LvItemClear()
        {
            this.lvAP.Items.Clear();
        }

        //바이트 배열을 문자열로 변환하여 wifi 이름을 반환
        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength); //지정된 바이트 배열을 문자열로 디코딩
            #region Encoding.ASCII.GetString(bytes, index, count) 메서드
            /*
                #Encoding.ASCII.GetString(bytes, index, count) 메서드
                 - 지정된 바이트 배열의 바이트 시퀸스를 문자열로 디코딩
                 - 매개변수
                   1) bytes : 디코딩할 바이트 시퀸스를 포함하는 바이트 배열
                   2) index : 디코딩할 첫 번째 바이트의 인덱스
                   3) count : 디코딩할 바이트 수
                */
            #endregion
        }

        //파라미터 값으로 전달받은 Wifi의 SSID값을 이용하여 MAC 주소와 채널 정보를 구해 반환
        private string GetMacChanel(int i, string Name)
        {
            Wlan.WlanBssEntry[] lstWlanBss = wlanClient.Interfaces[0].GetNetworkBssList();
            var reAP = "";
            foreach(var oWlan in lstWlanBss)
            {
                if(i == 2)
                {
                    if(ConvertToMac(oWlan.dot11Ssid.SSID) == Name)
                    {
                        reAP = ConvertToMac(oWlan.dot11Bssid);
                    }
                }
                else if(i == 1)
                {
                    if(ConvertToMac(oWlan.dot11Ssid.SSID) == Name)
                    {
                        var chnl = oWlan.chCenterFrequency.ToString();
                        switch (chnl)
                        {
                            case "2412000": reAP = "1"; break;
                            case "2417000": reAP = "2"; break;
                            case "2422000": reAP = "3"; break;
                            case "2427000": reAP = "4"; break;
                            case "2432000": reAP = "5"; break;
                            case "2437000": reAP = "6"; break;
                            case "2442000": reAP = "7"; break;
                            case "2447000": reAP = "8"; break;
                            case "2452000": reAP = "9"; break;
                            case "2457000": reAP = "10"; break;
                            case "2462000": reAP = "11"; break;
                            case "2467000": reAP = "12"; break;
                            case "2472000": reAP = "13"; break;
                        }
                    }
                }
            }
            return reAP;
        }

        //파라미터로 받은 바이트 배열 값을 이용하여 MAC 주소를 반환
        string ConvertToMac(byte[] MAC)
        {
            string strMAC = "";
            for (int index = 0; index < 6; index++)
                strMAC += MAC[index].ToString("X2") + "-"; //.ToString("X2") : 16진수로의 변환

            return strMAC.Substring(0, strMAC.Length - 1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.thrAP != null)
                thrAP.Abort();
            Application.ExitThread();
        }
    }
}
