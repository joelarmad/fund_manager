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

        private bool fEditMode = false;
        private int fEditIndex = -1;

        private int editModeAccountIndex = 0;
        private int editModeSubaccountIndex = 0;

        public OtherDetailsForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void OtherDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Accounts' Puede moverla o quitarla según sea necesario.
            this.accountsTableAdapter.FillByExistingAccount(this.fundsDBDataSet.Accounts, manager.Selected);

            loadSubAccounts();
            
            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                Subaccount _subaccount = new Subaccount();
                _subaccount = manager.My_db.Subaccounts.Find(Convert.ToInt32(_row.Cells[4].Value));
                _row.Cells[5].Value = _subaccount.name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addDetail();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                    int subaccountId = int.Parse(cbSubAccount.SelectedValue.ToString());

                    manager.DeleteOtherDetails(Convert.ToInt32(selectedRow.Cells[0].Value));
                    this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subaccountId, manager.Selected);

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
        }

        private void addDetail()
        {
            try
            {
                editModeAccountIndex = cbAccount.SelectedIndex;
                editModeSubaccountIndex = cbSubAccount.SelectedIndex;

                int subacctId = Convert.ToInt32(cbSubAccount.SelectedValue);

                if (!fEditMode)
                {
                    OtherDetail _validationOtherDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.number == txtNumber.Text && x.subacct_id == subacctId && x.FK_OtherDetails_Funds == manager.Selected);

                    if (_validationOtherDetail != null)
                    {
                        MessageBox.Show("Duplicated number.");
                        return;
                    }

                    OtherDetail _otherdetail = new OtherDetail();
                    _otherdetail.name = txtName.Text;
                    _otherdetail.subacct_id = Convert.ToInt32(cbSubAccount.SelectedValue);
                    _otherdetail.FK_OtherDetails_Funds = manager.Selected;
                    _otherdetail.number = txtNumber.Text;
                    manager.My_db.OtherDetails.Add(_otherdetail);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

                    OtherDetail _validationOtherDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id != _id && x.number == txtNumber.Text && x.subacct_id == subacctId && x.FK_OtherDetails_Funds == manager.Selected);

                    if (_validationOtherDetail != null)
                    {
                        MessageBox.Show("Duplicated number.");
                        return;
                    }

                    OtherDetail _selectedDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _id);

                    if (_selectedDetail != null)
                    {
                        _selectedDetail.name = txtName.Text;
                        _selectedDetail.subacct_id = Convert.ToInt32(cbSubAccount.SelectedValue);
                        _selectedDetail.number = txtNumber.Text;

                        manager.My_db.SaveChanges();
                    }

                }

                cmdCancel_Click(null, null);

                int subaccountId = int.Parse(cbSubAccount.SelectedValue.ToString());

                this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subaccountId, manager.Selected);

                foreach (DataGridViewRow _row in dataGridView1.Rows)
                {
                    Subaccount _subaccount = new Subaccount();
                    _subaccount = manager.My_db.Subaccounts.Find(Convert.ToInt32(_row.Cells[4].Value));
                    _row.Cells[5].Value = _subaccount.name;
                }

                
            }
            catch (Exception _ex)
            {
                string msg = "";

                Exception inner = _ex.InnerException;

                while (inner != null)
                {
                    msg += inner.Message;
                    msg += "\r";
                    inner = inner.InnerException;
                }

                MessageBox.Show("Error: " + msg);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fEditIndex = e.RowIndex;
            int _id = (int)dataGridView1.Rows[fEditIndex].Cells[0].Value;

            OtherDetail _selectedDetail = manager.My_db.OtherDetails.FirstOrDefault(x => x.Id == _id);

            if (_selectedDetail != null)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                txtName.Text = _selectedDetail.name;
                txtNumber.Text = _selectedDetail.number;

                Subaccount _subacct = manager.My_db.Subaccounts.FirstOrDefault(x => x.Id == _selectedDetail.subacct_id);

                foreach (DataRowView _item in cbSubAccount.Items)
                {
                    if (_item.Row[0].ToString() == _subacct.Id.ToString())
                    {
                        cbSubAccount.SelectedItem = _item;
                        break;
                    }
                }

                cmdCancel.Visible = true;

                editModeAccountIndex = cbAccount.SelectedIndex;
                editModeSubaccountIndex = cbSubAccount.SelectedIndex;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

            cbAccount.SelectedIndex = editModeAccountIndex;
            cbSubAccount.SelectedIndex = editModeSubaccountIndex;

            editModeAccountIndex = 0;
            editModeSubaccountIndex = 0;

            fEditMode = false;
            cmdAddOrSave.Text = "Add";

            txtName.Text = "";
            cbSubAccount.SelectedIndex = 0;
            txtNumber.Text = "";
            
            cmdCancel.Visible = false;

            dataGridView1.ClearSelection();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSubAccounts();
        }

        private void loadSubAccounts()
        {
            int accountId = 0;

            if (cbAccount.SelectedValue != null && int.TryParse(cbAccount.SelectedValue.ToString(), out accountId))
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Subaccounts' Puede moverla o quitarla según sea necesario.
                this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts, accountId, manager.Selected);

                loadDetails();
            }
        }

        private void loadDetails()
        {
            if (!fEditMode)
            {
                int subacctId = 0;

                if (cbSubAccount.SelectedValue != null && int.TryParse(cbSubAccount.SelectedValue.ToString(), out subacctId))
                {
                    // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
                    this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subacctId, manager.Selected);
                }
            }
        }

        private void cbSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDetails();
        }
    }
}
