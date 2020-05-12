namespace FundsManager
{
    partial class BondsTFAMActivation
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
            this.cbBond = new System.Windows.Forms.ComboBox();
            this.bondsTFAMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cmdActivate = new System.Windows.Forms.Button();
            this.bondsTFAMTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.BondsTFAMTableAdapter();
            this.dtpActivationDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bond:";
            // 
            // cbBond
            // 
            this.cbBond.DataSource = this.bondsTFAMBindingSource;
            this.cbBond.DisplayMember = "number";
            this.cbBond.FormattingEnabled = true;
            this.cbBond.Location = new System.Drawing.Point(96, 27);
            this.cbBond.Name = "cbBond";
            this.cbBond.Size = new System.Drawing.Size(149, 21);
            this.cbBond.TabIndex = 1;
            this.cbBond.ValueMember = "Id";
            // 
            // bondsTFAMBindingSource
            // 
            this.bondsTFAMBindingSource.DataMember = "BondsTFAM";
            this.bondsTFAMBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmdActivate
            // 
            this.cmdActivate.Location = new System.Drawing.Point(337, 62);
            this.cmdActivate.Name = "cmdActivate";
            this.cmdActivate.Size = new System.Drawing.Size(75, 23);
            this.cmdActivate.TabIndex = 2;
            this.cmdActivate.Text = "Activate";
            this.cmdActivate.UseVisualStyleBackColor = true;
            this.cmdActivate.Click += new System.EventHandler(this.cmdActivate_Click);
            // 
            // bondsTFAMTableAdapter
            // 
            this.bondsTFAMTableAdapter.ClearBeforeFill = true;
            // 
            // dtpActivationDate
            // 
            this.dtpActivationDate.Location = new System.Drawing.Point(96, 64);
            this.dtpActivationDate.Name = "dtpActivationDate";
            this.dtpActivationDate.Size = new System.Drawing.Size(223, 20);
            this.dtpActivationDate.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Activation Date:";
            // 
            // BondsTFAMActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 113);
            this.Controls.Add(this.dtpActivationDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdActivate);
            this.Controls.Add(this.cbBond);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BondsTFAMActivation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bonds TFAM Activation";
            this.Load += new System.EventHandler(this.BondsTFAMActivation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bondsTFAMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBond;
        private System.Windows.Forms.Button cmdActivate;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource bondsTFAMBindingSource;
        private FundsDBDataSetTableAdapters.BondsTFAMTableAdapter bondsTFAMTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpActivationDate;
        private System.Windows.Forms.Label label6;
    }
}