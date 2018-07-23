namespace FundsManager
{
    partial class ClientsForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.cmdAddOrSave = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.clientsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.ClientsTableAdapter();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.countriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countriesTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.CountriesTableAdapter();
            this.fillByCountryIdToolStrip = new System.Windows.Forms.ToolStrip();
            this.countryIdToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.countryIdToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByCountryIdToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).BeginInit();
            this.fillByCountryIdToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(158, 20);
            this.txtName.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.clientsBindingSource;
            this.listBox1.DisplayMember = "name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(77, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 186);
            this.listBox1.TabIndex = 2;
            this.listBox1.ValueMember = "Id";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmdAddOrSave
            // 
            this.cmdAddOrSave.Location = new System.Drawing.Point(265, 36);
            this.cmdAddOrSave.Name = "cmdAddOrSave";
            this.cmdAddOrSave.Size = new System.Drawing.Size(75, 23);
            this.cmdAddOrSave.TabIndex = 3;
            this.cmdAddOrSave.Text = "Add";
            this.cmdAddOrSave.UseVisualStyleBackColor = true;
            this.cmdAddOrSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(265, 267);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(265, 64);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Visible = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Country:";
            // 
            // cbCountry
            // 
            this.cbCountry.DataSource = this.countriesBindingSource;
            this.cbCountry.DisplayMember = "name";
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(77, 66);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(158, 21);
            this.cbCountry.TabIndex = 7;
            this.cbCountry.ValueMember = "Id";
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // countriesBindingSource
            // 
            this.countriesBindingSource.DataMember = "Countries";
            this.countriesBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // countriesTableAdapter
            // 
            this.countriesTableAdapter.ClearBeforeFill = true;
            // 
            // fillByCountryIdToolStrip
            // 
            this.fillByCountryIdToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countryIdToolStripLabel,
            this.countryIdToolStripTextBox,
            this.fillByCountryIdToolStripButton});
            this.fillByCountryIdToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByCountryIdToolStrip.Name = "fillByCountryIdToolStrip";
            this.fillByCountryIdToolStrip.Size = new System.Drawing.Size(375, 25);
            this.fillByCountryIdToolStrip.TabIndex = 8;
            this.fillByCountryIdToolStrip.Text = "fillByCountryIdToolStrip";
            this.fillByCountryIdToolStrip.Visible = false;
            // 
            // countryIdToolStripLabel
            // 
            this.countryIdToolStripLabel.Name = "countryIdToolStripLabel";
            this.countryIdToolStripLabel.Size = new System.Drawing.Size(63, 22);
            this.countryIdToolStripLabel.Text = "CountryId:";
            // 
            // countryIdToolStripTextBox
            // 
            this.countryIdToolStripTextBox.Name = "countryIdToolStripTextBox";
            this.countryIdToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillByCountryIdToolStripButton
            // 
            this.fillByCountryIdToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByCountryIdToolStripButton.Name = "fillByCountryIdToolStripButton";
            this.fillByCountryIdToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.fillByCountryIdToolStripButton.Text = "FillByCountryId";
            this.fillByCountryIdToolStripButton.Click += new System.EventHandler(this.fillByCountryIdToolStripButton_Click);
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 342);
            this.Controls.Add(this.fillByCountryIdToolStrip);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdAddOrSave);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Clients";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countriesBindingSource)).EndInit();
            this.fillByCountryIdToolStrip.ResumeLayout(false);
            this.fillByCountryIdToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button cmdAddOrSave;
        private System.Windows.Forms.Button cmdDelete;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private FundsDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.BindingSource countriesBindingSource;
        private FundsDBDataSetTableAdapters.CountriesTableAdapter countriesTableAdapter;
        private System.Windows.Forms.ToolStrip fillByCountryIdToolStrip;
        private System.Windows.Forms.ToolStripLabel countryIdToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox countryIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByCountryIdToolStripButton;
    }
}