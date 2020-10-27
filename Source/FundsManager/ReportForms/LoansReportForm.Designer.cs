namespace FundsManager.ReportForms
{
    partial class LoansReportForm
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
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loansReportViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loansReportViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.LoansReportViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansReportViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.LoansReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(25, 57);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(858, 490);
            this.reportViewer1.TabIndex = 5;
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(78, 12);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(185, 21);
            this.cbLender.TabIndex = 12;
            this.cbLender.ValueMember = "Id";
            this.cbLender.SelectedIndexChanged += new System.EventHandler(this.cbLender_SelectedIndexChanged);
            // 
            // creditorsBindingSource
            // 
            this.creditorsBindingSource.DataMember = "Creditors";
            this.creditorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Lender:";
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loansReportViewBindingSource
            // 
            this.loansReportViewBindingSource.DataMember = "LoansReportView";
            this.loansReportViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // loansReportViewTableAdapter
            // 
            this.loansReportViewTableAdapter.ClearBeforeFill = true;
            // 
            // LoansReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 572);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoansReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Loan Repayment";
            this.Load += new System.EventHandler(this.LoansReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loansReportViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbLender;
        private System.Windows.Forms.Label label1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.BindingSource loansReportViewBindingSource;
        private FundsDBDataSetTableAdapters.LoansReportViewTableAdapter loansReportViewTableAdapter;
    }
}