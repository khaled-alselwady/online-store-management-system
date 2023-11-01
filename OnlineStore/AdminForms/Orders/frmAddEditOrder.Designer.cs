namespace OnlineStore_WindowsForms_.AdminForms.Orders
{
    partial class frmAddEditOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShowOrderItems = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericCustomerID = new System.Windows.Forms.NumericUpDown();
            this.numericProductID = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvShowProductInfo = new System.Windows.Forms.DataGridView();
            this.dgvShowCustomerInfo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboPhones = new System.Windows.Forms.ComboBox();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.linkChangeCustomer = new System.Windows.Forms.LinkLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblMode = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearchCustomer = new FontAwesome.Sharp.IconButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnSaveOrder = new FontAwesome.Sharp.IconButton();
            this.btnPrint = new FontAwesome.Sharp.IconButton();
            this.btnRemove = new FontAwesome.Sharp.IconButton();
            this.btnAddToCart = new FontAwesome.Sharp.IconButton();
            this.btnEdit = new FontAwesome.Sharp.IconButton();
            this.btnSaveTheEdits = new FontAwesome.Sharp.IconButton();
            this.btnSearchProduct = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProductInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            this.panel4.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShowOrderItems
            // 
            this.dgvShowOrderItems.AllowUserToAddRows = false;
            this.dgvShowOrderItems.AllowUserToDeleteRows = false;
            this.dgvShowOrderItems.AllowUserToOrderColumns = true;
            this.dgvShowOrderItems.AllowUserToResizeRows = false;
            this.dgvShowOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowOrderItems.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvShowOrderItems.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.Quantity,
            this.Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowOrderItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowOrderItems.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowOrderItems.Location = new System.Drawing.Point(1173, 84);
            this.dgvShowOrderItems.Name = "dgvShowOrderItems";
            this.dgvShowOrderItems.ReadOnly = true;
            this.dgvShowOrderItems.Size = new System.Drawing.Size(395, 355);
            this.dgvShowOrderItems.TabIndex = 95;
            this.dgvShowOrderItems.Click += new System.EventHandler(this.dgvShowOrderItems_Click);
            // 
            // ID
            // 
            this.ID.FillWeight = 25F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 49;
            // 
            // ProductName
            // 
            this.ProductName.FillWeight = 80F;
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 121;
            // 
            // Quantity
            // 
            this.Quantity.FillWeight = 30F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 88;
            // 
            // Price
            // 
            this.Price.FillWeight = 45F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 96;
            this.label1.Text = "Customer ID:";
            // 
            // numericCustomerID
            // 
            this.numericCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCustomerID.Location = new System.Drawing.Point(141, 51);
            this.numericCustomerID.Name = "numericCustomerID";
            this.numericCustomerID.Size = new System.Drawing.Size(92, 29);
            this.numericCustomerID.TabIndex = 97;
            this.numericCustomerID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericCustomerID_MouseUp);
            // 
            // numericProductID
            // 
            this.numericProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericProductID.Location = new System.Drawing.Point(134, 59);
            this.numericProductID.Name = "numericProductID";
            this.numericProductID.Size = new System.Drawing.Size(92, 29);
            this.numericProductID.TabIndex = 99;
            this.numericProductID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericProductID_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 98;
            this.label2.Text = "Product ID:";
            // 
            // dgvShowProductInfo
            // 
            this.dgvShowProductInfo.AllowUserToAddRows = false;
            this.dgvShowProductInfo.AllowUserToDeleteRows = false;
            this.dgvShowProductInfo.AllowUserToOrderColumns = true;
            this.dgvShowProductInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowProductInfo.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvShowProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowProductInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowProductInfo.Location = new System.Drawing.Point(7, 100);
            this.dgvShowProductInfo.Name = "dgvShowProductInfo";
            this.dgvShowProductInfo.ReadOnly = true;
            this.dgvShowProductInfo.Size = new System.Drawing.Size(726, 66);
            this.dgvShowProductInfo.TabIndex = 100;
            // 
            // dgvShowCustomerInfo
            // 
            this.dgvShowCustomerInfo.AllowUserToAddRows = false;
            this.dgvShowCustomerInfo.AllowUserToDeleteRows = false;
            this.dgvShowCustomerInfo.AllowUserToOrderColumns = true;
            this.dgvShowCustomerInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowCustomerInfo.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvShowCustomerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowCustomerInfo.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowCustomerInfo.Location = new System.Drawing.Point(1, 102);
            this.dgvShowCustomerInfo.Name = "dgvShowCustomerInfo";
            this.dgvShowCustomerInfo.ReadOnly = true;
            this.dgvShowCustomerInfo.Size = new System.Drawing.Size(670, 66);
            this.dgvShowCustomerInfo.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(668, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.TabIndex = 102;
            this.label3.Text = "Numbers Phone:";
            // 
            // comboPhones
            // 
            this.comboPhones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPhones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPhones.FormattingEnabled = true;
            this.comboPhones.Location = new System.Drawing.Point(729, 113);
            this.comboPhones.Name = "comboPhones";
            this.comboPhones.Size = new System.Drawing.Size(143, 32);
            this.comboPhones.TabIndex = 103;
            // 
            // numericQuantity
            // 
            this.numericQuantity.Enabled = false;
            this.numericQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericQuantity.Location = new System.Drawing.Point(111, 206);
            this.numericQuantity.Name = "numericQuantity";
            this.numericQuantity.Size = new System.Drawing.Size(74, 29);
            this.numericQuantity.TabIndex = 107;
            this.numericQuantity.ValueChanged += new System.EventHandler(this.numericQuantity_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 106;
            this.label4.Text = "Quantity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(244, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 108;
            this.label5.Text = "Total Price:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.Location = new System.Drawing.Point(354, 208);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 29);
            this.txtTotalPrice.TabIndex = 109;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(1370, 464);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(109, 29);
            this.txtGrandTotal.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1254, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 112;
            this.label6.Text = "Grand Total:";
            // 
            // linkChangeCustomer
            // 
            this.linkChangeCustomer.AutoSize = true;
            this.linkChangeCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkChangeCustomer.Location = new System.Drawing.Point(302, 57);
            this.linkChangeCustomer.Name = "linkChangeCustomer";
            this.linkChangeCustomer.Size = new System.Drawing.Size(137, 18);
            this.linkChangeCustomer.TabIndex = 117;
            this.linkChangeCustomer.TabStop = true;
            this.linkChangeCustomer.Text = "Change Customer?";
            this.linkChangeCustomer.Visible = false;
            this.linkChangeCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChangeCustomer_LinkClicked);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1580, 27);
            this.panel4.TabIndex = 167;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 25F);
            this.lblMode.ForeColor = System.Drawing.Color.Black;
            this.lblMode.Location = new System.Drawing.Point(631, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(99, 41);
            this.lblMode.TabIndex = 168;
            this.lblMode.Text = "Mode";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Controls.Add(this.label7);
            this.guna2GroupBox1.Controls.Add(this.linkChangeCustomer);
            this.guna2GroupBox1.Controls.Add(this.btnSearchCustomer);
            this.guna2GroupBox1.Controls.Add(this.comboPhones);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.dgvShowCustomerInfo);
            this.guna2GroupBox1.Controls.Add(this.numericCustomerID);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2GroupBox1.Location = new System.Drawing.Point(23, 85);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(889, 219);
            this.guna2GroupBox1.TabIndex = 169;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 30);
            this.label7.TabIndex = 118;
            this.label7.Text = "Customer Info:";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Controls.Add(this.label8);
            this.guna2GroupBox2.Controls.Add(this.txtTotalPrice);
            this.guna2GroupBox2.Controls.Add(this.label5);
            this.guna2GroupBox2.Controls.Add(this.numericQuantity);
            this.guna2GroupBox2.Controls.Add(this.label4);
            this.guna2GroupBox2.Controls.Add(this.dgvShowProductInfo);
            this.guna2GroupBox2.Controls.Add(this.numericProductID);
            this.guna2GroupBox2.Controls.Add(this.label2);
            this.guna2GroupBox2.Controls.Add(this.btnSearchProduct);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.guna2GroupBox2.FillColor = System.Drawing.Color.DarkGray;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.guna2GroupBox2.Location = new System.Drawing.Point(23, 332);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(891, 258);
            this.guna2GroupBox2.TabIndex = 170;
            this.guna2GroupBox2.Text = "guna2GroupBox2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 30);
            this.label8.TabIndex = 119;
            this.label8.Text = "Product Info:";
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearchCustomer.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchCustomer.IconSize = 25;
            this.btnSearchCustomer.Location = new System.Drawing.Point(239, 45);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(39, 39);
            this.btnSearchCustomer.TabIndex = 105;
            this.btnSearchCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.Black;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 24;
            this.btnExit.Location = new System.Drawing.Point(1548, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 27);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancel.IconColor = System.Drawing.Color.White;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCancel.IconSize = 20;
            this.btnCancel.Location = new System.Drawing.Point(390, 736);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(188, 47);
            this.btnCancel.TabIndex = 119;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnSaveOrder.FlatAppearance.BorderSize = 0;
            this.btnSaveOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrder.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnSaveOrder.ForeColor = System.Drawing.Color.White;
            this.btnSaveOrder.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnSaveOrder.IconColor = System.Drawing.Color.White;
            this.btnSaveOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveOrder.IconSize = 20;
            this.btnSaveOrder.Location = new System.Drawing.Point(1241, 736);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSaveOrder.Size = new System.Drawing.Size(165, 47);
            this.btnSaveOrder.TabIndex = 118;
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveOrder.UseVisualStyleBackColor = false;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumOrchid;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnPrint.IconColor = System.Drawing.Color.White;
            this.btnPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrint.IconSize = 25;
            this.btnPrint.Location = new System.Drawing.Point(1412, 736);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPrint.Size = new System.Drawing.Size(167, 47);
            this.btnPrint.TabIndex = 115;
            this.btnPrint.Text = "Print Order";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRemove.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnRemove.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnRemove.IconColor = System.Drawing.Color.White;
            this.btnRemove.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnRemove.IconSize = 25;
            this.btnRemove.Location = new System.Drawing.Point(3, 736);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRemove.Size = new System.Drawing.Size(187, 47);
            this.btnRemove.TabIndex = 111;
            this.btnRemove.Text = "Remove Item";
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddToCart.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.btnAddToCart.IconColor = System.Drawing.Color.White;
            this.btnAddToCart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddToCart.IconSize = 25;
            this.btnAddToCart.Location = new System.Drawing.Point(353, 613);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(180, 72);
            this.btnAddToCart.TabIndex = 110;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCard_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(149)))), ((int)(((byte)(243)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEdit.IconColor = System.Drawing.Color.White;
            this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEdit.IconSize = 25;
            this.btnEdit.Location = new System.Drawing.Point(198, 736);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEdit.Size = new System.Drawing.Size(184, 47);
            this.btnEdit.TabIndex = 114;
            this.btnEdit.Text = " Edit Item";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSaveTheEdits
            // 
            this.btnSaveTheEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTheEdits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnSaveTheEdits.FlatAppearance.BorderSize = 0;
            this.btnSaveTheEdits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveTheEdits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTheEdits.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnSaveTheEdits.ForeColor = System.Drawing.Color.White;
            this.btnSaveTheEdits.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnSaveTheEdits.IconColor = System.Drawing.Color.White;
            this.btnSaveTheEdits.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveTheEdits.IconSize = 20;
            this.btnSaveTheEdits.Location = new System.Drawing.Point(198, 736);
            this.btnSaveTheEdits.Name = "btnSaveTheEdits";
            this.btnSaveTheEdits.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSaveTheEdits.Size = new System.Drawing.Size(184, 47);
            this.btnSaveTheEdits.TabIndex = 116;
            this.btnSaveTheEdits.Text = "Save The Edits";
            this.btnSaveTheEdits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveTheEdits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveTheEdits.UseVisualStyleBackColor = false;
            this.btnSaveTheEdits.Click += new System.EventHandler(this.btnSaveTheEdits_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchProduct.FlatAppearance.BorderSize = 0;
            this.btnSearchProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnSearchProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnSearchProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProduct.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearchProduct.ForeColor = System.Drawing.Color.White;
            this.btnSearchProduct.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearchProduct.IconColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchProduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchProduct.IconSize = 25;
            this.btnSearchProduct.Location = new System.Drawing.Point(237, 54);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(39, 39);
            this.btnSearchProduct.TabIndex = 104;
            this.btnSearchProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // frmAddEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1580, 786);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dgvShowOrderItems);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSaveTheEdits);
            this.Controls.Add(this.guna2GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "MANAGE ORDERS";
            this.Text = "frmOrders";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProductInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            this.panel4.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowOrderItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericCustomerID;
        private System.Windows.Forms.NumericUpDown numericProductID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvShowProductInfo;
        private System.Windows.Forms.DataGridView dgvShowCustomerInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboPhones;
        private FontAwesome.Sharp.IconButton btnSearchProduct;
        private FontAwesome.Sharp.IconButton btnSearchCustomer;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private FontAwesome.Sharp.IconButton btnAddToCart;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnEdit;
        private FontAwesome.Sharp.IconButton btnPrint;
        private FontAwesome.Sharp.IconButton btnSaveTheEdits;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.LinkLabel linkChangeCustomer;
        private FontAwesome.Sharp.IconButton btnSaveOrder;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private FontAwesome.Sharp.IconButton btnRemove;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label lblMode;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Label label8;
    }
}