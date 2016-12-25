using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mook_UTF8Base64
{
    class Conv
    {
        public string sTemp1 = null, sTemp2 = null;

        //문자열을 파라미터로 전달받아 UTF-8 형식으로 인코딩
        public string UTF8Encode(string sParam)
        {
            sTemp1 = sParam;
            sTemp2 = string.Empty; //빈 문자열을 설정, ""와 같다. 결국 초기화 하는 구문

            if(sParam == string.Empty || sParam == null) //매개변수로 받은 값이 ""의 빈문자열이거나 null이면
            {
                sTemp2 = "입력된 문자가 없습니다.";
                return sTemp2;
            }

            UTF8Encoding _UTF8 = new UTF8Encoding(); //UTF8 Encoding 클래스의 개체를 초기화하는 구문, 유니코드 문자를 UTF-8인코딩으로 변환

            try
            {
                byte[] enbytes = _UTF8.GetBytes(sTemp1); //byte배열을 초기화, 지정된 문자열의 모든 문자를 바이트로 인코딩

                #region foreach 구문을 이용하여 13행에서 바이트로 인코딩된 배열의 컬렉션 값을 가져오는 작업 수행
                foreach (byte bt in enbytes) //byte단위 문자와 매칭되는 16진수 값을 sTemp2에 저장
                {
                    sTemp2 += string.Format("%{0:X2}", bt); //UTF-8 형식으로 변환하기 위해 '%'를 앞에 붙여준다
                }                                           //{0:X2} 표현은 문자를 2자의 16진수 Hex값으로 변환하는 구문
                #endregion
                sTemp2 = sTemp2.ToUpper();
            }
            catch(Exception ex)
            {
                sTemp2 = "오류발생 : " + ex.Message.ToString();
            }
            return sTemp2; //변환된 문자열을 반환
        }

        //UTF-8로 변환된 문자열을 본래의 문자열로 디코딩
        public string UTF8Decode(string sParam)
        {
            sTemp1 = sParam;
            sTemp2 = string.Empty;
            int discarded;

            if(sParam == string.Empty || sParam == null)
            {
                sTemp2 = "입력된 문자가 없습니다";
                return sTemp2;
            }

            try
            {
                byte[] debytes = GetBytes(sTemp1, out discarded); //utf-8로 인코딩된 문자값을 16진수 바이트 배열로 반환
                char[] chars = new char[debytes.Length];
                chars = Encoding.UTF8.GetChars(debytes);

                foreach(char c in chars) //char배열에 저장된 문자 컬렉션을 가져와 sTemp2에 저장
                {
                    sTemp2 += c;
                }
            }
            catch(Exception ex)
            {
                sTemp2 = "오류발생 : " + ex.Message.ToString();
            }
            return sTemp2;

        }

        //UTF-8로 인코딩된 문자 값을 파라미터로 전달받아 16진수로 구성된 바이트 배열을 반환하는 작업 수행
        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            for (int i = 0; i < hexString.Length; i++) //입력받은 문자열의 길이만큼
            {
                c = hexString[i]; //하나씩 c에 집어넣어서

                if (IsHexDigit(c)) //16진수로 표현되는 값이면 newString에 추가하고
                    newString += c;
                else               //아니면 버리는 값 discarded에 +1
                    discarded++;   //'%'값을 지우는 역할을 한다
            }
            if(newString.Length % 2 != 0) //만약 매개변수 string이 홀수라면 
            {
                discarded++; //버리는 값이 1 추가하고
                newString = newString.Substring(0, newString.Length - 1); //마지막 하나를 자른다
            }

            #region 16진수 문자열을 분리하여 두 자리씩 hex에 저장하여 HexToByte() 메서드를 호출하여 16진수를 10진수 값으로 변환하여 byte배열에 저장
            int byteLength = newString.Length / 2; //newString을 반으로 잘라 
            byte[] bytes = new byte[byteLength]; //반으로 자른 길이만큼 byte 배열을 만들고
            string hex;
            int j = 0;
            
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new string(new char[] { newString[j], newString[j + 1] }); //2개씩 붙여서 16진수 값 string으로 만든다
                bytes[i] = HexToByte(hex);
                j = j + 2;
            } 
            #endregion
            return bytes;
        }

        //bool 타입을 반환하는 메소드, 파라미터 값으로 전달 받은 문자가 16진수로 유효한지 검사하는 작업
        public static bool IsHexDigit(char c)
        {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if (numChar >= numA && numChar < (numA + 6)) //입력받은 char이 A ~ F이면 true 반환
                return true;
            if (numChar >= num1 && numChar < (num1 + 10)) //입력받은 char이 0 ~ 9이면 true 반환
                return true;
            return false; //아니면 false 반환
        }

        //전달받은 파라미터 값을 10진수로 변환하여 반환
        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber); //16진수를 10진수로 변환하여 byte변수에 저장
            return newByte;
        }

        //문자열을 파라미터로 전달받아 Base64형식으로 인코딩
        public string Base64Encode(string sParam)
        {
            sTemp2 = string.Empty;
            if(sParam == string.Empty || sParam == null)
            {
                sTemp2 = "입력된 문자가 없습니다";
                return sTemp2;
            }
            try
            {
                byte[] enbytes = Encoding.Default.GetBytes(sParam); //GetBytes() 메소드로 지정된 문자열을 바이트 배열로 인코딩
                sTemp2 = Convert.ToBase64String(enbytes); //바이트 배열을 base64 숫자로 인코딩하여 해당하는 문자열 표현으로 변환
            }
            catch(Exception ex)
            {
                sTemp2 = "오류발생 : " + ex.Message.ToString();
            }
            return sTemp2;
        }

        //base64로 변환된 문자열을 본래의 문자열로 디코딩
        public string Base64Decode(string sParam)
        {
            sTemp2 = string.Empty;
            if(sParam == string.Empty || sParam == null)
            {
                sTemp2 = "입력된 문자열이 없습니다";
                return sTemp2;
            }

            try
            {
                byte[] debytes = Convert.FromBase64String(sParam); //base64문자열을 byte배열로 변환
                sTemp2 = Encoding.Default.GetString(debytes); //byte배열을 본래의 문자열로 변환
            }
            catch(Exception ex)
            {
                sTemp2 = "오류발생 : " + ex.Message.ToString();
            }
            return sTemp2;
        }
    }
}
