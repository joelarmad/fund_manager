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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.profitResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.profitResultsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ProfitResultsTableAdapter();
            this.profitsResumeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.profitsResumeTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ProfitsResumeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsResumeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // profitResultsBindingSource
            // 
            this.profitResultsBindingSource.DataMember = "ProfitResults";
            this.profitResultsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Under construction....";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.profitResultsBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.profitsResumeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.ProfitsState.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 25);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(732, 397);
            this.reportViewer1.TabIndex = 3;
            // 
            // profitResultsTableAdapter
            // 
            this.profitResultsTableAdapter.ClearBeforeFill = true;
            // 
            // profitsResumeBindingSource
            // 
            this.profitsResumeBindingSource.DataMember = "ProfitsResume";
            this.profitsResumeBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // profitsResumeTableAdapter
            // 
            this.profitsResumeTableAdapter.ClearBeforeFill = true;
            // 
            // ReturnsState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 434);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnsState";
            this.Text = "ReturnsState";
            this.Load += new System.EventHandler(this.ReturnsState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profitsResumeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource profitResultsBindingSource;
        private FundsDBDataSetTableAdapters.ProfitResultsTableAdapter profitResultsTableAdapter;
        private System.Windows.Forms.BindingSource profitsResumeBindingSource;
        private FundsDBDataSetTableAdapters.ProfitsResumeTableAdapter profitsResumeTableAdapter;
    }
}