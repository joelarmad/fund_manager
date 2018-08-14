using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace FundsManager
{
    public partial class DisbursementsForm : Form
    {
        private MyFundsManager manager;

        private Account cashAtBank;

        public DisbursementsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm: " + _ex.Message);
            }
        }

        private void DisbursementsForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Investments' Puede moverla o quitarla según sea necesario.
            this.investmentsTableAdapter.Fill(this.fundsDBDataSet.Investments);
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);

            try
            {
                cashAtBank = manager.My_db.Accounts.FirstOrDefault(x => x.number == "110");

                if (cashAtBank != null)
                {
                    lblAccount.Text = cashAtBank.name;
                    cbSubAccount.Enabled = true;
                    cbOtherDetails.Enabled = true;
                }

                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Subaccounts' Puede moverla o quitarla según sea necesario.
                this.subaccountsTableAdapter.FillByAccount(this.fundsDBDataSet.Subaccounts, cashAtBank.Id, manager.Selected);

                updateOtherDetailsCombobox();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm_Load: " + _ex.Message);
            }
        }

        private void updateOtherDetailsCombobox()
        {
            int subAccountId = 0;

            if (cbSubAccount.SelectedValue != null && int.TryParse(cbSubAccount.SelectedValue.ToString(), out subAccountId))
            {
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.OtherDetails' Puede moverla o quitarla según sea necesario.
                this.otherDetailsTableAdapter.FillBySubaccount(this.fundsDBDataSet.OtherDetails, subAccountId, manager.Selected);
            }
        }

        private void cbSubAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateOtherDetailsCombobox();
        }
    }
}
