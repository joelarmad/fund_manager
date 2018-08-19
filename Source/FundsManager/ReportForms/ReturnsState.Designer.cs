namespace FundsManager.ReportForms
{
    partial class ReturnsState
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.profitResultsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.profitsResumeViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.profitResultsViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ProfitResultsViewTableAdapter();
            this.profitsResumeViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ProfitsResumeViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsResumeViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.profitResultsViewBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.profitsResumeViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.ProfitsState.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(732, 410);
            this.reportViewer1.TabIndex = 3;
            // 
            // profitResultsViewBindingSource
            // 
            this.profitResultsViewBindingSource.DataMember = "ProfitResultsView";
            this.profitResultsViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // profitsResumeViewBindingSource
            // 
            this.profitsResumeViewBindingSource.DataMember = "ProfitsResumeView";
            this.profitsResumeViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // profitResultsViewTableAdapter
            // 
            this.profitResultsViewTableAdapter.ClearBeforeFill = true;
            // 
            // profitsResumeViewTableAdapter
            // 
            this.profitsResumeViewTableAdapter.ClearBeforeFill = true;
            // 
            // ReturnsState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 442);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnsState";
            this.Text = "Profit & Loss Statement";
            this.Load += new System.EventHandler(this.ReturnsState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsResumeViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource profitResultsViewBindingSource;
        private FundsDBDataSetTableAdapters.ProfitResultsViewTableAdapter profitResultsViewTableAdapter;
        private System.Windows.Forms.BindingSource profitsResumeViewBindingSource;
        private FundsDBDataSetTableAdapters.ProfitsResumeViewTableAdapter profitsResumeViewTableAdapter;
    }
}