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
            this.lvReceivedPackets = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 529);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lvReceivedPackets);
            this.Controls.Add(this.tsMenu);
            this.Name = "Form1";
            this.Text = "PacketSniffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ListView lvReceivedPackets;
        private System.Windows.Forms.TreeView treeView1;
    }
}

