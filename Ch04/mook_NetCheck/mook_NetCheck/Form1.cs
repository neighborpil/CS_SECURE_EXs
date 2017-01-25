using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[Net Check]
 - Ping 테스트 어플
 - 원격지의 네트워크가 정상적인지 알기위한 점검

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : cbTime 컨트롤의 속성을 설정
 - btnSave_Click(object sender, EventArgs e) : [입력], lbAddress에 IP를 추가하는 작업
 - lbAddress_SelectedIndexChanged(object sender, EventArgs e) : lbAddress 컨트롤의 IP를 선택할때 발생하는 이벤트 제어, [체크] 버튼 활성화
 - btnCheck_Click(object sender, EventArgs e) : [체크], Timer 컨트롤을 활성화
 - Timer_Tick(object sender, EventArgs e) : Timer 컨트롤의 Interval 동안 주기적으로 발생하는 이벤트 제어, 네트워크를 체크
 - cbTime_SelectedIndexChanged(object sender, EventArgs e) : cbTime 컨트롤 선택시 발생하는 이벤트 제어, Timer 컨트롤의 Interval 속성값을 설정
*/
namespace mook_NetCheck
{
    public partial class Form1 : Form
    {
        //멤버
        Ping pingSender = new Ping();
        PingOptions options = new PingOptions(); //Ping 데이터 패킷 전송 방법을 제어하는데 사용되는 PingOptions 클래스의 개체 'options' 개체를 생성
        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
        const int TIMEOUT = 120;

        public Form1()
        {
            InitializeComponent();
        }

        //폼을 실행할 때 cbTimer 컨트롤의 Text 속성에 값을 저장
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbTime.Text = "1초";
        }

        //[입력], txtAddress 컨트롤에 입력된 IP 주소를 lbAddress에 추가
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.lbAddress.Items.Add(this.txtAddress.Text);
        }

        //lbAddress에 추가된 IP 주소를 선택하여 [체크]버튼을 활성화
        private void lbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbAddress.SelectedItems.Count > 0) //listbox에서 선택한 아이템으 수가 0보다 클때 버튼 활성화
                this.btnCheck.Enabled = true;
        }

        //[체크], Timer 컨트롤을 활성화하여 네트워크 체크 수행
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(this.lbAddress.SelectedItems.Count == 0)
            {
                MessageBox.Show("체크할 IP를 선택하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(this.btnCheck.Text == "체크")
            {
                this.Timer.Enabled = true;
                this.lbAddress.Enabled = false;
                this.btnCheck.Text = "중지";
            }
            else
            {
                this.Timer.Enabled = false;
                this.lbAddress.Enabled = true;
                this.btnCheck.Text = "체크";
            }
        }

        //Timer 컨트롤의 Interval 주기에 맞춰 지정된 IP에 대한 네트워크 체크를 수행
        private void Timer_Tick(object sender, EventArgs e)
        {
            PingCheck();
        }

        //Timer 컨트롤의 Interval 주기에 맞춰 지정된 IP에 대한 네트워크 체크를 수행
        private void PingCheck()
        {
            try
            {
                Byte[] buffer = Encoding.ASCII.GetBytes(data);
                options.DontFragment = true;

                foreach(var args in this.lbAddress.SelectedItems)
                {
                    PingReply reply = pingSender.Send(args.ToString(), TIMEOUT, buffer, options);
                    string _lbResult = null;
                    if (reply.Status == IPStatus.Success)
                    {
                        _lbResult = args.ToString() + " 아이피 " + DateTime.Now + " " + " Reply Form " + args.ToString() + " bytes" + reply.Buffer.Length.ToString()
                            + " bytes=" + reply.RoundtripTime.ToString() + " TTL=" + reply.Options.Ttl.ToString();
                        this.lbResult.Items.Add(_lbResult);
                    }
                    else
                        this.lbResult.Items.Add(args.ToString() + " 아이피 확인실패");
                }
                this.lbResult.Items.Add("");
                if (this.lbResult.Items.Count + 5 > this.lbAddress.Items.Count * 10)
                    this.lbResult.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("네트워크 장애 : " + ex.ToString(), "에러 알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Timer 컨트롤의 [Interval] 속성 값을 설정
        private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbTime.Text)
            {
                case "1초": this.Timer.Interval = 1000; break;
                case "2초": this.Timer.Interval = 2000; break;
                case "3초": this.Timer.Interval = 3000; break;
                case "4초": this.Timer.Interval = 4000; break;
                case "5초": this.Timer.Interval = 5000; break;

            }
        }
    }
}
