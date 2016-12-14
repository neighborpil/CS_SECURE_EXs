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
 b) 인터넷 정보 서비스 - World Wide Web 서비스 클릭
 c) 응용 프로그램 개발 기능 클릭
 d) .NET 확장성 3.5 체크
 e) .NET 확장성 4.6 체크
 f) ASP 체크
 g) ASP.NET 3.5 체크
 h) ASP.NET 4.6 체크
 i) ISAPI 필터 체크
 j) ISAPI 확장 체크


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
