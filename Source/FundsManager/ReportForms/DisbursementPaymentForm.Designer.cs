namespace FundsManager.ReportForms
{
    partial class DisbursementPaymentForm
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
            this.investmentsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.investmentsViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.InvestmentsViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.investmentsViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsDisbursemets";
            reportDataSource1.Value = this.investmentsViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.DisbursementPaymentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(963, 465);
            this.reportViewer1.TabIndex = 1;
            // 
            // investmentsViewBindingSource
            // 
            this.investmentsViewBindingSource.DataMember = "InvestmentsView";
            this.investmentsViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // investmentsViewTableAdapter
            // 
            this.investmentsViewTableAdapter.ClearBeforeFill = true;
            // 
            // DisbursementPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 497);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DisbursementPaymentForm";
            this.Text = "Disbursement Payments";
            this.Load += new System.EventHandler(this.DisbursementPaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.investmentsViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource investmentsViewBindingSource;
        private FundsDBDataSetTableAdapters.InvestmentsViewTableAdapter investmentsViewTableAdapter;
    }
}