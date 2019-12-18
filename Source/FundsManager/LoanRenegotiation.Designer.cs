namespace FundsManager
{
    partial class LoanRenegotiation
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
            this.cmdRenegotiate = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblInterest = new System.Windows.Forms.Label();
            this.cbLoan = new System.Windows.Forms.ComboBox();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loansTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewReference = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRenegotiate
            // 
            this.cmdRenegotiate.Location = new System.Drawing.Point(145, 176);
            this.cmdRenegotiate.Name = "cmdRenegotiate";
            this.cmdRenegotiate.Size = new System.Drawing.Size(108, 23);
            this.cmdRenegotiate.TabIndex = 26;
            this.cmdRenegotiate.Text = "Re Negotiate";
            this.cmdRenegotiate.UseVisualStyleBackColor = true;
            this.cmdRenegotiate.Click += new System.EventHandler(this.cmdRenegotiate_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(313, 21);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(0, 13);
            this.lblAmount.TabIndex = 25;
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Location = new System.Drawing.Point(313, 60);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(0, 13);
            this.lblInterest.TabIndex = 24;
            // 
            // cbLoan
            // 
            this.cbLoan.DataSource = this.loansBindingSource;
            this.cbLoan.DisplayMember = "reference";
            this.cbLoan.FormattingEnabled = true;
            this.cbLoan.Location = new System.Drawing.Point(62, 60);
            this.cbLoan.Name = "cbLoan";
            this.cbLoan.Size = new System.Drawing.Size(191, 21);
            this.cbLoan.TabIndex = 21;
            this.cbLoan.ValueMember = "Id";
            this.cbLoan.SelectedIndexChanged += new System.EventHandler(this.cbLoan_SelectedIndexChanged);
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(62, 21);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(191, 21);
            this.cbLender.TabIndex = 20;
            this.cbLender.ValueMember = "Id";
            this.cbLender.SelectedIndexChanged += new System.EventHandler(this.cbLender_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Interest:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Loan:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Lender:";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(62, 94);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(191, 20);
            this.dtpStart.TabIndex = 27;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(303, 96);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(171, 20);
            this.dtpEnd.TabIndex = 28;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // creditorsBindingSource
            // 
            this.creditorsBindingSource.DataMember = "Creditors";
            this.creditorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loansBindingSource
            // 
            this.loansBindingSource.DataMember = "Loans";
            this.loansBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // loansTableAdapter
            // 
            this.loansTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Reference:";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(78, 134);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(0, 13);
            this.lblReference.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "New Reference:";
            // 
            // txtNewReference
            // 
            this.txtNewReference.Location = new System.Drawing.Point(360, 134);
            this.txtNewReference.Name = "txtNewReference";
            this.txtNewReference.Size = new System.Drawing.Size(114, 20);
            this.txtNewReference.TabIndex = 32;
            // 
            // LoanRenegotiation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 237);
            this.Controls.Add(this.txtNewReference);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cmdRenegotiate);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblInterest);
            this.Controls.Add(this.cbLoan);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoanRenegotiation";
            this.Text = "LoanRenegotiation";
            this.Load += new System.EventHandler(this.LoanRenegotiation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRenegotiate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblInterest;
        private System.Windows.Forms.ComboBox cbLoan;
        private System.Windows.Forms.ComboBox cbLender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.BindingSource loansBindingSource;
        private FundsDBDataSetTableAdapters.LoansTableAdapter loansTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewReference;
    }
}