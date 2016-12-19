namespace mook_cdkey
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbDateYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtMacAdd = new System.Windows.Forms.TextBox();
            this.txtCKey = new System.Windows.Forms.TextBox();
            this.btnKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Year :";
            // 
            // cbDateYear
            // 
            this.cbDateYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateYear.FormattingEnabled = true;
            this.cbDateYear.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018"});
            this.cbDateYear.Location = new System.Drawing.Point(110, 10);
            this.cbDateYear.Name = "cbDateYear";
            this.cbDateYear.Size = new System.Drawing.Size(148, 20);
            this.cbDateYear.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mac Add :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "CD-Key :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(110, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(222, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // txtMacAdd
            // 
            this.txtMacAdd.Location = new System.Drawing.Point(110, 69);
            this.txtMacAdd.Name = "txtMacAdd";
            this.txtMacAdd.Size = new System.Drawing.Size(222, 21);
            this.txtMacAdd.TabIndex = 2;
            // 
            // txtCKey
            // 
            this.txtCKey.Location = new System.Drawing.Point(110, 99);
            this.txtCKey.Name = "txtCKey";
            this.txtCKey.ReadOnly = true;
            this.txtCKey.Size = new System.Drawing.Size(351, 21);
            this.txtCKey.TabIndex = 2;
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(340, 8);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(121, 82);
            this.btnKey.TabIndex = 3;
            this.btnKey.Text = "CD-Key 생성";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 130);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.txtCKey);
            this.Controls.Add(this.txtMacAdd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cbDateYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CD키 생성";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDateYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtMacAdd;
        private System.Windows.Forms.TextBox txtCKey;
        private System.Windows.Forms.Button btnKey;
    }
}

