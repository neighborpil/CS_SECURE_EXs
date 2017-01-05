using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mook_RSA
{
    class DecryptionThread
    {
        private ContainerControl containerControl = null; //다른 컨트롤의 컨테이너로 작동 할 수 있도록 관리 기능 제공
        private Delegate updateTextDelegate = null;

        //파라메터로 전달받은 값을 분류하고 DecryptString() 메서드를 호출하여 RSA 암호화 알고리즘으로 암호화된 문자열을 복호화
        public void Decrypt(object inputObject)
        {
            object[] inputObjects = (object[])inputObject;
            containerControl = (Form)inputObjects[0];
            updateTextDelegate = (Delegate)inputObjects[1];
            string decryptedString = DecryptString((string)inputObjects[2], (int)inputObjects[3], (string)inputObjects[4]);
            containerControl.Invoke(updateTextDelegate, new object[] { decryptedString }); //특정 매개변수 목록을 사용하여 지정된 대리자 실행
                                        //updateTextDelegate 수행하여 복호화된 문자열을 txtDecrypt 컨트롤에 나타냄
        }

        //RSA 암&복호화 알고리즘을 이용하여 암호화된 문자열을 복호화
        public string DecryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize); //지정된 키 크기(1024)를 사용하여 RSACryptoServiceProvider객체 생성
            rsaCryptoServiceProvider.FromXmlString(xmlString); //.FromXmlString() 메서드를 이용하여 XML 문자열의 키 정보를 사용하여 RSA 개체를 초기화,
                                                               //매개변수는 RSA 비밀키 정보가 들어있는 XML 문자열(xmlString)
            int base64BlockSize = 172;
            int iterations = inputString.Length / base64BlockSize; //문자열을 base64BlockSize로 자른뒤 
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < iterations; i++)                   //그 숫자만큼 for문을 돈다
            {
                byte[] decryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize)); //

                Array.Reverse(decryptedBytes);

                rsaCryptoServiceProvider.Decrypt(decryptedBytes, true); //.Decrypt(복호화할 데이터, 패팅분류), RSA 알고리즘을 사용하여 데이터 복호화
                                            //패팅분류값이 true : OAEP 패팅을 사용하여 직접 RSA 해독을 수행
                                            //패팅분류값이 false : PKCS#1 v1.5 패팅을 사용하여 RSA 해독 수행
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(decryptedBytes, true)); //.AddRange 메서드 이용 ArrayList 각 요소 복사
            }

            return Encoding.UTF32.GetString(arrayList.ToArray(Type.GetType("System.Byte")) as byte[]); //byte 배열에서 Encoding.UTF32.GetString() 메서드 이용하여
                                            //해당하는 문자를 추출하여 반환, Type.GetType() 메서드는 지정된 형식을 나타내는 Type 개체를 가져옴
        }
    }
}
