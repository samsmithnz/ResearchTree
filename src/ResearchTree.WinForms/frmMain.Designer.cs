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
            this.lstAvailableItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnStartResearch = new System.Windows.Forms.Button();
            this.lstCurrentItems = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // lstAvailableItems
            // 
            this.lstAvailableItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstAvailableItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstAvailableItems.Location = new System.Drawing.Point(40, 516);
            this.lstAvailableItems.Name = "lstAvailableItems";
            this.lstAvailableItems.Size = new System.Drawing.Size(242, 194);
            this.lstAvailableItems.TabIndex = 14;
            this.lstAvailableItems.UseCompatibleStateImageBehavior = false;
            this.lstAvailableItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Research";
            this.columnHeader1.Width = 200;
            // 
            // btnStartResearch
            // 
            this.btnStartResearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartResearch.Location = new System.Drawing.Point(288, 662);
            this.btnStartResearch.Name = "btnStartResearch";
            this.btnStartResearch.Size = new System.Drawing.Size(205, 46);
            this.btnStartResearch.TabIndex = 15;
            this.btnStartResearch.Text = "Start Research";
            this.btnStartResearch.UseVisualStyleBackColor = true;
            this.btnStartResearch.Click += new System.EventHandler(this.btnStartResearch_Click);
            // 
            // lstCurrentItems
            // 
            this.lstCurrentItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.lstCurrentItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstCurrentItems.Location = new System.Drawing.Point(977, 514);
            this.lstCurrentItems.Name = "lstCurrentItems";
            this.lstCurrentItems.Size = new System.Drawing.Size(242, 194);
            this.lstCurrentItems.TabIndex = 16;
            this.lstCurrentItems.UseCompatibleStateImageBehavior = false;
            this.lstCurrentItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Research";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "#";
            this.columnHeader3.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 479);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Available Research:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(977, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 32);
            this.label2.TabIndex = 18;
            this.label2.Text = "Current Research:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 722);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstCurrentItems);
            this.Controls.Add(this.btnStartResearch);
            this.Controls.Add(this.lstAvailableItems);
            this.Controls.Add(this.cboWorkers);
            this.Controls.Add(this.btnAddTick);
            this.Name = "frmMain";
            this.Text = "Research Tree WinForms example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnAddTick;
        private ComboBox cboWorkers;
        private ListView lstAvailableItems;
        private Button btnStartResearch;
        private ListView lstCurrentItems;
        private Label label1;
        private Label label2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}