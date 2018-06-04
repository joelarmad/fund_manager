namespace FundsManager
{
    partial class BankingAccountsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.currenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.banksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FK_BankingAccounts_Banks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ibanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FK_BankingAccounts_Currencies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bAccountsWithBanksCurrenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet1 = new FundsManager.FundsDBDataSet();
            this.bankingAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankingAccountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BankingAccountsTableAdapter();
            this.banksTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BanksTableAdapter();
            this.currenciesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CurrenciesTableAdapter();
            this.bAccountsWithBanksCurrenciesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BAccountsWithBanksCurrenciesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAccountsWithBanksCurrenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankingAccountsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "IBAN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Currency:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bank:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Amount:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.currenciesBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(293, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "Id";
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
            // comboBox2
            // 
            this.comboBox2.DataSource = this.banksBindingSource;
            this.comboBox2.DisplayMember = "name";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(293, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.ValueMember = "Id";
            // 
            // banksBindingSource
            // 
            this.banksBindingSource.DataMember = "Banks";
            this.banksBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(78, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(121, 20);
            this.textBox3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 547);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.FK_BankingAccounts_Banks,
            this.ibanDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.FK_BankingAccounts_Currencies});
            this.dataGridView1.DataSource = this.bAccountsWithBanksCurrenciesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(543, 338);
            this.dataGridView1.TabIndex = 12;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FK_BankingAccounts_Banks
            // 
            this.FK_BankingAccounts_Banks.DataPropertyName = "BankName";
            this.FK_BankingAccounts_Banks.HeaderText = "Bank";
            this.FK_BankingAccounts_Banks.Name = "FK_BankingAccounts_Banks";
            this.FK_BankingAccounts_Banks.ReadOnly = true;
            // 
            // ibanDataGridViewTextBoxColumn
            // 
            this.ibanDataGridViewTextBoxColumn.DataPropertyName = "iban";
            this.ibanDataGridViewTextBoxColumn.HeaderText = "Iban";
            this.ibanDataGridViewTextBoxColumn.Name = "ibanDataGridViewTextBoxColumn";
            this.ibanDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FK_BankingAccounts_Currencies
            // 
            this.FK_BankingAccounts_Currencies.DataPropertyName = "CurrencyCode";
            this.FK_BankingAccounts_Currencies.HeaderText = "Currency";
            this.FK_BankingAccounts_Currencies.Name = "FK_BankingAccounts_Currencies";
            this.FK_BankingAccounts_Currencies.ReadOnly = true;
            // 
            // bAccountsWithBanksCurrenciesBindingSource
            // 
            this.bAccountsWithBanksCurrenciesBindingSource.DataMember = "BAccountsWithBanksCurrencies";
            this.bAccountsWithBanksCurrenciesBindingSource.DataSource = this.fundsDBDataSet1;
            // 
            // fundsDBDataSet1
            // 
            this.fundsDBDataSet1.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bankingAccountsBindingSource
            // 
            this.bankingAccountsBindingSource.DataMember = "BankingAccounts";
            this.bankingAccountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // bankingAccountsTableAdapter
            // 
            this.bankingAccountsTableAdapter.ClearBeforeFill = true;
            // 
            // banksTableAdapter
            // 
            this.banksTableAdapter.ClearBeforeFill = true;
            // 
            // currenciesTableAdapter
            // 
            this.currenciesTableAdapter.ClearBeforeFill = true;
            // 
            // bAccountsWithBanksCurrenciesTableAdapter
            // 
            this.bAccountsWithBanksCurrenciesTableAdapter.ClearBeforeFill = true;
            // 
            // BankingAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BankingAccountsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Banking Accounts";
            this.Load += new System.EventHandler(this.BankingAccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAccountsWithBanksCurrenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankingAccountsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bankingAccountsBindingSource;
        private FundsDBDataSetTableAdapters.BankingAccountsTableAdapter bankingAccountsTableAdapter;
        private System.Windows.Forms.BindingSource banksBindingSource;
        private FundsDBDataSetTableAdapters.BanksTableAdapter banksTableAdapter;
        private System.Windows.Forms.BindingSource currenciesBindingSource;
        private FundsDBDataSetTableAdapters.CurrenciesTableAdapter currenciesTableAdapter;
        private FundsDBDataSet fundsDBDataSet1;
        private System.Windows.Forms.BindingSource bAccountsWithBanksCurrenciesBindingSource;
        private FundsDBDataSetTableAdapters.BAccountsWithBanksCurrenciesTableAdapter bAccountsWithBanksCurrenciesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FK_BankingAccounts_Banks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ibanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FK_BankingAccounts_Currencies;
    }
}