using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography; //데이터 보안 및 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
#using System.Security.Cryptography;
- 데이터 보안 인코딩 및 디코딩을 포함한 암호화 서비스 제공
- 해시, 난수 생성, 메세지 인증 등 다른 작업 위한 기능 제공
*/
namespace mook_FileHash
{
    class HashConvert
    {
        //파라미터로 전달받은 파일에 대한 MD5 해시값을 반환하는 작업 수행
        public static string GetMD5Hash(string pathName)
        {
            string strResult = ""; //최종 출력값
            string strHashData = ""; //중간단계로 '-' 표시 포함값

            byte[] arrbyHashValue; //MD5 해쉬값이 저장될 바이트 배열
            FileStream oFileStream = null;

            MD5CryptoServiceProvider oMD5Hasher = new MD5CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName); //파일을 읽어들여 FileStream 열기
                arrbyHashValue = oMD5Hasher.ComputeHash(oFileStream); //FileStream 객체를 oMD5Hasher.ComputeHash() 메서드에 지정하여, FileStream 개체에 대한 해시값 계산, 바이트 배열 저장
                oFileStream.Close();

                strHashData = BitConverter.ToString(arrbyHashValue); //BitConverter.ToString()메서드 이용하여 지정된 바이트 배열의 각 요소 숫자값을 해당하는 16진수 문자열 표현으로 변환
                strHashData = strHashData.Replace("-", ""); 
                strResult = strHashData;
            }
            catch(Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return strResult;
        }

        //지정된 파일의 경로를 이용하여 FileStream 클래스를 반환
        private static FileStream GetFileStream(string pathName)
        {
            return new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        //파라미터로 전달받은 파일에 대한 SHA-1 해시값을 반환
        public static string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbyHashValue;
            FileStream oFileStream = null;

            SHA1CryptoServiceProvider oSHA1Hasher = new SHA1CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName);
                arrbyHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                strHashData = BitConverter.ToString(arrbyHashValue);

                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch(Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return strResult;
        }
    }
}
