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
using System.Security.Cryptography;
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
        //CD-Key 생성에 쓰일 배열멤버변수, 사용연도, User Name, MAC 값으로 얻은 첨자 값에 매칭되는 값을 CD-Key로 사용, 총 35개
        private char[] K = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(K.Count());
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
            StringBuilder sb = new StringBuilder(); //잦은 문자열변경이 생기므로 stringbuilder 클래스 사용
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text) % 36]); //사용연도를 36으로 나눈 값(0 ~ 35) 번째 K값
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(0, 1))]); //사용연도의 첫째자리 값 : 2 번째 K값
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(2, 1))]); //사용연도의 둘째자리 값 : 1 번째 K값
            sb.Append(K[Convert.ToInt32(this.cbDateYear.Text.Substring(3, 1))]); //사용연도의 셋째자리 값 : 6 번째 K값
            sb.Append(this.txtMacAdd.Text); //MAC Address값 
            sb.Append(this.txtMacAdd.Text.Substring(0, 1)); //MAC Address 첫째자리 값 
            sb.Append(this.txtMacAdd.Text.Substring(1, 1)); //MAC Address 둘째자리 값 
            sb.Append(MD5Hash(this.txtUserName.Text).Substring(0, 1)); //유저명의 MD5 hash 값의 첫째자리값
            sb.Append(MD5Hash(this.txtUserName.Text).Substring(29, 1)); //유저명의 MD5 hash 값의 30번째 자리값

            StringBuilder sbN = new StringBuilder();

            string cd = sb.ToString().ToUpper(); //cd : sb를 string으로 만든 값
            char[] key = cd.ToCharArray(); //char.ToCharArray : string을 char배열로 바꾸기
            int[] num = new int[key.Length]; //key의 길이만큼 int배열 생성
            int add = DateTime.Now.Year;
            int z;
            int con0 = 0;
            int con1 = 0;
            int con2 = 0;
            int con3 = 0;
            int con4 = 0;
            #region for문을 수행하며 sb개체에 저장된 문자 수만큼 반복하여 블록 내부 코드 수행, 20개의 문자를 5씩 나눠 '-' 붙이고 4개의 묶음으로 나눔

            for (int i = 0; i < key.Length; i++)
            {
                z = (i + 10) * add; //i에 10을 더한 값을 현재 연도를 곱한다
                num[i] = (int)key[i]; //sb개체에 저장된 문자를 int타입(10진수)으로 변환하고 
                sbN.Append(K[(z ^ num[i]) % 36]); //z변수 값을 제곱한 뒤 36으로 나눈 값에 대응하는 K값을 sbN에 추가

                if (((i + 1) % 5 == 0)) //중간중간 5번째 자리 뒤에 '-'를 추가한다
                {
                    sbN.Append("-");
                }

                switch (i % 5) //switch구문 이용하여 i%5값에 따라 선택적으로 con0~con4까지의 정수값 구한다
                {
                    case 0:
                        {
                            con0 += ((z ^ num[i]) % 36);
                            break;
                        }
                    case 1:
                        {
                            con1 += ((z ^ num[i]) % 36);
                            break;
                        }
                    case 2:
                        {
                            con2 += ((z ^ num[i]) % 36);
                            break;
                        }
                    case 3:
                        {
                            con3 += ((z ^ num[i]) % 36);
                            break;
                        }
                    case 4:
                        {
                            con4 += ((z ^ num[i]) % 36);
                            break;
                        }
                }
            }

            #endregion
            //앞에서 구한 con0~5값에 대응하는 K값 5개를 추가한다(총 25문자)
            sbN.Append(K[con0 % 36]); 
            sbN.Append(K[con1 % 36]);
            sbN.Append(K[con2 % 36]);
            sbN.Append(K[con3 % 36]);
            sbN.Append(K[con4 % 36]);

            this.txtCKey.Text = sbN.ToString();
        }

        //User Name을 파라미터로 전달받아 MD5 해시 값을 구하는 작업
        private string MD5Hash(string MdName)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create(); //MD5 해시 알고리즘 기본 구현 클래스의 개체 생성
            Byte[] hashed = md5.ComputeHash(Encoding.Default.GetBytes(MdName));
            var TransName = new StringBuilder();
            for (int i = 0; i < hashed.Length - 1; i++)
            {
                TransName.AppendFormat("{0:X2}", hashed[i]); //바이트배열을 16진수로 표현하는 방법
            }
            return TransName.ToString();
        }
    }
}
