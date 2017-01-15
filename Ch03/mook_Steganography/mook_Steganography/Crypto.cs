using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mook_Steganography
{
    class Crypto
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("123456789abcdefghijkllmn"); //왜 l이 두번?예제애도 똑같아서 따라했다만 빼면 안되나? 글자수를 맞춰야 하나?
                                                                                           //Rfc2898DeriveBytes 생성자에 지장할 키 파생에 사용되는 키 솔트를 생성하는 구문

        //데이터를 파라미터 값으로 전달받아 Rijndael 암호화 알고리즘을 이용하여 암호화된 문자열을 반환
        public static string EncryptStringAES(string HiddenText, string PrivateKey)
        {
            string outStr = null;
            RijndaelManaged rjdm = null; //Rijndael알고리즘을 제어하는 클래스 생성

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(PrivateKey, _salt);
                //Rfc2898DeriveBytes 클래스 : System.Security.Cryptography.HMACSHA1 기반의 의사(pseudo) 난수 생성기를 사용하여 암호 기반 키 파생
                //Rfc2898DeriveBytes()생성자를 이용하여 암호, 솔트 및 반복횟수(선택사항)을 받은 다음 GetBytes()메서드를 호출하여 키를 생성

                rjdm = new RijndaelManaged();
                rjdm.Key = key.GetBytes(rjdm.KeySize / 8); //key.GetBytes()메서드를 이용하여 난수키를 반환하여 대칭키 알고리즘의 비밀키로 사용될 rjdm.Key에 저장하는 작업 수행

                ICryptoTransform encryptor = rjdm.CreateEncryptor(rjdm.Key, rjdm.IV);
                //rjdm.CreateEncryptor()메서드에 비밀키와, 초기화벡터를 지정하여 대칭 Rijndael encryptor 개체를 생성
                #region MemoryStream개체를 생성하교 CrytpoStream 클래스의 개체를 이용하여 데이터를 암호화

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    #region msEncrypt.Write()메서드를 이용하여 버퍼에서 읽은 데이터를 사용하여 현재 스트림에 바이트 블록을 쓰는 작업을 수행
                    //이는 메모리 스트림에 초기화 벡터 값을 쓰는 것
                    msEncrypt.Write(BitConverter.GetBytes(rjdm.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(rjdm.IV, 0, rjdm.IV.Length);
                    #endregion
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(HiddenText); //데이터를 암호화하여 스트림에 저장
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray()); //Convert.ToBase64STring()메서드를 이용하여 8비트 부호 없는 정수로 구서된 배열을 base64 
                            //숫자로 인코딩된 해당하는 문자열 표현으로 변환
                }
                #endregion
            }
            finally
            {
                if (rjdm != null)
                    rjdm.Clear();
            }
            return outStr;
        }

        //이미지에서 추출된 암호화된 문자열을 복호화 알고리즘을 통해 일반 문자열로 반환하는 작업 수행
        public static string DecryptStringAES(string ExtractedText, string PrivateKey)
        {
            RijndaelManaged rjdm = null;
            string planeText = null;

            try
            {
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(PrivateKey, _salt);

                byte[] bytes = Convert.FromBase64String(ExtractedText);

                using(MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    rjdm = new RijndaelManaged();
                    rjdm.Key = key.GetBytes(rjdm.KeySize / 8);
                    rjdm.IV = ReadByteArray(msDecrypt);

                    ICryptoTransform decryptor = rjdm.CreateDecryptor(rjdm.Key, rjdm.IV);

                    using(CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using(StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            planeText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            finally
            {
                if (rjdm != null)
                    rjdm.Clear();
            }
            return planeText;
        }

        //초기화 벡터를 생성하여 반환
        private static byte[] ReadByteArray(Stream stmstr)
        {
            byte[] rawLength = new byte[sizeof(int)]; //rawLength의 바이트 배열 변수 생성 구문, 사이즈는 sizeof(int) 4이다
            if (stmstr.Read(rawLength, 0, rawLength.Length) != rawLength.Length) //stmstr.Read() 메서드를 이용하여 현재 스트림에서 바이트 블록을 읽어 데이터를 버퍼(rawLength)에 저장
                //buffer 바이트 배열의 크기(16)를 지정하기 위한 구문
                throw new SystemException();
            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (stmstr.Read(buffer, 0, buffer.Length) != buffer.Length) //stmstr.Read() 메서드를 이용하여 현재 스트림에서 바이트 블록을 읽어 데이터를 버퍼(buffer)에 저장
                //초기화 벡터를 스트림에서 읽어서 바이트 배열 변수에 저장
                throw new SystemException();
            return buffer;
        }
    }
}
