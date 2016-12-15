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
[UTF-8 or Base64 변환]
 * UTF-8 : 다양한 문자를 공통 표현식으로 나타내는 인코딩
 * Base64 : 일반적으로 바이너리 데이터를 텍스트 형식(문자)으로 저장하거나 전송하기 위해 사용되는 인코딩 기법
            데이터 전송중에 수정하지 않고, 전송하여도 데이터 손실이 없다
 * 인코딩 방식은 암, 복호화 알고리즘은 아니지만 암, 복호화 구현을 위해 사용되기 때문에 구현한다

#구동 개념
 - btnUTFEn_Click(object sender, EventArgs e) : [UTF8 Encode] 버튼 이벤트 핸들러, 문자열을 UTF-8 형식으로 인코딩
 - btnUTFDe_Click(object sender, EventArgs e) : [UTF8 Decode] 버튼 이벤트 핸들러, UTF-8로 인코딩된 문자열을 디코딩하는 작업
 - btnBaseEn_Click(object sender, EventArgs e) : [Base64 Encode] 버튼 이벤트 핸들러, 문자열을 Base64 형식으로 인코딩
 - btnBaseDe_Click(object sender, EventArgs e) : [Base64 Decode] 버튼 이벤트 핸들러, Base64로 인코딩된 문자열을 디코딩하는 작업
*/
namespace mook_UTF8Base64
{
    public partial class Form1 : Form
    {
        Conv cv = new Conv();

        public Form1()
        {
            InitializeComponent();
        }

        //UTF8로 인코딩
        private void btnUTFEn_Click(object sender, EventArgs e)
        {
            this.txtDecode.Text = cv.UTF8Encode(this.txtEncode.Text);
        }

        //UTF8로 디코딩
        private void btnUTFDe_Click(object sender, EventArgs e)
        {
            this.txtDecode.Text = cv.UTF8Decode(this.txtDecode.Text);
        }
    }
}
