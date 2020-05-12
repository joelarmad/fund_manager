namespace FundsManager
{
    partial class BondsTFAMForm
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpIssuingDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBondInterest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTFFInterest = new System.Windows.Forms.TextBox();
            this.cmdCreateBond = new System.Windows.Forms.Button();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.currenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currenciesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CurrenciesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(79, 32);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(104, 20);
            this.txtNumber.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issuing date:";
            // 
            // dtpIssuingDate
            // 
            this.dtpIssuingDate.Location = new System.Drawing.Point(111, 107);
            this.dtpIssuingDate.Name = "dtpIssuingDate";
            this.dtpIssuingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpIssuingDate.TabIndex = 30;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(250, 33);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(104, 20);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Interest on Bond:";
            // 
            // txtBondInterest
            // 
            this.txtBondInterest.Location = new System.Drawing.Point(121, 74);
            this.txtBondInterest.Name = "txtBondInterest";
            this.txtBondInterest.Size = new System.Drawing.Size(62, 20);
            this.txtBondInterest.TabIndex = 3;
            this.txtBondInterest.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Interest on TFF Contribution:";
            // 
            // txtTFFInterest
            // 
            this.txtTFFInterest.Location = new System.Drawing.Point(336, 74);
            this.txtTFFInterest.Name = "txtTFFInterest";
            this.txtTFFInterest.Size = new System.Drawing.Size(58, 20);
            this.txtTFFInterest.TabIndex = 4;
            this.txtTFFInterest.Text = "1";
            // 
            // cmdCreateBond
            // 
            this.cmdCreateBond.Location = new System.Drawing.Point(350, 193);
            this.cmdCreateBond.Name = "cmdCreateBond";
            this.cmdCreateBond.Size = new System.Drawing.Size(141, 36);
            this.cmdCreateBond.TabIndex = 16;
            this.cmdCreateBond.Text = "Create Bond";
            this.cmdCreateBond.UseVisualStyleBackColor = true;
            this.cmdCreateBond.Click += new System.EventHandler(this.cmdAddBond_Click);
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Location = new System.Drawing.Point(111, 133);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(200, 20);
            this.dtpExpirationDate.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Expiration date:";
            // 
            // cbCurrency
            // 
            this.cbCurrency.DataSource = this.currenciesBindingSource;
            this.cbCurrency.DisplayMember = "symbol";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(357, 32);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(63, 21);
            this.cbCurrency.TabIndex = 33;
            this.cbCurrency.ValueMember = "Id";
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // currenciesBindingSource
            // 
            this.currenciesBindingSource.DataMember = "Currencies";
            this.currenciesBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // currenciesTableAdapter
            // 
            this.currenciesTableAdapter.ClearBeforeFill = true;
            // 
            // BondsTFAMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 243);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.dtpExpirationDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdCreateBond);
            this.Controls.Add(this.txtTFFInterest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBondInterest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.dtpIssuingDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BondsTFAMForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bonds TFAM";
            this.Load += new System.EventHandler(this.BondsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpIssuingDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBondInterest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTFFInterest;
        private System.Windows.Forms.Button cmdCreateBond;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCurrency;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource currenciesBindingSource;
        private FundsDBDataSetTableAdapters.CurrenciesTableAdapter currenciesTableAdapter;
    }
}