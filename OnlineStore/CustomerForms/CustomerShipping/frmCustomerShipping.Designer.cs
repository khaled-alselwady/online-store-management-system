namespace OnlineStore_WindowsForms_.CustomerForms.CustomerShipping
{
    partial class frmCustomerShipping
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
            this.comboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvShowCustomerShippingList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.comboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerShippingList)).BeginInit();
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
            "ShippingID",
            "OrderID",
            "TrackingNumber"});
            this.comboSearch.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.comboSearch.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSearch.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.comboSearch.Location = new System.Drawing.Point(375, 104);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(186, 36);
            this.comboSearch.StartIndex = 0;
            this.comboSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboSearch.TabIndex = 112;
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.comboSearch_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(263, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 18);
            this.label1.TabIndex = 111;
            this.label1.Text = "Search Shipping:";
            // 
            // dgvShowCustomerShippingList
            // 
            this.dgvShowCustomerShippingList.AllowUserToAddRows = false;
            this.dgvShowCustomerShippingList.AllowUserToDeleteRows = false;
            this.dgvShowCustomerShippingList.AllowUserToOrderColumns = true;
            this.dgvShowCustomerShippingList.AllowUserToResizeRows = false;
            this.dgvShowCustomerShippingList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvShowCustomerShippingList.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvShowCustomerShippingList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowCustomerShippingList.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowCustomerShippingList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowCustomerShippingList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowCustomerShippingList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowCustomerShippingList.GridColor = System.Drawing.Color.DarkGray;
            this.dgvShowCustomerShippingList.Location = new System.Drawing.Point(286, 206);
            this.dgvShowCustomerShippingList.Name = "dgvShowCustomerShippingList";
            this.dgvShowCustomerShippingList.ReadOnly = true;
            this.dgvShowCustomerShippingList.Size = new System.Drawing.Size(1031, 551);
            this.dgvShowCustomerShippingList.TabIndex = 110;
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
            this.txtSearch.TabIndex = 109;
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
            this.btnSearch.TabIndex = 113;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // comboStatus
            // 
            this.comboStatus.AutoRoundedCorners = true;
            this.comboStatus.BackColor = System.Drawing.Color.White;
            this.comboStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboStatus.BorderRadius = 17;
            this.comboStatus.BorderThickness = 2;
            this.comboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(242)))));
            this.comboStatus.FocusedColor = System.Drawing.Color.Empty;
            this.comboStatus.FocusedState.ForeColor = System.Drawing.Color.White;
            this.comboStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.comboStatus.ForeColor = System.Drawing.Color.White;
            this.comboStatus.ItemHeight = 30;
            this.comboStatus.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.comboStatus.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.comboStatus.Location = new System.Drawing.Point(657, 104);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(163, 36);
            this.comboStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.comboStatus.TabIndex = 118;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(600, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 117;
            this.label3.Text = "Status:";
            // 
            // frmCustomerShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1380, 769);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvShowCustomerShippingList);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmCustomerShipping";
            this.Tag = "SHIPPING";
            this.Text = "frmCustomerShipping";
            this.Load += new System.EventHandler(this.frmCustomerShipping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowCustomerShippingList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnSearch;
        private Guna.UI2.WinForms.Guna2ComboBox comboSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShowCustomerShippingList;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox comboStatus;
        private System.Windows.Forms.Label label3;
    }
}