namespace FundsManager
{
    partial class BondsTFAMInterest
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
            this.cmdSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdGenerateAllInterest = new System.Windows.Forms.Button();
            this.cmdGenerateInterest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvData = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bond = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BondInterest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TFFInterest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Emited = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Expire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(218, 53);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 28;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdGenerateAllInterest);
            this.groupBox2.Controls.Add(this.cmdGenerateInterest);
            this.groupBox2.Location = new System.Drawing.Point(321, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 61);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Interest";
            // 
            // cmdGenerateAllInterest
            // 
            this.cmdGenerateAllInterest.Location = new System.Drawing.Point(57, 22);
            this.cmdGenerateAllInterest.Name = "cmdGenerateAllInterest";
            this.cmdGenerateAllInterest.Size = new System.Drawing.Size(108, 23);
            this.cmdGenerateAllInterest.TabIndex = 16;
            this.cmdGenerateAllInterest.Text = "For ALL";
            this.cmdGenerateAllInterest.UseVisualStyleBackColor = true;
            this.cmdGenerateAllInterest.Click += new System.EventHandler(this.cmdGenerateAllInterest_Click);
            // 
            // cmdGenerateInterest
            // 
            this.cmdGenerateInterest.Location = new System.Drawing.Point(200, 22);
            this.cmdGenerateInterest.Name = "cmdGenerateInterest";
            this.cmdGenerateInterest.Size = new System.Drawing.Size(177, 23);
            this.cmdGenerateInterest.TabIndex = 2;
            this.cmdGenerateInterest.Text = "Just for SELECTION";
            this.cmdGenerateInterest.UseVisualStyleBackColor = true;
            this.cmdGenerateInterest.Click += new System.EventHandler(this.cmdGenerateInterest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvData);
            this.groupBox1.Location = new System.Drawing.Point(25, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 366);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bonds";
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Bond,
            this.Amount,
            this.BondInterest,
            this.TFFInterest,
            this.Emited,
            this.Expire,
            this.Days});
            this.lvData.FullRowSelect = true;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(14, 28);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(768, 319);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // Bond
            // 
            this.Bond.Text = "Bond";
            this.Bond.Width = 100;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 100;
            // 
            // BondInterest
            // 
            this.BondInterest.Text = "Bond Interest";
            this.BondInterest.Width = 100;
            // 
            // TFFInterest
            // 
            this.TFFInterest.Text = "TFF Interest";
            this.TFFInterest.Width = 100;
            // 
            // Emited
            // 
            this.Emited.Text = "Emited";
            this.Emited.Width = 140;
            // 
            // Expire
            // 
            this.Expire.Text = "Expire";
            this.Expire.Width = 140;
            // 
            // Days
            // 
            this.Days.Text = "Days";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(93, 27);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Date:";
            // 
            // BondsTFAMInterest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 473);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BondsTFAMInterest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bonds TFAM Interest";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdGenerateAllInterest;
        private System.Windows.Forms.Button cmdGenerateInterest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Bond;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader BondInterest;
        private System.Windows.Forms.ColumnHeader Emited;
        private System.Windows.Forms.ColumnHeader Expire;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader TFFInterest;
        private System.Windows.Forms.ColumnHeader Days;
    }
}