using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[DES 암호화, 복호화]
 - DES(Data Encryption Standard) : 블ㄹ고 암호의 일종
 - 미국 NBS(National Bureau of Standard, 현 NIST)에서 국가 표준으로 정한 알고리즘
 - 대칭키 암호화 방식으로 56비트 키를 사용하여 데이터를 암호화
 - 현재는 취약한것으로 알려짐(너무 짧아서 현재 컴퓨터 성능)
 - Triple-DES : 취약점 보완 위해 DES를 세번 반복하는 방법

#DES 암, 복호화 프로그램
 - .NET Framework에서 기본으로 제공하는 DES 암, 복호화 클래스 이용하여 문자열 암, 복호화 어플리케이션 구현
*/
namespace mook_DES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
