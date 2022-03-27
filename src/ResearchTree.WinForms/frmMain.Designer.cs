namespace ResearchTree.WinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddTick = new System.Windows.Forms.Button();
            this.cboWorkers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddTick
            // 
            this.btnAddTick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTick.Location = new System.Drawing.Point(1473, 664);
            this.btnAddTick.Name = "btnAddTick";
            this.btnAddTick.Size = new System.Drawing.Size(150, 46);
            this.btnAddTick.TabIndex = 12;
            this.btnAddTick.Text = "Add Tick";
            this.btnAddTick.UseVisualStyleBackColor = true;
            this.btnAddTick.Click += new System.EventHandler(this.btnAddTick_Click);
            // 
            // cboWorkers
            // 
            this.cboWorkers.FormattingEnabled = true;
            this.cboWorkers.Location = new System.Drawing.Point(1225, 668);
            this.cboWorkers.Name = "cboWorkers";
            this.cboWorkers.Size = new System.Drawing.Size(242, 40);
            this.cboWorkers.TabIndex = 13;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 722);
            this.Controls.Add(this.cboWorkers);
            this.Controls.Add(this.btnAddTick);
            this.Name = "frmMain";
            this.Text = "Research Tree WinForms example";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnAddTick;
        private ComboBox cboWorkers;
    }
}