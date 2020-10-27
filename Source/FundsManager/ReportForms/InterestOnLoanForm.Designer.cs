namespace FundsManager.ReportForms
{
    partial class InterestOnLoanForm
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
            this.cmdFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLender = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.creditorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.creditorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CreditorsTableAdapter();
            this.loans1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.loans1TableAdapter = new FundsManager.FundsDBDataSetTableAdapters.Loans1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loans1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdFilter
            // 
            this.cmdFilter.Location = new System.Drawing.Point(298, 38);
            this.cmdFilter.Name = "cmdFilter";
            this.cmdFilter.Size = new System.Drawing.Size(75, 23);
            this.cmdFilter.TabIndex = 23;
            this.cmdFilter.Text = "OK";
            this.cmdFilter.UseVisualStyleBackColor = true;
            this.cmdFilter.Click += new System.EventHandler(this.cmdFilter_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(63, 39);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date:";
            // 
            // cbLender
            // 
            this.cbLender.DataSource = this.creditorsBindingSource;
            this.cbLender.DisplayMember = "name";
            this.cbLender.FormattingEnabled = true;
            this.cbLender.Location = new System.Drawing.Point(63, 12);
            this.cbLender.Name = "cbLender";
            this.cbLender.Size = new System.Drawing.Size(200, 21);
            this.cbLender.TabIndex = 20;
            this.cbLender.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Lender:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.InterestOnLoanReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(858, 445);
            this.reportViewer1.TabIndex = 24;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // creditorsBindingSource
            // 
            this.creditorsBindingSource.DataMember = "Creditors";
            this.creditorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // creditorsTableAdapter
            // 
            this.creditorsTableAdapter.ClearBeforeFill = true;
            // 
            // loans1BindingSource
            // 
            this.loans1BindingSource.DataMember = "Loans1";
            this.loans1BindingSource.DataSource = this.fundsDBDataSet;
            // 
            // loans1TableAdapter
            // 
            this.loans1TableAdapter.ClearBeforeFill = true;
            // 
            // InterestOnLoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 572);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmdFilter);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLender);
            this.Controls.Add(this.label1);
            this.Name = "InterestOnLoanForm";
            this.Text = "Interest On Loan";
            this.Load += new System.EventHandler(this.InterestOnLoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loans1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdFilter;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLender;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource creditorsBindingSource;
        private FundsDBDataSetTableAdapters.CreditorsTableAdapter creditorsTableAdapter;
        private System.Windows.Forms.BindingSource loans1BindingSource;
        private FundsDBDataSetTableAdapters.Loans1TableAdapter loans1TableAdapter;
    }
}