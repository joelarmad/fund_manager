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
    public partial class EmployeesForm : Form
    {
        private MyFundsManager manager;

        private bool fEditMode = false;

        public EmployeesForm()
        {
            manager = MyFundsManager.SingletonInstance;
            InitializeComponent();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            this.employeesTableAdapter.FillByFund(this.fundsDBDataSet.Employees, manager.Selected);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fEditMode)
                {
                    Employee _employee = new Employee();
                    _employee.name = txtName.Text;
                    _employee.FK_Employees_Funds = manager.Selected;
                    _employee.number = txtNumber.Text;
                    manager.My_db.Employees.Add(_employee);
                    manager.My_db.SaveChanges();
                }
                else
                {
                    Employee _selectedItem = manager.My_db.Employees.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                    if (_selectedItem != null)
                    {
                        _selectedItem.name = txtName.Text;
                        _selectedItem.number = txtNumber.Text;
                        manager.My_db.SaveChanges();
                    }
                }

                this.employeesTableAdapter.FillByFund(this.fundsDBDataSet.Employees, manager.Selected);

                cmdCancel_Click(null, null);
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

                    manager.DeleteEmployee(Convert.ToInt32(listBox1.SelectedValue));
                    this.employeesTableAdapter.FillByFund(this.fundsDBDataSet.Employees, manager.Selected);
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

                Employee _selectedItem = manager.My_db.Employees.FirstOrDefault(x => x.Id == (int)listBox1.SelectedValue);

                if (_selectedItem != null)
                {
                    txtName.Text = _selectedItem.name;
                    txtNumber.Text = _selectedItem.number;
                }

                cmdCancel.Visible = true;
            }
            else
            {
                fEditMode = false;
                cmdAddOrSave.Text = "Add";
                txtName.Text = "";
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
