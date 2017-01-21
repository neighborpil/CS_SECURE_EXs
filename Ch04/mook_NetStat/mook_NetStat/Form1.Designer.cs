namespace mook_NetStat
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
            this.lvNetState = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtForAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.clhLocalIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhLocalPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhRemoteIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhRemotePort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtForPort = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvNetState
            // 
            this.lvNetState.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhLocalIP,
            this.clhLocalPort,
            this.clhRemoteIP,
            this.clhRemotePort,
            this.clhState});
            this.lvNetState.GridLines = true;
            this.lvNetState.Location = new System.Drawing.Point(12, 12);
            this.lvNetState.Name = "lvNetState";
            this.lvNetState.Size = new System.Drawing.Size(620, 371);
            this.lvNetState.TabIndex = 0;
            this.lvNetState.UseCompatibleStateImageBehavior = false;
            this.lvNetState.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "로컬포트";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "외부주소";
            // 
            // txtForAdd
            // 
            this.txtForAdd.Location = new System.Drawing.Point(224, 393);
            this.txtForAdd.Name = "txtForAdd";
            this.txtForAdd.Size = new System.Drawing.Size(141, 25);
            this.txtForAdd.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "외부포트";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(512, 392);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(57, 23);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "체크";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // clhLocalIP
            // 
            this.clhLocalIP.Text = "로컬주소";
            this.clhLocalIP.Width = 180;
            // 
            // clhLocalPort
            // 
            this.clhLocalPort.Text = "로컬포트";
            this.clhLocalPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhLocalPort.Width = 80;
            // 
            // clhRemoteIP
            // 
            this.clhRemoteIP.Text = "외부주소";
            this.clhRemoteIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhRemoteIP.Width = 180;
            // 
            // clhRemotePort
            // 
            this.clhRemotePort.Text = "외부포트";
            this.clhRemotePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhRemotePort.Width = 80;
            // 
            // clhState
            // 
            this.clhState.Text = "상태";
            this.clhState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clhState.Width = 90;
            // 
            // txtForPort
            // 
            this.txtForPort.Location = new System.Drawing.Point(444, 393);
            this.txtForPort.Name = "txtForPort";
            this.txtForPort.Size = new System.Drawing.Size(62, 25);
            this.txtForPort.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 392);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(85, 393);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(62, 25);
            this.txtLocalPort.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 429);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtForAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.txtForPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvNetState);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NetStat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvNetState;
        private System.Windows.Forms.ColumnHeader clhLocalIP;
        private System.Windows.Forms.ColumnHeader clhLocalPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtForAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ColumnHeader clhRemoteIP;
        private System.Windows.Forms.ColumnHeader clhRemotePort;
        private System.Windows.Forms.ColumnHeader clhState;
        private System.Windows.Forms.TextBox txtForPort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLocalPort;
    }
}

