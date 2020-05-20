namespace FundsManager.ReportForms
{
    partial class BondGeneratedInterestForm
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
            this.bondGeneratedInterestViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bondGeneratedInterestViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BondGeneratedInterestViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondGeneratedInterestViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.BondGeneratedInterestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 16);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(847, 440);
            this.reportViewer1.TabIndex = 2;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bondGeneratedInterestViewBindingSource
            // 
            this.bondGeneratedInterestViewBindingSource.DataMember = "BondGeneratedInterestView";
            this.bondGeneratedInterestViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // bondGeneratedInterestViewTableAdapter
            // 
            this.bondGeneratedInterestViewTableAdapter.ClearBeforeFill = true;
            // 
            // BondGeneratedInterestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "BondGeneratedInterestForm";
            this.Text = "Bond Generated Interest";
            this.Load += new System.EventHandler(this.BondGeneratedInterestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bondGeneratedInterestViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bondGeneratedInterestViewBindingSource;
        private FundsDBDataSetTableAdapters.BondGeneratedInterestViewTableAdapter bondGeneratedInterestViewTableAdapter;
    }
}