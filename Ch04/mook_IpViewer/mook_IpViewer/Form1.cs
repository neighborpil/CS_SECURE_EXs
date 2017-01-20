using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[IP뷰어]
 - 로컬 호스트의 이름과 IP주소를 구하는 기초적 네트워크 프로그램

#이벤트 핸들러
 - btnOk_Click(object sender, EventArgs e) : [확인], 호스트명과 IP를 구하는 작업 수행

*/
namespace mook_IpViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //[확인]
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string hostName = null;
                IPAddress[] ips;
                hostName = Dns.GetHostName();
                ips = Dns.GetHostAddresses(hostName);
                foreach(IPAddress ip in ips)
                {
                    this.lbIp.Items.Add("호스트 명 : " + hostName);
                    this.lbIp.Items.Add("아이피 : " + ip.ToString());

                }
            }
            catch
            {
                MessageBox.Show("정보를 나타내는데 오류가 있습니다", "오류 메세지", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
