using System;
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

namespace mook_HexEditor
{
    public partial class Form1 : Form
    {
        private string fileName = "";
        Thread HexAnalysis = null;

        public Form1()
        {
            InitializeComponent();
        }

        //File 버튼 클릭 : 파일을 분석할 스레드를 실행
        private void btnFile_Click(object sender, EventArgs e)
        {
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                fileName = ofdFile.FileName; //파일의 이름을 저장
                this.HexView.Text = "";
            }

            ofdFile.Dispose();
            int fSize = getFileSize(fileName); //파일의 크기를 분석하여 일정 크기보다 크면 -1

            if(fSize > 0)
            {
                HexAnalysis = new Thread(new ParameterizedThreadStart(hexEditor)); 
                HexAnalysis.Start(fileName + "?" + fSize); //스레드에 2개 이상의 값을 넘길 때 꼼수
            }
            else
            {
                this.HexView.AppendText("\n파일 선택이 잘못되었습니다.\n");
            }
        }

        //읽어들이는 파일의 사이즈를 분석하여 일정 이하라야만 분석이 가능
        private int getFileSize(string inFile)
        {
            long size = -1;
            try
            {
                FileInfo fi = new FileInfo(inFile);
                size = fi.Length;
                if (size > 2147483640) //지정된 크기 이하일 때만 분석 가능
                    return -1;
                else
                    return (int)size;
            }
            catch
            {
                return -1;
            }
        }

        private void hexEditor(object _inFileInSize)
        {
            //하도 크로스체크 에러가 많이나서 포기하고 걍 씀
            CheckForIllegalCrossThreadCalls = false;

            var inFile = _inFileInSize.ToString().Split('?')[0];
            var inSize = Convert.ToInt32(_inFileInSize.ToString().Split('?')[1]);

            StringBuilder biglocal = new StringBuilder();
            StringBuilder sblocal = new StringBuilder();

            string message = "\n" + fileName + " " + (int)inSize + " Bytes\n\n"; //파일 경로와 크기를 HexView에 나타내는 작업
            this.HexView.AppendText(message);
            stbView.Text = " " + fileName + " " + (int)inSize + " Bytes"; //statusbar에 파일 정보 표시
            this.HexView.Update();

            //string msg_stbViewTxt = message + "|" + stbViewText;
            //HexViewAppTxtDele = new HexViewAppTxtDelegate(HexViewAppTxt);
            //Invoke(HexViewAppTxtDele, msg_stbViewTxt);

            FileStream fs;
            byte[] MyData;

            try
            {
                fs = new FileStream((string)inFile, FileMode.OpenOrCreate, FileAccess.Read); //파일 읽어들일 스트림 생성
                MyData = new byte[fs.Length]; //fs의 길이만큼의 byte배열 생성
            }
            catch
            {
                this.HexView.AppendText("\n 파일 분석에 오류가 발생했습니다.\n\n");
                //HexViewAppTxtDele2 = new HexViewAppTxtDelegate2(HexViewTxtErr);
                //Invoke(HexViewAppTxtDele);

                return;
            }

            stbView.Text = "하드 디스크 파일 분석";
            fs.Read(MyData, 0, (int)fs.Length); //파일을 읽어들이기(버퍼크기는 MyData만큼, offset은 0, fs의 길이만큼)
            fs.Close();

            int newrow = 0; //라인
            int global = 0; //offset 넘버링
            string hex = ""; //hex 값
            string numb = ""; //offset 값
            /*
            offset : 어떤 주소로부터 간격을 두고 떨어진 거리,
            하나의 시작 주소로부터 오프셋만큼 떨어진 위치
             */

            this.pgbView.Maximum = MyData.Length;  //progressbar 최대값
            this.pgbView.Value = 0; //시작값

            stbView.Text = "메모리 영역 분석";
            for (int i = 0; i < MyData.Length; i++)
            {
                if (i % 1000 == 0)
                    this.pgbView.Value = i; //i를 1000으로 나눈 나머지가 0일때만 progressbar 진행

                //offset Line값을 구하는 구문 한 라인에 16진수의 offset값을 가진다
                if (newrow == 0)
                {
                    numb = padZeros(global); //padZeros메소드를 이용하여 하나의 offset line값을 구한다
                    biglocal.Append(" " + numb + " "); //16진수를 하나 적고 앞뒤로 한칸 띄운다
                    global += 16; //offset 넘버를 16개 뒤로 넘긴다
                }

                hex = convertByteToHexString(MyData[i]); //hex값 구하기
                biglocal.Append(" " + hex); //3글자 더하기

                //value값을 구하는 작업을 수행, value값은 sblocal개체에 별도로 저장하고  offsetLine값과 hex값과 합친다
                int g = MyData[i];
                if (g > 13 || (g > 0 && g < 9)) //byte배열 MyData의 i번째 값이 g일때 그 값이 13보다 크거나 0과 9 사이의 값이면 char로 변환
                    sblocal.Append((char)MyData[i]);
                else //아니면 점찍기
                    sblocal.Append('.');

                ++newrow; //다음 라인으로
                if(newrow >= 16)
                {
                    biglocal.Append(" " + sblocal.ToString() + "\n"); //offset과 hex값에 value값 합치기
                    sblocal = new StringBuilder();
                    newrow = 0;
                }

            }

            

        }

        //offset line 값을 구하는 작업 수행
        private string padZeros(int inInt)
        {
            StringBuilder sblocal = new StringBuilder();
            string hex = Convert.ToString(inInt, 16); //매개변수로 Int32값을 받아서 16진수로 변환하여 문자열로 저장

            //offset line값은 16진수로 이루어진 8자리로 구성
            if (hex.Length < 8)
            {
                int ix = 8 - hex.Length; //8자리 중에 값을 넣을 곳 앞부분에 0으로 채워넣기
                for (int i = 0; i < ix; i++)
                {
                    sblocal.Append("0");
                }
            }
            sblocal.Append(hex); //실제 hex값 넣기
            return sblocal.ToString().ToUpper();
        }

        //Hex값을 구하는 작업을 수행
        public string convertByteToHexString(byte inByte)
        {
            StringBuilder sblocal = new StringBuilder();
            string hex = Convert.ToString(inByte, 16);
            if(hex.Length == 1) //hex넘버가 한자리일경우 앞에 0붙이기
            {
                sblocal.Append("0");
                sblocal.Append(hex);
            }
            else
                sblocal.Append(hex);

            return sblocal.ToString().ToUpper();
        }


        ////HexView(richboxText)와 stbView(StatusView)에 크로스 스레드 피하기 위한 델리게이트
        //public delegate void HexViewAppTxtDelegate(string message);
        //HexViewAppTxtDelegate HexViewAppTxtDele;

        ////HexViewAppTxtDelegate에 들어가는 메소드
        //private void HexViewAppTxt(string msg_stbViewTxt)
        //{
        //    string[] _msg_stbViewTxt = msg_stbViewTxt.Split('|');
        //    this.HexView.AppendText(_msg_stbViewTxt[0]);
        //    stbView.Text = _msg_stbViewTxt[1];
        //    this.HexView.Update();
        //}

        ////HexView(richboxText)와 stbView(StatusView)에 크로스 스레드 피하기 위한 델리게이트
        //public delegate void HexViewAppTxtDelegate2();
        //HexViewAppTxtDelegate2 HexViewAppTxtDele2;

        //private void HexViewTxtErr()
        //{
        //    this.HexView.AppendText("\n 파일 분석에 오류가 발생했습니다.\n\n");
        //}
    }
}
