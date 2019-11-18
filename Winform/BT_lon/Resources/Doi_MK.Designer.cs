namespace BT_lon.Resources
{
    partial class Doi_MK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.capnhat = new System.Windows.Forms.Button();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // capnhat
            // 
            this.capnhat.Location = new System.Drawing.Point(257, 262);
            this.capnhat.Name = "capnhat";
            this.capnhat.Size = new System.Drawing.Size(151, 56);
            this.capnhat.TabIndex = 0;
            this.capnhat.Text = "Cập Nhật";
            this.capnhat.UseVisualStyleBackColor = true;
            this.capnhat.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(238, 112);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(186, 22);
            this.txtten.TabIndex = 2;
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Location = new System.Drawing.Point(238, 174);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.Size = new System.Drawing.Size(186, 22);
            this.txtmatkhau.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật Khẩu mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nhập Lại Mật khẩu";
            // 
            // Doi_MK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 406);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmatkhau);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.capnhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Doi_MK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doi_MK";
            this.Load += new System.EventHandler(this.Doi_MK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button capnhat;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}