namespace mook_PortScanner
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
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.pgbScan = new System.Windows.Forms.ProgressBar();
            this.lvScan = new System.Windows.Forms.ListView();
            this.chPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fbdFile = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "스캔 IP";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(102, 16);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(195, 21);
            this.txtIp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "시작포트";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(102, 52);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(102, 21);
            this.txtStart.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "종료포트";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(102, 89);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(102, 21);
            this.txtEnd.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(222, 52);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 58);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "스캔";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(28, 129);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(269, 23);
            this.btnFile.TabIndex = 3;
            this.btnFile.Text = "파일경로";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(26, 168);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "생성 파일 :";
            // 
            // pgbScan
            // 
            this.pgbScan.Location = new System.Drawing.Point(28, 194);
            this.pgbScan.Maximum = 50;
            this.pgbScan.Name = "pgbScan";
            this.pgbScan.Size = new System.Drawing.Size(269, 23);
            this.pgbScan.Step = 1;
            this.pgbScan.TabIndex = 4;
            // 
            // lvScan
            // 
            this.lvScan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPort,
            this.chOpen});
            this.lvScan.GridLines = true;
            this.lvScan.Location = new System.Drawing.Point(316, 16);
            this.lvScan.Name = "lvScan";
            this.lvScan.Size = new System.Drawing.Size(240, 201);
            this.lvScan.TabIndex = 5;
            this.lvScan.UseCompatibleStateImageBehavior = false;
            this.lvScan.View = System.Windows.Forms.View.Details;
            // 
            // chPort
            // 
            this.chPort.Text = "Port";
            this.chPort.Width = 150;
            // 
            // chOpen
            // 
            this.chOpen.Text = "Open";
            this.chOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chOpen.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 237);
            this.Controls.Add(this.lvScan);
            this.Controls.Add(this.pgbScan);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "포트 스캐너";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ProgressBar pgbScan;
        private System.Windows.Forms.ListView lvScan;
        private System.Windows.Forms.ColumnHeader chPort;
        private System.Windows.Forms.ColumnHeader chOpen;
        private System.Windows.Forms.FolderBrowserDialog fbdFile;
    }
}

