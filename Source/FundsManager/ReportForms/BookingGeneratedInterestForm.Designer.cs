namespace FundsManager.ReportForms
{
    partial class BookingGeneratedInterestForm
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
            this.bookingGeneratedInterestViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingGeneratedInterestViewTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BookingGeneratedInterestViewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingGeneratedInterestViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FundsManager.Reports.BookingGeneratedInterestReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(847, 440);
            this.reportViewer1.TabIndex = 0;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookingGeneratedInterestViewBindingSource
            // 
            this.bookingGeneratedInterestViewBindingSource.DataMember = "BookingGeneratedInterestView";
            this.bookingGeneratedInterestViewBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // bookingGeneratedInterestViewTableAdapter
            // 
            this.bookingGeneratedInterestViewTableAdapter.ClearBeforeFill = true;
            // 
            // BookingGeneratedInterestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 464);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BookingGeneratedInterestForm";
            this.Text = "Booking Generated Interests";
            this.Load += new System.EventHandler(this.BookingGeneratedInterestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingGeneratedInterestViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bookingGeneratedInterestViewBindingSource;
        private FundsDBDataSetTableAdapters.BookingGeneratedInterestViewTableAdapter bookingGeneratedInterestViewTableAdapter;
    }
}