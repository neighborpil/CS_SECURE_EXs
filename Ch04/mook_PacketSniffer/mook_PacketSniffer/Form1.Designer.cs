namespace mook_PacketSniffer
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
            this.tsMenu = new System.Windows.Forms.ToolStrip();
<<<<<<< HEAD
            this.lvReceivedPackets = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
=======
            this.tsbtnStart = new System.Windows.Forms.ToolStripButton();
            this.tsbtnStop = new System.Windows.Forms.ToolStripButton();
            this.tslblIp = new System.Windows.Forms.ToolStripLabel();
            this.tscbIp = new System.Windows.Forms.ToolStripComboBox();
            this.tslblNum = new System.Windows.Forms.ToolStripLabel();
            this.tscbNum = new System.Windows.Forms.ToolStripComboBox();
            this.lvReceivedPackets = new System.Windows.Forms.ListView();
            this.chNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvPacketDetail = new System.Windows.Forms.TreeView();
            this.tsMenu.SuspendLayout();
>>>>>>> origin/ModifyBranch
            this.SuspendLayout();
            // 
            // tsMenu
            // 
<<<<<<< HEAD
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1040, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // lvReceivedPackets
            // 
            this.lvReceivedPackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvReceivedPackets.FullRowSelect = true;
            this.lvReceivedPackets.Location = new System.Drawing.Point(0, 25);
            this.lvReceivedPackets.Name = "lvReceivedPackets";
            this.lvReceivedPackets.Size = new System.Drawing.Size(1040, 97);
            this.lvReceivedPackets.TabIndex = 1;
            this.lvReceivedPackets.UseCompatibleStateImageBehavior = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 122);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1040, 407);
            this.treeView1.TabIndex = 2;
=======
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnStart,
            this.tsbtnStop,
            this.tslblIp,
            this.tscbIp,
            this.tslblNum,
            this.tscbNum});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(810, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbtnStart
            // 
            this.tsbtnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnStart.Image = global::mook_PacketSniffer.Properties.Resources.play;
            this.tsbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStart.Name = "tsbtnStart";
            this.tsbtnStart.Size = new System.Drawing.Size(23, 22);
            this.tsbtnStart.Text = "Start";
            this.tsbtnStart.Click += new System.EventHandler(this.tsbtnStart_Click);
            // 
            // tsbtnStop
            // 
            this.tsbtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnStop.Enabled = false;
            this.tsbtnStop.Image = global::mook_PacketSniffer.Properties.Resources.pause;
            this.tsbtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStop.Name = "tsbtnStop";
            this.tsbtnStop.Size = new System.Drawing.Size(23, 22);
            this.tsbtnStop.Text = "Stop";
            this.tsbtnStop.Click += new System.EventHandler(this.tsbtnStop_Click);
            // 
            // tslblIp
            // 
            this.tslblIp.Name = "tslblIp";
            this.tslblIp.Size = new System.Drawing.Size(83, 22);
            this.tslblIp.Text = "Select IP Addr";
            // 
            // tscbIp
            // 
            this.tscbIp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbIp.Name = "tscbIp";
            this.tscbIp.Size = new System.Drawing.Size(121, 25);
            // 
            // tslblNum
            // 
            this.tslblNum.Name = "tslblNum";
            this.tslblNum.Size = new System.Drawing.Size(79, 22);
            this.tslblNum.Text = "aPacket Num";
            // 
            // tscbNum
            // 
            this.tscbNum.Items.AddRange(new object[] {
            "100",
            "300",
            "400",
            "500",
            "1000"});
            this.tscbNum.Name = "tscbNum";
            this.tscbNum.Size = new System.Drawing.Size(121, 25);
            // 
            // lvReceivedPackets
            // 
            this.lvReceivedPackets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNo,
            this.chTime,
            this.chSource,
            this.chDest,
            this.chProtocol,
            this.chPack});
            this.lvReceivedPackets.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvReceivedPackets.FullRowSelect = true;
            this.lvReceivedPackets.GridLines = true;
            this.lvReceivedPackets.Location = new System.Drawing.Point(0, 25);
            this.lvReceivedPackets.Name = "lvReceivedPackets";
            this.lvReceivedPackets.Size = new System.Drawing.Size(810, 97);
            this.lvReceivedPackets.TabIndex = 1;
            this.lvReceivedPackets.UseCompatibleStateImageBehavior = false;
            this.lvReceivedPackets.View = System.Windows.Forms.View.Details;
            this.lvReceivedPackets.Click += new System.EventHandler(this.lvReceivedPackets_Click);
            // 
            // chNo
            // 
            this.chNo.Text = "No.";
            this.chNo.Width = 70;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTime.Width = 180;
            // 
            // chSource
            // 
            this.chSource.Text = "Source";
            this.chSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSource.Width = 150;
            // 
            // chDest
            // 
            this.chDest.Text = "Destination";
            this.chDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDest.Width = 150;
            // 
            // chProtocol
            // 
            this.chProtocol.Text = "Protocol";
            this.chProtocol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chProtocol.Width = 100;
            // 
            // chPack
            // 
            this.chPack.Text = "Packet Size";
            this.chPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPack.Width = 100;
            // 
            // tvPacketDetail
            // 
            this.tvPacketDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPacketDetail.Location = new System.Drawing.Point(0, 122);
            this.tvPacketDetail.Name = "tvPacketDetail";
            this.tvPacketDetail.Size = new System.Drawing.Size(810, 389);
            this.tvPacketDetail.TabIndex = 2;
>>>>>>> origin/ModifyBranch
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1040, 529);
            this.Controls.Add(this.treeView1);
=======
            this.ClientSize = new System.Drawing.Size(810, 511);
            this.Controls.Add(this.tvPacketDetail);
>>>>>>> origin/ModifyBranch
            this.Controls.Add(this.lvReceivedPackets);
            this.Controls.Add(this.tsMenu);
            this.Name = "Form1";
            this.Text = "PacketSniffer";
<<<<<<< HEAD
=======
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
>>>>>>> origin/ModifyBranch
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
<<<<<<< HEAD
        private System.Windows.Forms.ListView lvReceivedPackets;
        private System.Windows.Forms.TreeView treeView1;
=======
        private System.Windows.Forms.ToolStripButton tsbtnStart;
        private System.Windows.Forms.ListView lvReceivedPackets;
        private System.Windows.Forms.TreeView tvPacketDetail;
        private System.Windows.Forms.ToolStripButton tsbtnStop;
        private System.Windows.Forms.ToolStripLabel tslblIp;
        private System.Windows.Forms.ToolStripComboBox tscbIp;
        private System.Windows.Forms.ToolStripLabel tslblNum;
        private System.Windows.Forms.ToolStripComboBox tscbNum;
        private System.Windows.Forms.ColumnHeader chNo;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chSource;
        private System.Windows.Forms.ColumnHeader chDest;
        private System.Windows.Forms.ColumnHeader chProtocol;
        private System.Windows.Forms.ColumnHeader chPack;
>>>>>>> origin/ModifyBranch
    }
}

