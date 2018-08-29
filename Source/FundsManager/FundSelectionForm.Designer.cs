namespace FundsManager
{
    partial class FundSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbFund = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.fundsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.FundsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fund selected:";
            // 
            // cbFund
            // 
            this.cbFund.DataSource = this.fundsBindingSource;
            this.cbFund.DisplayMember = "name";
            this.cbFund.FormattingEnabled = true;
            this.cbFund.Location = new System.Drawing.Point(108, 33);
            this.cbFund.Name = "cbFund";
            this.cbFund.Size = new System.Drawing.Size(187, 21);
            this.cbFund.TabIndex = 1;
            this.cbFund.ValueMember = "Id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fundsBindingSource
            // 
            this.fundsBindingSource.DataMember = "Funds";
            this.fundsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsTableAdapter
            // 
            this.fundsTableAdapter.ClearBeforeFill = true;
            // 
            // FundSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 127);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbFund);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FundSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fund Selection";
            this.Load += new System.EventHandler(this.FundSelectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFund;
        private System.Windows.Forms.Button button1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource fundsBindingSource;
        private FundsDBDataSetTableAdapters.FundsTableAdapter fundsTableAdapter;
    }
}