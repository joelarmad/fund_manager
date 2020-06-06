namespace FundsManager
{
    partial class LoanRepaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.loansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loansTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounttoberepaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interesttoberepaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepayPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepayInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loansToBeRepaidViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loansToBeRepaidViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansToBeRepaidViewTableAdapter();
            this.cmdRepay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansToBeRepaidViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lender:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date:";
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(62, 12);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(195, 21);
            this.cbLender.TabIndex = 3;
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
            // cbContract
            // 
            this.cbContract.DataSource = this.loansBindingSource;
            this.cbContract.DisplayMember = "reference";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(327, 12);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(195, 21);
            this.cbContract.TabIndex = 4;
            this.cbContract.ValueMember = "Id";
            this.cbContract.SelectedIndexChanged += new System.EventHandler(this.cbContract_SelectedIndexChanged);
            // 
            // loansBindingSource
            // 
            this.loansBindingSource.DataMember = "Loans";
            this.loansBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(565, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(191, 20);
            this.dtpDate.TabIndex = 28;
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loansTableAdapter
            // 
            this.loansTableAdapter.ClearBeforeFill = true;
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
            this.endDataGridViewTextBoxColumn,
            this.amounttoberepaidDataGridViewTextBoxColumn,
            this.interesttoberepaidDataGridViewTextBoxColumn,
            this.RepayPrincipal,
            this.RepayInterest});
            this.dataGridView1.DataSource = this.loansToBeRepaidViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(17, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 339);
            this.dataGridView1.TabIndex = 29;
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
            // 
            // endDataGridViewTextBoxColumn
            // 
            this.endDataGridViewTextBoxColumn.DataPropertyName = "end";
            dataGridViewCellStyle1.Format = "d";
            this.endDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.endDataGridViewTextBoxColumn.HeaderText = "Expiry Date";
            this.endDataGridViewTextBoxColumn.Name = "endDataGridViewTextBoxColumn";
            // 
            // amounttoberepaidDataGridViewTextBoxColumn
            // 
            this.amounttoberepaidDataGridViewTextBoxColumn.DataPropertyName = "amount_to_be_repaid";
            dataGridViewCellStyle2.Format = "N2";
            this.amounttoberepaidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amounttoberepaidDataGridViewTextBoxColumn.HeaderText = "Principal";
            this.amounttoberepaidDataGridViewTextBoxColumn.Name = "amounttoberepaidDataGridViewTextBoxColumn";
            this.amounttoberepaidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interesttoberepaidDataGridViewTextBoxColumn
            // 
            this.interesttoberepaidDataGridViewTextBoxColumn.DataPropertyName = "interest_to_be_repaid";
            dataGridViewCellStyle3.Format = "N2";
            this.interesttoberepaidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.interesttoberepaidDataGridViewTextBoxColumn.HeaderText = "Interest Accrued";
            this.interesttoberepaidDataGridViewTextBoxColumn.Name = "interesttoberepaidDataGridViewTextBoxColumn";
            this.interesttoberepaidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RepayPrincipal
            // 
            this.RepayPrincipal.HeaderText = "Repay Principal";
            this.RepayPrincipal.Name = "RepayPrincipal";
            // 
            // RepayInterest
            // 
            this.RepayInterest.HeaderText = "Repay Interest";
            this.RepayInterest.Name = "RepayInterest";
            // 
            // loansToBeRepaidViewBindingSource
            // 
            this.loansToBeRepaidViewBindingSource.DataMember = "LoansToBeRepaidView";
            this.loansToBeRepaidViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // loansToBeRepaidViewTableAdapter
            // 
            this.loansToBeRepaidViewTableAdapter.ClearBeforeFill = true;
            // 
            // cmdRepay
            // 
            this.cmdRepay.Location = new System.Drawing.Point(680, 49);
            this.cmdRepay.Name = "cmdRepay";
            this.cmdRepay.Size = new System.Drawing.Size(75, 23);
            this.cmdRepay.TabIndex = 30;
            this.cmdRepay.Text = "REPAY";
            this.cmdRepay.UseVisualStyleBackColor = true;
            this.cmdRepay.Click += new System.EventHandler(this.cmdRepay_Click);
            // 
            // LoanRepaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 461);
            this.Controls.Add(this.cmdRepay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoanRepaymentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LoanRepaymentForm";
            this.Load += new System.EventHandler(this.LoanRepaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansToBeRepaidViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLender;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.BindingSource loansBindingSource;
        private FundsDBDataSetTableAdapters.LoansTableAdapter loansTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource loansToBeRepaidViewBindingSource;
        private FundsDBDataSetTableAdapters.LoansToBeRepaidViewTableAdapter loansToBeRepaidViewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounttoberepaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interesttoberepaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepayPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepayInterest;
        private System.Windows.Forms.Button cmdRepay;
    }
}