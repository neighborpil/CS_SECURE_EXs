namespace mook_NetworkScanner
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
            this.txtStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvScan = new System.Windows.Forms.ListView();
            this.chIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pgrScan = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start IP";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(63, 9);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(146, 21);
            this.txtStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "End IP";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(267, 9);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(146, 21);
            this.txtEnd.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(419, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvScan
            // 
            this.lvScan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIp,
            this.chHostName,
            this.chMac});
            this.lvScan.GridLines = true;
            this.lvScan.Location = new System.Drawing.Point(14, 45);
            this.lvScan.Name = "lvScan";
            this.lvScan.Size = new System.Drawing.Size(516, 329);
            this.lvScan.TabIndex = 3;
            this.lvScan.UseCompatibleStateImageBehavior = false;
            this.lvScan.View = System.Windows.Forms.View.Details;
            // 
            // chIp
            // 
            this.chIp.Text = "IP addr";
            this.chIp.Width = 170;
            // 
            // chHostName
            // 
            this.chHostName.Text = "HostName";
            this.chHostName.Width = 170;
            // 
            // chMac
            // 
            this.chMac.Text = "Mac";
            this.chMac.Width = 170;
            // 
            // pgrScan
            // 
            this.pgrScan.Location = new System.Drawing.Point(14, 380);
            this.pgrScan.Name = "pgrScan";
            this.pgrScan.Size = new System.Drawing.Size(516, 23);
            this.pgrScan.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 416);
            this.Controls.Add(this.pgrScan);
            this.Controls.Add(this.lvScan);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Network Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvScan;
        private System.Windows.Forms.ColumnHeader chIp;
        private System.Windows.Forms.ColumnHeader chHostName;
        private System.Windows.Forms.ColumnHeader chMac;
        private System.Windows.Forms.ProgressBar pgrScan;
    }
}

