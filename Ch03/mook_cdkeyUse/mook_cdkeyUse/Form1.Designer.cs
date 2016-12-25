namespace mook_cdkeyUse
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtKey01 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKey02 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKey03 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKey04 = new System.Windows.Forms.TextBox();
            this.txtKey05 = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(101, 6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(309, 25);
            this.txtUserName.TabIndex = 1;
            // 
            // txtKey01
            // 
            this.txtKey01.Location = new System.Drawing.Point(12, 37);
            this.txtKey01.Name = "txtKey01";
            this.txtKey01.Size = new System.Drawing.Size(58, 25);
            this.txtKey01.TabIndex = 1;
            this.txtKey01.TextChanged += new System.EventHandler(this.txtKey01_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "-";
            // 
            // txtKey02
            // 
            this.txtKey02.Location = new System.Drawing.Point(97, 37);
            this.txtKey02.Name = "txtKey02";
            this.txtKey02.Size = new System.Drawing.Size(58, 25);
            this.txtKey02.TabIndex = 1;
            this.txtKey02.TextChanged += new System.EventHandler(this.txtKey02_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "-";
            // 
            // txtKey03
            // 
            this.txtKey03.Location = new System.Drawing.Point(182, 37);
            this.txtKey03.Name = "txtKey03";
            this.txtKey03.Size = new System.Drawing.Size(58, 25);
            this.txtKey03.TabIndex = 1;
            this.txtKey03.TextChanged += new System.EventHandler(this.txtKey03_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "-";
            // 
            // txtKey04
            // 
            this.txtKey04.Location = new System.Drawing.Point(267, 37);
            this.txtKey04.Name = "txtKey04";
            this.txtKey04.Size = new System.Drawing.Size(58, 25);
            this.txtKey04.TabIndex = 1;
            this.txtKey04.TextChanged += new System.EventHandler(this.txtKey04_TextChanged);
            // 
            // txtKey05
            // 
            this.txtKey05.Location = new System.Drawing.Point(352, 37);
            this.txtKey05.Name = "txtKey05";
            this.txtKey05.Size = new System.Drawing.Size(58, 25);
            this.txtKey05.TabIndex = 1;
            this.txtKey05.TextChanged += new System.EventHandler(this.txtKey05_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(12, 82);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 15);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "결과 :";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(335, 78);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "입력";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 113);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtKey05);
            this.Controls.Add(this.txtKey04);
            this.Controls.Add(this.txtKey03);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtKey02);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKey01);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtKey01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKey02;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKey03;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKey04;
        private System.Windows.Forms.TextBox txtKey05;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnOk;
    }
}

