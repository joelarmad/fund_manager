using FundsManager.Classes.Utilities;
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
    public partial class LetterOfCreditForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        private bool fEditMode = false;

        public LetterOfCreditForm()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            addLetter();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            fEditMode = false;
            cmdAdd.Text = "Add";

            txtAmount.Text = "";
            txtReference.Text = "";

            cmdCancel.Visible = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {
                    int _id = int.Parse(listBox1.SelectedValue.ToString());

                    manager.DeleteLetter(_id);

                    loadLettersData();

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void LetterOfCreditForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Banks' Puede moverla o quitarla según sea necesario.
            this.banksTableAdapter.FillExcludingOwnWithNoEmpty(this.fundsDBDataSet.Banks, manager.Selected);

            loadLettersData();
        }

        private void loadLettersData()
        {
            if (fundsDBDataSet != null && cbBank.SelectedValue != null)
            {
                this.letter_of_creditsTableAdapter.FillByBankWithNoEmpty(this.fundsDBDataSet.letter_of_credits, int.Parse(cbBank.SelectedValue.ToString()), manager.Selected);
            }

            listBox1.SelectedIndex = -1;
        }

        private void addLetter()
        {
            try
            {
                int bankId = Convert.ToInt32(cbBank.SelectedValue);

                if (!fEditMode)
                {
                    letter_of_credits _validation = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Reference == txtReference.Text && x.BankId == bankId && x.FundId == manager.Selected);

                    if (_validation != null)
                    {
                        MessageBox.Show("Duplicated reference.");
                        return;
                    }

                    letter_of_credits _letter = new letter_of_credits();
                    _letter.Reference = txtReference.Text;
                    _letter.BankId = bankId;
                    _letter.FundId = manager.Selected;
                    _letter.Amount = decimal.Parse(txtAmount.Text);
                    manager.My_db.letter_of_credits.Add(_letter);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    int _id = int.Parse(listBox1.SelectedValue.ToString());

                    letter_of_credits _validation = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Id != _id && x.Reference == txtReference.Text && x.BankId == bankId && x.FundId == manager.Selected);

                    if (_validation != null)
                    {
                        MessageBox.Show("Duplicated reference.");
                        return;
                    }

                    letter_of_credits _selected = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Id == _id);

                    if (_selected != null)
                    {
                        _selected.Reference = txtReference.Text;
                        _selected.Amount = decimal.Parse(txtAmount.Text);
                        _selected.BankId = Convert.ToInt32(cbBank.SelectedValue);

                        manager.My_db.SaveChanges();
                    }
                }

                loadLettersData();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void cbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                loadLettersData();

                cmdCancel_Click(null, null);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int letterId = 0;

                if (listBox1.SelectedValue != null && int.TryParse(listBox1.SelectedValue.ToString(), out letterId))
                {
                    letter_of_credits _selected = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Id == letterId);

                    if (_selected != null)
                    {
                        fEditMode = true;
                        cmdAdd.Text = "Save";

                        txtReference.Text = _selected.Reference;
                        txtAmount.Text = String.Format("{0:n}", _selected.Amount);

                        Bank bank = manager.My_db.Banks.FirstOrDefault(x => x.Id == _selected.BankId);

                        foreach (DataRowView _item in cbBank.Items)
                        {
                            if (_item.Row[0].ToString() == bank.Id.ToString())
                            {
                                cbBank.SelectedItem = _item;
                                break;
                            }
                        }

                        cmdCancel.Visible = true;
                    }
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show("Error: " + _ex.Message);
            }
        }
    }
}
