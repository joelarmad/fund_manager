namespace FundsManager
{
    partial class SubaccountsForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.accountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdAddOrSave = new System.Windows.Forms.Button();
            this.accountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountsTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKAccountsFundsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subaccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subaccountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SubaccountsTableAdapter();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.accountIdToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.accountIdToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByAcccountIdToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fillByAcccountIdToolStrip = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).BeginInit();
            this.fillByAcccountIdToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // cbAccount
            // 
            this.cbAccount.DataSource = this.accountsBindingSource;
            this.cbAccount.DisplayMember = "name";
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(75, 81);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(190, 21);
            this.cbAccount.TabIndex = 2;
            this.cbAccount.ValueMember = "Id";
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // accountsBindingSource
            // 
            this.accountsBindingSource.DataMember = "Accounts";
            this.accountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Account:";
            // 
            // cmdAddOrSave
            // 
            this.cmdAddOrSave.Location = new System.Drawing.Point(279, 80);
            this.cmdAddOrSave.Name = "cmdAddOrSave";
            this.cmdAddOrSave.Size = new System.Drawing.Size(78, 23);
            this.cmdAddOrSave.TabIndex = 4;
            this.cmdAddOrSave.Text = "Add";
            this.cmdAddOrSave.UseVisualStyleBackColor = true;
            this.cmdAddOrSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // accountsTableAdapter
            // 
            this.accountsTableAdapter.ClearBeforeFill = true;
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
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn,
            this.Account,
            this.fKAccountsFundsDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.subaccountsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(34, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(406, 253);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            this.nameDataGridViewTextBoxColumn.Width = 180;
            // 
            // fKSubaccountsAccountsDataGridViewTextBoxColumn
            // 
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.DataPropertyName = "FK_Subaccounts_Accounts";
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.HeaderText = "Account_Number";
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.Name = "fKSubaccountsAccountsDataGridViewTextBoxColumn";
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.ReadOnly = true;
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.Visible = false;
            this.fKSubaccountsAccountsDataGridViewTextBoxColumn.Width = 180;
            // 
            // Account
            // 
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // fKAccountsFundsDataGridViewTextBoxColumn
            // 
            this.fKAccountsFundsDataGridViewTextBoxColumn.DataPropertyName = "FK_Accounts_Funds";
            this.fKAccountsFundsDataGridViewTextBoxColumn.HeaderText = "FK_Accounts_Funds";
            this.fKAccountsFundsDataGridViewTextBoxColumn.Name = "fKAccountsFundsDataGridViewTextBoxColumn";
            this.fKAccountsFundsDataGridViewTextBoxColumn.ReadOnly = true;
            this.fKAccountsFundsDataGridViewTextBoxColumn.Visible = false;
            // 
            // subaccountsBindingSource
            // 
            this.subaccountsBindingSource.DataMember = "Subaccounts";
            this.subaccountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // subaccountsTableAdapter
            // 
            this.subaccountsTableAdapter.ClearBeforeFill = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(293, 405);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(108, 23);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(363, 81);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(78, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // accountIdToolStripLabel
            // 
            this.accountIdToolStripLabel.Name = "accountIdToolStripLabel";
            this.accountIdToolStripLabel.Size = new System.Drawing.Size(65, 22);
            this.accountIdToolStripLabel.Text = "AccountId:";
            // 
            // accountIdToolStripTextBox
            // 
            this.accountIdToolStripTextBox.Name = "accountIdToolStripTextBox";
            this.accountIdToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillByAcccountIdToolStripButton
            // 
            this.fillByAcccountIdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByAcccountIdToolStripButton.Name = "fillByAcccountIdToolStripButton";
            this.fillByAcccountIdToolStripButton.Size = new System.Drawing.Size(100, 22);
            this.fillByAcccountIdToolStripButton.Text = "FillByAcccountId";
            this.fillByAcccountIdToolStripButton.Click += new System.EventHandler(this.fillByAcccountIdToolStripButton_Click);
            // 
            // fillByAcccountIdToolStrip
            // 
            this.fillByAcccountIdToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountIdToolStripLabel,
            this.accountIdToolStripTextBox,
            this.fillByAcccountIdToolStripButton});
            this.fillByAcccountIdToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByAcccountIdToolStrip.Name = "fillByAcccountIdToolStrip";
            this.fillByAcccountIdToolStrip.Size = new System.Drawing.Size(478, 25);
            this.fillByAcccountIdToolStrip.TabIndex = 8;
            this.fillByAcccountIdToolStrip.Text = "fillByAcccountIdToolStrip";
            this.fillByAcccountIdToolStrip.Visible = false;
            // 
            // SubaccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 473);
            this.Controls.Add(this.fillByAcccountIdToolStrip);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdAddOrSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAccount);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SubaccountsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Subaccounts";
            this.Load += new System.EventHandler(this.SubaccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).EndInit();
            this.fillByAcccountIdToolStrip.ResumeLayout(false);
            this.fillByAcccountIdToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdAddOrSave;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource accountsBindingSource;
        private FundsDBDataSetTableAdapters.AccountsTableAdapter accountsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource subaccountsBindingSource;
        private FundsDBDataSetTableAdapters.SubaccountsTableAdapter subaccountsTableAdapter;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKSubaccountsAccountsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKAccountsFundsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ToolStripLabel accountIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox accountIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByAcccountIdToolStripButton;
        private System.Windows.Forms.ToolStrip fillByAcccountIdToolStrip;
    }
}