using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FundsManager
{
    public partial class OtherDetailsForm : Form
    {
        private MyFundsManager manager;
        public OtherDetailsForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void OtherDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.accountsTableAdapter.Fill(this.fundsDBDataSet.Accounts);
            // TODO: This line of code loads data into the 'fundsDBDataSet.OtherDetails' table. You can move, or remove it, as needed.
            this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);
            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Account _account = new Account();
                _account = manager.My_db.Accounts.Find(Convert.ToInt32(_row.Cells[3].Value));
                _row.Cells[4].Value = _account.name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addDetail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                manager.DeleteOtherDetails(Convert.ToInt32(selectedRow.Cells[0].Value));
                this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);

            }
        }

        private void addDetail()
        {
            OtherDetail _otherdetail = new OtherDetail();
            _otherdetail.name = textBox1.Text;
            _otherdetail.FK_OtherDetails_Accounts = Convert.ToInt32(comboBox1.SelectedValue);
            _otherdetail.FK_OtherDetails_Funds = manager.Selected;
            manager.My_db.OtherDetails.Add(_otherdetail);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            //comboBox1.ResetText();
            this.otherDetailsTableAdapter.Fill(this.fundsDBDataSet.OtherDetails);
            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Account _account = new Account();
                _account = manager.My_db.Accounts.Find(Convert.ToInt32(_row.Cells[3].Value));
                _row.Cells[4].Value = _account.name;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b' || e.KeyChar == '\r')
            {
                addDetail();
            }
        }
    }
}
