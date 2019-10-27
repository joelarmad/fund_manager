namespace FundsManager
{
    partial class AddendumsLauncher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.disbursementsForAddendumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            this.disbursementsForAddendumsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementsForAddendumsTableAdapter();
            this.disbursementidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitshareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectiondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsForAddendumsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contract:";
            // 
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(50, 18);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(185, 21);
            this.cbClient.TabIndex = 2;
            this.cbClient.ValueMember = "Id";
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
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
            this.cbContract.Location = new System.Drawing.Point(333, 20);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(185, 21);
            this.cbContract.TabIndex = 3;
            this.cbContract.ValueMember = "investment_id";
            this.cbContract.SelectedIndexChanged += new System.EventHandler(this.cbContract_SelectedIndexChanged);
            // 
            // clientContractsBindingSource
            // 
            this.clientContractsBindingSource.DataMember = "ClientContracts";
            this.clientContractsBindingSource.DataSource = this.fundsDBDataSet;
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
            this.amountDataGridViewTextBoxColumn,
            this.profitshareDataGridViewTextBoxColumn,
            this.collectiondateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.disbursementsForAddendumsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(11, 67);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(735, 244);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // disbursementsForAddendumsBindingSource
            // 
            this.disbursementsForAddendumsBindingSource.DataMember = "DisbursementsForAddendums";
            this.disbursementsForAddendumsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // clientContractsTableAdapter
            // 
            this.clientContractsTableAdapter.ClearBeforeFill = true;
            // 
            // disbursementsForAddendumsTableAdapter
            // 
            this.disbursementsForAddendumsTableAdapter.ClearBeforeFill = true;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.numberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Investment";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profitshareDataGridViewTextBoxColumn
            // 
            this.profitshareDataGridViewTextBoxColumn.DataPropertyName = "profit_share";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.profitshareDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.profitshareDataGridViewTextBoxColumn.HeaderText = "Profit Share";
            this.profitshareDataGridViewTextBoxColumn.Name = "profitshareDataGridViewTextBoxColumn";
            this.profitshareDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // collectiondateDataGridViewTextBoxColumn
            // 
            this.collectiondateDataGridViewTextBoxColumn.DataPropertyName = "collection_date";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.collectiondateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.collectiondateDataGridViewTextBoxColumn.HeaderText = "Collection Date";
            this.collectiondateDataGridViewTextBoxColumn.Name = "collectiondateDataGridViewTextBoxColumn";
            this.collectiondateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // AddendumsLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 331);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddendumsLauncher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addendums";
            this.Load += new System.EventHandler(this.AddendumsLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsForAddendumsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
        private System.Windows.Forms.BindingSource disbursementsForAddendumsBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementsForAddendumsTableAdapter disbursementsForAddendumsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn toBeCollectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitshareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectiondateDataGridViewTextBoxColumn;
    }
}