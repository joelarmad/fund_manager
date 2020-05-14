using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.Classes.Utilities;
using FundsManager.Classes.Task;
using System.Collections;
using System.Globalization;

namespace FundsManager
{
    public partial class BondsTFAMForm : Form
    {
        private MyFundsManager manager;

        private int fBondConsecutive = 0;

        public BondsTFAMForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.BondsForm: " + _ex.Message);
            }
        }

        private void BondsForm_Load(object sender, EventArgs e)
        {
            this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);

            cbCurrency.SelectedIndex = 0;

            try
            {
                fBondConsecutive = 0;

                Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BONDTFAM_CONSECUTIVE_KEY);

                if (_resource != null && _resource.Value != null && int.TryParse(_resource.Value, out fBondConsecutive))
                {
                    txtNumber.Text = "Bond " + Conversions.toRomanNumeral(fBondConsecutive);
                }

                dtpExpirationDate.Value = dtpIssuingDate.Value.AddDays(30);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.BondsForm_Load: " + _ex.Message);
            }
        }

        private bool doValidations()
        {
            double amount = 0;
            double bondInterest = 0;
            double tffInterest = 0;

            if (cbCurrency.SelectedItem != null && 
                double.TryParse(txtAmount.Text, out amount) && 
                double.TryParse(txtBondInterest.Text, out bondInterest) && 
                double.TryParse(txtTFFInterest.Text, out tffInterest) && 
                amount > 0 && bondInterest > 0 && tffInterest > 0 && 
                dtpIssuingDate.Value.CompareTo(dtpExpirationDate.Value) < 0)
            {
                return true;
            }
            return false;
        }

        private void cmdAddBond_Click(object sender, EventArgs e)
        {
            try
            {
                if (doValidations())
                {
                    BondsTFAM bond = new BondsTFAM();
                    bond.number = txtNumber.Text;
                    bond.issued = Convert.ToDateTime(dtpIssuingDate.Text);
                    bond.expired = Convert.ToDateTime(dtpExpirationDate.Text);
                    bond.FK_Bonds_Funds = manager.Selected;
                    bond.amount = Math.Round(Convert.ToDecimal(txtAmount.Text), 2);
                    bond.interest_on_bond = Convert.ToInt32(txtBondInterest.Text);
                    bond.interest_tff_contribution = Convert.ToInt32(txtTFFInterest.Text);
                    bond.currency_id = int.Parse(cbCurrency.SelectedValue.ToString());

                    bond.active = 0;

                    manager.My_db.BondsTFAMs.Add(bond);

                    Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BONDTFAM_CONSECUTIVE_KEY);

                    fBondConsecutive++;

                    _resource.Value = fBondConsecutive.ToString();

                    manager.My_db.SaveChanges();

                    txtNumber.Text = "Bond " + Conversions.toRomanNumeral(fBondConsecutive);
                    txtAmount.Text = "0";
                    txtBondInterest.Text = "10";
                    txtTFFInterest.Text = "1";
                    txtAmount.ReadOnly = false;

                    MessageBox.Show("Bond has been saved", "");
                }
                else
                {
                    MessageBox.Show("Data verification error.", "Error");
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }
    }
}
