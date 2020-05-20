namespace FundsManager
{
    partial class BondsTFAMListForm
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
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.bondsTFAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bondsTFAMTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BondsTFAMTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interestonbondDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interesttffcontributionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bondsTFAMBindingSource
            // 
            this.bondsTFAMBindingSource.DataMember = "BondsTFAM";
            this.bondsTFAMBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // bondsTFAMTableAdapter
            // 
            this.bondsTFAMTableAdapter.ClearBeforeFill = true;
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
            this.issuedDataGridViewTextBoxColumn,
            this.expiredDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.interestonbondDataGridViewTextBoxColumn,
            this.interesttffcontributionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bondsTFAMBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(817, 439);
            this.dataGridView1.TabIndex = 1;
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
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // issuedDataGridViewTextBoxColumn
            // 
            this.issuedDataGridViewTextBoxColumn.DataPropertyName = "issued";
            this.issuedDataGridViewTextBoxColumn.HeaderText = "Issued";
            this.issuedDataGridViewTextBoxColumn.Name = "issuedDataGridViewTextBoxColumn";
            this.issuedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expiredDataGridViewTextBoxColumn
            // 
            this.expiredDataGridViewTextBoxColumn.DataPropertyName = "expired";
            this.expiredDataGridViewTextBoxColumn.HeaderText = "Expired";
            this.expiredDataGridViewTextBoxColumn.Name = "expiredDataGridViewTextBoxColumn";
            this.expiredDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interestonbondDataGridViewTextBoxColumn
            // 
            this.interestonbondDataGridViewTextBoxColumn.DataPropertyName = "interest_on_bond";
            this.interestonbondDataGridViewTextBoxColumn.HeaderText = "Interest on Bond";
            this.interestonbondDataGridViewTextBoxColumn.Name = "interestonbondDataGridViewTextBoxColumn";
            this.interestonbondDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // interesttffcontributionDataGridViewTextBoxColumn
            // 
            this.interesttffcontributionDataGridViewTextBoxColumn.DataPropertyName = "interest_tff_contribution";
            this.interesttffcontributionDataGridViewTextBoxColumn.HeaderText = "Interest TFF Contribution";
            this.interesttffcontributionDataGridViewTextBoxColumn.Name = "interesttffcontributionDataGridViewTextBoxColumn";
            this.interesttffcontributionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BondsTFAMListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 458);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BondsTFAMListForm";
            this.Text = "BondsTFAMListForm";
            this.Load += new System.EventHandler(this.BondsTFAMListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bondsTFAMBindingSource;
        private FundsDBDataSetTableAdapters.BondsTFAMTableAdapter bondsTFAMTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interestonbondDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn interesttffcontributionDataGridViewTextBoxColumn;
    }
}