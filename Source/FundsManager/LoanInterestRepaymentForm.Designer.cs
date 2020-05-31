namespace FundsManager
{
    partial class LoanInterestRepaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generatedinterestdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generatedinterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanGeneratedInterestViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdPay = new System.Windows.Forms.Button();
            this.loanGeneratedInterestViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoanGeneratedInterestViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanGeneratedInterestViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lender:";
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(77, 31);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(199, 21);
            this.cbLender.TabIndex = 1;
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
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(343, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.referenceDataGridViewTextBoxColumn,
            this.generatedinterestdateDataGridViewTextBoxColumn,
            this.generatedinterestDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.loanGeneratedInterestViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(31, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(640, 274);
            this.dataGridView1.TabIndex = 22;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "reference";
            this.referenceDataGridViewTextBoxColumn.HeaderText = "Reference";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            this.referenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generatedinterestdateDataGridViewTextBoxColumn
            // 
            this.generatedinterestdateDataGridViewTextBoxColumn.DataPropertyName = "generated_interest_date";
            dataGridViewCellStyle5.Format = "d";
            this.generatedinterestdateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.generatedinterestdateDataGridViewTextBoxColumn.HeaderText = "Interest Date";
            this.generatedinterestdateDataGridViewTextBoxColumn.Name = "generatedinterestdateDataGridViewTextBoxColumn";
            this.generatedinterestdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generatedinterestDataGridViewTextBoxColumn
            // 
            this.generatedinterestDataGridViewTextBoxColumn.DataPropertyName = "generated_interest";
            dataGridViewCellStyle6.Format = "N2";
            this.generatedinterestDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.generatedinterestDataGridViewTextBoxColumn.HeaderText = "Generated Interest";
            this.generatedinterestDataGridViewTextBoxColumn.Name = "generatedinterestDataGridViewTextBoxColumn";
            this.generatedinterestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loanGeneratedInterestViewBindingSource
            // 
            this.loanGeneratedInterestViewBindingSource.DataMember = "LoanGeneratedInterestView";
            this.loanGeneratedInterestViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // cmdPay
            // 
            this.cmdPay.Location = new System.Drawing.Point(442, 73);
            this.cmdPay.Name = "cmdPay";
            this.cmdPay.Size = new System.Drawing.Size(101, 23);
            this.cmdPay.TabIndex = 23;
            this.cmdPay.Text = "Re Pay";
            this.cmdPay.UseVisualStyleBackColor = true;
            this.cmdPay.Click += new System.EventHandler(this.cmdPay_Click);
            // 
            // loanGeneratedInterestViewTableAdapter
            // 
            this.loanGeneratedInterestViewTableAdapter.ClearBeforeFill = true;
            // 
            // LoanInterestRepaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 435);
            this.Controls.Add(this.cmdPay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoanInterestRepaymentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Loan Interest Repayment";
            this.Load += new System.EventHandler(this.LoanInterestRepaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanGeneratedInterestViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLender;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdPay;
        private System.Windows.Forms.BindingSource loanGeneratedInterestViewBindingSource;
        private FundsDBDataSetTableAdapters.LoanGeneratedInterestViewTableAdapter loanGeneratedInterestViewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generatedinterestdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generatedinterestDataGridViewTextBoxColumn;
    }
}