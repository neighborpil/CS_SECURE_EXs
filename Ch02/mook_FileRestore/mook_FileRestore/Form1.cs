using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
