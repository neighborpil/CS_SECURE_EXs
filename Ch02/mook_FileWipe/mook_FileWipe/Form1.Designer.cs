namespace mook_FileWipe
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
            this.lblWipe = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.cbWipe = new System.Windows.Forms.ComboBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.btnWipe = new System.Windows.Forms.Button();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWipe
            // 
            this.lblWipe.AutoSize = true;
            this.lblWipe.Location = new System.Drawing.Point(21, 27);
            this.lblWipe.Name = "lblWipe";
            this.lblWipe.Size = new System.Drawing.Size(37, 12);
            this.lblWipe.TabIndex = 0;
            this.lblWipe.Text = "선택 :";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(21, 60);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(37, 12);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "파일 :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(29, 27);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 12);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Level :";
            // 
            // lblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.Location = new System.Drawing.Point(29, 60);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(49, 12);
            this.lblPer.TabIndex = 0;
            this.lblPer.Text = "진행률 :";
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.lblPer);
            this.gbResult.Controls.Add(this.lblTotal);
            this.gbResult.Location = new System.Drawing.Point(23, 96);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(217, 100);
            this.gbResult.TabIndex = 1;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Status";
            // 
            // cbWipe
            // 
            this.cbWipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWipe.FormattingEnabled = true;
            this.cbWipe.Items.AddRange(new object[] {
            "British HMG IS5 (Base Line)",
            "British HMG IS5 (Enhanced)"});
            this.cbWipe.Location = new System.Drawing.Point(81, 24);
            this.cbWipe.Name = "cbWipe";
            this.cbWipe.Size = new System.Drawing.Size(209, 20);
            this.cbWipe.TabIndex = 2;
            this.cbWipe.SelectedIndexChanged += new System.EventHandler(this.cbWipe_SelectedIndexChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(81, 57);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(169, 21);
            this.txtPath.TabIndex = 3;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(256, 55);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(34, 23);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "모든 파일(*.*)|*.*";
            // 
            // btnWipe
            // 
            this.btnWipe.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWipe.Location = new System.Drawing.Point(246, 96);
            this.btnWipe.Name = "btnWipe";
            this.btnWipe.Size = new System.Drawing.Size(44, 23);
            this.btnWipe.TabIndex = 4;
            this.btnWipe.Text = "Wipe";
            this.btnWipe.UseVisualStyleBackColor = true;
            this.btnWipe.Click += new System.EventHandler(this.btnWipe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 216);
            this.Controls.Add(this.btnWipe);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.cbWipe);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblWipe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "File Wipe";
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWipe;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPer;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.ComboBox cbWipe;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.Button btnWipe;
    }
}

