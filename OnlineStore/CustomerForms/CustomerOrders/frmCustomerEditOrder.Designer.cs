namespace OnlineStore_WindowsForms_.CustomerForms.CustomerOrders
{
    partial class frmCustomerEditOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnSearchProduct = new FontAwesome.Sharp.IconButton();
            this.btnCancelEdits = new FontAwesome.Sharp.IconButton();
            this.btnAddToCart = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvShowOrderItems = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveTheEdits = new FontAwesome.Sharp.IconButton();
            this.numericProductID = new System.Windows.Forms.NumericUpDown();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvShowProductInfo = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnSaveOrder = new FontAwesome.Sharp.IconButton();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductID)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProductInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(1307, 466);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(109, 29);
            this.txtGrandTotal.TabIndex = 175;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1580, 27);
            this.panel4.TabIndex = 181;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
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
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Tahoma", 25F);
            this.lblMode.ForeColor = System.Drawing.Color.Black;
            this.lblMode.Location = new System.Drawing.Point(631, 32);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(99, 41);
            this.lblMode.TabIndex = 182;
            this.lblMode.Text = "Mode";
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
            // btnCancelEdits
            // 
            this.btnCancelEdits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnCancelEdits.FlatAppearance.BorderSize = 0;
            this.btnCancelEdits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelEdits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdits.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCancelEdits.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdits.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelEdits.IconColor = System.Drawing.Color.White;
            this.btnCancelEdits.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCancelEdits.IconSize = 20;
            this.btnCancelEdits.Location = new System.Drawing.Point(438, 394);
            this.btnCancelEdits.Name = "btnCancelEdits";
            this.btnCancelEdits.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancelEdits.Size = new System.Drawing.Size(188, 47);
            this.btnCancelEdits.TabIndex = 180;
            this.btnCancelEdits.Text = "Cancel";
            this.btnCancelEdits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelEdits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelEdits.UseVisualStyleBackColor = false;
            this.btnCancelEdits.Visible = false;
            this.btnCancelEdits.Click += new System.EventHandler(this.btnCancelEdits_Click);
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
            this.btnAddToCart.Location = new System.Drawing.Point(331, 369);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(180, 72);
            this.btnAddToCart.TabIndex = 172;
            this.btnAddToCart.Text = "Add To Cart";
            this.btnAddToCart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddToCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1191, 469);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 174;
            this.label6.Text = "Grand Total:";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowOrderItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShowOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.Quantity,
            this.Price});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowOrderItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShowOrderItems.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowOrderItems.Location = new System.Drawing.Point(1060, 86);
            this.dgvShowOrderItems.Name = "dgvShowOrderItems";
            this.dgvShowOrderItems.ReadOnly = true;
            this.dgvShowOrderItems.Size = new System.Drawing.Size(508, 355);
            this.dgvShowOrderItems.TabIndex = 171;
            this.dgvShowOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowOrderItems_CellContentClick);
            this.dgvShowOrderItems.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowOrderItems_CellMouseEnter);
            this.dgvShowOrderItems.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvShowOrderItems_CellToolTipTextNeeded);
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
            // btnSaveTheEdits
            // 
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
            this.btnSaveTheEdits.Location = new System.Drawing.Point(246, 394);
            this.btnSaveTheEdits.Name = "btnSaveTheEdits";
            this.btnSaveTheEdits.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSaveTheEdits.Size = new System.Drawing.Size(184, 47);
            this.btnSaveTheEdits.TabIndex = 178;
            this.btnSaveTheEdits.Text = "Save The Edits";
            this.btnSaveTheEdits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveTheEdits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveTheEdits.UseVisualStyleBackColor = false;
            this.btnSaveTheEdits.Visible = false;
            this.btnSaveTheEdits.Click += new System.EventHandler(this.btnSaveTheEdits_Click);
            // 
            // numericProductID
            // 
            this.numericProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericProductID.Location = new System.Drawing.Point(134, 59);
            this.numericProductID.Name = "numericProductID";
            this.numericProductID.Size = new System.Drawing.Size(92, 29);
            this.numericProductID.TabIndex = 99;
            this.numericProductID.ValueChanged += new System.EventHandler(this.numericProductID_ValueChanged);
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
            this.guna2GroupBox2.Location = new System.Drawing.Point(23, 86);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(891, 258);
            this.guna2GroupBox2.TabIndex = 184;
            this.guna2GroupBox2.Text = "guna2GroupBox2";
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
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnClose.IconSize = 28;
            this.btnClose.Location = new System.Drawing.Point(876, 605);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.btnClose.Size = new System.Drawing.Size(208, 53);
            this.btnClose.TabIndex = 186;
            this.btnClose.Text = "     Cancel";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnSaveOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSaveOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveOrder.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveOrder.ForeColor = System.Drawing.Color.White;
            this.btnSaveOrder.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.btnSaveOrder.IconColor = System.Drawing.Color.White;
            this.btnSaveOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveOrder.IconSize = 28;
            this.btnSaveOrder.Location = new System.Drawing.Point(532, 605);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.btnSaveOrder.Size = new System.Drawing.Size(208, 53);
            this.btnSaveOrder.TabIndex = 185;
            this.btnSaveOrder.Text = "  Save Order";
            this.btnSaveOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveOrder.UseVisualStyleBackColor = false;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // frmCustomerEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1580, 671);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnCancelEdits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvShowOrderItems);
            this.Controls.Add(this.btnSaveTheEdits);
            this.Controls.Add(this.guna2GroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCustomerEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCustomerEditOrder";
            this.Load += new System.EventHandler(this.frmCustomerEditOrder_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericProductID)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProductInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Label lblMode;
        private FontAwesome.Sharp.IconButton btnSearchProduct;
        private FontAwesome.Sharp.IconButton btnCancelEdits;
        private FontAwesome.Sharp.IconButton btnAddToCart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvShowOrderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private FontAwesome.Sharp.IconButton btnSaveTheEdits;
        private System.Windows.Forms.NumericUpDown numericProductID;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvShowProductInfo;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnSaveOrder;
    }
}