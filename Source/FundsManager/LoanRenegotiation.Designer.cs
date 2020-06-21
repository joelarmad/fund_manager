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
            this.loansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loansTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReference = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewReference = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNewAmount = new System.Windows.Forms.TextBox();
            this.txtNewInterest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRenegotiate
            // 
            this.cmdRenegotiate.Location = new System.Drawing.Point(490, 219);
            this.cmdRenegotiate.Name = "cmdRenegotiate";
            this.cmdRenegotiate.Size = new System.Drawing.Size(108, 23);
            this.cmdRenegotiate.TabIndex = 8;
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
            this.cbLoan.Location = new System.Drawing.Point(65, 60);
            this.cbLoan.Name = "cbLoan";
            this.cbLoan.Size = new System.Drawing.Size(188, 21);
            this.cbLoan.TabIndex = 2;
            this.cbLoan.ValueMember = "Id";
            this.cbLoan.SelectedIndexChanged += new System.EventHandler(this.cbLoan_SelectedIndexChanged);
            // 
            // loansBindingSource
            // 
            this.loansBindingSource.DataMember = "Loans";
            this.loansBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(65, 21);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(188, 21);
            this.cbLender.TabIndex = 1;
            this.cbLender.ValueMember = "Id";
            this.cbLender.SelectedIndexChanged += new System.EventHandler(this.cbLender_SelectedIndexChanged);
            // 
            // creditorsBindingSource
            // 
            this.creditorsBindingSource.DataMember = "Creditors";
            this.creditorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "New End:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "New Start:";
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
            this.dtpStart.Location = new System.Drawing.Point(65, 133);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(188, 20);
            this.dtpStart.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(323, 135);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(227, 20);
            this.dtpEnd.TabIndex = 6;
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loansTableAdapter
            // 
            this.loansTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Reference:";
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(78, 173);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(0, 13);
            this.lblReference.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "New Reference:";
            // 
            // txtNewReference
            // 
            this.txtNewReference.Location = new System.Drawing.Point(359, 173);
            this.txtNewReference.Name = "txtNewReference";
            this.txtNewReference.Size = new System.Drawing.Size(191, 20);
            this.txtNewReference.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(268, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "End:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Start:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(67, 100);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(0, 13);
            this.lblStart.TabIndex = 35;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(302, 100);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(0, 13);
            this.lblEnd.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "New Amount:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(398, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "New Interest:";
            // 
            // txtNewAmount
            // 
            this.txtNewAmount.Location = new System.Drawing.Point(475, 17);
            this.txtNewAmount.Name = "txtNewAmount";
            this.txtNewAmount.Size = new System.Drawing.Size(124, 20);
            this.txtNewAmount.TabIndex = 3;
            // 
            // txtNewInterest
            // 
            this.txtNewInterest.Location = new System.Drawing.Point(474, 56);
            this.txtNewInterest.Name = "txtNewInterest";
            this.txtNewInterest.Size = new System.Drawing.Size(124, 20);
            this.txtNewInterest.TabIndex = 4;
            // 
            // LoanRenegotiation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 273);
            this.Controls.Add(this.txtNewInterest);
            this.Controls.Add(this.txtNewAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
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
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNewAmount;
        private System.Windows.Forms.TextBox txtNewInterest;
    }
}