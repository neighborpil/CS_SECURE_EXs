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

            string message = "\n" + fileName + " " + inSize + " Bytes\n\n";
            string stbViewText = " " + fileName + " " + inSize + " Bytes";

            this.HexView.AppendText(message);
            stbView.Text = " " + fileName + " " + inSize + " Bytes";
            this.HexView.Update();

            //string msg_stbViewTxt = message + "|" + stbViewText;
            //HexViewAppTxtDele = new HexViewAppTxtDelegate(HexViewAppTxt);
            //Invoke(HexViewAppTxtDele, msg_stbViewTxt);

            FileStream fs;
            byte[] MyData;

            try
            {
                fs = new FileStream((string)inFile, FileMode.OpenOrCreate, FileAccess.Read);
                MyData = new byte[fs.Length]; //fs의 길이만큼의 byte배열 생성
            }
            catch
            {
                this.HexView.AppendText("\n 파일 분석에 오류가 발생했습니다.\n\n");
                //HexViewAppTxtDele2 = new HexViewAppTxtDelegate2(HexViewTxtErr);
                //Invoke(HexViewAppTxtDele);

                return;
            }

            //stbView.Text = "하드 디스크 파일 분석";
            fs.Read(MyData, 0, (int)fs.Length); //파일을 읽어들이기
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
                    this.pgbView.Value = i;
            }

            if(newrow == 0)
            {
                numb = padZeros(global);
            }

        }

        //offset line 값을 구하는 작업 수행
        private string padZeros(int inInt)
        {
            StringBuilder sblocal = new StringBuilder();
            string hex = Convert.ToString(inInt, 16);
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
