namespace FundsManager
{
    partial class ShipmentForm
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
            this.cbLetter = new System.Windows.Forms.ComboBox();
            this.letterofcreditsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.shipmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.letter_of_creditsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.letter_of_creditsTableAdapter();
            this.shipmentsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ShipmentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.letterofcreditsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Letter of Credit:";
            // 
            // cbLetter
            // 
            this.cbLetter.DataSource = this.letterofcreditsBindingSource;
            this.cbLetter.DisplayMember = "Reference";
            this.cbLetter.FormattingEnabled = true;
            this.cbLetter.Location = new System.Drawing.Point(101, 37);
            this.cbLetter.Name = "cbLetter";
            this.cbLetter.Size = new System.Drawing.Size(176, 21);
            this.cbLetter.TabIndex = 1;
            this.cbLetter.ValueMember = "Id";
            this.cbLetter.SelectedIndexChanged += new System.EventHandler(this.cbLetter_SelectedIndexChanged);
            // 
            // letterofcreditsBindingSource
            // 
            this.letterofcreditsBindingSource.DataMember = "letter_of_credits";
            this.letterofcreditsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(101, 67);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(176, 20);
            this.txtNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(101, 97);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(176, 20);
            this.txtValue.TabIndex = 5;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(290, 140);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 12;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(290, 66);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(290, 37);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 10;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.shipmentsBindingSource;
            this.listBox1.DisplayMember = "Number";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(101, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 186);
            this.listBox1.TabIndex = 13;
            this.listBox1.ValueMember = "Id";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // shipmentsBindingSource
            // 
            this.shipmentsBindingSource.DataMember = "Shipments";
            this.shipmentsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // letter_of_creditsTableAdapter
            // 
            this.letter_of_creditsTableAdapter.ClearBeforeFill = true;
            // 
            // shipmentsTableAdapter
            // 
            this.shipmentsTableAdapter.ClearBeforeFill = true;
            // 
            // ShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 405);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.cbLetter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShipmentForm";
            this.Text = "Shipment";
            this.Load += new System.EventHandler(this.ShipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.letterofcreditsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbLetter;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListBox listBox1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource letterofcreditsBindingSource;
        private FundsDBDataSetTableAdapters.letter_of_creditsTableAdapter letter_of_creditsTableAdapter;
        private System.Windows.Forms.BindingSource shipmentsBindingSource;
        private FundsDBDataSetTableAdapters.ShipmentsTableAdapter shipmentsTableAdapter;
    }
}