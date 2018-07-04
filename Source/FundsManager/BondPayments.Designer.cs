namespace FundsManager
{
    partial class BondPayments
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
            this.cbInvestor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lvGeneratedInterest = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdPayInterest = new System.Windows.Forms.Button();
            this.cmdPayBond = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblPieces = new System.Windows.Forms.Label();
            this.lblInterest = new System.Windows.Forms.Label();
            this.lblTFF = new System.Windows.Forms.Label();
            this.lblIssuingDate = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblInvestorPieces = new System.Windows.Forms.Label();
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.fundsDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.investorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.InvestorsTableAdapter();
            this.investorsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Investor:";
            // 
            // cbInvestor
            // 
            this.cbInvestor.DataSource = this.investorsBindingSource1;
            this.cbInvestor.DisplayMember = "name";
            this.cbInvestor.FormattingEnabled = true;
            this.cbInvestor.Location = new System.Drawing.Point(78, 19);
            this.cbInvestor.Name = "cbInvestor";
            this.cbInvestor.Size = new System.Drawing.Size(140, 21);
            this.cbInvestor.TabIndex = 1;
            this.cbInvestor.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bond:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(304, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // lvGeneratedInterest
            // 
            this.lvGeneratedInterest.Location = new System.Drawing.Point(27, 273);
            this.lvGeneratedInterest.Name = "lvGeneratedInterest";
            this.lvGeneratedInterest.Size = new System.Drawing.Size(336, 120);
            this.lvGeneratedInterest.TabIndex = 4;
            this.lvGeneratedInterest.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Generated Interests:";
            // 
            // cmdPayInterest
            // 
            this.cmdPayInterest.Enabled = false;
            this.cmdPayInterest.Location = new System.Drawing.Point(369, 273);
            this.cmdPayInterest.Name = "cmdPayInterest";
            this.cmdPayInterest.Size = new System.Drawing.Size(75, 23);
            this.cmdPayInterest.TabIndex = 6;
            this.cmdPayInterest.Text = "Pay Interest";
            this.cmdPayInterest.UseVisualStyleBackColor = true;
            // 
            // cmdPayBond
            // 
            this.cmdPayBond.Enabled = false;
            this.cmdPayBond.Location = new System.Drawing.Point(288, 408);
            this.cmdPayBond.Name = "cmdPayBond";
            this.cmdPayBond.Size = new System.Drawing.Size(75, 23);
            this.cmdPayBond.TabIndex = 7;
            this.cmdPayBond.Text = "Pay Bond";
            this.cmdPayBond.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInvestorPieces);
            this.groupBox1.Controls.Add(this.lblExpirationDate);
            this.groupBox1.Controls.Add(this.lblIssuingDate);
            this.groupBox1.Controls.Add(this.lblTFF);
            this.groupBox1.Controls.Add(this.lblInterest);
            this.groupBox1.Controls.Add(this.lblPieces);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.lblNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(27, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 168);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bond";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Pieces:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Interest of Bond:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(161, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Interest of TFF Contribution:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Issuing date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(219, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Expiration date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Investor pieces:";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(56, 27);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(0, 13);
            this.lblNumber.TabIndex = 16;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(178, 27);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 13);
            this.lblPrice.TabIndex = 17;
            // 
            // lblPieces
            // 
            this.lblPieces.AutoSize = true;
            this.lblPieces.Location = new System.Drawing.Point(299, 27);
            this.lblPieces.Name = "lblPieces";
            this.lblPieces.Size = new System.Drawing.Size(0, 13);
            this.lblPieces.TabIndex = 18;
            // 
            // lblInterest
            // 
            this.lblInterest.AutoSize = true;
            this.lblInterest.Location = new System.Drawing.Point(91, 60);
            this.lblInterest.Name = "lblInterest";
            this.lblInterest.Size = new System.Drawing.Size(0, 13);
            this.lblInterest.TabIndex = 19;
            // 
            // lblTFF
            // 
            this.lblTFF.AutoSize = true;
            this.lblTFF.Location = new System.Drawing.Point(299, 60);
            this.lblTFF.Name = "lblTFF";
            this.lblTFF.Size = new System.Drawing.Size(0, 13);
            this.lblTFF.TabIndex = 20;
            // 
            // lblIssuingDate
            // 
            this.lblIssuingDate.AutoSize = true;
            this.lblIssuingDate.Location = new System.Drawing.Point(79, 90);
            this.lblIssuingDate.Name = "lblIssuingDate";
            this.lblIssuingDate.Size = new System.Drawing.Size(0, 13);
            this.lblIssuingDate.TabIndex = 21;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(299, 90);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(0, 13);
            this.lblExpirationDate.TabIndex = 22;
            // 
            // lblInvestorPieces
            // 
            this.lblInvestorPieces.AutoSize = true;
            this.lblInvestorPieces.Location = new System.Drawing.Point(91, 132);
            this.lblInvestorPieces.Name = "lblInvestorPieces";
            this.lblInvestorPieces.Size = new System.Drawing.Size(0, 13);
            this.lblInvestorPieces.TabIndex = 23;
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
            // investorsBindingSource
            // 
            this.investorsBindingSource.DataMember = "Investors";
            this.investorsBindingSource.DataSource = this.fundsDBDataSetBindingSource;
            // 
            // investorsTableAdapter
            // 
            this.investorsTableAdapter.ClearBeforeFill = true;
            // 
            // investorsBindingSource1
            // 
            this.investorsBindingSource1.DataMember = "Investors";
            this.investorsBindingSource1.DataSource = this.fundsDBDataSetBindingSource;
            // 
            // BondPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 440);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdPayBond);
            this.Controls.Add(this.cmdPayInterest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvGeneratedInterest);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbInvestor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BondPayments";
            this.Text = "Bond Payments";
            this.Load += new System.EventHandler(this.BondPayments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInvestor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView lvGeneratedInterest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdPayInterest;
        private System.Windows.Forms.Button cmdPayBond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource fundsDBDataSetBindingSource;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.Label lblInvestorPieces;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblIssuingDate;
        private System.Windows.Forms.Label lblTFF;
        private System.Windows.Forms.Label lblInterest;
        private System.Windows.Forms.Label lblPieces;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.BindingSource investorsBindingSource;
        private FundsDBDataSetTableAdapters.InvestorsTableAdapter investorsTableAdapter;
        private System.Windows.Forms.BindingSource investorsBindingSource1;
    }
}