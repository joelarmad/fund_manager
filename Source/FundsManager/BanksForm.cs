﻿using FundsManager.Classes.Utilities;
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
    public partial class BanksForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public BanksForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void BanksForm_Load(object sender, EventArgs e)
        {
            this.banksTableAdapter.FillByFund(this.fundsDBDataSet.Banks, manager.Selected);
            this.countriesTableAdapter.FillByFund(this.fundsDBDataSet.Countries, manager.Selected);

            listBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    Bank _bank = new Bank();
                    _bank.name = txtName.Text;
                    _bank.FK_Banks_Funds = manager.Selected;
                    _bank.FK_Banks_Countries = Convert.ToInt32(cbCountry.SelectedValue);
                    _bank.number = txtNumber.Text;
    
                if (chkOurBank.Checked)
                        _bank.own = 1;
                    else
                        _bank.own = 0;


                    manager.My_db.Banks.Add(_bank);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    Bank _selectedItem = manager.My_db.Banks.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.FK_Banks_Countries = Convert.ToInt32(cbCountry.SelectedValue);
                        _selectedItem.own = chkOurBank.Checked ? 1 : 0;
                        _selectedItem.number = txtNumber.Text;

                        manager.My_db.SaveChanges();
                    }
                }


                cmdCancel_Click(null, null);

                this.banksTableAdapter.FillByFund(this.fundsDBDataSet.Banks, manager.Selected);
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert;
                alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (alert == DialogResult.OK)
                {

                    manager.DeleteBank(Convert.ToInt32(listBox1.SelectedValue));
                    this.banksTableAdapter.FillByFund(this.fundsDBDataSet.Banks, manager.Selected);

                    cmdCancel_Click(null, null);
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                fEditMode = true;
                cmdAddOrSave.Text = "Save";

                Bank _selectedItem = manager.My_db.Banks.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    txtName.Text = _selectedItem.name;
                    txtNumber.Text = _selectedItem.number;

                    foreach (DataRowView _item in cbCountry.Items)
                    {
                        if (_item.Row[0].ToString() == _selectedItem.FK_Banks_Countries.ToString())
                        {
                            cbCountry.SelectedItem = _item;
                            break;
                        }
                    }

                    chkOurBank.Checked = _selectedItem.own != 0;
                }

                cmdCancel.Visible = true;
            }
            else
            {
                fEditMode = false;
                cmdAddOrSave.Text = "Add";
                txtName.Text = "";
                cbCountry.SelectedIndex = 0;
                chkOurBank.Checked = false;
                txtNumber.Text = "";

                cmdCancel.Visible = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
