using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_RSAUser
{
    class EncryptionThread
    {
        private ContainerControl containerControl = null; //폼의 부모 클래스로 Form으로 사용 가능
        private Delegate updateTextDelegate = null;

        //파라미터로 전달받은 값을 분류하고 EncryptString() 메서드를 호출하여 RSA 암호화 알고리즘을 이용하여 데이터를 암호화
        public void Encrypt(object inputObject)
        {
            /*
            #object[]는 총 5개의 매개변수로 구성된다
             1. Form1
             2. Form1에서 실행될 델리게이트
             3. 암호화 해독에 사용되는 text
             4. 암호화 해독에 사용되는 bitNum
             5. 암호호 해독에 사용되는 공개키
             3~5를 EncryptedString()메서드에 넣어서 암호문을 해독하고 그것을 다시
             델리이트로 Form1(containerControl)에 전달한다
            */
            object[] inputObjects = (Object[])inputObject; 
            containerControl = (Form)inputObjects[0];
            updateTextDelegate = (Delegate)inputObjects[1]; //containerControl.Invoke() 메서드를 호출하여 암호화된 문자열을 txtEncrypt 컨트롤에 나타내는 작업
            string encryptedString = EncryptedString((string)inputObjects[2], (int)inputObjects[3], (string)inputObjects[4]);
                    //DecryptString() 메서드에 파라미터로 전달받은 암호화된 문자열과 비트, 공개키를 지정하여 암호화된 문자열을 반환
            containerControl.Invoke(updateTextDelegate, new object[] { encryptedString });
        }

        //파라미터로 전달된 문자열 데이터와 공개키를 이용하여 RSA 암호화 알고리즘을 이용하여 암호화 한다
        private string EncryptedString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize); //지정된 키사이즈(1024)로 초기화
            rsaCryptoServiceProvider.FromXmlString(xmlString); //공개키(xmlString)을 FromXmlString()에 넣어 초기화
            
            #region 암호화 블럭의 사이즈를 결정하는 구문들
            int keySize = dwKeySize / 8; //키사이즈 1024 / 8
            byte[] bytes = Encoding.UTF32.GetBytes(inputString); // 지정된 문자열을 바이트 시퀸스로 변환
            int maxLength = keySize - 42; //
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            #endregion

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                #region Buffer.BlockCopy()
                /*
                #Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count)
                 - 특정 오프셋에서 시작하는 소스 배열에서 특정 오프셋에서 시작하는 대상 배열로 지정된 바이트 수를 복사
                 - src : 소스 버퍼
                 - srcOffset : src에 대한 바이트 오프셋(0부터 시작)
                 - dst : 대상 버퍼
                 - dstOffset : dst에 대한 바이트 오프셋(0부터 시작)
                 - count : 복사할 바이트 수
                */
                #endregion
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                Array.Reverse(encryptedBytes);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }
    }
}
