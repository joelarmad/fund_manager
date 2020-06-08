namespace FundsManager
{
    partial class BondsTFAMRepaymentForm
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
            this.cmdRepay = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.expired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepayPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepayInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounttoberepaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interesttoberepaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bondsTFAMToBeRepaidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.bondsTFAMToBeRepaidTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BondsTFAMToBeRepaidTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMToBeRepaidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRepay
            // 
            this.cmdRepay.Location = new System.Drawing.Point(676, 49);
            this.cmdRepay.Name = "cmdRepay";
            this.cmdRepay.Size = new System.Drawing.Size(75, 23);
            this.cmdRepay.TabIndex = 33;
            this.cmdRepay.Text = "REPAY";
            this.cmdRepay.UseVisualStyleBackColor = true;
            this.cmdRepay.Click += new System.EventHandler(this.cmdRepay_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(561, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(191, 20);
            this.dtpDate.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Date:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.expired,
            this.amounttoberepaidDataGridViewTextBoxColumn,
            this.interesttoberepaidDataGridViewTextBoxColumn,
            this.RepayPrincipal,
            this.RepayInterest});
            this.dataGridView1.DataSource = this.bondsTFAMToBeRepaidBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 339);
            this.dataGridView1.TabIndex = 34;
            // 
            // expired
            // 
            this.expired.DataPropertyName = "expired";
            dataGridViewCellStyle1.Format = "d";
            this.expired.DefaultCellStyle = dataGridViewCellStyle1;
            this.expired.HeaderText = "Expiry Date";
            this.expired.Name = "expired";
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Reference";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
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
            // bondsTFAMToBeRepaidBindingSource
            // 
            this.bondsTFAMToBeRepaidBindingSource.DataMember = "BondsTFAMToBeRepaid";
            this.bondsTFAMToBeRepaidBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bondsTFAMToBeRepaidTableAdapter
            // 
            this.bondsTFAMToBeRepaidTableAdapter.ClearBeforeFill = true;
            // 
            // BondsTFAMRepaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 447);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdRepay);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BondsTFAMRepaymentForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BondsTFAMRepaymentForm";
            this.Load += new System.EventHandler(this.BondsTFAMRepaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMToBeRepaidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRepay;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bondsTFAMToBeRepaidBindingSource;
        private FundsDBDataSetTableAdapters.BondsTFAMToBeRepaidTableAdapter bondsTFAMToBeRepaidTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expired;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounttoberepaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interesttoberepaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepayPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepayInterest;
    }
}