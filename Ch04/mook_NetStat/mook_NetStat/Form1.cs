using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[NetStat]
 - 사용중인 포트 및 서비스중인 프로세스들의 상태 정보 및 네트워크 연결 상태 확인
 
#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : 네트워크 상태를 살펴보는 스레드를 추가
 - btnCheck_Click(object sender, EventArgs e) : [체크], 입력 컨트롤의 활성화 여부를 설정
 - btnSave_Click(object sender, EventArgs e) : [저장], 현재 네트워크 상태를 파일로 저장
 - Form1_FormClosing(object sender, FormClosingEventArgs e) : 스레드 종료

#System.Net.NetworkInformation 네임스페이스
 - 로컬 컴퓨터에 대한 주소 변경 알림, 네트워크 주소 정보 및 네트워크 트래픽에 액세스 가능
 - Ping 유틸리티 구현 가능, 이를 통해 컴퓨터가 네트워크 연결이 가능한지 확인 가능
*/
namespace mook_NetStat
{
    public partial class Form1 : Form
    {
        //멤버
        IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties(); //로컬 컴퓨터의 네트워크 연결 및 트래픽 통계에 대한 정보 제공 개체 생성
        Thread NetThread = null;
        string LocPort, RemoAdd, RemoPort;
        bool CheckBool = true;

        public Form1()
        {
            InitializeComponent();
        }

        //네트워크 상태를 체크하는 메서드 실행
        private void Form1_Load(object sender, EventArgs e)
        {
            NetThread = new Thread(NetView);
            NetThread.Start();
        }

        private delegate void NetViewDelegate();

        //주기적으로 while반복문을 실행하면서 네트워크 상태 정보를 lvNetState에 나타내는 작업 수행
        private void NetView()
        {
            CheckForIllegalCrossThreadCalls = false;

            while (true)
            {
                this.CheckBool = true;
                NCheck();
                this.lvNetState.Items.Clear();
                TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections(); //로컬 컴퓨터의 ipv4, ipv6 tcp연결에 대한 정보를
                                                                                                    //TcpConnectionInformation배열에 반환
                #region TcpConnectionInformation 클래스
                /*
                #TcpConnectionInformation의 속성
                 - LocalEndPoint : tcp의 로컬의 끝점
                 - RemoteEndPoint : tcp의 원격지의 끝점
                 - state : tcp의 연결 상태
                */
                #endregion
                int i = 0;

                #region TcpConnectionInformation배열에 저장된 ipv4, ipv6 tcp 연결에 대한 컬렉션 정보를 가져와 lvNetState 컨트롤에 나타냄
                foreach (TcpConnectionInformation NetInfo in tcpConnections)
                {
                    this.lvNetState.Items.Add(NetInfo.LocalEndPoint.Address.ToString()); //tcp 연결의 로컬 ip 주소
                    this.lvNetState.Items[i].SubItems.Add(NetInfo.LocalEndPoint.Port.ToString()); //tcp 연결의 로컬 포트
                    this.lvNetState.Items[i].SubItems.Add(NetInfo.RemoteEndPoint.Address.ToString()); //tcp연결의 원격지 ip
                    this.lvNetState.Items[i].SubItems.Add(NetInfo.RemoteEndPoint.Port.ToString()); //tcp연결의 원격지 port
                    this.lvNetState.Items[i].SubItems.Add(NetInfo.State.ToString()); //tcp의 연결 상태

                    //연결상태에 따른 lvNetState의 배경색 설정
                    if (NetInfo.LocalEndPoint.Port.ToString() == LocPort)
                        this.lvNetState.Items[i].SubItems[0].BackColor = Color.GreenYellow;
                    if (NetInfo.RemoteEndPoint.Address.ToString() == RemoAdd)
                        this.lvNetState.Items[i].SubItems[0].BackColor = Color.LightPink;
                    if (NetInfo.RemoteEndPoint.Port.ToString() == RemoPort)
                        this.lvNetState.Items[i].SubItems[0].BackColor = Color.Aqua;
                    i++;
                }
                #endregion
                this.CheckBool = false;
                NCheck();
                Thread.Sleep(30000);
            }

            //if (this.InvokeRequired)
            //{
            //    NetViewDelegate NetViewDele = new NetViewDelegate(NetView);

            //    Invoke(NetViewDele);
            //}
            //else
            //{
            //    while (true)
            //    {
            //        this.CheckBool = true;
            //        NCheck();
            //        this.lvNetState.Items.Clear();
            //        TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections(); //로컬 컴퓨터의 ipv4, ipv6 tcp연결에 대한 정보를
            //                                                                                            //TcpConnectionInformation배열에 반환
            //        #region TcpConnectionInformation 클래스
            //        /*
            //        #TcpConnectionInformation의 속성
            //         - LocalEndPoint : tcp의 로컬의 끝점
            //         - RemoteEndPoint : tcp의 원격지의 끝점
            //         - state : tcp의 연결 상태
            //        */
            //        #endregion
            //        int i = 0;

            //        #region TcpConnectionInformation배열에 저장된 ipv4, ipv6 tcp 연결에 대한 컬렉션 정보를 가져와 lvNetState 컨트롤에 나타냄
            //        foreach (TcpConnectionInformation NetInfo in tcpConnections)
            //        {
            //            this.lvNetState.Items.Add(NetInfo.LocalEndPoint.Address.ToString()); //tcp 연결의 로컬 ip 주소
            //            this.lvNetState.Items[i].SubItems.Add(NetInfo.LocalEndPoint.Port.ToString()); //tcp 연결의 로컬 포트
            //            this.lvNetState.Items[i].SubItems.Add(NetInfo.RemoteEndPoint.Address.ToString()); //tcp연결의 원격지 ip
            //            this.lvNetState.Items[i].SubItems.Add(NetInfo.RemoteEndPoint.Port.ToString()); //tcp연결의 원격지 port
            //            this.lvNetState.Items[i].SubItems.Add(NetInfo.State.ToString()); //tcp의 연결 상태

            //            //연결상태에 따른 lvNetState의 배경색 설정
            //            if (NetInfo.LocalEndPoint.Port.ToString() == LocPort)
            //                this.lvNetState.Items[i].SubItems[0].BackColor = Color.GreenYellow;
            //            if (NetInfo.RemoteEndPoint.Address.ToString() == RemoAdd)
            //                this.lvNetState.Items[i].SubItems[0].BackColor = Color.LightPink;
            //            if (NetInfo.RemoteEndPoint.Port.ToString() == RemoPort)
            //                this.lvNetState.Items[i].SubItems[0].BackColor = Color.Aqua;
            //            i++;
            //        }
            //        #endregion
            //        this.CheckBool = false;
            //        NCheck();
            //        Thread.Sleep(30000);
            //    }
            //}

        }

