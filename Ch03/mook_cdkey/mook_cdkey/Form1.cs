using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
/*
[CD-Key 만들기]
 - User name, 사용연도, MAC값을 혼용하여 25자리의 CD-Key를 생성하는 애플리케이션
 - CD-Key를 생성하는 'mook_Kegen' 프로젝트와
 - 로컬 컴퓨터에서 CD-Key 인증을 수행하는 'mook_cdkey' 애플리케이션으로 구성
 - CD-Key를 직접 배포하는 방식으로 구현

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : 폼 로딩 이벤트 핸들러, cdDateYear 컨트롤 입력과 MAC 값을 입력
 - btnKey_Click(object sender, EventArgs e) : [CD Key 생성] 버튼 이벤트 핸들러, CD-Key 생성

※ 'System.Management' 어셈블리를 [참조 추가] 한다
※ cbDateYear의 컬렉션 값은 2015, 2016, 2017, 2018이다
*/
namespace mook_cdkey
{
    public partial class Form1 : Form
    {
        //멤버 변수
        //CD-Key 생성에 쓰일 배열멤버변수, 사용연도, User Name, MAC 값으로 얻은 첨자 값에 매칭되는 값을 CD-Key로 사용
        private char[] K = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        public Form1()
        {
            InitializeComponent();
        }

        //폼이 실행될 때 MAC 주소값을 얻는 작업 수행
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbDateYear.Text = DateTime.Now.Year.ToString();
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter"); //MAC 주소를 구하기 위한 쿼리 문자열 설정
            ManagementObjectSearcher query = new ManagementObjectSearcher(oq); //컴퓨터 관리 정보에 대한 지정된 쿼리 호출
            foreach(ManagementObject mo in query.Get()) //관리정보 컬렉션 값을 이용하여 MAC주소 구하기
            {
                if (mo["MACAddress"] != null)
                    this.txtMacAdd.Text = mo["MACAddress"].ToString().Replace(":", "");
            }
        }

        //사용연도, MAC 주소, User Name값을 이용하여 CD-Key를 구하는 작업 수행
        private void btnKey_Click(object sender, EventArgs e)
        {
            if(this.txtUserName.Text == "")
            {
                MessageBox.Show("사용자 이름을 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUserName.Focus();
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text) % 36]);
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(0, 1))]);
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(2, 1))]);
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(3, 1))]);
            sb.Append(this.txtMacAdd.Text);
            sb.Append(this.txtMacAdd.Text.Substring(0, 1));
            sb.Append(this.txtMacAdd.Text.Substring(1, 1));
            sb.Append(MD5Hash(this.txtUserName.Text).Substring(0, 1));
            sb.Append(MD5Hash(this.txtUserName.Text).Substring(29, 1));

            StringBuilder sbN = new StringBuilder();

            string cd = sb.ToString().ToUpper();
            char[] key = cd.ToCharArray();
            int[] num = new int[key.Length];
            int add = DateTime.Now.Year;
            int z;
            int con0 = 0;
            int con1 = 0;
            int con2 = 0;
            int con3 = 0;
            int con4 = 0;

            for (int i = 0; i < key.Length; i++)
            {
                z = (i + 10) * add;
                num[i] = (int)key[i];

            }
        }
    }
}
