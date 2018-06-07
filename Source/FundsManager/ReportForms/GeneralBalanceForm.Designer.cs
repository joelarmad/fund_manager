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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.fundsDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SubAccountBalanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subAccountBalanceBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subAccountBalanceTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.SubAccountBalanceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubAccountBalanceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subAccountBalanceBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.subAccountBalanceBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.GeneralBalance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 27);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(797, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Under construction....";
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fundsDBDataSetBindingSource
            // 
            this.fundsDBDataSetBindingSource.DataSource = this.fundsDBDataSet;
            this.fundsDBDataSetBindingSource.Position = 0;
            // 
            // SubAccountBalanceBindingSource
            // 
            this.SubAccountBalanceBindingSource.DataMember = "SubAccountBalance";
            this.SubAccountBalanceBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // subAccountBalanceBindingSource1
            // 
            this.subAccountBalanceBindingSource1.DataMember = "SubAccountBalance";
            this.subAccountBalanceBindingSource1.DataSource = this.fundsDBDataSet;
            // 
            // subAccountBalanceTableAdapter
            // 
            this.subAccountBalanceTableAdapter.ClearBeforeFill = true;
            // 
            // GeneralBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 489);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralBalanceForm";
            this.Text = "General Balance";
            this.Load += new System.EventHandler(this.GeneralBalanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubAccountBalanceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subAccountBalanceBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource fundsDBDataSetBindingSource;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource SubAccountBalanceBindingSource;
        private System.Windows.Forms.BindingSource subAccountBalanceBindingSource1;
        private FundsDBDataSetTableAdapters.SubAccountBalanceTableAdapter subAccountBalanceTableAdapter;
    }
}