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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.profitResultsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.profitResultsViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ProfitResultsViewTableAdapter();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // profitResultsViewBindingSource
            // 
            this.profitResultsViewBindingSource.DataMember = "ProfitResultsView";
            this.profitResultsViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.EnforceConstraints = false;
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = this.profitResultsViewBindingSource;
            reportDataSource6.Name = "DataSet2";
            reportDataSource6.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.ProfitsState.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 59);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(732, 443);
            this.reportViewer1.TabIndex = 3;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(285, 21);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 10;
            this.cmdFilter.Text = "OK";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Date:";
            // 
            // profitResultsViewTableAdapter
            // 
            this.profitResultsViewTableAdapter.ClearBeforeFill = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(50, 22);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 8;
            // 
            // ReturnsState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 514);
            this.Controls.Add(this.cmdFilter);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnsState";
            this.Text = "Profit & Loss Statement";
            this.Load += new System.EventHandler(this.ReturnsState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.profitResultsViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource profitResultsViewBindingSource;
        private FundsDBDataSetTableAdapters.ProfitResultsViewTableAdapter profitResultsViewTableAdapter;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
    }
}