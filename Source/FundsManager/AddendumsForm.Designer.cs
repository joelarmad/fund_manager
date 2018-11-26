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
            this.cbShipment = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbLetterOfCredit = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpCollectionDate = new System.Windows.Forms.DateTimePicker();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.lblContractPrefix = new System.Windows.Forms.Label();
            this.txtDelayInterest = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdDeleteItem = new System.Windows.Forms.Button();
            this.cmdBook = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDisbursementDate = new System.Windows.Forms.DateTimePicker();
            this.cmdDeleteBooking = new System.Windows.Forms.Button();
            this.lvDisbursements = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdAddBooking = new System.Windows.Forms.Button();
            this.txtTotalToBeCollected = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbISelectedItems = new System.Windows.Forms.ListBox();
            this.cmdAddItem = new System.Windows.Forms.Button();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSector = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProfitShare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUnderlyingDebtor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbShipment
            // 
            this.cbShipment.DisplayMember = "Number";
            this.cbShipment.FormattingEnabled = true;
            this.cbShipment.Location = new System.Drawing.Point(351, 192);
            this.cbShipment.Name = "cbShipment";
            this.cbShipment.Size = new System.Drawing.Size(121, 21);
            this.cbShipment.TabIndex = 273;
            this.cbShipment.ValueMember = "Id";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(289, 196);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 274;
            this.label15.Text = "Shipment:";
            // 
            // cbLetterOfCredit
            // 
            this.cbLetterOfCredit.DisplayMember = "Reference";
            this.cbLetterOfCredit.FormattingEnabled = true;
            this.cbLetterOfCredit.Location = new System.Drawing.Point(351, 157);
            this.cbLetterOfCredit.Name = "cbLetterOfCredit";
            this.cbLetterOfCredit.Size = new System.Drawing.Size(121, 21);
            this.cbLetterOfCredit.TabIndex = 271;
            this.cbLetterOfCredit.ValueMember = "Id";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 161);
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
            this.dtpCollectionDate.TabIndex = 257;
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(351, 18);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(121, 20);
            this.txtContract.TabIndex = 245;
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
            this.txtDelayInterest.Location = new System.Drawing.Point(97, 156);
            this.txtDelayInterest.Name = "txtDelayInterest";
            this.txtDelayInterest.Size = new System.Drawing.Size(121, 20);
            this.txtDelayInterest.TabIndex = 243;
            this.txtDelayInterest.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 266;
            this.label12.Text = "Delay Interest:";
            // 
            // cmdDeleteItem
            // 
            this.cmdDeleteItem.Enabled = false;
            this.cmdDeleteItem.Location = new System.Drawing.Point(725, 57);
            this.cmdDeleteItem.Name = "cmdDeleteItem";
            this.cmdDeleteItem.Size = new System.Drawing.Size(75, 23);
            this.cmdDeleteItem.TabIndex = 265;
            this.cmdDeleteItem.Text = "Delete Item";
            this.cmdDeleteItem.UseVisualStyleBackColor = true;
            // 
            // cmdBook
            // 
            this.cmdBook.Enabled = false;
            this.cmdBook.Location = new System.Drawing.Point(672, 544);
            this.cmdBook.Name = "cmdBook";
            this.cmdBook.Size = new System.Drawing.Size(128, 23);
            this.cmdBook.TabIndex = 264;
            this.cmdBook.Text = "Book";
            this.cmdBook.UseVisualStyleBackColor = true;
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
            // dtpDisbursementDate
            // 
            this.dtpDisbursementDate.Location = new System.Drawing.Point(589, 165);
            this.dtpDisbursementDate.Name = "dtpDisbursementDate";
            this.dtpDisbursementDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDisbursementDate.TabIndex = 255;
            // 
            // cmdDeleteBooking
            // 
            this.cmdDeleteBooking.Enabled = false;
            this.cmdDeleteBooking.Location = new System.Drawing.Point(678, 226);
            this.cmdDeleteBooking.Name = "cmdDeleteBooking";
            this.cmdDeleteBooking.Size = new System.Drawing.Size(121, 23);
            this.cmdDeleteBooking.TabIndex = 262;
            this.cmdDeleteBooking.Text = "Delete";
            this.cmdDeleteBooking.UseVisualStyleBackColor = true;
            // 
            // lvDisbursements
            // 
            this.lvDisbursements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDisbursements.Location = new System.Drawing.Point(15, 263);
            this.lvDisbursements.MultiSelect = false;
            this.lvDisbursements.Name = "lvDisbursements";
            this.lvDisbursements.Size = new System.Drawing.Size(784, 270);
            this.lvDisbursements.TabIndex = 270;
            this.lvDisbursements.UseCompatibleStateImageBehavior = false;
            this.lvDisbursements.View = System.Windows.Forms.View.Details;
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
            this.columnHeader5.Width = 120;
            // 
            // cmdAddBooking
            // 
            this.cmdAddBooking.Enabled = false;
            this.cmdAddBooking.Location = new System.Drawing.Point(557, 226);
            this.cmdAddBooking.Name = "cmdAddBooking";
            this.cmdAddBooking.Size = new System.Drawing.Size(115, 23);
            this.cmdAddBooking.TabIndex = 258;
            this.cmdAddBooking.Text = "Add Booking";
            this.cmdAddBooking.UseVisualStyleBackColor = true;
            // 
            // txtTotalToBeCollected
            // 
            this.txtTotalToBeCollected.Location = new System.Drawing.Point(125, 228);
            this.txtTotalToBeCollected.Name = "txtTotalToBeCollected";
            this.txtTotalToBeCollected.ReadOnly = true;
            this.txtTotalToBeCollected.Size = new System.Drawing.Size(100, 20);
            this.txtTotalToBeCollected.TabIndex = 261;
            this.txtTotalToBeCollected.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 260;
            this.label10.Text = "Total to be Collected:";
            // 
            // lbISelectedItems
            // 
            this.lbISelectedItems.FormattingEnabled = true;
            this.lbISelectedItems.Location = new System.Drawing.Point(589, 57);
            this.lbISelectedItems.Name = "lbISelectedItems";
            this.lbISelectedItems.Size = new System.Drawing.Size(120, 95);
            this.lbISelectedItems.TabIndex = 269;
            // 
            // cmdAddItem
            // 
            this.cmdAddItem.Location = new System.Drawing.Point(725, 16);
            this.cmdAddItem.Name = "cmdAddItem";
            this.cmdAddItem.Size = new System.Drawing.Size(75, 23);
            this.cmdAddItem.TabIndex = 254;
            this.cmdAddItem.Text = "Add Item";
            this.cmdAddItem.UseVisualStyleBackColor = true;
            // 
            // cbItems
            // 
            this.cbItems.DisplayMember = "name";
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(589, 18);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(121, 21);
            this.cbItems.TabIndex = 252;
            this.cbItems.ValueMember = "Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(548, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 259;
            this.label9.Text = "Items:";
            // 
            // cbSector
            // 
            this.cbSector.DisplayMember = "name";
            this.cbSector.FormattingEnabled = true;
            this.cbSector.Location = new System.Drawing.Point(351, 227);
            this.cbSector.Name = "cbSector";
            this.cbSector.Size = new System.Drawing.Size(121, 21);
            this.cbSector.TabIndex = 251;
            this.cbSector.ValueMember = "Id";
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
            this.txtProfitShare.Location = new System.Drawing.Point(97, 122);
            this.txtProfitShare.Name = "txtProfitShare";
            this.txtProfitShare.Size = new System.Drawing.Size(121, 20);
            this.txtProfitShare.TabIndex = 242;
            this.txtProfitShare.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 253;
            this.label7.Text = "Profit Share:";
            // 
            // cbBank
            // 
            this.cbBank.DisplayMember = "name";
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Location = new System.Drawing.Point(351, 122);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(121, 21);
            this.cbBank.TabIndex = 249;
            this.cbBank.ValueMember = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 250;
            this.label6.Text = "Underlying Bank:";
            // 
            // cbUnderlyingDebtor
            // 
            this.cbUnderlyingDebtor.DisplayMember = "name";
            this.cbUnderlyingDebtor.FormattingEnabled = true;
            this.cbUnderlyingDebtor.Location = new System.Drawing.Point(351, 87);
            this.cbUnderlyingDebtor.Name = "cbUnderlyingDebtor";
            this.cbUnderlyingDebtor.Size = new System.Drawing.Size(121, 21);
            this.cbUnderlyingDebtor.TabIndex = 247;
            this.cbUnderlyingDebtor.ValueMember = "Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 248;
            this.label5.Text = "Underlying Debtor:";
            // 
            // cbClient
            // 
            this.cbClient.DisplayMember = "name";
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(351, 52);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(121, 21);
            this.cbClient.TabIndex = 246;
            this.cbClient.ValueMember = "Id";
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
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(97, 88);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate.TabIndex = 240;
            this.txtExchangeRate.Text = "1.0000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 241;
            this.label3.Text = "Exchange Rate:";
            // 
            // cbCurrency
            // 
            this.cbCurrency.DisplayMember = "name";
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(97, 53);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(121, 21);
            this.cbCurrency.TabIndex = 239;
            this.cbCurrency.ValueMember = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 238;
            this.label2.Text = "Currency:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(97, 19);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 237;
            this.txtAmount.Text = "0";
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
            this.txtNumber.Location = new System.Drawing.Point(97, 190);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(121, 20);
            this.txtNumber.TabIndex = 276;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 192);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 277;
            this.label16.Text = "Number:";
            // 
            // AddendumsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 579);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cbShipment);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbLetterOfCredit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpCollectionDate);
            this.Controls.Add(this.txtContract);
            this.Controls.Add(this.lblContractPrefix);
            this.Controls.Add(this.txtDelayInterest);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmdDeleteItem);
            this.Controls.Add(this.cmdBook);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpDisbursementDate);
            this.Controls.Add(this.cmdDeleteBooking);
            this.Controls.Add(this.lvDisbursements);
            this.Controls.Add(this.cmdAddBooking);
            this.Controls.Add(this.txtTotalToBeCollected);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbISelectedItems);
            this.Controls.Add(this.cmdAddItem);
            this.Controls.Add(this.cbItems);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbSector);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProfitShare);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBank);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbUnderlyingDebtor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExchangeRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddendumsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addendums";
            this.Load += new System.EventHandler(this.AddendumsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbShipment;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbLetterOfCredit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpCollectionDate;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label lblContractPrefix;
        private System.Windows.Forms.TextBox txtDelayInterest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cmdDeleteItem;
        private System.Windows.Forms.Button cmdBook;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDisbursementDate;
        private System.Windows.Forms.Button cmdDeleteBooking;
        private System.Windows.Forms.ListView lvDisbursements;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button cmdAddBooking;
        private System.Windows.Forms.TextBox txtTotalToBeCollected;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbISelectedItems;
        private System.Windows.Forms.Button cmdAddItem;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSector;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProfitShare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbUnderlyingDebtor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label16;
    }
}