namespace FundsManager
{
    partial class BondsTFAMInterestPayment
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdPay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bondidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generatedbondinterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generatedtffinterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generatedinterestdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fundidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bondsTFAMInterestToPayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.bondsTFAMInterestToPayTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BondsTFAMInterestToPayTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMInterestToPayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(114, 11);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Payment Date:";
            // 
            // cmdPay
            // 
            this.cmdPay.Location = new System.Drawing.Point(623, 48);
            this.cmdPay.Name = "cmdPay";
            this.cmdPay.Size = new System.Drawing.Size(75, 23);
            this.cmdPay.TabIndex = 37;
            this.cmdPay.Text = "Pay";
            this.cmdPay.UseVisualStyleBackColor = true;
            this.cmdPay.Click += new System.EventHandler(this.cmdPay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 248);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bonds";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.bondidDataGridViewTextBoxColumn,
            this.generatedbondinterestDataGridViewTextBoxColumn,
            this.generatedtffinterestDataGridViewTextBoxColumn,
            this.generatedinterestdateDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.fundidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bondsTFAMInterestToPayBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(658, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bondidDataGridViewTextBoxColumn
            // 
            this.bondidDataGridViewTextBoxColumn.DataPropertyName = "bond_id";
            this.bondidDataGridViewTextBoxColumn.HeaderText = "bond_id";
            this.bondidDataGridViewTextBoxColumn.Name = "bondidDataGridViewTextBoxColumn";
            this.bondidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generatedbondinterestDataGridViewTextBoxColumn
            // 
            this.generatedbondinterestDataGridViewTextBoxColumn.DataPropertyName = "generated_bond_interest";
            this.generatedbondinterestDataGridViewTextBoxColumn.HeaderText = "generated_bond_interest";
            this.generatedbondinterestDataGridViewTextBoxColumn.Name = "generatedbondinterestDataGridViewTextBoxColumn";
            this.generatedbondinterestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generatedtffinterestDataGridViewTextBoxColumn
            // 
            this.generatedtffinterestDataGridViewTextBoxColumn.DataPropertyName = "generated_tff_interest";
            this.generatedtffinterestDataGridViewTextBoxColumn.HeaderText = "generated_tff_interest";
            this.generatedtffinterestDataGridViewTextBoxColumn.Name = "generatedtffinterestDataGridViewTextBoxColumn";
            this.generatedtffinterestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // generatedinterestdateDataGridViewTextBoxColumn
            // 
            this.generatedinterestdateDataGridViewTextBoxColumn.DataPropertyName = "generated_interest_date";
            this.generatedinterestdateDataGridViewTextBoxColumn.HeaderText = "generated_interest_date";
            this.generatedinterestdateDataGridViewTextBoxColumn.Name = "generatedinterestdateDataGridViewTextBoxColumn";
            this.generatedinterestdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fundidDataGridViewTextBoxColumn
            // 
            this.fundidDataGridViewTextBoxColumn.DataPropertyName = "fund_id";
            this.fundidDataGridViewTextBoxColumn.HeaderText = "fund_id";
            this.fundidDataGridViewTextBoxColumn.Name = "fundidDataGridViewTextBoxColumn";
            this.fundidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bondsTFAMInterestToPayBindingSource
            // 
            this.bondsTFAMInterestToPayBindingSource.DataMember = "BondsTFAMInterestToPay";
            this.bondsTFAMInterestToPayBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bondsTFAMInterestToPayTableAdapter
            // 
            this.bondsTFAMInterestToPayTableAdapter.ClearBeforeFill = true;
            // 
            // BondsTFAMInterestPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 339);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdPay);
            this.Controls.Add(this.groupBox1);
            this.Name = "BondsTFAMInterestPayment";
            this.Text = "BondsTFAMInterestPayment";
            this.Load += new System.EventHandler(this.BondsTFAMInterestPayment_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMInterestToPayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdPay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bondsTFAMInterestToPayBindingSource;
        private FundsDBDataSetTableAdapters.BondsTFAMInterestToPayTableAdapter bondsTFAMInterestToPayTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bondidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generatedbondinterestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generatedtffinterestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn generatedinterestdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fundidDataGridViewTextBoxColumn;
    }
}