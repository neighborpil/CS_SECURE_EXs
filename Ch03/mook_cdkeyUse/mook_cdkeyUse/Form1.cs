using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[CD-Key입력 예제]
 - cdkey 만들기 예제(mook_cdkey)에서 만든 씨디키를 입력해서 일치하는지 확인

#이벤트 핸드러
txtKey01_TextChanged(object sender, EventArgs e) : txtKey01 이벤트 핸들러, 5개의 문자가 입력되면 다음txtbox로 이동
        txtKey02~05_TextChanged와 동일
btnOk_Click(object sender, EventArgs e) : [입력] 버튼 이벤트 핸들러, CD-Key입력이 정상인지 판단
Form1_Load(object sender, EventArgs e) : MAC주소 구하는 작업 수행

※System.Management 어셈블리 참조 추가
*/
namespace mook_cdkeyUse
{
    public partial class Form1 : Form
    {
        private char[] K = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        private string _MAC, _CDKey;
        
        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        //Mac주소 구하기
        private void InitializeComponent2()
        {
            ObjectQuery oq = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
            ManagementObjectSearcher query = new ManagementObjectSearcher(oq);
            foreach(ManagementObject mo in query.Get())
            {
                if(mo["MACAddress"] != null)
                {
                    _MAC = mo["MACAddress"].ToString().Replace(":", "");
                }
            }
        }

        //5글자가 차면 다음 textbox로 넘어간다
        private void txtKey01_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKey01.TextLength == 5)
                this.txtKey02.Focus();
        }

        private void txtKey02_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKey02.TextLength == 5)
                this.txtKey03.Focus();
        }

        private void txtKey03_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKey03.TextLength == 5)
                this.txtKey04.Focus();
        }

        private void txtKey04_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKey04.TextLength == 5)
                this.txtKey05.Focus();
        }

        private void txtKey05_TextChanged(object sender, EventArgs e)
        {
            if (this.txtKey05.TextLength == 5)
                this.btnOk.Focus();
        }

        //[입력] 버튼 : 입력된 CD-Key가 유효한지 검사
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(this.txtUserName.Text == "")
            {
                MessageBox.Show("사용자 이름을 입력하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtUserName.Focus();
                return;
            }

            if(this.txtKey01.Text == "" || this.txtKey02.Text == "" || this.txtKey03.Text == "" ||
                this.txtKey04.Text == "" || this.txtKey05.Text == "")
            {
                MessageBox.Show("CD-KEY 입력이 올바르지 않습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CDKeyGen(); //CD키 생성

            string _CDKeyGen = this.txtKey01.Text + "-" + this.txtKey02.Text + "-" + this.txtKey03.Text + "-" +
                this.txtKey04.Text + "-" + this.txtKey05.Text;

            if (_CDKey == _CDKeyGen)
                this.lblResult.Text = "결과 : CD-KEY가 일치합니다";
            else
                this.lblResult.Text = "결과 : CD-KEY가 일치하지 않습니다";
        }

        //userName과 MAC주소로 CD키 구하기
        private void CDKeyGen()
        {
            string _DateYear = DateTime.Now.Year.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(K[Convert.ToInt32(_DateYear) % 36]);
            sb.Append(K[Convert.ToInt32(_DateYear.Substring(0, 1))]);
            sb.Append(K[Convert.ToInt32(_DateYear.Substring(2, 1))]);
            sb.Append(K[Convert.ToInt32(_DateYear.Substring(3, 1))]);
            sb.Append(_MAC);
            sb.Append(_MAC.Substring(0, 1));
            sb.Append(_MAC.Substring(1, 1));
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
                sbN.Append(K[(z ^ num[i]) % 36]);

                if(((i + 1) % 5 == 0))
                {
                    sbN.Append("-");
                }

                switch(i % 5)
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

            sbN.Append(K[con0 % 36]);
            sbN.Append(K[con1 % 36]);
            sbN.Append(K[con2 % 36]);
            sbN.Append(K[con3 % 36]);
            sbN.Append(K[con4 % 36]);
            _CDKey = sbN.ToString();
        }
        
        //MD5 Hash 구하기
        private string MD5Hash(string MdName)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            Byte[] hashed = md5.ComputeHash(Encoding.Default.GetBytes(MdName));
            var TransName = new StringBuilder();
            for (int i = 0; i < hashed.Length; i++)
            {
                TransName.AppendFormat("{0:X2}", hashed[i]);
            }
            return TransName.ToString();
        }
    }
}
