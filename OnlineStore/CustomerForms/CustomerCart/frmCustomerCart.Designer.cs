namespace OnlineStore_WindowsForms_.CustomerForms.CustomerCart
{
    partial class frmCustomerCart
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
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvShowOrderItems = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveAll = new FontAwesome.Sharp.IconButton();
            this.btnSaveOrder = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.Location = new System.Drawing.Point(471, 494);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(109, 29);
            this.txtGrandTotal.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(355, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 115;
            this.label6.Text = "Grand Total:";
            // 
            // dgvShowOrderItems
            // 
            this.dgvShowOrderItems.AllowUserToAddRows = false;
            this.dgvShowOrderItems.AllowUserToDeleteRows = false;
            this.dgvShowOrderItems.AllowUserToOrderColumns = true;
            this.dgvShowOrderItems.AllowUserToResizeRows = false;
            this.dgvShowOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowOrderItems.BackgroundColor = System.Drawing.Color.LightGray;
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
            this.dgvShowOrderItems.Location = new System.Drawing.Point(274, 114);
            this.dgvShowOrderItems.Name = "dgvShowOrderItems";
            this.dgvShowOrderItems.ReadOnly = true;
            this.dgvShowOrderItems.Size = new System.Drawing.Size(494, 355);
            this.dgvShowOrderItems.TabIndex = 114;
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
            // btnRemoveAll
            // 
            this.btnRemoveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnRemoveAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRemoveAll.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnRemoveAll.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnRemoveAll.IconColor = System.Drawing.Color.White;
            this.btnRemoveAll.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnRemoveAll.IconSize = 25;
            this.btnRemoveAll.Location = new System.Drawing.Point(574, 616);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRemoveAll.Size = new System.Drawing.Size(165, 47);
            this.btnRemoveAll.TabIndex = 117;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnSaveOrder
            // 
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
            this.btnSaveOrder.Location = new System.Drawing.Point(303, 616);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSaveOrder.Size = new System.Drawing.Size(165, 47);
            this.btnSaveOrder.TabIndex = 119;
            this.btnSaveOrder.Text = "Save Order";
            this.btnSaveOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveOrder.UseVisualStyleBackColor = false;
            this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
            // 
            // frmCustomerCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1671, 749);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvShowOrderItems);
            this.Name = "frmCustomerCart";
            this.Tag = "MY CART";
            this.Text = "frmCustomerCart";
            this.Load += new System.EventHandler(this.frmCustomerCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvShowOrderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private FontAwesome.Sharp.IconButton btnRemoveAll;
        private FontAwesome.Sharp.IconButton btnSaveOrder;
    }
}