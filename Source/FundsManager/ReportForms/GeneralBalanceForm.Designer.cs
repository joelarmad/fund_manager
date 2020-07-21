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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cmdFilter = new System.Windows.Forms.Button();
            this.accountBalanceViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.accountBalanceViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountBalanceViewTableAdapter();
            this.accountBalanceClosedPeriodViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountBalanceClosedPeriodTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.AccountBalanceClosedPeriodTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceClosedPeriodViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.accountBalanceViewBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.GeneralBalance.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 70);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(797, 465);
            this.reportViewer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(54, 23);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(289, 22);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 5;
            this.cmdFilter.Text = "OK";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // accountBalanceViewBindingSource
            // 
            this.accountBalanceViewBindingSource.DataMember = "AccountBalanceView";
            this.accountBalanceViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountBalanceViewTableAdapter
            // 
            this.accountBalanceViewTableAdapter.ClearBeforeFill = true;
            // 
            // accountBalanceClosedPeriodViewBindingSource
            // 
            this.accountBalanceClosedPeriodViewBindingSource.DataMember = "AccountBalanceClosedPeriodView";
            this.accountBalanceClosedPeriodViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // accountBalanceClosedPeriodTableAdapter
            // 
            this.accountBalanceClosedPeriodTableAdapter.ClearBeforeFill = true;
            // 
            // GeneralBalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 555);
            this.Controls.Add(this.cmdFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralBalanceForm";
            this.Text = "Balance Sheet";
            this.Load += new System.EventHandler(this.GeneralBalanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBalanceClosedPeriodViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.BindingSource accountBalanceViewBindingSource;
        private FundsDBDataSetTableAdapters.AccountBalanceViewTableAdapter accountBalanceViewTableAdapter;
        private System.Windows.Forms.BindingSource accountBalanceClosedPeriodViewBindingSource;
        private FundsDBDataSetTableAdapters.AccountBalanceClosedPeriodTableAdapter accountBalanceClosedPeriodTableAdapter;
    }
}