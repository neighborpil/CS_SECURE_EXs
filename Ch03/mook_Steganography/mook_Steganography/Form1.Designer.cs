namespace mook_Steganography
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImgView = new System.Windows.Forms.PictureBox();
            this.plStegano = new System.Windows.Forms.Panel();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgView)).BeginInit();
            this.plStegano.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(719, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기OToolStripMenuItem,
            this.toolStripSeparator1,
            this.종료XToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기OToolStripMenuItem
            // 
            this.열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            this.열기OToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.열기OToolStripMenuItem.Text = "열기(&O)";
            this.열기OToolStripMenuItem.Click += new System.EventHandler(this.열기OToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(112, 6);
            // 
            // 종료XToolStripMenuItem
            // 
            this.종료XToolStripMenuItem.Name = "종료XToolStripMenuItem";
            this.종료XToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.종료XToolStripMenuItem.Text = "종료(&X)";
            this.종료XToolStripMenuItem.Click += new System.EventHandler(this.종료XToolStripMenuItem_Click);
            // 
            // pbImgView
            // 
            this.pbImgView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImgView.Location = new System.Drawing.Point(0, 27);
            this.pbImgView.Name = "pbImgView";
            this.pbImgView.Size = new System.Drawing.Size(434, 404);
            this.pbImgView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImgView.TabIndex = 1;
            this.pbImgView.TabStop = false;
            // 
            // plStegano
            // 
            this.plStegano.Controls.Add(this.btnDecrypt);
            this.plStegano.Controls.Add(this.btnEncrypt);
            this.plStegano.Controls.Add(this.txtKey);
            this.plStegano.Controls.Add(this.txtData);
            this.plStegano.Controls.Add(this.lblResult);
            this.plStegano.Controls.Add(this.label2);
            this.plStegano.Controls.Add(this.label1);
            this.plStegano.Location = new System.Drawing.Point(440, 27);
            this.plStegano.Name = "plStegano";
            this.plStegano.Size = new System.Drawing.Size(279, 404);
            this.plStegano.TabIndex = 2;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(147, 343);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(120, 23);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "복호화";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(20, 343);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(120, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "암호화";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(65, 316);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(202, 21);
            this.txtKey.TabIndex = 2;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(65, 26);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(202, 282);
            this.txtData.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(18, 379);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(48, 12);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "비밀키";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터";
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "mage Files (*.jpeg; *.png; *.bmp)|*.jpg; *.png; *.bmp";
            // 
            // sfdFile
            // 
            this.sfdFile.Filter = "Png Image|*.png|Bitmap Image|*.bmp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 432);
            this.Controls.Add(this.plStegano);
            this.Controls.Add(this.pbImgView);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Steganography";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgView)).EndInit();
            this.plStegano.ResumeLayout(false);
            this.plStegano.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기OToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 종료XToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbImgView;
        private System.Windows.Forms.Panel plStegano;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.SaveFileDialog sfdFile;
    }
}

