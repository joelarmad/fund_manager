namespace FundsManager
{
    partial class DisbursementCollectionForm
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
            this.cmdCollect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.disbursementsToBeCollectedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.disbursementsToBeCollectedTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementsToBeCollectedTableAdapter();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.disbursementidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collection_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toBeCollected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collect125 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collect128 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Collect130 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsToBeCollectedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCollect
            // 
            this.cmdCollect.Location = new System.Drawing.Point(683, 51);
            this.cmdCollect.Name = "cmdCollect";
            this.cmdCollect.Size = new System.Drawing.Size(75, 23);
            this.cmdCollect.TabIndex = 25;
            this.cmdCollect.Text = "Collect";
            this.cmdCollect.UseVisualStyleBackColor = true;
            this.cmdCollect.Click += new System.EventHandler(this.cmdCollect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(8, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 248);
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
            this.disbursementidDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.collection_date,
            this.amount,
            this.amountDataGridViewTextBoxColumn,
            this.toBeCollected,
            this.DelayInterest,
            this.Collect125,
            this.Collect128,
            this.Collect130});
            this.dataGridView1.DataSource = this.disbursementsToBeCollectedBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(14, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(909, 212);
            this.dataGridView1.TabIndex = 0;
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
            this.cbContract.ValueMember = "investment_id";
            this.cbContract.SelectedIndexChanged += new System.EventHandler(this.cbContract_SelectedIndexChanged);
            // 
            // clientContractsBindingSource
            // 
            this.clientContractsBindingSource.DataMember = "ClientContracts";
            this.clientContractsBindingSource.DataSource = this.fundsDBDataSet;
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
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
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
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // clientContractsTableAdapter
            // 
            this.clientContractsTableAdapter.ClearBeforeFill = true;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(559, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Collection Date:";
            // 
            // disbursementidDataGridViewTextBoxColumn
            // 
            this.disbursementidDataGridViewTextBoxColumn.DataPropertyName = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.HeaderText = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.Name = "disbursementidDataGridViewTextBoxColumn";
            this.disbursementidDataGridViewTextBoxColumn.ReadOnly = true;
            this.disbursementidDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 60;
            // 
            // collection_date
            // 
            this.collection_date.DataPropertyName = "collection_date";
            this.collection_date.HeaderText = "Collection Date";
            this.collection_date.Name = "collection_date";
            this.collection_date.ReadOnly = true;
            this.collection_date.Width = 120;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Disbursement";
            this.amount.Name = "amount";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount_remainig";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 70;
            // 
            // toBeCollected
            // 
            this.toBeCollected.DataPropertyName = "profit_share_accrued_remaining";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.toBeCollected.DefaultCellStyle = dataGridViewCellStyle2;
            this.toBeCollected.HeaderText = "Profit Share";
            this.toBeCollected.Name = "toBeCollected";
            this.toBeCollected.ReadOnly = true;
            // 
            // DelayInterest
            // 
            this.DelayInterest.DataPropertyName = "delay_interest_accrued_remaining";
            this.DelayInterest.HeaderText = "Delay Interest";
            this.DelayInterest.Name = "DelayInterest";
            this.DelayInterest.ReadOnly = true;
            // 
            // Collect125
            // 
            this.Collect125.HeaderText = "Collect to 125";
            this.Collect125.Name = "Collect125";
            // 
            // Collect128
            // 
            this.Collect128.HeaderText = "Collect to 128";
            this.Collect128.Name = "Collect128";
            // 
            // Collect130
            // 
            this.Collect130.HeaderText = "Collect to 130";
            this.Collect130.Name = "Collect130";
            // 
            // DisbursementCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 339);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCollect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementCollectionForm";
            this.Text = "Collection";
            this.Load += new System.EventHandler(this.DisbursementCollectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsToBeCollectedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCollect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label4;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource disbursementsToBeCollectedBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementsToBeCollectedTableAdapter disbursementsToBeCollectedTableAdapter;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collection_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toBeCollected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayInterest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collect125;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collect128;
        private System.Windows.Forms.DataGridViewTextBoxColumn Collect130;
    }
}