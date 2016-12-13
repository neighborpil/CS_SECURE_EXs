using Shell32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[휴지통 복원]
 * 프로그램으로 휴지통에 담겨 있는 파일에 접근하기 위해서는 닷넷의 파일클래스로는 권한문제로 어렵다
 * win32 API를 활용하여 특정 폴더 및 파일에 접근이 가능하다

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : 휴지통에 담겨 있는 파일 리스트 출력
 - btnRefresh_Click(object sender, EventArgs e) : [새로고침] 버튼 이벤트 핸들러, 휴지통에 담겨있는 파일 리스11트 출력
 - btnDel_Click(object sender, EventArgs e) : [휴지통 비우기] 버튼 이벤트 핸들러, 휴지통에 담겨 있는 파일 삭제
 - btnRestore_Click(object sender, EventArgs e) : [복원] 버튼 이벤트 핸들러, 휴지통 파일 중 선택된 파일 복원

#참조(WIN32 API)
 - shell32.dll : c:\Windows\System32\ 경로에서 shell32.dll 파일을 추가
*/
namespace mook_FileRestore
{
    public partial class Form1 : Form
    {
        //SHEmptyRecycleBin의 세번째 매개변수 값을 설정하는 작업 수행
        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x0000004
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        //SHEmptyRecycleBin : 시스템의 휴지통을 비우는 작업 수행
        //첫번째 인수 : Process의 Handle을 전달
        //세번째 인수 : 0x00000001(관련 메세지가 표현되지 않도록)
        //             0x00000002(휴지통에 대량의 데이터가 존재할 경우 휴지통을 비우는 진행상태가 표시되지 않도록
        //             0x00000004(휴지통을 비울때 소리나지 않도록


        public Form1()
        {
            InitializeComponent();
        }

        //폼로드 : Load_RecycleBinFile()메소드 호출, 휴지통에 담겨 있는 파일의 리스트를 출력
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_RecycleBinFile();
        }

        /*
        Shell.NameSpace() 메서드는 지정된 상수 또는 문자열 경로 하위의 폴더 및 파일 정보를 가져오기 위한
        Folder 인터페이스와 FolderItem 인터페이스를 제공

        Shell.NameSpace(0) : 바탕화면 폴더 및 파일
        Shell.NameSpace(4) : installed printers
        Shell.NameSpace(5) : c:\Users\username\Documents
        Shell.NameSpace(6) : c:\Documents and Settings\username\Favorites
        Shell.NameSpace(8) : c:\Users\username\AppData\Roaming\Microsoft\Windows\Recent
        Shell.NameSpace(10) : 휴지통
        */


        private void Load_RecycleBinFile()
        {
            this.lvRcvFile.Items.Clear();
            Shell Shl = new Shell(); //Shell32.dll 라이브러리 하위에 존재하는 Shell 클래스의 개체를 생성
                                     //Folder 및 FolderItem 인터페이스를 사용 할 수 있다
            Folder Recycler = Shl.NameSpace(10); //휴지통의 폴더

            #region for문을 이용하여 Recyle 개체가 포함하고 있는 Item의 수만큼 반복하여 개체에 포함된 점보를 listview에 표시

            for (int i = 0; i < Recycler.Items().Count; i++)
            {
                FolderItem FI = Recycler.Items().Item(i); //Recycler폴더 내의 아이템들을 FolderItem객체에 저장
                string FileName = Recycler.GetDetailsOf(FI, 0); //FI 개체에 첫번째 저장된 정보, 즉 폴더 및 파일의 이름 얻는 작업
                if (Path.GetExtension(FileName) == "") //Path.GetExtension() : 지정된 경로 문자열에서 확장자가 없다면
                    FileName += Path.GetExtension(FI.Path); //파일명에 확장자 합치기
                string FilePath = Recycler.GetDetailsOf(FI, 1); //FI 개체에 두번째 저장된 정보, 삭제전 원래 폴더 및 파일의 이름 얻는 작업
                string FileDelDate = Recycler.GetDetailsOf(FI, 2); //FI 개체에 세번째 저장된 정보, 삭제전 원래 폴더 및 파일의 삭제 시간
                var lvt = new ListViewItem(new string[] { FileName, FilePath, FileDelDate });
                this.lvRcvFile.Items.Add(lvt);
            }

            #endregion
        }

        //[새로고침] :휴지통에 담겨 있는 삭제된 폴더 및 파일 출력
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_RecycleBinFile();
        }

        //[휴지통 비우기] : 휴지통에 담겨 있는 폴더 및 파일 삭제
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
                MessageBox.Show(this, "휴지통을 비웠습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "휴지통을 비우는 작업에 실패했습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Load_RecycleBinFile();
            }
        }

        //[복원] : FileRestor() 메서드 호출
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if(this.lvRcvFile.SelectedItems.Count != 0)
            {
                FileRestor()
            }
        }

        //매개변수로 전달 받는 파일을 삭제되기 전으로 복원하기 위한 사전 작업
        private bool FileRestore(string Item)
        {
            Shell shl = new Shell();
            Folder Recycler = shl.NameSpace(10);
            for (int i = 0; i < Recycler.Items().Count; i++)
            {
                FolderItem FI = Recycler.Items().Item(i);
                string FileName = Recycler.GetDetailsOf(FI, 0);
                if (Path.GetExtension(FileName) == "")
                    FileName += Path.GetExtension(FI.Path);
                string FilePath = Recycler.GetDetailsOf(FI, 1);
                
                if(Item == Path.Combine(FilePath, FileName))
                {
                    DoVerb(FI, "복원(&E");
                    return true;
                }
            }
            return false;
        }
    }
}
