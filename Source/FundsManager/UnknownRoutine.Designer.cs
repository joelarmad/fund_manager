namespace FundsManager
{
    partial class UnknownRoutine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.unlinkedDisbursementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fundsDBDataSet = new FundsManager.FundsDBDataSet();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.unlinkedDisbursementsTableAdapter = new FundsManager.FundsDBDataSetTableAdapters.UnlinkedDisbursementsTableAdapter();
            this.investmentidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disbursementidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectiondateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_to_be_collected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlinkedDisbursementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.investmentidDataGridViewTextBoxColumn,
            this.disbursementidDataGridViewTextBoxColumn,
            this.clientDataGridViewTextBoxColumn,
            this.contractDataGridViewTextBoxColumn,
            this.collectiondateDataGridViewTextBoxColumn,
            this.total_to_be_collected});
            this.dataGridView1.DataSource = this.unlinkedDisbursementsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(38, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(704, 263);
            this.dataGridView1.TabIndex = 0;
            // 
            // unlinkedDisbursementsBindingSource
            // 
            this.unlinkedDisbursementsBindingSource.DataMember = "UnlinkedDisbursements";
            this.unlinkedDisbursementsBindingSource.DataSource = this.fundsDBDataSet;
            // 
            // fundsDBDataSet
            // 
            this.fundsDBDataSet.DataSetName = "FundsDBDataSet";
            this.fundsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(38, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // unlinkedDisbursementsTableAdapter
            // 
            this.unlinkedDisbursementsTableAdapter.ClearBeforeFill = true;
            // 
            // investmentidDataGridViewTextBoxColumn
            // 
            this.investmentidDataGridViewTextBoxColumn.DataPropertyName = "investment_id";
            this.investmentidDataGridViewTextBoxColumn.HeaderText = "investment_id";
            this.investmentidDataGridViewTextBoxColumn.Name = "investmentidDataGridViewTextBoxColumn";
            this.investmentidDataGridViewTextBoxColumn.ReadOnly = true;
            this.investmentidDataGridViewTextBoxColumn.Visible = false;
            // 
            // disbursementidDataGridViewTextBoxColumn
            // 
            this.disbursementidDataGridViewTextBoxColumn.DataPropertyName = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.HeaderText = "disbursement_id";
            this.disbursementidDataGridViewTextBoxColumn.Name = "disbursementidDataGridViewTextBoxColumn";
            this.disbursementidDataGridViewTextBoxColumn.ReadOnly = true;
            this.disbursementidDataGridViewTextBoxColumn.Visible = false;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Client";
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientDataGridViewTextBoxColumn.Width = 200;
            // 
            // contractDataGridViewTextBoxColumn
            // 
            this.contractDataGridViewTextBoxColumn.DataPropertyName = "contract";
            this.contractDataGridViewTextBoxColumn.HeaderText = "Contract";
            this.contractDataGridViewTextBoxColumn.Name = "contractDataGridViewTextBoxColumn";
            this.contractDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // collectiondateDataGridViewTextBoxColumn
            // 
            this.collectiondateDataGridViewTextBoxColumn.DataPropertyName = "collection_date";
            this.collectiondateDataGridViewTextBoxColumn.HeaderText = "Collection Date";
            this.collectiondateDataGridViewTextBoxColumn.Name = "collectiondateDataGridViewTextBoxColumn";
            this.collectiondateDataGridViewTextBoxColumn.ReadOnly = true;
            this.collectiondateDataGridViewTextBoxColumn.Width = 150;
            // 
            // total_to_be_collected
            // 
            this.total_to_be_collected.DataPropertyName = "total_to_be_collected";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.total_to_be_collected.DefaultCellStyle = dataGridViewCellStyle1;
            this.total_to_be_collected.HeaderText = "Total to be Collected";
            this.total_to_be_collected.Name = "total_to_be_collected";
            this.total_to_be_collected.ReadOnly = true;
            this.total_to_be_collected.Width = 150;
            // 
            // UnknownRoutine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 390);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UnknownRoutine";
            this.Text = "UnknownRoutine";
            this.Load += new System.EventHandler(this.UnknownRoutine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unlinkedDisbursementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fundsDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private FundsDBDataSet fundsDBDataSet;
        private System.Windows.Forms.BindingSource unlinkedDisbursementsBindingSource;
        private FundsDBDataSetTableAdapters.UnlinkedDisbursementsTableAdapter unlinkedDisbursementsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn investmentidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn disbursementidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectiondateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_to_be_collected;
    }
}