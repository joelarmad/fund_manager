namespace FundsManager
{
    partial class DisbursementCollection
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
            this.cmdPay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fundidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbursementidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.investmentidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectiondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paydateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cangenerateinterestDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitshareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbursementsToBeCollectedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.disbursementsToBeCollectedTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementsToBeCollectedTableAdapter();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsToBeCollectedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdPay
            // 
            this.cmdPay.Location = new System.Drawing.Point(665, 51);
            this.cmdPay.Name = "cmdPay";
            this.cmdPay.Size = new System.Drawing.Size(75, 23);
            this.cmdPay.TabIndex = 25;
            this.cmdPay.Text = "Pay";
            this.cmdPay.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(8, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 248);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disbursements";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fundidDataGridViewTextBoxColumn,
            this.contractDataGridViewTextBoxColumn,
            this.disbursementidDataGridViewTextBoxColumn,
            this.investmentidDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.collectiondateDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.paydateDataGridViewTextBoxColumn,
            this.cangenerateinterestDataGridViewCheckBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.profitshareDataGridViewTextBoxColumn,
            this.collectedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.disbursementsToBeCollectedBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(718, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // fundidDataGridViewTextBoxColumn
            // 
            this.fundidDataGridViewTextBoxColumn.DataPropertyName = "fund_id";
            this.fundidDataGridViewTextBoxColumn.HeaderText = "fund_id";
            this.fundidDataGridViewTextBoxColumn.Name = "fundidDataGridViewTextBoxColumn";
            this.fundidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contractDataGridViewTextBoxColumn
            // 
            this.contractDataGridViewTextBoxColumn.DataPropertyName = "contract";
            this.contractDataGridViewTextBoxColumn.HeaderText = "contract";
            this.contractDataGridViewTextBoxColumn.Name = "contractDataGridViewTextBoxColumn";
            this.contractDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // disbursementidDataGridViewTextBoxColumn
            // 
            this.disbursementidDataGridViewTextBoxColumn.DataPropertyName = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.HeaderText = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.Name = "disbursementidDataGridViewTextBoxColumn";
            this.disbursementidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // investmentidDataGridViewTextBoxColumn
            // 
            this.investmentidDataGridViewTextBoxColumn.DataPropertyName = "investment_id";
            this.investmentidDataGridViewTextBoxColumn.HeaderText = "investment_id";
            this.investmentidDataGridViewTextBoxColumn.Name = "investmentidDataGridViewTextBoxColumn";
            this.investmentidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // collectiondateDataGridViewTextBoxColumn
            // 
            this.collectiondateDataGridViewTextBoxColumn.DataPropertyName = "collection_date";
            this.collectiondateDataGridViewTextBoxColumn.HeaderText = "collection_date";
            this.collectiondateDataGridViewTextBoxColumn.Name = "collectiondateDataGridViewTextBoxColumn";
            this.collectiondateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paydateDataGridViewTextBoxColumn
            // 
            this.paydateDataGridViewTextBoxColumn.DataPropertyName = "pay_date";
            this.paydateDataGridViewTextBoxColumn.HeaderText = "pay_date";
            this.paydateDataGridViewTextBoxColumn.Name = "paydateDataGridViewTextBoxColumn";
            this.paydateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cangenerateinterestDataGridViewCheckBoxColumn
            // 
            this.cangenerateinterestDataGridViewCheckBoxColumn.DataPropertyName = "can_generate_interest";
            this.cangenerateinterestDataGridViewCheckBoxColumn.HeaderText = "can_generate_interest";
            this.cangenerateinterestDataGridViewCheckBoxColumn.Name = "cangenerateinterestDataGridViewCheckBoxColumn";
            this.cangenerateinterestDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profitshareDataGridViewTextBoxColumn
            // 
            this.profitshareDataGridViewTextBoxColumn.DataPropertyName = "profit_share";
            this.profitshareDataGridViewTextBoxColumn.HeaderText = "profit_share";
            this.profitshareDataGridViewTextBoxColumn.Name = "profitshareDataGridViewTextBoxColumn";
            this.profitshareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // collectedDataGridViewTextBoxColumn
            // 
            this.collectedDataGridViewTextBoxColumn.DataPropertyName = "collected";
            this.collectedDataGridViewTextBoxColumn.HeaderText = "collected";
            this.collectedDataGridViewTextBoxColumn.Name = "collectedDataGridViewTextBoxColumn";
            this.collectedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // disbursementsToBeCollectedBindingSource
            // 
            this.disbursementsToBeCollectedBindingSource.DataMember = "DisbursementsToBeCollected";
            this.disbursementsToBeCollectedBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbContract
            // 
            this.cbContract.DataSource = this.clientContractsBindingSource;
            this.cbContract.DisplayMember = "contract";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(314, 12);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(139, 21);
            this.cbContract.TabIndex = 21;
            this.cbContract.ValueMember = "contract";
            this.cbContract.SelectedIndexChanged += new System.EventHandler(this.cbContract_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Contract:";
            // 
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(56, 12);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(182, 21);
            this.cbClient.TabIndex = 19;
            this.cbClient.ValueMember = "Id";
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Client:";
            // 
            // disbursementsToBeCollectedTableAdapter
            // 
            this.disbursementsToBeCollectedTableAdapter.ClearBeforeFill = true;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // clientContractsBindingSource
            // 
            this.clientContractsBindingSource.DataMember = "ClientContracts";
            this.clientContractsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // clientContractsTableAdapter
            // 
            this.clientContractsTableAdapter.ClearBeforeFill = true;
            // 
            // DisbursementCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 522);
            this.Controls.Add(this.cmdPay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementCollection";
            this.Text = "Disbursement Collection";
            this.Load += new System.EventHandler(this.DisbursementCollection_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsToBeCollectedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdPay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label4;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource disbursementsToBeCollectedBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementsToBeCollectedTableAdapter disbursementsToBeCollectedTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn fundidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn investmentidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectiondateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paydateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cangenerateinterestDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitshareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
    }
}