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
            for (int i = 0; i < Imgbmp.Height; i++)
            {
                for (int j = 0; j < Imgbmp.Width; j++)
                {
                    Color pixel = Imgbmp.GetPixel(j, i);

                    pixel = Color.FromArgb(pixel.R - pixel.R % 2, pixel.G - pixel.G % 2, pixel.B - pixel.B % 2);

                    R = pixel.R;
                    G = pixel.G;
                    B = pixel.B;

                    for (int n = 0; n < 3; n++)
                    {
                        if(colorUnitIndex % 8 == 0)
                        {
                            if(charIndex < HiddenText.Length)
                            {
                                charValue = HiddenText[charIndex++];
                                runNum(++RunStatus);
                            }
                        }
                        switch(colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    R += charValue % 2;
                                    charValue /= 2;
                                } break;
                            case 1:
                                {
                                    G += charValue % 2;
                                    charValue /= 2;
                                } break;
                            case 2:
                                {
                                    B += charValue % 2;
                                    charValue /= 2;
                                } break;
                        }
                        Imgbmp.SetPixel(j, i, Color.FromArgb(R, G, B));
                        colorUnitIndex++;
                    }
                }
            }
            Application.DoEvents();
            return Imgbmp;
        }
    }
}
