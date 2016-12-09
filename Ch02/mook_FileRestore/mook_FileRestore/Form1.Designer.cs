namespace mook_FileRestore
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
            this.lvRcvFile = new System.Windows.Forms.ListView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvRcvFile
            // 
            this.lvRcvFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chPath,
            this.chDel});
            this.lvRcvFile.FullRowSelect = true;
            this.lvRcvFile.GridLines = true;
            this.lvRcvFile.Location = new System.Drawing.Point(12, 12);
            this.lvRcvFile.Name = "lvRcvFile";
            this.lvRcvFile.Size = new System.Drawing.Size(569, 420);
            this.lvRcvFile.TabIndex = 0;
            this.lvRcvFile.UseCompatibleStateImageBehavior = false;
            this.lvRcvFile.View = System.Windows.Forms.View.Details;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(277, 439);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(94, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "휴지통 비우기";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(377, 439);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(94, 23);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "복원";
            this.btnRestore.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(477, 439);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // chName
            // 
            this.chName.Text = "이름";
            this.chName.Width = 150;
            // 
            // chPath
            // 
            this.chPath.Text = "원래 위치";
            this.chPath.Width = 260;
            // 
            // chDel
            // 
            this.chDel.Text = "삭제된 날짜";
            this.chDel.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 469);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lvRcvFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "휴지통 복원";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRcvFile;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chDel;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRefresh;
    }
}

