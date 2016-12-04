namespace mook_HexEditor
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
            this.btnFile = new System.Windows.Forms.Button();
            this.pgbView = new System.Windows.Forms.ProgressBar();
            this.HexView = new System.Windows.Forms.RichTextBox();
            this.stbView = new System.Windows.Forms.StatusBar();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(0, 0);
            this.btnFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(105, 29);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // pgbView
            // 
            this.pgbView.Location = new System.Drawing.Point(111, 0);
            this.pgbView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgbView.Name = "pgbView";
            this.pgbView.Size = new System.Drawing.Size(857, 29);
            this.pgbView.TabIndex = 1;
            // 
            // HexView
            // 
            this.HexView.Font = new System.Drawing.Font("Courier New", 9F);
            this.HexView.ForeColor = System.Drawing.Color.Black;
            this.HexView.Location = new System.Drawing.Point(0, 37);
            this.HexView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HexView.Name = "HexView";
            this.HexView.Size = new System.Drawing.Size(968, 368);
            this.HexView.TabIndex = 2;
            this.HexView.Text = "";
            // 
            // stbView
            // 
            this.stbView.Location = new System.Drawing.Point(0, 412);
            this.stbView.Name = "stbView";
            this.stbView.Size = new System.Drawing.Size(968, 22);
            this.stbView.TabIndex = 3;
            this.stbView.Text = "statusBar1";
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 434);
            this.Controls.Add(this.stbView);
            this.Controls.Add(this.HexView);
            this.Controls.Add(this.pgbView);
            this.Controls.Add(this.btnFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Hex Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ProgressBar pgbView;
        private System.Windows.Forms.RichTextBox HexView;
        private System.Windows.Forms.StatusBar stbView;
        internal System.Windows.Forms.OpenFileDialog ofdFile;
    }
}

