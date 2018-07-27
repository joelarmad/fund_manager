namespace FundsManager
{
    partial class FundsForm
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
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label label2;
            this.cmdAddOrUpdate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.fundsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.fundsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.FundsTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContractPrefix = new System.Windows.Forms.TextBox();
            this.cmdCancelEdit = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            nameLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fundsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(59, 41);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // cmdAddOrUpdate
            // 
            this.cmdAddOrUpdate.Location = new System.Drawing.Point(273, 36);
            this.cmdAddOrUpdate.Name = "cmdAddOrUpdate";
            this.cmdAddOrUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdAddOrUpdate.TabIndex = 3;
            this.cmdAddOrUpdate.Text = "Add";
            this.cmdAddOrUpdate.UseVisualStyleBackColor = true;
            this.cmdAddOrUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.fundsBindingSource1;
            this.listBox1.DisplayMember = "name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(104, 139);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 160);
            this.listBox1.TabIndex = 6;
            this.listBox1.ValueMember = "Id";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // fundsBindingSource1
            // 
            this.fundsBindingSource1.DataMember = "Funds";
            this.fundsBindingSource1.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fundsTableAdapter
            // 
            this.fundsTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contract Prefix:";
            // 
            // txtContractPrefix
            // 
            this.txtContractPrefix.Location = new System.Drawing.Point(104, 96);
            this.txtContractPrefix.Name = "txtContractPrefix";
            this.txtContractPrefix.Size = new System.Drawing.Size(153, 20);
            this.txtContractPrefix.TabIndex = 8;
            // 
            // cmdCancelEdit
            // 
            this.cmdCancelEdit.Location = new System.Drawing.Point(273, 71);
            this.cmdCancelEdit.Name = "cmdCancelEdit";
            this.cmdCancelEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdCancelEdit.TabIndex = 9;
            this.cmdCancelEdit.Text = "Cancel";
            this.cmdCancelEdit.UseVisualStyleBackColor = true;
            this.cmdCancelEdit.Visible = false;
            this.cmdCancelEdit.Click += new System.EventHandler(this.cmdCancelEdit_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(104, 68);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(153, 20);
            this.txtNumber.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(50, 71);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 10;
            label2.Text = "Number:";
            // 
            // FundsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 314);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(label2);
            this.Controls.Add(this.cmdCancelEdit);
            this.Controls.Add(this.txtContractPrefix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdAddOrUpdate);
            this.Controls.Add(nameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FundsForm";
            this.ShowInTaskbar = false;
            this.Text = "FundsForm";
            this.Load += new System.EventHandler(this.FundsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fundsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdAddOrUpdate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox listBox1;
        private FundsDBDataSet fundsDBDataSet;
        private FundsDBDataSetTableAdapters.FundsTableAdapter fundsTableAdapter;
        private System.Windows.Forms.BindingSource fundsBindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContractPrefix;
        private System.Windows.Forms.Button cmdCancelEdit;
        private System.Windows.Forms.TextBox txtNumber;
    }
}