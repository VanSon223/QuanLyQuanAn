namespace QuanLyNhaHang
{
    partial class fInvoice
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lvInvoiceItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(27, 55);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(87, 25);
            this.lblOrderID.TabIndex = 0;
            this.lblOrderID.Text = "OrderID:";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(27, 100);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(120, 25);
            this.lblTableName.TabIndex = 1;
            this.lblTableName.Text = "TableName:";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.Location = new System.Drawing.Point(27, 141);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(160, 25);
            this.lblCustomerPhone.TabIndex = 2;
            this.lblCustomerPhone.Text = "CustomerPhone:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(187, 441);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(130, 25);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "TotalAmount:";
            // 
            // lvInvoiceItems
            // 
            this.lvInvoiceItems.BackColor = System.Drawing.SystemColors.Window;
            this.lvInvoiceItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvInvoiceItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "ddđ";
            this.lvInvoiceItems.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvInvoiceItems.HideSelection = false;
            this.lvInvoiceItems.Location = new System.Drawing.Point(32, 182);
            this.lvInvoiceItems.Name = "lvInvoiceItems";
            this.lvInvoiceItems.Size = new System.Drawing.Size(420, 184);
            this.lvInvoiceItems.TabIndex = 4;
            this.lvInvoiceItems.UseCompatibleStateImageBehavior = false;
            this.lvInvoiceItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 84;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SL";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá tiền";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 73;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 91;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(407, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 5;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "HOÁ ĐƠN THANH TOÁN";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.Location = new System.Drawing.Point(12, 386);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(52, 20);
            this.lblInvoiceDate.TabIndex = 7;
            this.lblInvoiceDate.Text = "Ngày:";
            // 
            // fInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(455, 528);
            this.Controls.Add(this.lblInvoiceDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.lvInvoiceItems);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblCustomerPhone);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.lblOrderID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fInvoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.ListView lvInvoiceItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInvoiceDate;
    }
}