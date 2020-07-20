namespace FundsManager
{
    partial class AddendumsForm
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
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpCollectionDate = new System.Windows.Forms.DateTimePicker();
            this.lblContractPrefix = new System.Windows.Forms.Label();
            this.txtDelayInterest = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdBook = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpStartingDate = new System.Windows.Forms.DateTimePicker();
            this.cmdDeleteBooking = new System.Windows.Forms.Button();
            this.lvBooking = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAddBooking = new System.Windows.Forms.Button();
            this.lblTotalToBeCollected = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbISelectedItems = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProfitShare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblContract = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblUnderLayingDebtor = new System.Windows.Forms.Label();
            this.lblUnderlayingBank = new System.Windows.Forms.Label();
            this.lblLetterOfCredit = new System.Windows.Forms.Label();
            this.lblShipment = new System.Windows.Forms.Label();
            this.lblSector = new System.Windows.Forms.Label();
            this.currenciesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CurrenciesTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpBookingDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(289, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 274;
            this.label15.Text = "Shipment:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 272;
            this.label14.Text = "Letter of Credit:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(501, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 268;
            this.label13.Text = "Collection Date:";
            // 
            // dtpCollectionDate
            // 
            this.dtpCollectionDate.Location = new System.Drawing.Point(589, 193);
            this.dtpCollectionDate.Name = "dtpCollectionDate";
            this.dtpCollectionDate.Size = new System.Drawing.Size(200, 20);
            this.dtpCollectionDate.TabIndex = 248;
            // 
            // lblContractPrefix
            // 
            this.lblContractPrefix.Location = new System.Drawing.Point(224, 22);
            this.lblContractPrefix.Name = "lblContractPrefix";
            this.lblContractPrefix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblContractPrefix.Size = new System.Drawing.Size(122, 13);
            this.lblContractPrefix.TabIndex = 267;
            this.lblContractPrefix.Text = "Contract:";
            this.lblContractPrefix.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDelayInterest
            // 
            this.txtDelayInterest.Location = new System.Drawing.Point(97, 87);
            this.txtDelayInterest.Name = "txtDelayInterest";
            this.txtDelayInterest.Size = new System.Drawing.Size(121, 20);
            this.txtDelayInterest.TabIndex = 243;
            this.txtDelayInterest.Text = "0";
            this.txtDelayInterest.Click += new System.EventHandler(this.txtDelayInterest_Click);
            this.txtDelayInterest.TextChanged += new System.EventHandler(this.txtDelayInterest_TextChanged);
            this.txtDelayInterest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDelayInterest_KeyUp);
            this.txtDelayInterest.Leave += new System.EventHandler(this.txtDelayInterest_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 266;
            this.label12.Text = "Delay Interest:";
            // 
            // cmdBook
            // 
            this.cmdBook.Enabled = false;
            this.cmdBook.Location = new System.Drawing.Point(672, 544);
            this.cmdBook.Name = "cmdBook";
            this.cmdBook.Size = new System.Drawing.Size(128, 23);
            this.cmdBook.TabIndex = 252;
            this.cmdBook.Text = "Book";
            this.cmdBook.UseVisualStyleBackColor = true;
            this.cmdBook.Click += new System.EventHandler(this.cmdBook_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(510, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 263;
            this.label11.Text = "Starting Date:";
            // 
            // dtpStartingDate
            // 
            this.dtpStartingDate.Enabled = false;
            this.dtpStartingDate.Location = new System.Drawing.Point(589, 165);
            this.dtpStartingDate.Name = "dtpStartingDate";
            this.dtpStartingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartingDate.TabIndex = 247;
            // 
            // cmdDeleteBooking
            // 
            this.cmdDeleteBooking.Enabled = false;
            this.cmdDeleteBooking.Location = new System.Drawing.Point(678, 226);
            this.cmdDeleteBooking.Name = "cmdDeleteBooking";
            this.cmdDeleteBooking.Size = new System.Drawing.Size(121, 23);
            this.cmdDeleteBooking.TabIndex = 251;
            this.cmdDeleteBooking.Text = "Delete";
            this.cmdDeleteBooking.UseVisualStyleBackColor = true;
            this.cmdDeleteBooking.Click += new System.EventHandler(this.cmdDeleteBooking_Click);
            // 
            // lvBooking
            // 
            this.lvBooking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBooking.FullRowSelect = true;
            this.lvBooking.Location = new System.Drawing.Point(15, 263);
            this.lvBooking.MultiSelect = false;
            this.lvBooking.Name = "lvBooking";
            this.lvBooking.Size = new System.Drawing.Size(784, 270);
            this.lvBooking.TabIndex = 270;
            this.lvBooking.UseCompatibleStateImageBehavior = false;
            this.lvBooking.View = System.Windows.Forms.View.Details;
            this.lvBooking.SelectedIndexChanged += new System.EventHandler(this.lvBooking_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Number";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Investment";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Profit Share";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Delay Interest";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Total to be collected";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "New collection date";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 200;
            // 
            // cmdAddBooking
            // 
            this.cmdAddBooking.Enabled = false;
            this.cmdAddBooking.Location = new System.Drawing.Point(557, 226);
            this.cmdAddBooking.Name = "cmdAddBooking";
            this.cmdAddBooking.Size = new System.Drawing.Size(115, 23);
            this.cmdAddBooking.TabIndex = 249;
            this.cmdAddBooking.Text = "Add Booking";
            this.cmdAddBooking.UseVisualStyleBackColor = true;
            this.cmdAddBooking.Click += new System.EventHandler(this.cmdAddBooking_Click);
            // 
            // lblTotalToBeCollected
            // 
            this.lblTotalToBeCollected.Location = new System.Drawing.Point(125, 159);
            this.lblTotalToBeCollected.Name = "lblTotalToBeCollected";
            this.lblTotalToBeCollected.ReadOnly = true;
            this.lblTotalToBeCollected.Size = new System.Drawing.Size(100, 20);
            this.lblTotalToBeCollected.TabIndex = 261;
            this.lblTotalToBeCollected.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 260;
            this.label10.Text = "Total to be Collected:";
            // 
            // lbISelectedItems
            // 
            this.lbISelectedItems.FormattingEnabled = true;
            this.lbISelectedItems.Location = new System.Drawing.Point(589, 44);
            this.lbISelectedItems.Name = "lbISelectedItems";
            this.lbISelectedItems.Size = new System.Drawing.Size(120, 82);
            this.lbISelectedItems.TabIndex = 245;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 256;
            this.label8.Text = "Sector:";
            // 
            // txtProfitShare
            // 
            this.txtProfitShare.Location = new System.Drawing.Point(97, 53);
            this.txtProfitShare.Name = "txtProfitShare";
            this.txtProfitShare.Size = new System.Drawing.Size(121, 20);
            this.txtProfitShare.TabIndex = 242;
            this.txtProfitShare.Text = "0.00";
            this.txtProfitShare.Click += new System.EventHandler(this.txtProfitShare_Click);
            this.txtProfitShare.TextChanged += new System.EventHandler(this.txtProfitShare_TextChanged);
            this.txtProfitShare.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProfitShare_KeyUp);
            this.txtProfitShare.Leave += new System.EventHandler(this.txtProfitShare_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 253;
            this.label7.Text = "Profit Share:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 250;
            this.label6.Text = "Underlying Bank:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 248;
            this.label5.Text = "Underlying Debtor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 244;
            this.label4.Text = "Client:";
            // 
            // currenciesBindingSource
            // 
            this.currenciesBindingSource.DataMember = "Currencies";
            this.currenciesBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(97, 19);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 237;
            this.txtAmount.Text = "0";
            this.txtAmount.Click += new System.EventHandler(this.txtAmount_Click);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 236;
            this.label1.Text = "Amount:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(97, 121);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(121, 20);
            this.txtNumber.TabIndex = 244;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.Leave += new System.EventHandler(this.txtNumber_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 277;
            this.label16.Text = "Number:";
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(351, 22);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(0, 13);
            this.lblContract.TabIndex = 278;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(351, 56);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(0, 13);
            this.lblClient.TabIndex = 279;
            // 
            // lblUnderLayingDebtor
            // 
            this.lblUnderLayingDebtor.AutoSize = true;
            this.lblUnderLayingDebtor.Location = new System.Drawing.Point(351, 90);
            this.lblUnderLayingDebtor.Name = "lblUnderLayingDebtor";
            this.lblUnderLayingDebtor.Size = new System.Drawing.Size(0, 13);
            this.lblUnderLayingDebtor.TabIndex = 280;
            // 
            // lblUnderlayingBank
            // 
            this.lblUnderlayingBank.AutoSize = true;
            this.lblUnderlayingBank.Location = new System.Drawing.Point(351, 124);
            this.lblUnderlayingBank.Name = "lblUnderlayingBank";
            this.lblUnderlayingBank.Size = new System.Drawing.Size(0, 13);
            this.lblUnderlayingBank.TabIndex = 281;
            // 
            // lblLetterOfCredit
            // 
            this.lblLetterOfCredit.AutoSize = true;
            this.lblLetterOfCredit.Location = new System.Drawing.Point(351, 158);
            this.lblLetterOfCredit.Name = "lblLetterOfCredit";
            this.lblLetterOfCredit.Size = new System.Drawing.Size(0, 13);
            this.lblLetterOfCredit.TabIndex = 282;
            // 
            // lblShipment
            // 
            this.lblShipment.AutoSize = true;
            this.lblShipment.Location = new System.Drawing.Point(349, 192);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(0, 13);
            this.lblShipment.TabIndex = 283;
            // 
            // lblSector
            // 
            this.lblSector.AutoSize = true;
            this.lblSector.Location = new System.Drawing.Point(351, 226);
            this.lblSector.Name = "lblSector";
            this.lblSector.Size = new System.Drawing.Size(0, 13);
            this.lblSector.TabIndex = 284;
            // 
            // currenciesTableAdapter
            // 
            this.currenciesTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(587, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 285;
            this.label9.Text = "Items:";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(458, 226);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(92, 23);
            this.cmdCancel.TabIndex = 250;
            this.cmdCancel.Text = "Cancel Edition";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(507, 140);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 13);
            this.label17.TabIndex = 288;
            this.label17.Text = "Booking Date:";
            // 
            // dtpBookingDate
            // 
            this.dtpBookingDate.Location = new System.Drawing.Point(589, 137);
            this.dtpBookingDate.Name = "dtpBookingDate";
            this.dtpBookingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBookingDate.TabIndex = 246;
            // 
            // AddendumsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 579);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dtpBookingDate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSector);
            this.Controls.Add(this.lblShipment);
            this.Controls.Add(this.lblLetterOfCredit);
            this.Controls.Add(this.lblUnderlayingBank);
            this.Controls.Add(this.lblUnderLayingDebtor);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpCollectionDate);
            this.Controls.Add(this.lblContractPrefix);
            this.Controls.Add(this.txtDelayInterest);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdBook);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpStartingDate);
            this.Controls.Add(this.cmdDeleteBooking);
            this.Controls.Add(this.lvBooking);
            this.Controls.Add(this.cmdAddBooking);
            this.Controls.Add(this.lblTotalToBeCollected);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbISelectedItems);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProfitShare);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddendumsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addendums";
            this.Load += new System.EventHandler(this.AddendumsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpCollectionDate;
        private System.Windows.Forms.Label lblContractPrefix;
        private System.Windows.Forms.TextBox txtDelayInterest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdBook;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpStartingDate;
        private System.Windows.Forms.Button cmdDeleteBooking;
        private System.Windows.Forms.ListView lvBooking;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button cmdAddBooking;
        private System.Windows.Forms.TextBox lblTotalToBeCollected;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbISelectedItems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProfitShare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblUnderLayingDebtor;
        private System.Windows.Forms.Label lblUnderlayingBank;
        private System.Windows.Forms.Label lblLetterOfCredit;
        private System.Windows.Forms.Label lblShipment;
        private System.Windows.Forms.Label lblSector;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource currenciesBindingSource;
        private FundsDBDataSetTableAdapters.CurrenciesTableAdapter currenciesTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpBookingDate;
    }
}