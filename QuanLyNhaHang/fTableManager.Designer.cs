namespace QuanLyNhaHang
{
    partial class fTableManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.lbOrderID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.gnibtnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gnbtnAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfilesAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.gnbtnCheckout = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btSwitchTable = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.btDiscount = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.btAddFood = new System.Windows.Forms.Button();
            this.nmFoodCount = new System.Windows.Forms.NumericUpDown();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderID.ForeColor = System.Drawing.Color.Black;
            this.lbOrderID.Location = new System.Drawing.Point(76, 2);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(0, 21);
            this.lbOrderID.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(161)))), ((int)(((byte)(22)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 11;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 8);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(551, 421);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món ăn";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá tiền";
            this.columnHeader3.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 165;
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalPrice.ForeColor = System.Drawing.Color.OrangeRed;
            this.tbTotalPrice.Location = new System.Drawing.Point(297, 9);
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            this.tbTotalPrice.Size = new System.Drawing.Size(265, 27);
            this.tbTotalPrice.TabIndex = 12;
            this.tbTotalPrice.Text = "0";
            this.tbTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbOrderID);
            this.panel2.Location = new System.Drawing.Point(769, 180);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 434);
            this.panel2.TabIndex = 9;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(43)))));
            this.guna2Panel1.BorderRadius = 12;
            this.guna2Panel1.Controls.Add(this.gnibtnExit);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Controls.Add(this.gnbtnAdmin);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(155, 728);
            this.guna2Panel1.TabIndex = 13;
            // 
            // gnibtnExit
            // 
            this.gnibtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(43)))));
            this.gnibtnExit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.gnibtnExit.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.gnibtnExit.HoverState.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            this.gnibtnExit.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.gnibtnExit.Image = ((System.Drawing.Image)(resources.GetObject("gnibtnExit.Image")));
            this.gnibtnExit.ImageOffset = new System.Drawing.Point(0, 0);
            this.gnibtnExit.ImageRotate = 0F;
            this.gnibtnExit.ImageSize = new System.Drawing.Size(40, 40);
            this.gnibtnExit.Location = new System.Drawing.Point(43, 617);
            this.gnibtnExit.Name = "gnibtnExit";
            this.gnibtnExit.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.gnibtnExit.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.gnibtnExit.Size = new System.Drawing.Size(70, 65);
            this.gnibtnExit.TabIndex = 4;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::QuanLyNhaHang.Properties.Resources.snapedit_1731990810989;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(9, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(140, 106);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // gnbtnAdmin
            // 
            this.gnbtnAdmin.BorderRadius = 12;
            this.gnbtnAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnbtnAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnbtnAdmin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(161)))), ((int)(((byte)(22)))));
            this.gnbtnAdmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gnbtnAdmin.ForeColor = System.Drawing.Color.White;
            this.gnbtnAdmin.Location = new System.Drawing.Point(21, 115);
            this.gnbtnAdmin.Name = "gnbtnAdmin";
            this.gnbtnAdmin.Size = new System.Drawing.Size(105, 50);
            this.gnbtnAdmin.TabIndex = 0;
            this.gnbtnAdmin.Text = "Admin";
            this.gnbtnAdmin.Click += new System.EventHandler(this.gnbtnAdmin_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.LightGray;
            this.guna2Panel2.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(155, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1199, 29);
            this.guna2Panel2.TabIndex = 14;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.White;
            this.guna2ControlBox2.BorderColor = System.Drawing.Color.White;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox2.ForeColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1099, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(50, 30);
            this.guna2ControlBox2.TabIndex = 15;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.LightGray;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.White;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1146, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(50, 30);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.Controls.Add(this.menuStrip1);
            this.guna2Panel3.ForeColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(162, 35);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(601, 34);
            this.guna2Panel3.TabIndex = 15;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.ProfilesAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(14, 24);
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // ProfilesAccountToolStripMenuItem
            // 
            this.ProfilesAccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.ProfilesAccountToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ProfilesAccountToolStripMenuItem.Name = "ProfilesAccountToolStripMenuItem";
            this.ProfilesAccountToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.ProfilesAccountToolStripMenuItem.Text = "ProfileAccount";
            this.ProfilesAccountToolStripMenuItem.Click += new System.EventHandler(this.ProfilesAccountToolStripMenuItem_Click);
            // 
            // personToolStripMenuItem
            // 
            this.personToolStripMenuItem.Name = "personToolStripMenuItem";
            this.personToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.personToolStripMenuItem.Text = "Person";
            this.personToolStripMenuItem.Click += new System.EventHandler(this.personToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.Color.Transparent;
            this.flpTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.flpTable.Location = new System.Drawing.Point(169, 79);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(594, 558);
            this.flpTable.TabIndex = 6;
            this.flpTable.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTable_Paint);
            // 
            // gnbtnCheckout
            // 
            this.gnbtnCheckout.BorderRadius = 6;
            this.gnbtnCheckout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnCheckout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnbtnCheckout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnbtnCheckout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnbtnCheckout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(161)))), ((int)(((byte)(22)))));
            this.gnbtnCheckout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gnbtnCheckout.ForeColor = System.Drawing.Color.White;
            this.gnbtnCheckout.Location = new System.Drawing.Point(297, 42);
            this.gnbtnCheckout.Name = "gnbtnCheckout";
            this.gnbtnCheckout.Size = new System.Drawing.Size(265, 45);
            this.gnbtnCheckout.TabIndex = 13;
            this.gnbtnCheckout.Text = "Thanh Toán";
            this.gnbtnCheckout.Click += new System.EventHandler(this.gnbtnCheckout_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.gnbtnCheckout);
            this.panel3.Controls.Add(this.btSwitchTable);
            this.panel3.Controls.Add(this.nmDisCount);
            this.panel3.Controls.Add(this.tbTotalPrice);
            this.panel3.Controls.Add(this.btDiscount);
            this.panel3.Location = new System.Drawing.Point(765, 627);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 93);
            this.panel3.TabIndex = 16;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            this.cbSwitchTable.Location = new System.Drawing.Point(7, 53);
            this.cbSwitchTable.Margin = new System.Windows.Forms.Padding(4);
            this.cbSwitchTable.Name = "cbSwitchTable";
            this.cbSwitchTable.Size = new System.Drawing.Size(100, 24);
            this.cbSwitchTable.TabIndex = 16;
            // 
            // btSwitchTable
            // 
            this.btSwitchTable.BackColor = System.Drawing.Color.White;
            this.btSwitchTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btSwitchTable.Location = new System.Drawing.Point(7, 23);
            this.btSwitchTable.Margin = new System.Windows.Forms.Padding(4);
            this.btSwitchTable.Name = "btSwitchTable";
            this.btSwitchTable.Size = new System.Drawing.Size(101, 31);
            this.btSwitchTable.TabIndex = 15;
            this.btSwitchTable.Text = "Chuyển bàn";
            this.btSwitchTable.UseVisualStyleBackColor = false;
            // 
            // nmDisCount
            // 
            this.nmDisCount.Location = new System.Drawing.Point(141, 55);
            this.nmDisCount.Margin = new System.Windows.Forms.Padding(4);
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(108, 22);
            this.nmDisCount.TabIndex = 14;
            this.nmDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btDiscount
            // 
            this.btDiscount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btDiscount.Location = new System.Drawing.Point(141, 23);
            this.btDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.btDiscount.Name = "btDiscount";
            this.btDiscount.Size = new System.Drawing.Size(108, 31);
            this.btDiscount.TabIndex = 13;
            this.btDiscount.Text = "Giảm giá";
            this.btDiscount.UseVisualStyleBackColor = true;
            this.btDiscount.Click += new System.EventHandler(this.btDiscount_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(161)))), ((int)(((byte)(22)))));
            this.label4.Location = new System.Drawing.Point(769, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 19);
            this.label4.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbFood);
            this.panel1.Controls.Add(this.btAddFood);
            this.panel1.Controls.Add(this.nmFoodCount);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Location = new System.Drawing.Point(769, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 119);
            this.panel1.TabIndex = 20;
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(19, 78);
            this.cbFood.Margin = new System.Windows.Forms.Padding(4);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(201, 24);
            this.cbFood.TabIndex = 4;
            // 
            // btAddFood
            // 
            this.btAddFood.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btAddFood.Location = new System.Drawing.Point(424, 24);
            this.btAddFood.Name = "btAddFood";
            this.btAddFood.Size = new System.Drawing.Size(86, 62);
            this.btAddFood.TabIndex = 3;
            this.btAddFood.Text = "Them mon";
            this.btAddFood.UseVisualStyleBackColor = true;
            this.btAddFood.Click += new System.EventHandler(this.btAddFood_Click);
            // 
            // nmFoodCount
            // 
            this.nmFoodCount.Location = new System.Drawing.Point(243, 42);
            this.nmFoodCount.Name = "nmFoodCount";
            this.nmFoodCount.Size = new System.Drawing.Size(120, 22);
            this.nmFoodCount.TabIndex = 2;
            this.nmFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(19, 8);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(201, 24);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1354, 728);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmFoodCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button gnbtnCheckout;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2ImageButton gnibtnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAddFood;
        private System.Windows.Forms.NumericUpDown nmFoodCount;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btSwitchTable;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Button btDiscount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProfilesAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Button gnbtnAdmin;
        private System.Windows.Forms.ComboBox cbFood;
    }
}