﻿namespace FundsManager
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
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvDisbursements = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CollectionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisbursementDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PaidDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.dtpPayDate = new System.Windows.Forms.DateTimePicker();
            this.cmdPay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.cbClient.Location = new System.Drawing.Point(63, 15);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(182, 21);
            this.cbClient.TabIndex = 11;
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
            this.label4.Location = new System.Drawing.Point(26, 18);
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
            this.cbContract.DataSource = this.clientContractsBindingSource;
            this.cbContract.DisplayMember = "contract";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(321, 15);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(139, 21);
            this.cbContract.TabIndex = 13;
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
            this.label5.Location = new System.Drawing.Point(266, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Contract:";
            // 
            // clientContractsTableAdapter
            // 
            this.clientContractsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvDisbursements);
            this.groupBox1.Location = new System.Drawing.Point(15, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 248);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disbursements";
            // 
            // lvDisbursements
            // 
            this.lvDisbursements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Number,
            this.Amount,
            this.CollectionDate,
            this.DisbursementDate,
            this.PaidDate});
            this.lvDisbursements.FullRowSelect = true;
            this.lvDisbursements.HideSelection = false;
            this.lvDisbursements.Location = new System.Drawing.Point(14, 28);
            this.lvDisbursements.Name = "lvDisbursements";
            this.lvDisbursements.Size = new System.Drawing.Size(718, 200);
            this.lvDisbursements.TabIndex = 0;
            this.lvDisbursements.UseCompatibleStateImageBehavior = false;
            this.lvDisbursements.View = System.Windows.Forms.View.Details;
            this.lvDisbursements.SelectedIndexChanged += new System.EventHandler(this.lvDisbursements_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 0;
            // 
            // Number
            // 
            this.Number.Text = "Number";
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 100;
            // 
            // CollectionDate
            // 
            this.CollectionDate.Text = "Collection Date";
            this.CollectionDate.Width = 180;
            // 
            // DisbursementDate
            // 
            this.DisbursementDate.Text = "Disbursement Date";
            this.DisbursementDate.Width = 180;
            // 
            // PaidDate
            // 
            this.PaidDate.Text = "Paid Date";
            this.PaidDate.Width = 180;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pay Date:";
            // 
            // dtpPayDate
            // 
            this.dtpPayDate.Location = new System.Drawing.Point(540, 18);
            this.dtpPayDate.Name = "dtpPayDate";
            this.dtpPayDate.Size = new System.Drawing.Size(223, 20);
            this.dtpPayDate.TabIndex = 16;
            // 
            // cmdPay
            // 
            this.cmdPay.Location = new System.Drawing.Point(672, 54);
            this.cmdPay.Name = "cmdPay";
            this.cmdPay.Size = new System.Drawing.Size(75, 23);
            this.cmdPay.TabIndex = 17;
            this.cmdPay.Text = "Pay";
            this.cmdPay.UseVisualStyleBackColor = true;
            this.cmdPay.Click += new System.EventHandler(this.cmdPay_Click);
            // 
            // DisbursementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 341);
            this.Controls.Add(this.cmdPay);
            this.Controls.Add(this.dtpPayDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Disbursements";
            this.Load += new System.EventHandler(this.DisbursementsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.ToolStrip fillByAccountToolStrip;
        private System.Windows.Forms.ToolStripLabel accountIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox accountIdToolStripTextBox;
        private System.Windows.Forms.ToolStripLabel fundIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox fundIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByAccountToolStripButton;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvDisbursements;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader DisbursementDate;
        private System.Windows.Forms.ColumnHeader PaidDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpPayDate;
        private System.Windows.Forms.Button cmdPay;
        private System.Windows.Forms.ColumnHeader CollectionDate;
    }
}