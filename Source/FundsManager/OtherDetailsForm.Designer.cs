﻿namespace FundsManager
{
    partial class OtherDetailsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubAccount = new System.Windows.Forms.ComboBox();
            this.subaccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.subaccountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SubaccountsTableAdapter();
            this.otherDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.otherDetailsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.OtherDetailsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subacctidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Account:";
            // 
            // cbSubAccount
            // 
            this.cbSubAccount.DataSource = this.subaccountsBindingSource;
            this.cbSubAccount.DisplayMember = "name";
            this.cbSubAccount.FormattingEnabled = true;
            this.cbSubAccount.Location = new System.Drawing.Point(94, 68);
            this.cbSubAccount.Name = "cbSubAccount";
            this.cbSubAccount.Size = new System.Drawing.Size(131, 21);
            this.cbSubAccount.TabIndex = 5;
            this.cbSubAccount.ValueMember = "Id";
            // 
            // subaccountsBindingSource
            // 
            this.subaccountsBindingSource.DataMember = "Subaccounts";
            this.subaccountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn,
            this.subacctidDataGridViewTextBoxColumn,
            this.Sub_Account});
            this.dataGridView1.DataSource = this.otherDetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(376, 278);
            this.dataGridView1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // subaccountsTableAdapter
            // 
            this.subaccountsTableAdapter.ClearBeforeFill = true;
            // 
            // otherDetailsBindingSource
            // 
            this.otherDetailsBindingSource.DataMember = "OtherDetails";
            this.otherDetailsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // otherDetailsTableAdapter
            // 
            this.otherDetailsTableAdapter.ClearBeforeFill = true;
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
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // fKOtherDetailsFundsDataGridViewTextBoxColumn
            // 
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn.DataPropertyName = "FK_OtherDetails_Funds";
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn.HeaderText = "FK_OtherDetails_Funds";
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn.Name = "fKOtherDetailsFundsDataGridViewTextBoxColumn";
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn.ReadOnly = true;
            this.fKOtherDetailsFundsDataGridViewTextBoxColumn.Visible = false;
            // 
            // subacctidDataGridViewTextBoxColumn
            // 
            this.subacctidDataGridViewTextBoxColumn.DataPropertyName = "subacct_id";
            this.subacctidDataGridViewTextBoxColumn.HeaderText = "subacct_id";
            this.subacctidDataGridViewTextBoxColumn.Name = "subacctidDataGridViewTextBoxColumn";
            this.subacctidDataGridViewTextBoxColumn.ReadOnly = true;
            this.subacctidDataGridViewTextBoxColumn.Visible = false;
            // 
            // Sub_Account
            // 
            this.Sub_Account.HeaderText = "Sub Account";
            this.Sub_Account.Name = "Sub_Account";
            this.Sub_Account.ReadOnly = true;
            this.Sub_Account.Width = 200;
            // 
            // OtherDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 405);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbSubAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OtherDetailsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Other Account Details";
            this.Load += new System.EventHandler(this.OtherDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.otherDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubAccount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKOtherDetailsAccountsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource subaccountsBindingSource;
        private FundsDBDataSetTableAdapters.SubaccountsTableAdapter subaccountsTableAdapter;
        private System.Windows.Forms.BindingSource otherDetailsBindingSource;
        private FundsDBDataSetTableAdapters.OtherDetailsTableAdapter otherDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKOtherDetailsFundsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subacctidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_Account;
    }
}