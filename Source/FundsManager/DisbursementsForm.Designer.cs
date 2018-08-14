namespace FundsManager
{
    partial class DisbursementsForm
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
            this.lblAccount = new System.Windows.Forms.Label();
            this.cbOtherDetails = new System.Windows.Forms.ComboBox();
            this.otherDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSubAccount = new System.Windows.Forms.ComboBox();
            this.subaccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.subaccountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SubaccountsTableAdapter();
            this.otherDetailsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.OtherDetailsTableAdapter();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.investmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.investmentsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.InvestmentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.otherDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account:";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(68, 25);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(58, 13);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "<account>";
            // 
            // cbOtherDetails
            // 
            this.cbOtherDetails.DataSource = this.otherDetailsBindingSource;
            this.cbOtherDetails.DisplayMember = "name";
            this.cbOtherDetails.Enabled = false;
            this.cbOtherDetails.FormattingEnabled = true;
            this.cbOtherDetails.Location = new System.Drawing.Point(599, 24);
            this.cbOtherDetails.Name = "cbOtherDetails";
            this.cbOtherDetails.Size = new System.Drawing.Size(164, 21);
            this.cbOtherDetails.TabIndex = 9;
            this.cbOtherDetails.ValueMember = "Id";
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Other Account Details:";
            // 
            // cbSubAccount
            // 
            this.cbSubAccount.DataSource = this.subaccountsBindingSource;
            this.cbSubAccount.DisplayMember = "name";
            this.cbSubAccount.Enabled = false;
            this.cbSubAccount.FormattingEnabled = true;
            this.cbSubAccount.Location = new System.Drawing.Point(322, 23);
            this.cbSubAccount.Name = "cbSubAccount";
            this.cbSubAccount.Size = new System.Drawing.Size(138, 21);
            this.cbSubAccount.TabIndex = 7;
            this.cbSubAccount.ValueMember = "Id";
            this.cbSubAccount.SelectedIndexChanged += new System.EventHandler(this.cbSubAccount_SelectedIndexChanged);
            // 
            // subaccountsBindingSource
            // 
            this.subaccountsBindingSource.DataMember = "Subaccounts";
            this.subaccountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "SubAccount:";
            // 
            // subaccountsTableAdapter
            // 
            this.subaccountsTableAdapter.ClearBeforeFill = true;
            // 
            // otherDetailsTableAdapter
            // 
            this.otherDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(63, 64);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(182, 21);
            this.cbClient.TabIndex = 11;
            this.cbClient.ValueMember = "Id";
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Client:";
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // cbContract
            // 
            this.cbContract.DataSource = this.investmentsBindingSource;
            this.cbContract.DisplayMember = "contract";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(321, 64);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(182, 21);
            this.cbContract.TabIndex = 13;
            this.cbContract.ValueMember = "Id";
            // 
            // investmentsBindingSource
            // 
            this.investmentsBindingSource.DataMember = "Investments";
            this.investmentsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Contract:";
            // 
            // investmentsTableAdapter
            // 
            this.investmentsTableAdapter.ClearBeforeFill = true;
            // 
            // DisbursementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 578);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbOtherDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSubAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Disbursements";
            this.Load += new System.EventHandler(this.DisbursementsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.otherDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investmentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cbOtherDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSubAccount;
        private System.Windows.Forms.Label label2;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource subaccountsBindingSource;
        private FundsDBDataSetTableAdapters.SubaccountsTableAdapter subaccountsTableAdapter;
        private System.Windows.Forms.ToolStrip fillByAccountToolStrip;
        private System.Windows.Forms.ToolStripLabel accountIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox accountIdToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel fundIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox fundIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByAccountToolStripButton;
        private System.Windows.Forms.BindingSource otherDetailsBindingSource;
        private FundsDBDataSetTableAdapters.OtherDetailsTableAdapter otherDetailsTableAdapter;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource investmentsBindingSource;
        private FundsDBDataSetTableAdapters.InvestmentsTableAdapter investmentsTableAdapter;
    }
}