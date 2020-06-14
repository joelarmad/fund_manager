namespace FundsManager.ReportForms
{
    partial class DealTrackingReportForm
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
            this.dealTrackingViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dealTrackingViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DealTrackingViewTableAdapter();
            this.cbContract = new System.Windows.Forms.ComboBox();
            this.clientContractsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.clientContractsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientContractsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealTrackingViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.DealTrackingReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 102);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1049, 440);
            this.reportViewer1.TabIndex = 3;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dealTrackingViewBindingSource
            // 
            this.dealTrackingViewBindingSource.DataMember = "DealTrackingView";
            this.dealTrackingViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // dealTrackingViewTableAdapter
            // 
            this.dealTrackingViewTableAdapter.ClearBeforeFill = true;
            // 
            // cbContract
            // 
            this.cbContract.DataSource = this.clientContractsBindingSource;
            this.cbContract.DisplayMember = "contract";
            this.cbContract.FormattingEnabled = true;
            this.cbContract.Location = new System.Drawing.Point(346, 14);
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
            // cbClient
            // 
            this.cbClient.DataSource = this.clientsBindingSource;
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(63, 12);
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
            this.label2.Location = new System.Drawing.Point(287, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contract:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
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
            // DealTrackingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 562);
            this.Controls.Add(this.cbContract);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DealTrackingReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DealTrackingReportForm";
            this.Load += new System.EventHandler(this.DealTrackingReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dealTrackingViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientContractsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource dealTrackingViewBindingSource;
        private FundsDBDataSetTableAdapters.DealTrackingViewTableAdapter dealTrackingViewTableAdapter;
        private System.Windows.Forms.ComboBox cbContract;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.BindingSource clientContractsBindingSource;
        private FundsDBDataSetTableAdapters.ClientContractsTableAdapter clientContractsTableAdapter;
    }
}