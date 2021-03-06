﻿namespace mook_UTF8Base64
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
            this.btnUTFEn = new System.Windows.Forms.Button();
            this.btnUTFDe = new System.Windows.Forms.Button();
            this.btnBaseEn = new System.Windows.Forms.Button();
            this.btnBaseDe = new System.Windows.Forms.Button();
            this.txtEncode = new System.Windows.Forms.TextBox();
            this.txtDecode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnUTFEn
            // 
            this.btnUTFEn.Location = new System.Drawing.Point(15, 15);
            this.btnUTFEn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUTFEn.Name = "btnUTFEn";
            this.btnUTFEn.Size = new System.Drawing.Size(123, 29);
            this.btnUTFEn.TabIndex = 0;
            this.btnUTFEn.Text = "UTF8 Encode";
            this.btnUTFEn.UseVisualStyleBackColor = true;
            this.btnUTFEn.Click += new System.EventHandler(this.btnUTFEn_Click);
            // 
            // btnUTFDe
            // 
            this.btnUTFDe.Location = new System.Drawing.Point(15, 51);
            this.btnUTFDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUTFDe.Name = "btnUTFDe";
            this.btnUTFDe.Size = new System.Drawing.Size(123, 29);
            this.btnUTFDe.TabIndex = 0;
            this.btnUTFDe.Text = "UTF8 Decode";
            this.btnUTFDe.UseVisualStyleBackColor = true;
            this.btnUTFDe.Click += new System.EventHandler(this.btnUTFDe_Click);
            // 
            // btnBaseEn
            // 
            this.btnBaseEn.Location = new System.Drawing.Point(15, 149);
            this.btnBaseEn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBaseEn.Name = "btnBaseEn";
            this.btnBaseEn.Size = new System.Drawing.Size(123, 29);
            this.btnBaseEn.TabIndex = 0;
            this.btnBaseEn.Text = "Base64 Encode";
            this.btnBaseEn.UseVisualStyleBackColor = true;
            this.btnBaseEn.Click += new System.EventHandler(this.btnBaseEn_Click);
            // 
            // btnBaseDe
            // 
            this.btnBaseDe.Location = new System.Drawing.Point(15, 185);
            this.btnBaseDe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBaseDe.Name = "btnBaseDe";
            this.btnBaseDe.Size = new System.Drawing.Size(123, 29);
            this.btnBaseDe.TabIndex = 0;
            this.btnBaseDe.Text = "Base64 Decode";
            this.btnBaseDe.UseVisualStyleBackColor = true;
            this.btnBaseDe.Click += new System.EventHandler(this.btnBaseDe_Click);
            // 
            // txtEncode
            // 
            this.txtEncode.Location = new System.Drawing.Point(145, 15);
            this.txtEncode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEncode.Multiline = true;
            this.txtEncode.Name = "txtEncode";
            this.txtEncode.Size = new System.Drawing.Size(404, 123);
            this.txtEncode.TabIndex = 1;
            // 
            // txtDecode
            // 
            this.txtDecode.Location = new System.Drawing.Point(145, 149);
            this.txtDecode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDecode.Multiline = true;
            this.txtDecode.Name = "txtDecode";
            this.txtDecode.Size = new System.Drawing.Size(404, 123);
            this.txtDecode.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 282);
            this.Controls.Add(this.txtDecode);
            this.Controls.Add(this.txtEncode);
            this.Controls.Add(this.btnBaseDe);
            this.Controls.Add(this.btnBaseEn);
            this.Controls.Add(this.btnUTFDe);
            this.Controls.Add(this.btnUTFEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "UTF / Base64 EnDecoder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUTFEn;
        private System.Windows.Forms.Button btnUTFDe;
        private System.Windows.Forms.Button btnBaseEn;
        private System.Windows.Forms.Button btnBaseDe;
        private System.Windows.Forms.TextBox txtEncode;
        private System.Windows.Forms.TextBox txtDecode;
    }
}

