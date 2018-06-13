namespace FundsManager
{
    partial class BondsForm
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
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBondInterest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTFFInterest = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbInvestors = new System.Windows.Forms.ComboBox();
            this.investorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdAddPiece = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvestorPieces = new System.Windows.Forms.TextBox();
            this.cmdCreateBond = new System.Windows.Forms.Button();
            this.cmdRemovePiece = new System.Windows.Forms.Button();
            this.investorsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.InvestorsTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBondPieces = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(407, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issuing date:";
            // 
            // dtpIssuingDate
            // 
            this.dtpIssuingDate.Location = new System.Drawing.Point(480, 74);
            this.dtpIssuingDate.Name = "dtpIssuingDate";
            this.dtpIssuingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpIssuingDate.TabIndex = 30;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(275, 32);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(104, 20);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.Text = "0";
            this.txtPrice.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            this.txtPrice.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price:";
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
            this.txtBondInterest.Text = "0";
            this.txtBondInterest.Enter += new System.EventHandler(this.textBox3_Enter);
            this.txtBondInterest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyUp);
            this.txtBondInterest.Leave += new System.EventHandler(this.textBox3_Leave);
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
            this.txtTFFInterest.Text = "0";
            this.txtTFFInterest.Enter += new System.EventHandler(this.textBox4_Enter);
            this.txtTFFInterest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyUp);
            this.txtTFFInterest.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(29, 189);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(489, 289);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Investor";
            this.columnHeader1.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pieces";
            this.columnHeader2.Width = 156;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Amount";
            this.columnHeader3.Width = 144;
            // 
            // cbInvestors
            // 
            this.cbInvestors.DataSource = this.investorsBindingSource;
            this.cbInvestors.DisplayMember = "name";
            this.cbInvestors.FormattingEnabled = true;
            this.cbInvestors.Location = new System.Drawing.Point(60, 35);
            this.cbInvestors.Name = "cbInvestors";
            this.cbInvestors.Size = new System.Drawing.Size(121, 21);
            this.cbInvestors.TabIndex = 5;
            this.cbInvestors.ValueMember = "Id";
            this.cbInvestors.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // investorsBindingSource
            // 
            this.investorsBindingSource.DataMember = "Investors";
            this.investorsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Investor:";
            // 
            // cmdAddPiece
            // 
            this.cmdAddPiece.Enabled = false;
            this.cmdAddPiece.Location = new System.Drawing.Point(413, 35);
            this.cmdAddPiece.Name = "cmdAddPiece";
            this.cmdAddPiece.Size = new System.Drawing.Size(75, 23);
            this.cmdAddPiece.TabIndex = 7;
            this.cmdAddPiece.Text = "Add";
            this.cmdAddPiece.UseVisualStyleBackColor = true;
            this.cmdAddPiece.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Pieces:";
            // 
            // txtInvestorPieces
            // 
            this.txtInvestorPieces.Location = new System.Drawing.Point(249, 36);
            this.txtInvestorPieces.Name = "txtInvestorPieces";
            this.txtInvestorPieces.Size = new System.Drawing.Size(100, 20);
            this.txtInvestorPieces.TabIndex = 6;
            this.txtInvestorPieces.Text = "0";
            this.txtInvestorPieces.Enter += new System.EventHandler(this.textBox5_Enter);
            this.txtInvestorPieces.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox5_KeyUp);
            this.txtInvestorPieces.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // cmdCreateBond
            // 
            this.cmdCreateBond.Enabled = false;
            this.cmdCreateBond.Location = new System.Drawing.Point(377, 484);
            this.cmdCreateBond.Name = "cmdCreateBond";
            this.cmdCreateBond.Size = new System.Drawing.Size(141, 36);
            this.cmdCreateBond.TabIndex = 16;
            this.cmdCreateBond.Text = "Create Bond";
            this.cmdCreateBond.UseVisualStyleBackColor = true;
            this.cmdCreateBond.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdRemovePiece
            // 
            this.cmdRemovePiece.Enabled = false;
            this.cmdRemovePiece.Location = new System.Drawing.Point(519, 34);
            this.cmdRemovePiece.Name = "cmdRemovePiece";
            this.cmdRemovePiece.Size = new System.Drawing.Size(75, 23);
            this.cmdRemovePiece.TabIndex = 17;
            this.cmdRemovePiece.Text = "Delete";
            this.cmdRemovePiece.UseVisualStyleBackColor = true;
            this.cmdRemovePiece.Click += new System.EventHandler(this.button3_Click);
            // 
            // investorsTableAdapter
            // 
            this.investorsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbInvestors);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmdRemovePiece);
            this.groupBox1.Controls.Add(this.cmdAddPiece);
            this.groupBox1.Controls.Add(this.txtInvestorPieces);
            this.groupBox1.Location = new System.Drawing.Point(30, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 70);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Investor Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(401, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pieces:";
            // 
            // txtBondPieces
            // 
            this.txtBondPieces.Location = new System.Drawing.Point(443, 32);
            this.txtBondPieces.Name = "txtBondPieces";
            this.txtBondPieces.Size = new System.Drawing.Size(100, 20);
            this.txtBondPieces.TabIndex = 2;
            this.txtBondPieces.Text = "0";
            this.txtBondPieces.Enter += new System.EventHandler(this.textBox6_Enter);
            this.txtBondPieces.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox6_KeyUp);
            this.txtBondPieces.Leave += new System.EventHandler(this.textBox6_Leave);
            // 
            // BondsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 569);
            this.Controls.Add(this.txtBondPieces);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCreateBond);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtTFFInterest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBondInterest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.dtpIssuingDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BondsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Bonds";
            this.Load += new System.EventHandler(this.BondsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.investorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpIssuingDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBondInterest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTFFInterest;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox cbInvestors;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdAddPiece;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvestorPieces;
        private System.Windows.Forms.Button cmdCreateBond;
        private System.Windows.Forms.Button cmdRemovePiece;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource investorsBindingSource;
        private FundsDBDataSetTableAdapters.InvestorsTableAdapter investorsTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBondPieces;
    }
}