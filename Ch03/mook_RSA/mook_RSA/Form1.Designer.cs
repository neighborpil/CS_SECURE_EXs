namespace mook_RSA
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGetFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.privateKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbpbData = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.grpbResult = new System.Windows.Forms.GroupBox();
            this.txtDecrypt = new System.Windows.Forms.TextBox();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.msMenu.SuspendLayout();
            this.gbpbData.SuspendLayout();
            this.grpbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(532, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "내보내기";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(532, 68);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 0;
            this.btnGetFile.Text = "가져오기";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(532, 97);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "복호화";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // msMenu
            // 
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(623, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateKeyToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitXToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // generateKeyToolStripMenuItem
            // 
            this.generateKeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicKeyToolStripMenuItem,
            this.privateKeyToolStripMenuItem});
            this.generateKeyToolStripMenuItem.Name = "generateKeyToolStripMenuItem";
            this.generateKeyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.generateKeyToolStripMenuItem.Text = "Generate Key";
            // 
            // publicKeyToolStripMenuItem
            // 
            this.publicKeyToolStripMenuItem.Name = "publicKeyToolStripMenuItem";
            this.publicKeyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.publicKeyToolStripMenuItem.Text = "Public Key";
            this.publicKeyToolStripMenuItem.Click += new System.EventHandler(this.publicKeyToolStripMenuItem_Click);
            // 
            // privateKeyToolStripMenuItem
            // 
            this.privateKeyToolStripMenuItem.Name = "privateKeyToolStripMenuItem";
            this.privateKeyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.privateKeyToolStripMenuItem.Text = "Private Key";
            this.privateKeyToolStripMenuItem.Click += new System.EventHandler(this.privateKeyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // exitXToolStripMenuItem
            // 
            this.exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            this.exitXToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitXToolStripMenuItem.Text = "Exit(&X)";
            this.exitXToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
            // 
            // gbpbData
            // 
            this.gbpbData.Controls.Add(this.txtMessage);
            this.gbpbData.Location = new System.Drawing.Point(12, 27);
            this.gbpbData.Name = "gbpbData";
            this.gbpbData.Size = new System.Drawing.Size(505, 122);
            this.gbpbData.TabIndex = 2;
            this.gbpbData.TabStop = false;
            this.gbpbData.Text = "메시지";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 14);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(493, 102);
            this.txtMessage.TabIndex = 0;
            // 
            // grpbResult
            // 
            this.grpbResult.Controls.Add(this.txtDecrypt);
            this.grpbResult.Location = new System.Drawing.Point(12, 155);
            this.grpbResult.Name = "grpbResult";
            this.grpbResult.Size = new System.Drawing.Size(505, 122);
            this.grpbResult.TabIndex = 2;
            this.grpbResult.TabStop = false;
            this.grpbResult.Text = "메시지";
            // 
            // txtDecrypt
            // 
            this.txtDecrypt.Location = new System.Drawing.Point(6, 14);
            this.txtDecrypt.Multiline = true;
            this.txtDecrypt.Name = "txtDecrypt";
            this.txtDecrypt.ReadOnly = true;
            this.txtDecrypt.Size = new System.Drawing.Size(493, 102);
            this.txtDecrypt.TabIndex = 0;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            this.ofdFile.Filter = "Public Key Document(*.pke)|*.pke";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 284);
            this.Controls.Add(this.grpbResult);
            this.Controls.Add(this.gbpbData);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RSA Server";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.gbpbData.ResumeLayout(false);
            this.gbpbData.PerformLayout();
            this.grpbResult.ResumeLayout(false);
            this.grpbResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem privateKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitXToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbpbData;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox grpbResult;
        private System.Windows.Forms.TextBox txtDecrypt;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.OpenFileDialog ofdFile;
    }
}

