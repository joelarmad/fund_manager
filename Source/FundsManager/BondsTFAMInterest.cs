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
    public partial class BondsTFAMInterest : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public BondsTFAMInterest()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                lvData.Items.Clear();

                DateTime _date = dtpDate.Value;

                List<BondsTFAM> _bondsList = manager.My_db.BondsTFAMs.Where(x => x.active == 1 && x.can_generate_interest == 1 && x.issued <= _date).OrderBy(x => x.Id).ToList();

                foreach (BondsTFAM _bond in _bondsList)
                {

                    BondsTFAMGeneratedInterest interestDetail = manager.My_db.BondsTFAMGeneratedInterests.FirstOrDefault(x => x.bond_id == _bond.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                    if (interestDetail == null)
                    {

                        string starting_date = _bond.issued.ToLongDateString();

                        DateTime? fromDate = getLastGeneratedInterestDateFor(_bond.Id);

                        if (fromDate == null)
                        {
                            fromDate = _bond.issued;
                        }

                        DateTime toDate = dtpDate.Value <= _bond.expired ? dtpDate.Value : _bond.expired;

                        int financingDays = (toDate.Date - fromDate.Value.Date).Days;

                        string[] row = {
                            _bond.Id.ToString(),
                            _bond.number,
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _bond.amount),
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:N2}", _bond.interest_on_bond) + "%",
                            String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:N2}", _bond.interest_tff_contribution) + "%",
                            _bond.issued.ToLongDateString(),
                            _bond.expired.ToLongDateString(),
                            financingDays.ToString()
                        };

                        ListViewItem my_item = new ListViewItem(row);
                        lvData.Items.Add(my_item);
                    }

                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private DateTime? getLastGeneratedInterestDateFor(int bondId)
        {
            try
            {
                BondsTFAMGeneratedInterest interest = manager.My_db.BondsTFAMGeneratedInterests.OrderByDescending(x => x.generated_interest_date).FirstOrDefault(x => x.bond_id == bondId);

                if (interest != null)
                {
                    return interest.generated_interest_date;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void generateInterest(bool forAll)
        {
            bool errorsDetected = false;
            string errorMessages = "";

            cmdGenerateInterest.Enabled = false;
            cmdGenerateAllInterest.Enabled = false;

            Account account840 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "840" && x.FK_Accounts_Funds == manager.Selected);
            Account account540 = manager.My_db.Accounts.FirstOrDefault(x => x.number == "540" && x.FK_Accounts_Funds == manager.Selected);

            if (account840 != null && account540 != null)
            {
                Subaccount subacct840 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account840.Id && x.name == "Interest on Bonds");
                Subaccount subacct540 = manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == account540.Id && x.name == "Interest Bond");

                if (subacct840 != null && subacct540 != null)
                {
                    try
                    {
                        if (manager.My_db.ClosedPeriods.FirstOrDefault(x => x.year == dtpDate.Value.Year) == null)
                        {
                            DateTime _date = Convert.ToDateTime(dtpDate.Text);

                            List<BondsTFAM> _bondsToGenerateInterest = new List<BondsTFAM>();

                            if (!forAll)
                            {
                                foreach (ListViewItem _item in lvData.SelectedItems)
                                {
                                    int bondId = 0;

                                    if (int.TryParse(_item.Text, out bondId))
                                    {
                                        BondsTFAM toGenerate = manager.My_db.BondsTFAMs.FirstOrDefault(x => x.Id == bondId);

                                        if (toGenerate != null)
                                        {
                                            _bondsToGenerateInterest.Add(toGenerate);
                                        }

                                        if (toGenerate.expired <= toGenerate.issued)
                                        {
                                            errorsDetected = true;
                                            errorMessages += "\rBond " + toGenerate.number + ": expire <= issued date.";
                                        }

                                        if (toGenerate.amount == 0)
                                        {
                                            errorsDetected = true;
                                            errorMessages += "\rBond " + toGenerate.number + ": amount = 0.";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (ListViewItem _item in lvData.Items)
                                {
                                    int bondId = 0;

                                    if (int.TryParse(_item.Text, out bondId))
                                    {
                                        BondsTFAM toGenerate = manager.My_db.BondsTFAMs.FirstOrDefault(x => x.Id == bondId);

                                        if (toGenerate != null)
                                        {
                                            _bondsToGenerateInterest.Add(toGenerate);
                                        }

                                        if (toGenerate.expired <= toGenerate.issued)
                                        {
                                            errorsDetected = true;
                                            errorMessages += "\rBond " + toGenerate.number + ": expire <= issued date.";
                                        }

                                        if (toGenerate.amount == 0)
                                        {
                                            errorsDetected = true;
                                            errorMessages += "\rBond " + toGenerate.number + ": amount = 0.";
                                        }
                                    }
                                }
                            }

                            if (errorsDetected)
                            {
                                if (MessageBox.Show("Do you want continue?\r\rThese bonds will be ignored in interest generation." + errorMessages, "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
                                {
                                    cmdGenerateInterest.Enabled = true;
                                    cmdGenerateAllInterest.Enabled = true;
                                    return;
                                }
                            }

                            if (_bondsToGenerateInterest.Count > 0)
                            {

                                foreach (BondsTFAM _bondToGenerate in _bondsToGenerateInterest)
                                {
                                    BondsTFAMGeneratedInterest existingInterest = manager.My_db.BondsTFAMGeneratedInterests.FirstOrDefault(x => x.bond_id == _bondToGenerate.Id && x.generated_interest_date.Year == _date.Year && x.generated_interest_date.Month == _date.Month);

                                    if (existingInterest == null)
                                    {
                                        DateTime? fromDate = getLastGeneratedInterestDateFor(_bondToGenerate.Id);

                                        if (fromDate == null)
                                        {
                                            fromDate = _bondToGenerate.issued;
                                        }

                                        bool canContinueGeneratingInterest = true;

                                        decimal _interestOnBond = 0;
                                        decimal _interestOnTFF = 0;

                                        DateTime toDate = dtpDate.Value <= _bondToGenerate.expired ? dtpDate.Value : _bondToGenerate.expired;

                                        int days = (toDate.Date - fromDate.Value.Date).Days;

                                        if (days > 0)
                                        {
                                            _interestOnBond = Math.Round(_bondToGenerate.amount * (decimal)_bondToGenerate.interest_on_bond * days / 360 / 100, 2);
                                            _interestOnTFF = Math.Round(_bondToGenerate.amount * (decimal)_bondToGenerate.interest_tff_contribution * days / 360 / 100, 2);
                                        }

                                        canContinueGeneratingInterest = toDate < _bondToGenerate.expired;

                                        if (_interestOnBond > 0 && _interestOnTFF > 0)
                                        {
                                            BondsTFAMGeneratedInterest _interest = new BondsTFAMGeneratedInterest();

                                            _interest.bond_id = _bondToGenerate.Id;
                                            _interest.generated_bond_interest = Math.Round(_interestOnBond, 2);
                                            _interest.generated_tff_interest = Math.Round(_interestOnTFF, 2);
                                            _interest.generated_interest_date = toDate;

                                            manager.My_db.BondsTFAMGeneratedInterests.Add(_interest);

                                            AccountingMovement _accountingMovement = new AccountingMovement();

                                            _accountingMovement.FK_AccountingMovements_Funds = manager.Selected;
                                            _accountingMovement.description = _bondToGenerate.number + " Interest";
                                            _accountingMovement.date = dtpDate.Value;
                                            _accountingMovement.reference = KeyDefinitions.NextAccountMovementReference(dtpDate.Value.Year);
                                            _accountingMovement.FK_AccountingMovements_Currencies = _bondToGenerate.currency_id;
                                            _accountingMovement.original_reference = "";
                                            _accountingMovement.contract = "";

                                            manager.My_db.AccountingMovements.Add(_accountingMovement);

                                            _interest.AccountingMovement = _accountingMovement;

                                            Movements_Accounts _maccount840 = new Movements_Accounts();

                                            _maccount840.AccountingMovement = _accountingMovement;
                                            _maccount840.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount840.FK_Movements_Accounts_Accounts = account840.Id;
                                            if (subacct840 != null)
                                                _maccount840.FK_Movements_Accounts_Subaccounts = subacct840.Id;
                                            _maccount840.debit = Math.Round(_interestOnBond + _interestOnTFF, 2);
                                            _maccount840.credit = 0;

                                            manager.My_db.Movements_Accounts.Add(_maccount840);

                                            Movements_Accounts _maccount540 = new Movements_Accounts();

                                            _maccount540.AccountingMovement = _accountingMovement;
                                            _maccount540.FK_Movements_Accounts_Funds = manager.Selected;
                                            _maccount540.FK_Movements_Accounts_Accounts = account540.Id;
                                            _maccount540.debit = 0;
                                            _maccount540.credit = Math.Round(_interestOnBond + _interestOnTFF, 2);

                                            manager.My_db.Movements_Accounts.Add(_maccount540);

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Attempt to duplicate bond interest generation.");
                                    }
                                }

                                manager.My_db.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("No bonds found for interest generation.");
                            }
                        }
                        else
                        {
                            ErrorMessage.showErrorMessage(new Exception("No movement allowed in closed period."));
                        }
                        

                    }
                    catch (Exception _ex)
                    {
                        ErrorMessage.showErrorMessage(_ex);
                    }
                }
                else
                {
                    ErrorMessage.showErrorMessage(new Exception("No subaccount for 840 or 540 were found."));
                }

                cmdGenerateInterest.Enabled = true;
                cmdGenerateAllInterest.Enabled = true;
            }
            else
            {
                ErrorMessage.showErrorMessage(new Exception("No account 840 or 540 were found."));
            }
        }

        private void cmdGenerateAllInterest_Click(object sender, EventArgs e)
        {
            generateInterest(true);

            LoadData();
        }

        private void cmdGenerateInterest_Click(object sender, EventArgs e)
        {
            generateInterest(false);

            LoadData();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
