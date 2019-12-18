namespace FundsManager
{
    partial class LoanRepayment
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbLoan = new System.Windows.Forms.ComboBox();
            this.loansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtStart = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.Label();
            this.txtInterest = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.Label();
            this.cmdRepay = new System.Windows.Forms.Button();
            this.lbRepayments = new System.Windows.Forms.ListBox();
            this.loanRepaymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loansTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansTableAdapter();
            this.loan_RepaymentsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.Loan_RepaymentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanRepaymentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lender:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Interest:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Start:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(286, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "End:";
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(80, 28);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(191, 21);
            this.cbLender.TabIndex = 7;
            this.cbLender.ValueMember = "Id";
            this.cbLender.SelectedIndexChanged += new System.EventHandler(this.cbLender_SelectedIndexChanged);
            // 
            // creditorsBindingSource
            // 
            this.creditorsBindingSource.DataMember = "Creditors";
            this.creditorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.EnforceConstraints = false;
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbLoan
            // 
            this.cbLoan.DataSource = this.loansBindingSource;
            this.cbLoan.DisplayMember = "reference";
            this.cbLoan.FormattingEnabled = true;
            this.cbLoan.Location = new System.Drawing.Point(80, 67);
            this.cbLoan.Name = "cbLoan";
            this.cbLoan.Size = new System.Drawing.Size(191, 21);
            this.cbLoan.TabIndex = 8;
            this.cbLoan.ValueMember = "Id";
            this.cbLoan.SelectedIndexChanged += new System.EventHandler(this.cbLoan_SelectedIndexChanged);
            // 
            // loansBindingSource
            // 
            this.loansBindingSource.DataMember = "Loans";
            this.loansBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // txtStart
            // 
            this.txtStart.AutoSize = true;
            this.txtStart.Location = new System.Drawing.Point(77, 106);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(0, 13);
            this.txtStart.TabIndex = 9;
            // 
            // txtEnd
            // 
            this.txtEnd.AutoSize = true;
            this.txtEnd.Location = new System.Drawing.Point(331, 106);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(0, 13);
            this.txtEnd.TabIndex = 10;
            // 
            // txtInterest
            // 
            this.txtInterest.AutoSize = true;
            this.txtInterest.Location = new System.Drawing.Point(331, 67);
            this.txtInterest.Name = "txtInterest";
            this.txtInterest.Size = new System.Drawing.Size(0, 13);
            this.txtInterest.TabIndex = 11;
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.Location = new System.Drawing.Point(331, 28);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(0, 13);
            this.txtAmount.TabIndex = 12;
            // 
            // cmdRepay
            // 
            this.cmdRepay.Location = new System.Drawing.Point(214, 139);
            this.cmdRepay.Name = "cmdRepay";
            this.cmdRepay.Size = new System.Drawing.Size(75, 23);
            this.cmdRepay.TabIndex = 13;
            this.cmdRepay.Text = "Re Pay";
            this.cmdRepay.UseVisualStyleBackColor = true;
            this.cmdRepay.Click += new System.EventHandler(this.cmdRepay_Click);
            // 
            // lbRepayments
            // 
            this.lbRepayments.DataSource = this.loanRepaymentsBindingSource;
            this.lbRepayments.DisplayMember = "repayment_date";
            this.lbRepayments.FormattingEnabled = true;
            this.lbRepayments.Location = new System.Drawing.Point(33, 199);
            this.lbRepayments.Name = "lbRepayments";
            this.lbRepayments.Size = new System.Drawing.Size(381, 147);
            this.lbRepayments.TabIndex = 14;
            this.lbRepayments.ValueMember = "Id";
            // 
            // loanRepaymentsBindingSource
            // 
            this.loanRepaymentsBindingSource.DataMember = "Loan_Repayments";
            this.loanRepaymentsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Repayments:";
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loansTableAdapter
            // 
            this.loansTableAdapter.ClearBeforeFill = true;
            // 
            // loan_RepaymentsTableAdapter
            // 
            this.loan_RepaymentsTableAdapter.ClearBeforeFill = true;
            // 
            // LoanRepayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 374);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbRepayments);
            this.Controls.Add(this.cmdRepay);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtInterest);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.cbLoan);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoanRepayment";
            this.Text = "LoanRepayment";
            this.Load += new System.EventHandler(this.LoanRepayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanRepaymentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLender;
        private System.Windows.Forms.ComboBox cbLoan;
        private System.Windows.Forms.Label txtStart;
        private System.Windows.Forms.Label txtEnd;
        private System.Windows.Forms.Label txtInterest;
        private System.Windows.Forms.Label txtAmount;
        private System.Windows.Forms.Button cmdRepay;
        private System.Windows.Forms.ListBox lbRepayments;
        private System.Windows.Forms.Label label11;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.BindingSource loansBindingSource;
        private FundsDBDataSetTableAdapters.LoansTableAdapter loansTableAdapter;
        private System.Windows.Forms.BindingSource loanRepaymentsBindingSource;
        private FundsDBDataSetTableAdapters.Loan_RepaymentsTableAdapter loan_RepaymentsTableAdapter;
    }
}