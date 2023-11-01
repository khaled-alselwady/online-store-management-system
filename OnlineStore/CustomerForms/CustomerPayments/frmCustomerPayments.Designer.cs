namespace OnlineStore_WindowsForms_.CustomerForms.CustomerPayments
{
    partial class frmCustomerPayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvShowCustomerOrdersList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.btnViewPreviousPaymentRecords = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerOrdersList)).BeginInit();
            this.SuspendLayout();
            // 
            // comboSearch
            // 
            this.comboSearch.AutoRoundedCorners = true;
            this.comboSearch.BackColor = System.Drawing.Color.White;
            this.comboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboSearch.BorderRadius = 17;
            this.comboSearch.BorderThickness = 2;
            this.comboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboSearch.FocusedColor = System.Drawing.Color.Empty;
            this.comboSearch.FocusedState.ForeColor = System.Drawing.Color.White;
            this.comboSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboSearch.ForeColor = System.Drawing.Color.White;
            this.comboSearch.ItemHeight = 30;
            this.comboSearch.Items.AddRange(new object[] {
            "OrderID"});
            this.comboSearch.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.comboSearch.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.comboSearch.Location = new System.Drawing.Point(375, 104);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(186, 36);
            this.comboSearch.StartIndex = 0;
            this.comboSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboSearch.TabIndex = 122;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(273, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 121;
            this.label1.Text = "Search Order:";
            // 
            // dgvShowCustomerOrdersList
            // 
            this.dgvShowCustomerOrdersList.AllowUserToAddRows = false;
            this.dgvShowCustomerOrdersList.AllowUserToDeleteRows = false;
            this.dgvShowCustomerOrdersList.AllowUserToOrderColumns = true;
            this.dgvShowCustomerOrdersList.AllowUserToResizeRows = false;
            this.dgvShowCustomerOrdersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowCustomerOrdersList.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvShowCustomerOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowCustomerOrdersList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowCustomerOrdersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowCustomerOrdersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowCustomerOrdersList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowCustomerOrdersList.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowCustomerOrdersList.Location = new System.Drawing.Point(286, 206);
            this.dgvShowCustomerOrdersList.Name = "dgvShowCustomerOrdersList";
            this.dgvShowCustomerOrdersList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowCustomerOrdersList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShowCustomerOrdersList.Size = new System.Drawing.Size(1031, 551);
            this.dgvShowCustomerOrdersList.TabIndex = 120;
            this.dgvShowCustomerOrdersList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowCustomerOrdersList_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.BorderRadius = 16;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(318, 146);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(854, 35);
            this.txtSearch.TabIndex = 119;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearch.IconColor = System.Drawing.Color.DimGray;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 20;
            this.btnSearch.Location = new System.Drawing.Point(1142, 153);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(24, 19);
            this.btnSearch.TabIndex = 123;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnViewPreviousPaymentRecords
            // 
            this.btnViewPreviousPaymentRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnViewPreviousPaymentRecords.FlatAppearance.BorderSize = 0;
            this.btnViewPreviousPaymentRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnViewPreviousPaymentRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPreviousPaymentRecords.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnViewPreviousPaymentRecords.ForeColor = System.Drawing.Color.White;
            this.btnViewPreviousPaymentRecords.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnViewPreviousPaymentRecords.IconColor = System.Drawing.Color.White;
            this.btnViewPreviousPaymentRecords.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnViewPreviousPaymentRecords.IconSize = 25;
            this.btnViewPreviousPaymentRecords.Location = new System.Drawing.Point(681, 105);
            this.btnViewPreviousPaymentRecords.Name = "btnViewPreviousPaymentRecords";
            this.btnViewPreviousPaymentRecords.Size = new System.Drawing.Size(264, 35);
            this.btnViewPreviousPaymentRecords.TabIndex = 124;
            this.btnViewPreviousPaymentRecords.Text = "View previous payment records";
            this.btnViewPreviousPaymentRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewPreviousPaymentRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewPreviousPaymentRecords.UseVisualStyleBackColor = false;
            this.btnViewPreviousPaymentRecords.Click += new System.EventHandler(this.btnViewPreviousPaymentRecords_Click);
            // 
            // frmCustomerPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1380, 769);
            this.Controls.Add(this.btnViewPreviousPaymentRecords);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvShowCustomerOrdersList);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmCustomerPayments";
            this.Tag = "PAYMENTS";
            this.Text = "frmCustomerPayments";
            this.Load += new System.EventHandler(this.frmCustomerPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerOrdersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnSearch;
        private Guna.UI2.WinForms.Guna2ComboBox comboSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShowCustomerOrdersList;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FontAwesome.Sharp.IconButton btnViewPreviousPaymentRecords;
    }
}