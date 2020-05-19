﻿namespace FundsManager.ReportForms
{
    partial class AccountReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.accountReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountReportTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountReportTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.accountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbSubAccount = new System.Windows.Forms.ComboBox();
            this.subaccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cmdFind = new System.Windows.Forms.Button();
            this.accountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountsTableAdapter();
            this.subaccountsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SubaccountsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.AccountReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(847, 440);
            this.reportViewer1.TabIndex = 1;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountReportBindingSource
            // 
            this.accountReportBindingSource.DataMember = "AccountReport";
            this.accountReportBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // accountReportTableAdapter
            // 
            this.accountReportTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sub Account:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Detail:";
            // 
            // cbAccount
            // 
            this.cbAccount.DataSource = this.accountsBindingSource;
            this.cbAccount.DisplayMember = "name";
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(82, 15);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(169, 21);
            this.cbAccount.TabIndex = 5;
            this.cbAccount.ValueMember = "Id";
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // accountsBindingSource
            // 
            this.accountsBindingSource.DataMember = "Accounts";
            this.accountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // cbSubAccount
            // 
            this.cbSubAccount.DataSource = this.subaccountsBindingSource;
            this.cbSubAccount.DisplayMember = "name";
            this.cbSubAccount.FormattingEnabled = true;
            this.cbSubAccount.Location = new System.Drawing.Point(82, 41);
            this.cbSubAccount.Name = "cbSubAccount";
            this.cbSubAccount.Size = new System.Drawing.Size(169, 21);
            this.cbSubAccount.TabIndex = 6;
            this.cbSubAccount.ValueMember = "Id";
            // 
            // subaccountsBindingSource
            // 
            this.subaccountsBindingSource.DataMember = "Subaccounts";
            this.subaccountsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(82, 70);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(169, 20);
            this.txtDetail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "From:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "To:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(305, 18);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(305, 44);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 11;
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(389, 70);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(116, 23);
            this.cmdFind.TabIndex = 12;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // accountsTableAdapter
            // 
            this.accountsTableAdapter.ClearBeforeFill = true;
            // 
            // subaccountsTableAdapter
            // 
            this.subaccountsTableAdapter.ClearBeforeFill = true;
            // 
            // AccountReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 557);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.cbSubAccount);
            this.Controls.Add(this.cbAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Account Report";
            this.Load += new System.EventHandler(this.AccountReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subaccountsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource accountReportBindingSource;
        private FundsDBDataSetTableAdapters.AccountReportTableAdapter accountReportTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.ComboBox cbSubAccount;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.BindingSource accountsBindingSource;
        private FundsDBDataSetTableAdapters.AccountsTableAdapter accountsTableAdapter;
        private System.Windows.Forms.BindingSource subaccountsBindingSource;
        private FundsDBDataSetTableAdapters.SubaccountsTableAdapter subaccountsTableAdapter;
    }
}