        //[체크] : 입력 컨트롤 및 버튼 컨트롤의 Enabled 속성 값을 false로 설정하는 작업 수행, 이는 네트워크 연결상태를 검사할 때 입력 컴트롤 및 버튼 컨트롤을 조작하지 못하도록
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.LocPort = this.txtLocalPort.Text;
            this.RemoAdd = this.txtForAdd.Text;
            this.RemoPort = this.txtForPort.Text;
            NCheck();
        }

        private delegate void NCheckDelegate();

        //입력 컨트롤 및 버튼 컨트롤의 Enabled 속성 값을 false로 설정하는 작업 수행, 이는 네트워크 연결상태를 검사할 때 입력 컴트롤 및 버튼 컨트롤을 조작하지 못하도록
        private void NCheck()
        {
            CheckForIllegalCrossThreadCalls = false;

            if (CheckBool)
            {
                this.txtLocalPort.Enabled = false;
                this.txtForAdd.Enabled = false;
                this.txtForPort.Enabled = false;
                this.btnCheck.Enabled = false;
                this.btnSave.Enabled = false;
            }
            else
            {
                this.txtLocalPort.Enabled = true;
                this.txtForAdd.Enabled = true;
                this.txtForPort.Enabled = true;
                this.btnCheck.Enabled = true;
                this.btnSave.Enabled = true;
            }

            //if (this.InvokeRequired)
            //{
            //    NCheckDelegate NCheckDele = new NCheckDelegate(NCheck);

            //    this.Invoke(NCheckDele);
            //}
            //else
            //{
            //    if (CheckBool)
            //    {
            //        this.txtLocalPort.Enabled = false;
            //        this.txtForAdd.Enabled = false;
            //        this.txtForPort.Enabled = false;
            //        this.btnCheck.Enabled = false;
            //        this.btnSave.Enabled = false;
            //    }
            //    else
            //    {
            //        this.txtLocalPort.Enabled = true;
            //        this.txtForAdd.Enabled = true;
            //        this.txtForPort.Enabled = true;
            //        this.btnCheck.Enabled = true;
            //        this.btnSave.Enabled = true;
            //    }
            //}


        }

        //[저장] : 네트워크 연결상태를 파일로 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "텍스트 파일 (*.txt)|*.txt", ValidateNames = true })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine("파일생성 : " + DateTime.Now);
                    sw.WriteLine();
                    sw.WriteLine("로컬주소\t로컬포트\t외부주소\t외부포트\t상태");
                    for (int i = 0; i < this.lvNetState.Items.Count - 1; i++)
                    {
                        sw.WriteLine(this.lvNetState.Items[i].SubItems[0].Text + "\t" +
                            this.lvNetState.Items[i].SubItems[1].Text + "\t" +
                            this.lvNetState.Items[i].SubItems[2].Text + "\t" +
                            this.lvNetState.Items[i].SubItems[3].Text + "\t" +
                            this.lvNetState.Items[i].SubItems[4].Text);
                    }
                    sw.WriteLine();
                    sw.WriteLine("파일생성 종료 : " + DateTime.Now);
                    sw.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NetThread != null) NetThread.Abort();
            Application.ExitThread();
        }
    }
}
