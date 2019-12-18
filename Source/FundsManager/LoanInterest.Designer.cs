namespace FundsManager
{
    partial class LoanInterest
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
            this.Reference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Interest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.End = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(200, 41);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(75, 23);
            this.cmdSearch.TabIndex = 23;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdGenerateAllInterest);
            this.groupBox2.Controls.Add(this.cmdGenerateInterest);
            this.groupBox2.Location = new System.Drawing.Point(303, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 61);
            this.groupBox2.TabIndex = 22;
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
            this.groupBox1.Location = new System.Drawing.Point(7, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 366);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loans";
            // 
            // lvData
            // 
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Reference,
            this.Amount,
            this.Interest,
            this.Start,
            this.End,
            this.Days});
            this.lvData.FullRowSelect = true;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(14, 28);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(718, 319);
            this.lvData.TabIndex = 0;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // Reference
            // 
            this.Reference.Text = "Reference";
            this.Reference.Width = 100;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            // 
            // Interest
            // 
            this.Interest.Text = "Interest";
            this.Interest.Width = 100;
            // 
            // Start
            // 
            this.Start.Text = "Start";
            this.Start.Width = 180;
            // 
            // End
            // 
            this.End.Text = "End";
            this.End.Width = 180;
            // 
            // Days
            // 
            this.Days.Text = "Days";
            this.Days.Width = 180;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(75, 15);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Date:";
            // 
            // LoanInterest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 466);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanInterest";
            this.Text = "LoanInterest";
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
        private System.Windows.Forms.ColumnHeader Reference;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Interest;
        private System.Windows.Forms.ColumnHeader Start;
        private System.Windows.Forms.ColumnHeader End;
        private System.Windows.Forms.ColumnHeader Days;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
    }
}