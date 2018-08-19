namespace FundsManager.ReportForms
{
    partial class DisbursementGeneratedInterestForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.disbursementGeneratedInterestViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.disbursementGeneratedInterestViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementGeneratedInterestViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGeneratedInterestViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsGeneratedInterest";
            reportDataSource1.Value = this.disbursementGeneratedInterestViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.DisbursementGeneratedInterestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(839, 432);
            this.reportViewer1.TabIndex = 0;
            // 
            // disbursementGeneratedInterestViewBindingSource
            // 
            this.disbursementGeneratedInterestViewBindingSource.DataMember = "DisbursementGeneratedInterestView";
            this.disbursementGeneratedInterestViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // disbursementGeneratedInterestViewTableAdapter
            // 
            this.disbursementGeneratedInterestViewTableAdapter.ClearBeforeFill = true;
            // 
            // DisbursementGeneratedInterestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 464);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementGeneratedInterestForm";
            this.Text = "Disbursement Generated Interests";
            this.Load += new System.EventHandler(this.DisbursementGeneratedInterestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.disbursementGeneratedInterestViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource disbursementGeneratedInterestViewBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementGeneratedInterestViewTableAdapter disbursementGeneratedInterestViewTableAdapter;
    }
}