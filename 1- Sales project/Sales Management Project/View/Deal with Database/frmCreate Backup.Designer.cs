namespace Sales_Management_Project
{
    partial class frmCreate_Backup
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
            this.TxtPathLocation = new System.Windows.Forms.TextBox();
            this.LbCommend = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BtnPathLocation = new System.Windows.Forms.Button();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // TxtPathLocation
            // 
            this.TxtPathLocation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPathLocation.Location = new System.Drawing.Point(51, 109);
            this.TxtPathLocation.Name = "TxtPathLocation";
            this.TxtPathLocation.Size = new System.Drawing.Size(541, 26);
            this.TxtPathLocation.TabIndex = 0;
            // 
            // LbCommend
            // 
            this.LbCommend.AutoSize = true;
            this.LbCommend.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCommend.Location = new System.Drawing.Point(47, 69);
            this.LbCommend.Name = "LbCommend";
            this.LbCommend.Size = new System.Drawing.Size(317, 20);
            this.LbCommend.TabIndex = 1;
            this.LbCommend.Text = "Select the backup location path:";
            // 
            // BtnPathLocation
            // 
            this.BtnPathLocation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPathLocation.Location = new System.Drawing.Point(598, 108);
            this.BtnPathLocation.Name = "BtnPathLocation";
            this.BtnPathLocation.Size = new System.Drawing.Size(75, 27);
            this.BtnPathLocation.TabIndex = 2;
            this.BtnPathLocation.Text = "...";
            this.BtnPathLocation.UseVisualStyleBackColor = true;
            this.BtnPathLocation.Click += new System.EventHandler(this.BtnPathLocation_Click);
            // 
            // BtnBackup
            // 
            this.BtnBackup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBackup.Location = new System.Drawing.Point(361, 218);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(178, 50);
            this.BtnBackup.TabIndex = 4;
            this.BtnBackup.Text = "Create Backup Database";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(132, 218);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(169, 50);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmCreate_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(757, 349);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnBackup);
            this.Controls.Add(this.BtnPathLocation);
            this.Controls.Add(this.LbCommend);
            this.Controls.Add(this.TxtPathLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCreate_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Backup";
            this.Load += new System.EventHandler(this.frmCreate_Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPathLocation;
        private System.Windows.Forms.Label LbCommend;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BtnPathLocation;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}