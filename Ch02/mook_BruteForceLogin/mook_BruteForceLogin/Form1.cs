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
[웹 자동 로그인]
#개요
 - 과거 아이디와 비밀번호를 알아내기 위해 사용되던 해킹 프로그램을 간략화한 예제
 - 보안에 취약한 예전 홈페이지 해킹에 많이 사용

#과정
 1. 웹서버 구축
 2. 로그인 기능을 가진 간단한 홈페이지 제작
 3. 해킹 프로그램 제작

1. 웹서버 구축
 a) 제어판에서 [Windows 기능 켜기/끄기] 클릭
 b) 인터넷 정보 서비스에 체크
 ***
 //[인터넷 정보 서비스] - [World Wide web]
 - 인터넷 정보 서비스에 +를 눌러 혹시 아래의 항목이 체크되어 있지 않다면 체크한다.
 - 응용 프로그램 개발 기능 클릭
 - .NET 확장성 3.5 체크
 - .NET 확장성 4.6 체크
 - ASP 체크
 - ASP.NET 3.5 체크
 - ASP.NET 4.6 체크
 - ISAPI 필터 체크
 - ISAPI 확장 체크

 //[인터넷 정보 서비스] - [웹 관리 도구]
 ***


*/
namespace mook_BruteForceLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
