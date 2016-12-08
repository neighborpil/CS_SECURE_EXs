using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_FileWipe
{
    class FileDelete
    {
        FileInfo fi = null;
        FileStream fs = null;
        byte[] ByteArray = null;
        public delegate void ProcessEventHandler(int Current);
        public event ProcessEventHandler runPer;

        //생성자 : 삭제할 파일의 경로 전달
        public FileDelete(string FilePath)
        {
            fi = new FileInfo(FilePath);
        }

        //선택된 파일 영역에 0x0 값을 1회 채워 넣어 파일이 복구되지 않도록 완전히 삭제하는 작업 수행
        public void British_HMG_IS5_BaseLine(string FilePath)
        {
            try
            {
                ByteArray = new byte[fi.Length];
                runPer(0); //runPer이벤트를 호출하여 진행률의 초기값 선언, 델리게이트에 설정된 이벤트 처리기가 실행되어 진행률이 화면에 나타난다
                Application.DoEvents(); //현재 메시지 큐에 있는 모든 Windows메세지 처리
                for (int i = 0; i < fi.Length; i++)
                {
                    ByteArray[i] = 0x0; //파일 영역 버퍼로 쓰일 byte 배열에 임의 값인 '0x0'을 채워넣어 파일이 복구되지 않도록 하는 작업
                    runPer((int)(((float)i / (float)(fi.Length - 1.0)) * 100.0)); //runPer 이벤트를 호출하여 작업 진행률을 표시
                                            //i를 fi.Length - 1의 값으로 나누고 100곱한다, 그뒤 int로 변환
                }
                RunBuffer(FilePath, ByteArray); //실제 파일에 쓰는 작업
                //fi.Delete(); //더미 데이터를 넣은 뒤 삭제, 윈도우즈 휴지통에 넣었다 비운것과 같은효과
                Application.DoEvents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //파일 영역 버퍼에 임의 값인 0x0으로 채우는 작업 수행
        private void RunBuffer(string FilePath, byte[] Buffer)
        {
            fs = new FileStream(FilePath, FileMode.Open, FileAccess.Write, FileShare.None); //FileStream(지정된 경로, 생성모드, 읽기/쓰기 권한, 공유권한)으로 파일 쓰기
                            //FileShare열거형 : 프로세스에서 파일을 공유하는 방법을 결정하는 상수(None(현재 파일 공유 거절), Read(다음에 파일을 읽기용으로 여는거 허용)
            fs.Write(Buffer, 0, Buffer.Length); //FileStream.Write(버퍼, offset, 횟수)
            fs.Flush(); //쓰기
            fs.Close(); //닫기
        }
        
        public void British_HMG_IS5_Enhanced(string FilePath)
        {
            try
            {
                ByteArray = new byte[fi.Length];
                runPer(0);
                Application.DoEvents();
                int n = 0;
                for (int c = 0; c < 4; c++)
                {
                    switch (c)
                    {
                        case 1: //0x0으로 덮어쓰기
                            for (int i = 0; i < fi.Length; i++)
                            {
                                ByteArray[i] = 0x0;
                                runPer((int)(((float)i / (float)((fi.Length - 1.0) * 3.0)) * 100.0));
                                n++;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                        case 2: //0x0으로 덮어쓰기
                            for (int i = 0; i < fi.Length; i++)
                            {
                                ByteArray[i] = 0x0;
                                runPer((int)(((float)i / ((fi.Length - 1.0) * 3)) * 100.0));
                                n++;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                        case 3: //랜덤수로 덮어쓰기
                            switch (RandomBuffer(n)) //쓸데없이 switch써서 헥갈리게 하네, 그래도 신기한 방법이니 놔두자
                            {
                                case true:
                                    break;
                            }
                            RunBuffer(FilePath, ByteArray);
                            ByteArray = new byte[fi.Length];
                            break;
                    }
                }
                //fi.Delete();
                Application.DoEvents();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool RandomBuffer(int n)
        {
            ByteArray = new byte[fi.Length];
            Application.DoEvents();
            for (int i = 0; i < fi.Length; i++)
            {
                ByteArray[i] = RandomByte();
                runPer((int)(((float)n / (float)((fi.Length - 1.0) * 3.0)) * 100.0));
                n++;
            }
            return true;
        }

        //0~255사이의 랜덤값을 byte형식으로 반환받아 ByteArray 배열에 저장하는 작업 수행
        private byte RandomByte()
        {
            byte minimo = 0;
            byte maximo = 255;
            Random rnd = new Random(DateTime.Now.Millisecond); //밀리초단위로 랜덤넘버 받기
            byte resultRnd = (byte)(rnd.Next(minimo, maximo));
            return resultRnd;
        }
    }
}
