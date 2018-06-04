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
        public EmployeesForm(MyFundsManager _manager)
        {
            manager = _manager;
            InitializeComponent();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fundsDBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.fundsDBDataSet.Employees);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee _employee = new Employee();
            _employee.name = textBox1.Text;
            _employee.FK_Employees_Funds = manager.Selected;
            manager.My_db.Employees.Add(_employee);
            manager.My_db.SaveChanges();
            textBox1.Clear();
            this.employeesTableAdapter.Fill(this.fundsDBDataSet.Employees);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult alert;
            alert = MessageBox.Show("Warning, this action can not be undone. Are you sure that´s what you want?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (alert == DialogResult.OK)
            {

                manager.DeleteEmployee(Convert.ToInt32(listBox1.SelectedValue));
                this.employeesTableAdapter.Fill(this.fundsDBDataSet.Employees);

            }
        }
    }
}
