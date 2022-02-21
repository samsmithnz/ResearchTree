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
            this.btnHideButtons = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHideButtons
            // 
            this.btnHideButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideButtons.Location = new System.Drawing.Point(1473, 664);
            this.btnHideButtons.Name = "btnHideButtons";
            this.btnHideButtons.Size = new System.Drawing.Size(150, 46);
            this.btnHideButtons.TabIndex = 12;
            this.btnHideButtons.Text = "hide btns";
            this.btnHideButtons.UseVisualStyleBackColor = true;
            this.btnHideButtons.Click += new System.EventHandler(this.btnHideButtons_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 722);
            this.Controls.Add(this.btnHideButtons);
            this.Name = "frmMain";
            this.Text = "Research Tree WinForms example";
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnHideButtons;
    }
}