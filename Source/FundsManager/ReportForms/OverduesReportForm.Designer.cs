namespace FundsManager.ReportForms
{
    partial class OverduesReportForm
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
            this.disbursementOverdueGeneratedViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disbursementOverdueGeneratedViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.DisbursementOverdueGeneratedViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementOverdueGeneratedViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.DisbursementOverduesGeneratedReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 18);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(889, 440);
            this.reportViewer1.TabIndex = 3;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // disbursementOverdueGeneratedViewBindingSource
            // 
            this.disbursementOverdueGeneratedViewBindingSource.DataMember = "DisbursementOverdueGeneratedView";
            this.disbursementOverdueGeneratedViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // disbursementOverdueGeneratedViewTableAdapter
            // 
            this.disbursementOverdueGeneratedViewTableAdapter.ClearBeforeFill = true;
            // 
            // OverduesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 478);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OverduesReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Overdues Report";
            this.Load += new System.EventHandler(this.OverduesReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.disbursementOverdueGeneratedViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource disbursementOverdueGeneratedViewBindingSource;
        private FundsDBDataSetTableAdapters.DisbursementOverdueGeneratedViewTableAdapter disbursementOverdueGeneratedViewTableAdapter;
    }
}