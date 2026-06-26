namespace Sales_Management_Project
{
    partial class frmCategoryManagement
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSaveCurrent = new System.Windows.Forms.Button();
            this.BtnSaveAll = new System.Windows.Forms.Button();
            this.BtnPrintCurrentCategory = new System.Windows.Forms.Button();
            this.BtnPrintAllCategories = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LbCount = new System.Windows.Forms.Label();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtLast = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnFirst = new System.Windows.Forms.Button();
            this.DGVCategories = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCategoryID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.BtnClose);
            this.groupBox1.Controls.Add(this.LbCount);
            this.groupBox1.Controls.Add(this.BtnPrevious);
            this.groupBox1.Controls.Add(this.BtLast);
            this.groupBox1.Controls.Add(this.BtnNext);
            this.groupBox1.Controls.Add(this.BtnFirst);
            this.groupBox1.Controls.Add(this.DGVCategories);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtCategoryID);
            this.groupBox1.Location = new System.Drawing.Point(44, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(891, 581);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Category Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSaveCurrent);
            this.groupBox2.Controls.Add(this.BtnSaveAll);
            this.groupBox2.Controls.Add(this.BtnPrintCurrentCategory);
            this.groupBox2.Controls.Add(this.BtnPrintAllCategories);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnUpdate);
            this.groupBox2.Controls.Add(this.BtnAdd);
            this.groupBox2.Controls.Add(this.BtnNew);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 163);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available operations:";
            // 
            // BtnSaveCurrent
            // 
            this.BtnSaveCurrent.Location = new System.Drawing.Point(450, 106);
            this.BtnSaveCurrent.Name = "BtnSaveCurrent";
            this.BtnSaveCurrent.Size = new System.Drawing.Size(160, 47);
            this.BtnSaveCurrent.TabIndex = 8;
            this.BtnSaveCurrent.Text = "Save Current as PDF";
            this.BtnSaveCurrent.UseVisualStyleBackColor = true;
            this.BtnSaveCurrent.Click += new System.EventHandler(this.BtnSaveCurrent_Click);
            // 
            // BtnSaveAll
            // 
            this.BtnSaveAll.Location = new System.Drawing.Point(252, 106);
            this.BtnSaveAll.Name = "BtnSaveAll";
            this.BtnSaveAll.Size = new System.Drawing.Size(142, 47);
            this.BtnSaveAll.TabIndex = 7;
            this.BtnSaveAll.Text = "Save All as PDF";
            this.BtnSaveAll.UseVisualStyleBackColor = true;
            this.BtnSaveAll.Click += new System.EventHandler(this.BtnSaveAll_Click);
            // 
            // BtnPrintCurrentCategory
            // 
            this.BtnPrintCurrentCategory.Location = new System.Drawing.Point(668, 36);
            this.BtnPrintCurrentCategory.Name = "BtnPrintCurrentCategory";
            this.BtnPrintCurrentCategory.Size = new System.Drawing.Size(182, 47);
            this.BtnPrintCurrentCategory.TabIndex = 5;
            this.BtnPrintCurrentCategory.Text = "Print Current Category";
            this.BtnPrintCurrentCategory.UseVisualStyleBackColor = true;
            this.BtnPrintCurrentCategory.Click += new System.EventHandler(this.BtnPrintCurrentCategory_Click);
            // 
            // BtnPrintAllCategories
            // 
            this.BtnPrintAllCategories.Location = new System.Drawing.Point(491, 36);
            this.BtnPrintAllCategories.Name = "BtnPrintAllCategories";
            this.BtnPrintAllCategories.Size = new System.Drawing.Size(155, 47);
            this.BtnPrintAllCategories.TabIndex = 4;
            this.BtnPrintAllCategories.Text = "Print All Categories";
            this.BtnPrintAllCategories.UseVisualStyleBackColor = true;
            this.BtnPrintAllCategories.Click += new System.EventHandler(this.BtnPrintAllCategories_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(380, 36);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(92, 47);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(261, 36);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(103, 47);
            this.BtnUpdate.TabIndex = 2;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(143, 36);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(97, 47);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Location = new System.Drawing.Point(23, 36);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(105, 47);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(748, 531);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(122, 44);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LbCount
            // 
            this.LbCount.AutoSize = true;
            this.LbCount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCount.Location = new System.Drawing.Point(232, 240);
            this.LbCount.Name = "LbCount";
            this.LbCount.Size = new System.Drawing.Size(39, 20);
            this.LbCount.TabIndex = 9;
            this.LbCount.Text = "1/1";
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.BackgroundImage = global::Sales_Management_Project.Properties.Resources.rewind__1_;
            this.BtnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPrevious.Location = new System.Drawing.Point(294, 229);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(58, 46);
            this.BtnPrevious.TabIndex = 8;
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtLast
            // 
            this.BtLast.BackgroundImage = global::Sales_Management_Project.Properties.Resources.next__2_;
            this.BtLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtLast.Location = new System.Drawing.Point(370, 229);
            this.BtLast.Name = "BtLast";
            this.BtLast.Size = new System.Drawing.Size(58, 46);
            this.BtLast.TabIndex = 7;
            this.BtLast.UseVisualStyleBackColor = true;
            this.BtLast.Click += new System.EventHandler(this.BtLast_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.BackgroundImage = global::Sales_Management_Project.Properties.Resources.fast_forward__1_;
            this.BtnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnNext.Location = new System.Drawing.Point(144, 229);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(58, 46);
            this.BtnNext.TabIndex = 6;
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnFirst
            // 
            this.BtnFirst.BackColor = System.Drawing.Color.Transparent;
            this.BtnFirst.BackgroundImage = global::Sales_Management_Project.Properties.Resources.previous;
            this.BtnFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnFirst.Location = new System.Drawing.Point(67, 229);
            this.BtnFirst.Name = "BtnFirst";
            this.BtnFirst.Size = new System.Drawing.Size(58, 46);
            this.BtnFirst.TabIndex = 5;
            this.BtnFirst.UseVisualStyleBackColor = false;
            this.BtnFirst.Click += new System.EventHandler(this.BtnFirst_Click);
            // 
            // DGVCategories
            // 
            this.DGVCategories.AllowUserToAddRows = false;
            this.DGVCategories.AllowUserToDeleteRows = false;
            this.DGVCategories.AllowUserToOrderColumns = true;
            this.DGVCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCategories.Location = new System.Drawing.Point(488, 63);
            this.DGVCategories.Name = "DGVCategories";
            this.DGVCategories.ReadOnly = true;
            this.DGVCategories.RowHeadersWidth = 51;
            this.DGVCategories.RowTemplate.Height = 26;
            this.DGVCategories.Size = new System.Drawing.Size(382, 231);
            this.DGVCategories.TabIndex = 4;
            this.DGVCategories.Click += new System.EventHandler(this.DGVCategories_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(163, 116);
            this.TxtDescription.Multiline = true;
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDescription.Size = new System.Drawing.Size(290, 87);
            this.TxtDescription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Category ID:";
            // 
            // TxtCategoryID
            // 
            this.TxtCategoryID.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TxtCategoryID.Location = new System.Drawing.Point(163, 63);
            this.TxtCategoryID.Name = "TxtCategoryID";
            this.TxtCategoryID.ReadOnly = true;
            this.TxtCategoryID.Size = new System.Drawing.Size(143, 24);
            this.TxtCategoryID.TabIndex = 0;
            // 
            // frmCategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(990, 627);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCategoryManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category Management";
            this.Load += new System.EventHandler(this.frmCategoryManagement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCategoryID;
        private System.Windows.Forms.Label LbCount;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtLast;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnFirst;
        private System.Windows.Forms.DataGridView DGVCategories;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSaveCurrent;
        private System.Windows.Forms.Button BtnSaveAll;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnPrintCurrentCategory;
        private System.Windows.Forms.Button BtnPrintAllCategories;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnNew;
    }
}