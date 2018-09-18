namespace FundsManager
{
    partial class InvestmentsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.currenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbUnderlyingDebtor = new System.Windows.Forms.ComboBox();
            this.underlyingDebtorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currenciesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CurrenciesTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.banksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtProfitShare = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSector = new System.Windows.Forms.ComboBox();
            this.sectorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sectorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SectorsTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ItemsTableAdapter();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.lbISelectedItems = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalToBeCollected = new System.Windows.Forms.TextBox();
            this.cmdAddDisbursement = new System.Windows.Forms.Button();
            this.lvDisbursements = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdDeleteDisbursement = new System.Windows.Forms.Button();
            this.dtpDisbursementDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.cmdCreateInvestment = new System.Windows.Forms.Button();
            this.cmdDeleteItem = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.lblContractPrefix = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpCollectionDate = new System.Windows.Forms.DateTimePicker();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.underlyingDebtorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.UnderlyingDebtorsTableAdapter();
            this.banksTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BanksTableAdapter();
            this.cbLetterOfCredit = new System.Windows.Forms.ComboBox();
            this.letterofcreditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cbShipment = new System.Windows.Forms.ComboBox();
            this.shipmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.letter_of_creditsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.letter_of_creditsTableAdapter();
            this.shipmentsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ShipmentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.underlyingDebtorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterofcreditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(94, 16);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Text = "0";
            this.txtAmount.Click += new System.EventHandler(this.txtAmount_Click);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Currency:";
            // 
            // cbCurrency
            // 
            this.cbCurrency.DataSource = this.currenciesBindingSource;
            this.cbCurrency.DisplayMember = "name";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(94, 51);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(121, 21);
            this.cbCurrency.TabIndex = 2;
            this.cbCurrency.ValueMember = "Id";
            this.cbCurrency.SelectedIndexChanged += new System.EventHandler(this.cbCurrency_SelectedIndexChanged);
            this.cbCurrency.Leave += new System.EventHandler(this.cbCurrency_Leave);
            // 
            // currenciesBindingSource
            // 
            this.currenciesBindingSource.DataMember = "Currencies";
            this.currenciesBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Exchange Rate:";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(94, 88);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate.TabIndex = 3;
            this.txtExchangeRate.Text = "0.0";
            this.txtExchangeRate.Click += new System.EventHandler(this.txtExchangeRate_Click);
            this.txtExchangeRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExchangeRate_KeyUp);
            this.txtExchangeRate.Leave += new System.EventHandler(this.txtExchangeRate_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Client:";
            // 
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(348, 49);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(121, 21);
            this.cbClient.TabIndex = 7;
            this.cbClient.ValueMember = "Id";
            this.cbClient.SelectedIndexChanged += new System.EventHandler(this.cbClient_SelectedIndexChanged);
            this.cbClient.Leave += new System.EventHandler(this.cbClient_Leave);
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Underlying Debtor:";
            // 
            // cbUnderlyingDebtor
            // 
            this.cbUnderlyingDebtor.DataSource = this.underlyingDebtorsBindingSource;
            this.cbUnderlyingDebtor.DisplayMember = "name";
            this.cbUnderlyingDebtor.FormattingEnabled = true;
            this.cbUnderlyingDebtor.Location = new System.Drawing.Point(348, 84);
            this.cbUnderlyingDebtor.Name = "cbUnderlyingDebtor";
            this.cbUnderlyingDebtor.Size = new System.Drawing.Size(121, 21);
            this.cbUnderlyingDebtor.TabIndex = 8;
            this.cbUnderlyingDebtor.ValueMember = "Id";
            this.cbUnderlyingDebtor.SelectedIndexChanged += new System.EventHandler(this.cbUnderlyingDebtor_SelectedIndexChanged);
            this.cbUnderlyingDebtor.Leave += new System.EventHandler(this.cbUnderlyingDebtor_Leave);
            // 
            // underlyingDebtorsBindingSource
            // 
            this.underlyingDebtorsBindingSource.DataMember = "UnderlyingDebtors";
            this.underlyingDebtorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // currenciesTableAdapter
            // 
            this.currenciesTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Underlying Bank:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cbBank
            // 
            this.cbBank.DataSource = this.banksBindingSource;
            this.cbBank.DisplayMember = "name";
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(348, 119);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(121, 21);
            this.cbBank.TabIndex = 9;
            this.cbBank.ValueMember = "Id";
            this.cbBank.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            this.cbBank.Leave += new System.EventHandler(this.cbBank_Leave);
            // 
            // banksBindingSource
            // 
            this.banksBindingSource.DataMember = "Banks";
            this.banksBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Profit Share:";
            // 
            // txtProfitShare
            // 
            this.txtProfitShare.Location = new System.Drawing.Point(94, 125);
            this.txtProfitShare.Name = "txtProfitShare";
            this.txtProfitShare.Size = new System.Drawing.Size(121, 20);
            this.txtProfitShare.TabIndex = 4;
            this.txtProfitShare.Text = "1";
            this.txtProfitShare.Click += new System.EventHandler(this.txtProfitShare_Click);
            this.txtProfitShare.TextChanged += new System.EventHandler(this.txtProfitShare_TextChanged);
            this.txtProfitShare.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProfitShare_KeyUp);
            this.txtProfitShare.Leave += new System.EventHandler(this.txtProfitShare_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sector:";
            // 
            // cbSector
            // 
            this.cbSector.DataSource = this.sectorsBindingSource;
            this.cbSector.DisplayMember = "name";
            this.cbSector.FormattingEnabled = true;
            this.cbSector.Location = new System.Drawing.Point(348, 224);
            this.cbSector.Name = "cbSector";
            this.cbSector.Size = new System.Drawing.Size(121, 21);
            this.cbSector.TabIndex = 10;
            this.cbSector.ValueMember = "Id";
            this.cbSector.SelectedIndexChanged += new System.EventHandler(this.cbSector_SelectedIndexChanged);
            this.cbSector.Leave += new System.EventHandler(this.cbSector_Leave);
            // 
            // sectorsBindingSource
            // 
            this.sectorsBindingSource.DataMember = "Sectors";
            this.sectorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // sectorsTableAdapter
            // 
            this.sectorsTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(545, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Items:";
            // 
            // cbItems
            // 
            this.cbItems.DataSource = this.itemsBindingSource;
            this.cbItems.DisplayMember = "name";
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(586, 15);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(121, 21);
            this.cbItems.TabIndex = 11;
            this.cbItems.ValueMember = "Id";
            this.cbItems.SelectedIndexChanged += new System.EventHandler(this.cbItems_SelectedIndexChanged);
            this.cbItems.Leave += new System.EventHandler(this.cbItems_Leave);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataMember = "Items";
            this.itemsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // itemsTableAdapter
            // 
            this.itemsTableAdapter.ClearBeforeFill = true;
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(722, 13);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(75, 23);
            this.cmdAddItem.TabIndex = 12;
            this.cmdAddItem.Text = "Add Item";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            this.cmdAddItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbISelectedItems
            // 
            this.lbISelectedItems.FormattingEnabled = true;
            this.lbISelectedItems.Location = new System.Drawing.Point(586, 54);
            this.lbISelectedItems.Name = "lbISelectedItems";
            this.lbISelectedItems.Size = new System.Drawing.Size(120, 95);
            this.lbISelectedItems.TabIndex = 190;
            this.lbISelectedItems.SelectedIndexChanged += new System.EventHandler(this.lbISelectedItems_SelectedIndexChanged);
            this.lbISelectedItems.Leave += new System.EventHandler(this.lbISelectedItems_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Total to be Collected:";
            // 
            // txtTotalToBeCollected
            // 
            this.txtTotalToBeCollected.Location = new System.Drawing.Point(122, 225);
            this.txtTotalToBeCollected.Name = "txtTotalToBeCollected";
            this.txtTotalToBeCollected.ReadOnly = true;
            this.txtTotalToBeCollected.Size = new System.Drawing.Size(100, 20);
            this.txtTotalToBeCollected.TabIndex = 21;
            this.txtTotalToBeCollected.Text = "0.0";
            // 
            // cmdAddDisbursement
            // 
            this.cmdAddDisbursement.Enabled = false;
            this.cmdAddDisbursement.Location = new System.Drawing.Point(672, 223);
            this.cmdAddDisbursement.Name = "cmdAddDisbursement";
            this.cmdAddDisbursement.Size = new System.Drawing.Size(115, 23);
            this.cmdAddDisbursement.TabIndex = 15;
            this.cmdAddDisbursement.Text = "Add Disbursement";
            this.cmdAddDisbursement.UseVisualStyleBackColor = true;
            this.cmdAddDisbursement.Click += new System.EventHandler(this.button2_Click);
            // 
            // lvDisbursements
            // 
            this.lvDisbursements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader6,
            this.columnHeader7});
            this.lvDisbursements.Location = new System.Drawing.Point(12, 260);
            this.lvDisbursements.Name = "lvDisbursements";
            this.lvDisbursements.Size = new System.Drawing.Size(919, 270);
            this.lvDisbursements.TabIndex = 230;
            this.lvDisbursements.UseCompatibleStateImageBehavior = false;
            this.lvDisbursements.View = System.Windows.Forms.View.Details;
            this.lvDisbursements.SelectedIndexChanged += new System.EventHandler(this.lvDisbursements_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Client";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Underlying Debtor";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Amount";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Profit Share";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total to Collect";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Collection Date";
            this.columnHeader8.Width = 170;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Disbursement Date";
            this.columnHeader6.Width = 170;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Day";
            this.columnHeader7.Width = 50;
            // 
            // cmdDeleteDisbursement
            // 
            this.cmdDeleteDisbursement.Enabled = false;
            this.cmdDeleteDisbursement.Location = new System.Drawing.Point(793, 223);
            this.cmdDeleteDisbursement.Name = "cmdDeleteDisbursement";
            this.cmdDeleteDisbursement.Size = new System.Drawing.Size(121, 23);
            this.cmdDeleteDisbursement.TabIndex = 24;
            this.cmdDeleteDisbursement.Text = "Delete";
            this.cmdDeleteDisbursement.UseVisualStyleBackColor = true;
            this.cmdDeleteDisbursement.Click += new System.EventHandler(this.cmdDeleteDisbursement_Click);
            // 
            // dtpDisbursementDate
            // 
            this.dtpDisbursementDate.Location = new System.Drawing.Point(586, 162);
            this.dtpDisbursementDate.Name = "dtpDisbursementDate";
            this.dtpDisbursementDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDisbursementDate.TabIndex = 13;
            this.dtpDisbursementDate.ValueChanged += new System.EventHandler(this.dtpDisbursementDate_ValueChanged);
            this.dtpDisbursementDate.Leave += new System.EventHandler(this.dtpDisbursementDate_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(482, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Disbursement Date:";
            // 
            // cmdCreateInvestment
            // 
            this.cmdCreateInvestment.Enabled = false;
            this.cmdCreateInvestment.Location = new System.Drawing.Point(803, 536);
            this.cmdCreateInvestment.Name = "cmdCreateInvestment";
            this.cmdCreateInvestment.Size = new System.Drawing.Size(128, 23);
            this.cmdCreateInvestment.TabIndex = 27;
            this.cmdCreateInvestment.Text = "Create Investment";
            this.cmdCreateInvestment.UseVisualStyleBackColor = true;
            this.cmdCreateInvestment.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // cmdDeleteItem
            // 
            this.cmdDeleteItem.Enabled = false;
            this.cmdDeleteItem.Location = new System.Drawing.Point(722, 54);
            this.cmdDeleteItem.Name = "cmdDeleteItem";
            this.cmdDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.cmdDeleteItem.TabIndex = 28;
            this.cmdDeleteItem.Text = "Delete Item";
            this.cmdDeleteItem.UseVisualStyleBackColor = true;
            this.cmdDeleteItem.Click += new System.EventHandler(this.cmdDeleteItem_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(94, 161);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(121, 20);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(46, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Number:";
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(348, 15);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(121, 20);
            this.txtContract.TabIndex = 6;
            this.txtContract.Click += new System.EventHandler(this.txtContract_Click);
            this.txtContract.Enter += new System.EventHandler(this.txtContract_Enter);
            // 
            // lblContractPrefix
            // 
            this.lblContractPrefix.Location = new System.Drawing.Point(221, 19);
            this.lblContractPrefix.Name = "lblContractPrefix";
            this.lblContractPrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblContractPrefix.Size = new System.Drawing.Size(122, 13);
            this.lblContractPrefix.TabIndex = 31;
            this.lblContractPrefix.Text = "Contract:";
            this.lblContractPrefix.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(498, 193);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Collection Date:";
            // 
            // dtpCollectionDate
            // 
            this.dtpCollectionDate.Location = new System.Drawing.Point(586, 190);
            this.dtpCollectionDate.Name = "dtpCollectionDate";
            this.dtpCollectionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpCollectionDate.TabIndex = 14;
            this.dtpCollectionDate.Leave += new System.EventHandler(this.dtpCollectionDate_Leave);
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // underlyingDebtorsTableAdapter
            // 
            this.underlyingDebtorsTableAdapter.ClearBeforeFill = true;
            // 
            // banksTableAdapter
            // 
            this.banksTableAdapter.ClearBeforeFill = true;
            // 
            // cbLetterOfCredit
            // 
            this.cbLetterOfCredit.DataSource = this.letterofcreditsBindingSource;
            this.cbLetterOfCredit.DisplayMember = "Reference";
            this.cbLetterOfCredit.FormattingEnabled = true;
            this.cbLetterOfCredit.Location = new System.Drawing.Point(348, 154);
            this.cbLetterOfCredit.Name = "cbLetterOfCredit";
            this.cbLetterOfCredit.Size = new System.Drawing.Size(121, 21);
            this.cbLetterOfCredit.TabIndex = 231;
            this.cbLetterOfCredit.ValueMember = "Id";
            this.cbLetterOfCredit.SelectedIndexChanged += new System.EventHandler(this.cbLetterOfCredit_SelectedIndexChanged);
            // 
            // letterofcreditsBindingSource
            // 
            this.letterofcreditsBindingSource.DataMember = "letter_of_credits";
            this.letterofcreditsBindingSource.DataSource = this.fundsDBDataSetBindingSource;
            // 
            // fundsDBDataSetBindingSource
            // 
            this.fundsDBDataSetBindingSource.DataSource = this.fundsDBDataSet;
            this.fundsDBDataSetBindingSource.Position = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(261, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 232;
            this.label14.Text = "Letter of Credit:";
            // 
            // cbShipment
            // 
            this.cbShipment.DataSource = this.shipmentsBindingSource;
            this.cbShipment.DisplayMember = "Number";
            this.cbShipment.FormattingEnabled = true;
            this.cbShipment.Location = new System.Drawing.Point(348, 189);
            this.cbShipment.Name = "cbShipment";
            this.cbShipment.Size = new System.Drawing.Size(121, 21);
            this.cbShipment.TabIndex = 233;
            this.cbShipment.ValueMember = "Id";
            this.cbShipment.SelectedIndexChanged += new System.EventHandler(this.cbShipment_SelectedIndexChanged);
            // 
            // shipmentsBindingSource
            // 
            this.shipmentsBindingSource.DataMember = "Shipments";
            this.shipmentsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(286, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 234;
            this.label15.Text = "Shipment:";
            // 
            // letter_of_creditsTableAdapter
            // 
            this.letter_of_creditsTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentsTableAdapter
            // 
            this.shipmentsTableAdapter.ClearBeforeFill = true;
            // 
            // InvestmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 579);
            this.Controls.Add(this.cbShipment);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbLetterOfCredit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpCollectionDate);
            this.Controls.Add(this.txtContract);
            this.Controls.Add(this.lblContractPrefix);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdDeleteItem);
            this.Controls.Add(this.cmdCreateInvestment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpDisbursementDate);
            this.Controls.Add(this.cmdDeleteDisbursement);
            this.Controls.Add(this.lvDisbursements);
            this.Controls.Add(this.cmdAddDisbursement);
            this.Controls.Add(this.txtTotalToBeCollected);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbISelectedItems);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.cbItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbSector);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProfitShare);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbUnderlyingDebtor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExchangeRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InvestmentsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Investments";
            this.Load += new System.EventHandler(this.InvestmentsForm_Load);
            this.Click += new System.EventHandler(this.DisbursementsForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.underlyingDebtorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.letterofcreditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUnderlyingDebtor;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource currenciesBindingSource;
        private FundsDBDataSetTableAdapters.CurrenciesTableAdapter currenciesTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProfitShare;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSector;
        private System.Windows.Forms.BindingSource sectorsBindingSource;
        private FundsDBDataSetTableAdapters.SectorsTableAdapter sectorsTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private FundsDBDataSetTableAdapters.ItemsTableAdapter itemsTableAdapter;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.ListBox lbISelectedItems;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalToBeCollected;
        private System.Windows.Forms.Button cmdAddDisbursement;
        private System.Windows.Forms.ListView lvDisbursements;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button cmdDeleteDisbursement;
        private System.Windows.Forms.DateTimePicker dtpDisbursementDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button cmdCreateInvestment;
        private System.Windows.Forms.Button cmdDeleteItem;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label lblContractPrefix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpCollectionDate;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource underlyingDebtorsBindingSource;
        private FundsDBDataSetTableAdapters.UnderlyingDebtorsTableAdapter underlyingDebtorsTableAdapter;
        private System.Windows.Forms.BindingSource banksBindingSource;
        private FundsDBDataSetTableAdapters.BanksTableAdapter banksTableAdapter;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox cbLetterOfCredit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbShipment;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.BindingSource fundsDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource letterofcreditsBindingSource;
        private FundsDBDataSetTableAdapters.letter_of_creditsTableAdapter letter_of_creditsTableAdapter;
        private System.Windows.Forms.BindingSource shipmentsBindingSource;
        private FundsDBDataSetTableAdapters.ShipmentsTableAdapter shipmentsTableAdapter;
    }
}