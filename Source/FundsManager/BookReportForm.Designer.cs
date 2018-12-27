namespace FundsManager
{
    partial class BookReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.disbursementsBookingViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disbursementsBookingViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementsBookingViewTableAdapter();
            this.disbursement_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbursementnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookingamountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookingprofitshareDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayinterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startingdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newcollectiondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsBookingViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbContract
            // 
            this.cbContract.DataSource = this.clientContractsBindingSource;
            this.cbContract.DisplayMember = "contract";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(331, 14);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(185, 21);
            this.cbContract.TabIndex = 7;
            this.cbContract.ValueMember = "investment_id";
            this.cbContract.SelectedIndexChanged += new System.EventHandler(this.cbContract_SelectedIndexChanged);
            // 
            // clientContractsBindingSource
            // 
            this.clientContractsBindingSource.DataMember = "ClientContracts";
            this.clientContractsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(48, 12);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(185, 21);
            this.cbClient.TabIndex = 6;
            this.cbClient.ValueMember = "Id";
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contract:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client:";
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // clientContractsTableAdapter
            // 
            this.clientContractsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disbursement_id,
            this.book_id,
            this.disbursementnumberDataGridViewTextBoxColumn,
            this.bookingamountDataGridViewTextBoxColumn,
            this.bookingprofitshareDataGridViewTextBoxColumn,
            this.delayinterestDataGridViewTextBoxColumn,
            this.startingdateDataGridViewTextBoxColumn,
            this.newcollectiondateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.disbursementsBookingViewBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 58);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(832, 244);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // disbursementsBookingViewBindingSource
            // 
            this.disbursementsBookingViewBindingSource.DataMember = "DisbursementsBookingView";
            this.disbursementsBookingViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // disbursementsBookingViewTableAdapter
            // 
            this.disbursementsBookingViewTableAdapter.ClearBeforeFill = true;
            // 
            // disbursement_id
            // 
            this.disbursement_id.DataPropertyName = "disbursement_id";
            this.disbursement_id.HeaderText = "disbursement_id";
            this.disbursement_id.Name = "disbursement_id";
            this.disbursement_id.ReadOnly = true;
            this.disbursement_id.Visible = false;
            // 
            // book_id
            // 
            this.book_id.DataPropertyName = "book_id";
            this.book_id.HeaderText = "book_id";
            this.book_id.Name = "book_id";
            this.book_id.ReadOnly = true;
            this.book_id.Visible = false;
            // 
            // disbursementnumberDataGridViewTextBoxColumn
            // 
            this.disbursementnumberDataGridViewTextBoxColumn.DataPropertyName = "disbursement_number";
            this.disbursementnumberDataGridViewTextBoxColumn.HeaderText = "Disbursement Number";
            this.disbursementnumberDataGridViewTextBoxColumn.Name = "disbursementnumberDataGridViewTextBoxColumn";
            this.disbursementnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.disbursementnumberDataGridViewTextBoxColumn.Width = 120;
            // 
            // bookingamountDataGridViewTextBoxColumn
            // 
            this.bookingamountDataGridViewTextBoxColumn.DataPropertyName = "booking_amount";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.bookingamountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.bookingamountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.bookingamountDataGridViewTextBoxColumn.Name = "bookingamountDataGridViewTextBoxColumn";
            this.bookingamountDataGridViewTextBoxColumn.ReadOnly = true;
            this.bookingamountDataGridViewTextBoxColumn.Width = 120;
            // 
            // bookingprofitshareDataGridViewTextBoxColumn
            // 
            this.bookingprofitshareDataGridViewTextBoxColumn.DataPropertyName = "booking_profit_share";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            this.bookingprofitshareDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.bookingprofitshareDataGridViewTextBoxColumn.HeaderText = "Profit Share";
            this.bookingprofitshareDataGridViewTextBoxColumn.Name = "bookingprofitshareDataGridViewTextBoxColumn";
            this.bookingprofitshareDataGridViewTextBoxColumn.ReadOnly = true;
            this.bookingprofitshareDataGridViewTextBoxColumn.Width = 120;
            // 
            // delayinterestDataGridViewTextBoxColumn
            // 
            this.delayinterestDataGridViewTextBoxColumn.DataPropertyName = "delay_interest";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            this.delayinterestDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.delayinterestDataGridViewTextBoxColumn.HeaderText = "Delay Interest";
            this.delayinterestDataGridViewTextBoxColumn.Name = "delayinterestDataGridViewTextBoxColumn";
            this.delayinterestDataGridViewTextBoxColumn.ReadOnly = true;
            this.delayinterestDataGridViewTextBoxColumn.Width = 120;
            // 
            // startingdateDataGridViewTextBoxColumn
            // 
            this.startingdateDataGridViewTextBoxColumn.DataPropertyName = "starting_date";
            dataGridViewCellStyle14.Format = "d";
            dataGridViewCellStyle14.NullValue = null;
            this.startingdateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.startingdateDataGridViewTextBoxColumn.HeaderText = "Starting Date";
            this.startingdateDataGridViewTextBoxColumn.Name = "startingdateDataGridViewTextBoxColumn";
            this.startingdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.startingdateDataGridViewTextBoxColumn.Width = 150;
            // 
            // newcollectiondateDataGridViewTextBoxColumn
            // 
            this.newcollectiondateDataGridViewTextBoxColumn.DataPropertyName = "new_collection_date";
            dataGridViewCellStyle15.Format = "d";
            this.newcollectiondateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.newcollectiondateDataGridViewTextBoxColumn.HeaderText = "New Collection Date";
            this.newcollectiondateDataGridViewTextBoxColumn.Name = "newcollectiondateDataGridViewTextBoxColumn";
            this.newcollectiondateDataGridViewTextBoxColumn.ReadOnly = true;
            this.newcollectiondateDataGridViewTextBoxColumn.Width = 150;
            // 
            // BookReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 322);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BookReportForm";
            this.Text = "Book Report";
            this.Load += new System.EventHandler(this.BookReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementsBookingViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource disbursementsBookingViewBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementsBookingViewTableAdapter disbursementsBookingViewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursement_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingprofitshareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayinterestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startingdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newcollectiondateDataGridViewTextBoxColumn;
    }
}