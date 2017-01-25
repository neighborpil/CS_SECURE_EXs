using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_Steganography
{
    class SteganographyConvert
    {
        public delegate void ProcessEventHandler(int Current); //스테가노 그래피 진행률을 나타내는 작업
        public event ProcessEventHandler runNum;

        //숨길 암호화된 문자열과 Bitmap 이미지를 파라미터로 전달받아 이미지와 문자열을 믹싱
        public Bitmap embedText(string HiddenText, Bitmap Imgbmp)
        {
            int charIndex = 0;
            int charValue = 0;
            long colorUnitIndex = 0;
            int R = 0, G = 0, B = 0;

            int RunStatus = 0;
            Application.DoEvents(); //현재 메시지 큐에 있는 모든 Windows메세지를 처리
            #region 중첩 for 구문을 이용하여 Bitmap 클래스의 개체인 Imgbmp의 픽셀 R, G, B값을 구하거나 설정하는 작업을 수행
             //암호화된 문자에 해당하는 아스키 코드값을 이용하여 픽셀 RGB값을 변경하여 저장하여 이미지에 암호화된 문자를 숨김

            for (int i = 0; i < Imgbmp.Height; i++)
            {
                for (int j = 0; j < Imgbmp.Width; j++)
                {
                    Color pixel = Imgbmp.GetPixel(j, i); //해당 Bitmap의 지정된 픽셀의 색을 가져와 Color 구조체를 생성

                    //Color.FromArgb()메서드를 이용하여 지정된 8비트 값(빨강, 녹생 및 파랑)으로 Color 구조체를 만드는 작업 수행
                    //R, G, B값은 각각 0~255범위에서 지정 될 수 있다. 다음 행에서 0 또는 1이 가산 될 수 있으므로 범위를 벗어나지 않도록 0또는 1을 감산하여 pixel구조체 초기화
                    pixel = Color.FromArgb(pixel.R - pixel.R % 2, pixel.G - pixel.G % 2, pixel.B - pixel.B % 2);

                    R = pixel.R;
                    G = pixel.G;
                    B = pixel.B;

                    for (int n = 0; n < 3; n++)
                    {
                        #region colorUniIndex 값을 '8'로 나누고 나머지가 '0'일 때 즉, 8번째마다 [구문1]을 수행하여 암호화된 문자의 정수 값을 charValue에 저장하고
                        //switch 구문을 이용하여 해당 R, G, B값을 변경
                        //8배수가 되는 이유는 switch 구문의 'charValue /= 2 소스의 문자열 숨기기 알고리즘을 충족하기 위함
                        //이미지에서 암호화된 문자열을 추출하기 위하여 약속한 범위로 '2'로 나누어 8번째까지는 나눈 몫이 '0'이 되어야 한다
                        //이 구문의 궁극적 이유는 암호화된 문자의 정수 최대 범위를 '2'로 나누어 '0의 몫을 가질 때까지 8번 반복하면 무조건 구해지기 때문이다
                        
                        //구문1
                        if (colorUnitIndex % 8 == 0)
                        {
                            #region HiddenText에 저장된 암호화된 문자열에서 하나의 문자를 추출하여 정수값을 가져오는 작업
                            if (charIndex < HiddenText.Length)
                            {
                                charValue = HiddenText[charIndex++]; //charValue 변수에 HiddenText 문자열의 문자를 반복하여 정수 타입으로 묵시적 변경하여 저장
                                runNum(++RunStatus); //대리자 호출, 스테가노 그래피의 진행률을 설정
                            } 
                            #endregion
                        }
                        //구문1 end
                        #endregion
                        #region switch구문을 이용하여 픽셀 하나당 3회 반복하여 RGB값을 구하는 작업을 수행
                        //총 8회 반복하며 R, G, B값도 변경되지만 이 값은 암호화된 문자열을 저장하는 작업이기도 함

                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    R += charValue % 2;
                                    charValue /= 2;
                                }
                                break;
                            case 1:
                                {
                                    G += charValue % 2;
                                    charValue /= 2;
                                }
                                break;
                            case 2:
                                {
                                    B += charValue % 2;
                                    charValue /= 2;
                                }
                                break;
                        } 
                        #endregion
                        Imgbmp.SetPixel(j, i, Color.FromArgb(R, G, B)); //Imgbmp.SetPixel() 메서드를 이용하여 해당하는 픽셀의 R, G, B값을 설정

                        colorUnitIndex++;
                    }
                }
            } 

            #endregion
            Application.DoEvents();
            return Imgbmp;
        }

        //파라미터로 전달받은 Bitmap 이미지에서 숨겨 있는 암호화된 문자열을 추출하는 작업
        public string ExtractText(Bitmap Imgbmp)
        {
            int colorUnitIndex = 0;
            int charValue = 0;

            string ExtractedText = string.Empty;
            int RunStatus = 0;
            Application.DoEvents();
            for (int i = 0; i < Imgbmp.Height; i++)
            {
                for (int j = 0; j < Imgbmp.Width; j++)
                {
                    Color pixel = Imgbmp.GetPixel(j, i);

                    for (int n = 0; n < 3; n++)
                    {
                        switch(colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    charValue = charValue * 2 + pixel.R % 2;
                                }break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                }break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                }break;
                        }
                        colorUnitIndex++;
                        if(colorUnitIndex % 8 == 0)
                        {
                            charValue = ReverseBits(charValue);

                            if (charValue == 0)
                                return ExtractedText;

                            runNum(++RunStatus);
                            char c = (char)charValue;
                            ExtractedText += c.ToString();
                        }
                    }
                }
            }
            Application.DoEvents();
            return ExtractedText;
        }

        //ExtractText() 값에서 추출된 charValue 값을 파라미터값으로 전달받아 암호화된 문자의 정수 값으로 변경
        public static int ReverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;
                n /= 2;
            }
            return result;
        }
    }
}
