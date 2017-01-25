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
[DNSLookUp]
 - 도메인을 통하여 IP 주솔ㄹ 알아내는 방법 중 하나
 - DNS 정보와 연관된 도메인 정보를 확인 할 수 있는 유용한 명령어
*/
namespace mook_DNSLookUp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //[검색] : 입력된 도메인과 연결된 IP 주소를 listAddr 컨트롤에 출력
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string hostName = null;
            if(this.txtHost.Text.Contains("://") == true)
            {
                hostName = this.txtHost.Text.Replace("http://", "");
            }
            else
            {
                hostName = this.txtHost.Text;
            }

            try
            {
                IPHostEntry ipe = Dns.GetHostEntry(hostName);
                IPAddress[] addrs = ipe.AddressList;

                if (listAddr.Items.Count > 0)
                    listAddr.Items.Clear();

                foreach(IPAddress addr in addrs)
                {
                    listAddr.Items.Add(addr);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
