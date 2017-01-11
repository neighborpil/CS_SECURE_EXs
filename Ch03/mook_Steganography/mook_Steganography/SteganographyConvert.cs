using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
