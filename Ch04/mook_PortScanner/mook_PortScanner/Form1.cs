using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[포트 스캐너]
 - 어떤 포트가 열려 있고 닫혀 있는지
 - 해킹도구로서는 해킹전 시스템에 대한 사전 분석

#이벤트 핸들러
 - btnFile_Click(object sender, EventArgs e) : [파일경로], 파일 경로를 설정
 - btnStart_Click(object sender, EventArgs e) : [스캔], 포트 스캔을 실행할 스레드 생성
*/
namespace mook_PortScanner
{
    public partial class Form1 : Form
    {
        //멤버
        private IPAddress scanIp = null;
        private string strFile = null;
        Thread PortScan = null;

        public Form1()
        {
            InitializeComponent();
        }

        //[파일경로] : folderbrowserdialog를 호출하여 파일이 저장될 경로를 설정
        private void btnFile_Click(object sender, EventArgs e)
        {
            if (this.fbdFile.ShowDialog() == DialogResult.OK)
            {
                strFile = this.fbdFile.SelectedPath + " 포트스캔(" + this.txtIp.Text + ").txt";
            }
        }

        //스캔 : 포트 스캔을 진행할 스레드 PortScan을 생성
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(strFile != null)
            {
                this.pgbScan.Minimum = Convert.ToInt32(this.txtStart.Text);
                this.pgbScan.Maximum = Convert.ToInt32(this.txtEnd.Text);
                this.btnStart.Enabled = false;
                this.btnFile.Enabled = false;
                PortScan = new Thread(PortScanner);
                PortScan.Start();
            }
        }

        //지정된 포트 정보에 따라 순차적으로 OPEN 여부에 대한 확인을 진행하며 결과를 파일로 저장
        private void PortScanner()
        {
            CheckForIllegalCrossThreadCalls = false;

            int i, intStart, intEnd;
            this.lblFile.Text = "생성파일 : " + strFile;

            StreamWriter sw = new StreamWriter(strFile);
            scanIp = IPAddress.Parse(this.txtIp.Text); //IPAddress.Parse(string) : string을 IPAddress 인스턴스로 변환
            intStart = Convert.ToInt32(this.txtStart.Text);
            intEnd = Convert.ToInt32(this.txtEnd.Text);

            sw.WriteLine("*******************스캔 시작*******************" + DateTime.Now);
            sw.WriteLine();
            for(i = intStart;i <= intEnd; i++)
            {
                this.pgbScan.Value = i;

                try
                {
                    IPEndPoint endPoint = new IPEndPoint(scanIp, i);
                    Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sSocket.Connect(endPoint);
                    sw.WriteLine("ScanPort {0} 열려있음", i);
                    this.lvScan.Items.Add(new ListViewItem(new string[] { i.ToString(), "open" }));
                    continue;
                }
                catch(SocketException ex) //포트가 닫혀 있다면 에러메세지를 띄우고
                {
                    if (ex.ErrorCode != 10061)
                        sw.WriteLine("에러 : {0}", ex.Message);
                }
                sw.WriteLine("ScanPort {0} 닫혀있음", i); //파일에 닫혀 있다고 쓰고, listview에 쓰기
                this.lvScan.Items.Add(new ListViewItem(new string[] { i.ToString(), "close" }));
            }
            sw.WriteLine();
            sw.WriteLine("*******************스캔 종료*******************" + DateTime.Now);
            sw.Close();

            this.btnStart.Enabled = true;
            this.btnFile.Enabled = true;
            MessageBox.Show("포트 스캔을 완료하였습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #region Process개체를 생성한 뒤 파일의 주소를 읽어 들이고 실행시킨다
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = strFile;
            myProcess.Start(); 
            #endregion

            PortScan.Abort();
        }
    }
}
