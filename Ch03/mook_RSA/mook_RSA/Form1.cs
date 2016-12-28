using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
[RSA]
 - 비대칭키 암호화 알고리즘
 - 수신자의 공개키를 가져와서 암호화하고, 수신자는 자신의 비밀키로 복호화한다
 - 대칭키 방식이 비밀키를 전달 중 해킹 당할 위험이 있지만 그에 비해 안전
 - 대칭키 방식에 비해 10~1000배 느리다
 - 따라서 비번 같이 중요한 것은 비대칭키 방식, 일반 데이터 전송은 대칭키 방식 주로 사용

#RSA
 - 종류 : 블록
 - 키의 크기 : 512, 1024 2048
 - 가장 많이 사용, 2000년도 특허 만료
 - 전자서명 가능 최초 알고리즘

#예제 구성
 1. 수신자(mook_Server.exe(RSA Server))
  - 공개키(*.pke)와 비밀키(*.kez)를 생성
  - 공개키를 내보내는 기능
  - 송신자에게 암호화된 통신문을 가져오는 기능
 2. 송신자(mook_RSA.exe(RSA User))
  - 수신자의 공개키를 가져와 데이터를 암호화
  - 암호화 데이터 파일을 내보내기







*/

//RSA 서버
namespace mook_RSA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
