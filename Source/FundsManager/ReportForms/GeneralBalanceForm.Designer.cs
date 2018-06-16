namespace FundsManager.ReportForms
{
    partial class GeneralBalanceForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.accountBalanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.balanceResumeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.accountBalanceTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountBalanceTableAdapter();
            this.balanceResumeTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BalanceResumeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceResumeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // accountBalanceBindingSource
            // 
            this.accountBalanceBindingSource.DataMember = "AccountBalance";
            this.accountBalanceBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // balanceResumeBindingSource
            // 
            this.balanceResumeBindingSource.DataMember = "BalanceResume";
            this.balanceResumeBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.accountBalanceBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.balanceResumeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.GeneralBalance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(797, 465);
            this.reportViewer1.TabIndex = 0;
            // 
            // accountBalanceTableAdapter
            // 
            this.accountBalanceTableAdapter.ClearBeforeFill = true;
            // 
            // balanceResumeTableAdapter
            // 
            this.balanceResumeTableAdapter.ClearBeforeFill = true;
            // 
            // GeneralBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 489);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralBalanceForm";
            this.Text = "Balance Sheet";
            this.Load += new System.EventHandler(this.GeneralBalanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceResumeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource accountBalanceBindingSource;
        private FundsDBDataSetTableAdapters.AccountBalanceTableAdapter accountBalanceTableAdapter;
        private System.Windows.Forms.BindingSource balanceResumeBindingSource;
        private FundsDBDataSetTableAdapters.BalanceResumeTableAdapter balanceResumeTableAdapter;
    }
}