namespace FundsManager.ReportForms
{
    partial class LoanGeneratedInterestForm
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
            this.loanGeneratedInterestViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loanGeneratedInterestViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoanGeneratedInterestViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanGeneratedInterestViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.LoanGeneratedInterestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
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
            // loanGeneratedInterestViewBindingSource
            // 
            this.loanGeneratedInterestViewBindingSource.DataMember = "LoanGeneratedInterestView";
            this.loanGeneratedInterestViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // loanGeneratedInterestViewTableAdapter
            // 
            this.loanGeneratedInterestViewTableAdapter.ClearBeforeFill = true;
            // 
            // LoanGeneratedInterestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 472);
            this.Controls.Add(this.reportViewer1);
            this.Name = "LoanGeneratedInterestForm";
            this.Text = "Loan Generated Interest";
            this.Load += new System.EventHandler(this.LoanGeneratedInterestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loanGeneratedInterestViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource loanGeneratedInterestViewBindingSource;
        private FundsDBDataSetTableAdapters.LoanGeneratedInterestViewTableAdapter loanGeneratedInterestViewTableAdapter;
    }
}