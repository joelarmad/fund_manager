﻿namespace FundsManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.disbursement_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit_share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayinterestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbursementsBookingViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disbursementsBookingViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementsBookingViewTableAdapter();
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
            this.contract,
            this.number,
            this.amount,
            this.profit_share,
            this.delayinterestDataGridViewTextBoxColumn});
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
            // disbursement_id
            // 
            this.disbursement_id.DataPropertyName = "disbursement_id";
            this.disbursement_id.HeaderText = "disbursement_id";
            this.disbursement_id.Name = "disbursement_id";
            this.disbursement_id.ReadOnly = true;
            this.disbursement_id.Visible = false;
            // 
            // contract
            // 
            this.contract.DataPropertyName = "contract";
            this.contract.HeaderText = "Contract";
            this.contract.Name = "contract";
            this.contract.ReadOnly = true;
            // 
            // number
            // 
            this.number.DataPropertyName = "number";
            this.number.HeaderText = "Number";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            dataGridViewCellStyle1.Format = "N2";
            this.amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // profit_share
            // 
            this.profit_share.DataPropertyName = "profit_share";
            dataGridViewCellStyle2.Format = "N2";
            this.profit_share.DefaultCellStyle = dataGridViewCellStyle2;
            this.profit_share.HeaderText = "Profit Share";
            this.profit_share.Name = "profit_share";
            this.profit_share.ReadOnly = true;
            // 
            // delayinterestDataGridViewTextBoxColumn
            // 
            this.delayinterestDataGridViewTextBoxColumn.DataPropertyName = "delay_interest";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.delayinterestDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.delayinterestDataGridViewTextBoxColumn.HeaderText = "Delay Interest";
            this.delayinterestDataGridViewTextBoxColumn.Name = "delayinterestDataGridViewTextBoxColumn";
            this.delayinterestDataGridViewTextBoxColumn.ReadOnly = true;
            this.delayinterestDataGridViewTextBoxColumn.Width = 120;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingamountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookingprofitshareDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startingdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newcollectiondateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursement_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn contract;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit_share;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayinterestDataGridViewTextBoxColumn;
    }
}