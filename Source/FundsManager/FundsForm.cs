﻿using System;
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
    public partial class FundsForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;
        
        public FundsForm()
        {
            manager = MyFundsManager.SingletonInstance;            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fEditMode)
            {
                Fund _fund = new Fund();
                _fund.name = txtName.Text;
                _fund.contract_prefix = txtContractPrefix.Text;
                manager.My_db.Funds.Add(_fund);
                manager.My_db.SaveChanges();
                txtName.Clear();
                txtContractPrefix.Clear();
                this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);
            }
            else
            {
                Fund _selectedFund = manager.My_db.Funds.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedFund != null)
                {
                    _selectedFund.name = txtName.Text;
                    _selectedFund.contract_prefix = txtContractPrefix.Text;

                    manager.My_db.SaveChanges();

                    this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);
                }
            }
            

            listBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action would delete all the operations of this fund. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {
                
                manager.DeleteFund(Convert.ToInt32(listBox1.SelectedValue));                
                this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);
                listBox1.SelectedIndex = -1;
            }
        }

        private void FundsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Funds' table. You can move, or remove it, as needed.
            this.fundsTableAdapter.Fill(this.fundsDBDataSet.Funds);

            listBox1.SelectedIndex = -1;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                fEditMode = true;
                cmdAddOrUpdate.Text = "Save";

                Fund _selectedFund = manager.My_db.Funds.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedFund != null)
                {
                    txtName.Text = _selectedFund.name;
                    txtContractPrefix.Text = _selectedFund.contract_prefix;
                }

                cmdCancelEdit.Visible = true;
            }
            else
            {
                fEditMode = false;
                cmdAddOrUpdate.Text = "Add";
                txtName.Text = "";
                txtContractPrefix.Text = "";

                cmdCancelEdit.Visible = false;
            }
        }

        private void cmdCancelEdit_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }
    }
}
