namespace FundsManager
{
    partial class ProfitShareToAccrueForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmdGenerateInterest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvDisbursements = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProfitShare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CollectionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaidDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdGenerateAllInterest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.Contract = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(80, 23);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
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
            this.groupBox1.Controls.Add(this.lvDisbursements);
            this.groupBox1.Location = new System.Drawing.Point(12, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 366);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disbursements";
            // 
            // lvDisbursements
            // 
            this.lvDisbursements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Contract,
            this.Number,
            this.ProfitShare,
            this.CollectionDate,
            this.PaidDate,
            this.Days});
            this.lvDisbursements.FullRowSelect = true;
            this.lvDisbursements.HideSelection = false;
            this.lvDisbursements.Location = new System.Drawing.Point(14, 28);
            this.lvDisbursements.Name = "lvDisbursements";
            this.lvDisbursements.Size = new System.Drawing.Size(718, 319);
            this.lvDisbursements.TabIndex = 0;
            this.lvDisbursements.UseCompatibleStateImageBehavior = false;
            this.lvDisbursements.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // Number
            // 
            this.Number.Text = "Number";
            // 
            // ProfitShare
            // 
            this.ProfitShare.Text = "Profit Share";
            this.ProfitShare.Width = 100;
            // 
            // CollectionDate
            // 
            this.CollectionDate.Text = "Collection Date";
            this.CollectionDate.Width = 180;
            // 
            // PaidDate
            // 
            this.PaidDate.Text = "Paid Date";
            this.PaidDate.Width = 180;
            // 
            // Days
            // 
            this.Days.Text = "Days";
            this.Days.Width = 180;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdGenerateAllInterest);
            this.groupBox2.Controls.Add(this.cmdGenerateInterest);
            this.groupBox2.Location = new System.Drawing.Point(308, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 61);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Interest";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(205, 49);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 18;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // Contract
            // 
            this.Contract.Text = "Contract";
            this.Contract.Width = 100;
            // 
            // ProfitShareToAccrueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 463);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfitShareToAccrueForm";
            this.Text = "Profit Share To Accrue";
            this.Load += new System.EventHandler(this.ProfitShareToAccrueForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdGenerateInterest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvDisbursements;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader ProfitShare;
        private System.Windows.Forms.ColumnHeader CollectionDate;
        private System.Windows.Forms.ColumnHeader Days;
        private System.Windows.Forms.ColumnHeader PaidDate;
        private System.Windows.Forms.Button cmdGenerateAllInterest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.ColumnHeader Contract;
    }
}