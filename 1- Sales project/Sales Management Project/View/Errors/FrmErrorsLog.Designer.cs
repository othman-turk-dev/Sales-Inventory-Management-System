namespace Sales_Management_Project
{
    partial class frmErrorsLog
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
            this.DGVErrors = new System.Windows.Forms.DataGridView();
            this.CMStripErrors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SetCompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGVErrors)).BeginInit();
            this.CMStripErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVErrors
            // 
            this.DGVErrors.AllowUserToAddRows = false;
            this.DGVErrors.AllowUserToDeleteRows = false;
            this.DGVErrors.AllowUserToOrderColumns = true;
            this.DGVErrors.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.DGVErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVErrors.ContextMenuStrip = this.CMStripErrors;
            this.DGVErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVErrors.Location = new System.Drawing.Point(0, 0);
            this.DGVErrors.MultiSelect = false;
            this.DGVErrors.Name = "DGVErrors";
            this.DGVErrors.ReadOnly = true;
            this.DGVErrors.RowHeadersWidth = 51;
            this.DGVErrors.RowTemplate.Height = 26;
            this.DGVErrors.Size = new System.Drawing.Size(1313, 562);
            this.DGVErrors.TabIndex = 2;
            // 
            // CMStripErrors
            // 
            this.CMStripErrors.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMStripErrors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetCompleteToolStripMenuItem});
            this.CMStripErrors.Name = "CMStripUsers";
            this.CMStripErrors.Size = new System.Drawing.Size(211, 56);
            this.CMStripErrors.Opening += new System.ComponentModel.CancelEventHandler(this.CMStripErrors_Opening);
            // 
            // SetCompleteToolStripMenuItem
            // 
            this.SetCompleteToolStripMenuItem.Name = "SetCompleteToolStripMenuItem";
            this.SetCompleteToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.SetCompleteToolStripMenuItem.Text = "Set Complete";
            this.SetCompleteToolStripMenuItem.Click += new System.EventHandler(this.SetCompleteToolStripMenuItem_Click);
            // 
            // frmErrorsLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 562);
            this.Controls.Add(this.DGVErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmErrorsLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Errors List";
            this.Load += new System.EventHandler(this.frmErrorsLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVErrors)).EndInit();
            this.CMStripErrors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVErrors;
        private System.Windows.Forms.ContextMenuStrip CMStripErrors;
        private System.Windows.Forms.ToolStripMenuItem SetCompleteToolStripMenuItem;
    }
}