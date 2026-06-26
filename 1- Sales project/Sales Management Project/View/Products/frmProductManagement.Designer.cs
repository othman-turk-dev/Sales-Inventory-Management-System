namespace Sales_Management_Project
{
    partial class frmProductManagement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVProducts = new System.Windows.Forms.DataGridView();
            this.CMStripProducts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delectProdectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printhProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtFilterValue = new System.Windows.Forms.TextBox();
            this.CbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddProduct = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnPrintAllProduct = new System.Windows.Forms.Button();
            this.BtnSaveAsExcelFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducts)).BeginInit();
            this.CMStripProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVProducts);
            this.groupBox1.Location = new System.Drawing.Point(5, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DGVProducts
            // 
            this.DGVProducts.AllowUserToAddRows = false;
            this.DGVProducts.AllowUserToDeleteRows = false;
            this.DGVProducts.AllowUserToOrderColumns = true;
            this.DGVProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProducts.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DGVProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProducts.ContextMenuStrip = this.CMStripProducts;
            this.DGVProducts.Location = new System.Drawing.Point(7, 13);
            this.DGVProducts.Name = "DGVProducts";
            this.DGVProducts.ReadOnly = true;
            this.DGVProducts.RowHeadersWidth = 51;
            this.DGVProducts.RowTemplate.Height = 26;
            this.DGVProducts.Size = new System.Drawing.Size(1089, 432);
            this.DGVProducts.TabIndex = 0;
            this.DGVProducts.DoubleClick += new System.EventHandler(this.DGVProducts_DoubleClick);
            // 
            // CMStripProducts
            // 
            this.CMStripProducts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMStripProducts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateProToolStripMenuItem,
            this.delectProdectToolStripMenuItem,
            this.printhProductToolStripMenuItem});
            this.CMStripProducts.Name = "CMStripProducts";
            this.CMStripProducts.Size = new System.Drawing.Size(183, 76);
            // 
            // updateProToolStripMenuItem
            // 
            this.updateProToolStripMenuItem.Name = "updateProToolStripMenuItem";
            this.updateProToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.updateProToolStripMenuItem.Text = "Update Product";
            this.updateProToolStripMenuItem.Click += new System.EventHandler(this.updateProToolStripMenuItem_Click);
            // 
            // delectProdectToolStripMenuItem
            // 
            this.delectProdectToolStripMenuItem.Name = "delectProdectToolStripMenuItem";
            this.delectProdectToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.delectProdectToolStripMenuItem.Text = "Delect Product";
            this.delectProdectToolStripMenuItem.Click += new System.EventHandler(this.delectProdectToolStripMenuItem_Click);
            // 
            // printhProductToolStripMenuItem
            // 
            this.printhProductToolStripMenuItem.Name = "printhProductToolStripMenuItem";
            this.printhProductToolStripMenuItem.Size = new System.Drawing.Size(182, 24);
            this.printhProductToolStripMenuItem.Text = "Print Product";
            this.printhProductToolStripMenuItem.Click += new System.EventHandler(this.printhProductToolStripMenuItem_Click);
            // 
            // TxtFilterValue
            // 
            this.TxtFilterValue.BackColor = System.Drawing.SystemColors.Control;
            this.TxtFilterValue.Location = new System.Drawing.Point(328, 95);
            this.TxtFilterValue.MaxLength = 50;
            this.TxtFilterValue.Name = "TxtFilterValue";
            this.TxtFilterValue.Size = new System.Drawing.Size(213, 24);
            this.TxtFilterValue.TabIndex = 117;
            this.TxtFilterValue.TextChanged += new System.EventHandler(this.TxtFilterValue_TextChanged);
            this.TxtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilterValue_KeyPress);
            // 
            // CbFilterBy
            // 
            this.CbFilterBy.BackColor = System.Drawing.SystemColors.Control;
            this.CbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFilterBy.FormattingEnabled = true;
            this.CbFilterBy.Items.AddRange(new object[] {
            "None",
            "Product ID",
            "Product Name",
            "Product Category"});
            this.CbFilterBy.Location = new System.Drawing.Point(103, 95);
            this.CbFilterBy.Name = "CbFilterBy";
            this.CbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.CbFilterBy.TabIndex = 116;
            this.CbFilterBy.SelectedIndexChanged += new System.EventHandler(this.CbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 115;
            this.label1.Text = "Filter By:";
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddProduct.BackgroundImage = global::Sales_Management_Project.Properties.Resources.add_product;
            this.BtnAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddProduct.Location = new System.Drawing.Point(1026, 72);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(75, 68);
            this.BtnAddProduct.TabIndex = 118;
            this.BtnAddProduct.UseVisualStyleBackColor = false;
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Sales_Management_Project.Properties.Resources.close;
            this.pictureBox3.Location = new System.Drawing.Point(21, 600);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 123;
            this.pictureBox3.TabStop = false;
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.Location = new System.Drawing.Point(14, 592);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(129, 51);
            this.BtnClose.TabIndex = 121;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnPrintAllProduct
            // 
            this.BtnPrintAllProduct.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrintAllProduct.Location = new System.Drawing.Point(884, 593);
            this.BtnPrintAllProduct.Name = "BtnPrintAllProduct";
            this.BtnPrintAllProduct.Size = new System.Drawing.Size(217, 51);
            this.BtnPrintAllProduct.TabIndex = 120;
            this.BtnPrintAllProduct.Text = "Print All Product";
            this.BtnPrintAllProduct.UseVisualStyleBackColor = true;
            this.BtnPrintAllProduct.Click += new System.EventHandler(this.BtnPrintAllProduct_Click);
            // 
            // BtnSaveAsExcelFile
            // 
            this.BtnSaveAsExcelFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveAsExcelFile.Location = new System.Drawing.Point(629, 592);
            this.BtnSaveAsExcelFile.Name = "BtnSaveAsExcelFile";
            this.BtnSaveAsExcelFile.Size = new System.Drawing.Size(217, 51);
            this.BtnSaveAsExcelFile.TabIndex = 124;
            this.BtnSaveAsExcelFile.Text = "Save As Excel File";
            this.BtnSaveAsExcelFile.UseVisualStyleBackColor = true;
            this.BtnSaveAsExcelFile.Click += new System.EventHandler(this.BtnSaveAsExcelFile_Click);
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1130, 655);
            this.Controls.Add(this.BtnSaveAsExcelFile);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnPrintAllProduct);
            this.Controls.Add(this.BtnAddProduct);
            this.Controls.Add(this.TxtFilterValue);
            this.Controls.Add(this.CbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProductManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.frmProductManagement_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProducts)).EndInit();
            this.CMStripProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVProducts;
        private System.Windows.Forms.TextBox TxtFilterValue;
        private System.Windows.Forms.ComboBox CbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddProduct;
        private System.Windows.Forms.ContextMenuStrip CMStripProducts;
        private System.Windows.Forms.ToolStripMenuItem updateProToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delectProdectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printhProductToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnPrintAllProduct;
        private System.Windows.Forms.Button BtnSaveAsExcelFile;
    }
}