namespace QuanLyNhaHang
{
    partial class fLogin1
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
            System.Windows.Forms.Label label2;
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbpass = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label2.Location = new System.Drawing.Point(4, 41);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 24);
            label2.TabIndex = 0;
            label2.Text = "Mật khẩu:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 351);
            this.panel1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(488, 297);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(130, 45);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(331, 297);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(130, 45);
            this.btnlogin.TabIndex = 3;
            this.btnlogin.Text = "Đăng nhập";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbpass);
            this.panel3.Controls.Add(label2);
            this.panel3.Location = new System.Drawing.Point(11, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 105);
            this.panel3.TabIndex = 1;
            // 
            // txbpass
            // 
            this.txbpass.Location = new System.Drawing.Point(170, 42);
            this.txbpass.Name = "txbpass";
            this.txbpass.Size = new System.Drawing.Size(300, 22);
            this.txbpass.TabIndex = 2;
            this.txbpass.UseSystemPasswordChar = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbTen);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(11, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 105);
            this.panel2.TabIndex = 0;
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(170, 42);
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(300, 22);
            this.txbTen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnlogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyNhaHang.Properties.Resources.download;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(656, 426);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Load += new System.EventHandler(this.fLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbpass;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnExit;
    }
}

