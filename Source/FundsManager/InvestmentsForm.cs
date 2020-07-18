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
using FundsManager.Classes.Utilities;

namespace FundsManager
{
    public partial class InvestmentsForm : Form
    {
        private MyFundsManager manager;

        public bool EditingExistingInvestment = false;
        public Investment InvestmenToEdit = null;

        private decimal disbursement;
        private decimal profit;

        //private List<DisbursementForInvestement> disbursements;
        private List<Disbursement> disbursements;
        private List<Disbursement> toDelete;
        private List<int> fItemIds = new List<int>();

        private DateTime fMaxDisbursementDate;

        private string fContractPreffix = "";

        private bool fEditMode;

        public InvestmentsForm()
        {
            try
            {
                disbursement = 0;
                profit = 0;

                //disbursements = new List<DisbursementForInvestement>();
                disbursements = new List<Disbursement>();

                toDelete = new List<Disbursement>();

                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.InvestmentsForm: " + _ex.Message);
            }
        }

        private void InvestmentsForm_Load(object sender, EventArgs e)
        {
            try
            {

                txtExchangeRate.Text = String.Format("{0:0.00000000}", 1);
                txtProfitShare.Text = String.Format("{0:0.00}", 0);
                txtTotalToBeCollected.Text = String.Format("{0:0.00}", 0);

                this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);
                this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);
                this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);
                this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
                this.underlyingDebtorsTableAdapter.FillAddingEmptyRow(this.fundsDBDataSet.UnderlyingDebtors, manager.Selected);
                this.banksTableAdapter.FillExcludingOwnBanks(this.fundsDBDataSet.Banks, manager.Selected);
                this.letter_of_creditsTableAdapter.FillByBank(this.fundsDBDataSet.letter_of_credits, manager.Selected, int.Parse(cbBank.SelectedValue.ToString()));
                this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));

                Fund fund = manager.My_db.Funds.FirstOrDefault(x => x.Id == manager.Selected);

                if (fund != null)
                {
                    fContractPreffix = fund.contract_prefix + " - ";
                    lblContractPrefix.Text = "Contract:  " + fContractPreffix;
                }

                txtContract.Text = "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2);

                if (EditingExistingInvestment && InvestmenToEdit != null)
                {
                    cmdCreateInvestment.Text = "Save Investment";
                    cmdCreateInvestment.Enabled = true;

                    txtContract.Text = InvestmenToEdit.contract.Substring(fContractPreffix.Length);
                    txtContract.Enabled = false;

                    disbursements = manager.My_db.Disbursements.Where(x => x.investment_id == InvestmenToEdit.Id).ToList();

                    foreach (Disbursement disb in disbursements)
                    {
                        List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == disb.Id).ToList();

                        foreach (DisbursementItem item in items)
                        {
                            disb.AddItemId(item.ItemId);
                        }
                    }

                    loadDisbursements();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.InvestmentsForm_Load: " + _ex.Message);
            }
        }

        private void calculate_total_collection()
        {
            try
            {
                decimal _amount = 0;
                decimal _profit = 0;
                decimal _exchange = 0;

                if (decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profit)
                    && decimal.TryParse(txtExchangeRate.Text, out _exchange) && _exchange > 0)
                {
                    decimal toBeColected = Math.Round((_amount + _profit) / _exchange, 2);
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", toBeColected);
                }
                else
                {
                    txtTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.calculate_total_collection: " + _ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbBank.SelectedValue != null)
                {
                    this.letter_of_creditsTableAdapter.FillByBank(this.fundsDBDataSet.letter_of_credits, manager.Selected, int.Parse(cbBank.SelectedValue.ToString()));
                }

                if (cbLetterOfCredit.SelectedValue != null)
                {
                    this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));
                }

                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.comboBox4_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbItems.SelectedIndex >= 0 && !fItemIds.Contains((int)cbItems.SelectedValue))
                {
                    fItemIds.Add((int)cbItems.SelectedValue);

                    lbISelectedItems.Items.Add(cbItems.Text);

                    checkEnablingAddDisbursementButton();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.button1_Click: " + _ex.Message);
            }
        }

        private bool duplicatedDisbursementNumber()
        {
            int i = 0;
            foreach (Disbursement disb in disbursements)
            {
                if (disb.number == txtNumber.Text && (!fEditMode || (fEditMode && lvDisbursements.SelectedIndices.Count > 0 && lvDisbursements.SelectedIndices[0] != i)))
                {
                    return true;
                }

                i++;
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();

                if (!cmdAddDisbursement.Enabled)
                {
                    return;
                }

                float exchangeRate = 0;

                if (float.TryParse(txtExchangeRate.Text, out exchangeRate) && exchangeRate > 0)
                {
                    if (!duplicatedDisbursementNumber())
                    {
                        Disbursement toAdd = getDisbursementFromGUI();

                        if (fEditMode)
                        {
                            disbursements.RemoveAt(lvDisbursements.SelectedIndices[0]);
                        }

                        addDisbursement(toAdd);

                        loadDisbursements();

                        cmdCancel_Click(null, null);

                        checkEnablingAddInvestmentButton();
                    }
                    else
                    {
                        MessageBox.Show("Duplicated disbursement number.");
                    }
                }
                else
                {
                    MessageBox.Show("Error in exchage rate data.");
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.button2_Click: " + _ex.Message);
            }
        }

        private void loadDisbursements()
        {
            try
            {
                lvDisbursements.Items.Clear();

                Decimal total_amount = 0;
                Decimal total_profit = 0;
                Decimal total_euro_collection = 0;
                TimeSpan day = new TimeSpan();

                foreach (Disbursement _disbursement in disbursements)
                {
                    decimal _totalToBeCollected = _disbursement.amount + _disbursement.profit_share;

                    if (disbursements.First<Disbursement>().date != _disbursement.date)
                        day = _disbursement.date.Subtract(disbursements.First<Disbursement>().date);

                    string clientName = _disbursement.Client != null ? _disbursement.Client.name : _disbursement.TextClient;
                    string underlyingDebtorName = _disbursement.UnderlyingDebtor != null ? _disbursement.UnderlyingDebtor.name : _disbursement.TextUnderlyingDebtor;

                    string[] row = { _disbursement.number, clientName, underlyingDebtorName, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.profit_share), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _totalToBeCollected), _disbursement.collection_date.ToLongDateString(), _disbursement.date.ToLongDateString(), Convert.ToString(day.Days) };
                    ListViewItem my_item = new ListViewItem(row);
                    lvDisbursements.Items.Add(my_item);

                    total_amount += _disbursement.amount;
                    total_profit += _disbursement.profit_share;
                    total_euro_collection += _disbursement.Euro_collection;
                }

                if (disbursements.Count > 0)
                {
                    string[] totales = { "Total", "", "", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_euro_collection) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvDisbursements.Items.Add(listViewItemTotal);
                }                
            }
            catch (Exception)
            {
                
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal _totalDisbursement = 0;
                decimal _totalProfitShare = 0;

                Investment _newInvestment = new Investment();

                if (EditingExistingInvestment && InvestmenToEdit != null)
                {
                    _newInvestment = InvestmenToEdit;
                }
                else
                {
                    _newInvestment.contract = fContractPreffix + txtContract.Text;
                    _newInvestment.date = DateTime.Now.Date;
                    _newInvestment.fund_id = manager.Selected;
                    _newInvestment.number = DateTime.Now.Ticks.ToString();

                    manager.My_db.Investments.Add(_newInvestment);
                }

                foreach (Disbursement disbToDelete in toDelete)
                {
                    if (disbToDelete.Id > 0)
                    {
                        manager.My_db.Disbursements.Remove(disbToDelete);
                    }
                }

                foreach (Disbursement _disbursement in disbursements)
                {
                    _disbursement.Investment = _newInvestment;
                    _disbursement.contract = _newInvestment.contract;

                    _totalDisbursement += _disbursement.Euro_collection;
                    _totalProfitShare += _disbursement.profit_share;

                    if (_disbursement.Id == 0)
                    {
                        manager.My_db.Disbursements.Add(_disbursement);
                    }
                    else
                    {
                        List<DisbursementItem> items = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == _disbursement.Id).ToList();

                        foreach (DisbursementItem item in items)
                        {
                            manager.My_db.DisbursementItems.Remove(item);
                        }
                    }
                }

                _newInvestment.total_disbursement = Math.Round(_totalDisbursement, 2);
                _newInvestment.profit_share = Math.Round(_totalProfitShare, 2);

                manager.My_db.SaveChanges();

                foreach (Disbursement _disbursement in disbursements)
                {     
                    foreach (int _itemId in _disbursement.ItemsIds)
                    {
                        Item _item = manager.My_db.Items.FirstOrDefault(x => x.Id == _itemId);

                        if (_item != null)
                        {
                            DisbursementItem _disbursementItem = new DisbursementItem();
                            _disbursementItem.ItemId = _item.Id;
                            _disbursementItem.DisbursementId = _disbursement.Id;

                            manager.My_db.DisbursementItems.Add(_disbursementItem);
                        }
                    }
                }

                manager.My_db.SaveChanges();

                fItemIds.Clear();

                txtAmount.Text = "0";
                txtNumber.Text = "";
                txtContract.Text = "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2);
                txtProfitShare.Text = String.Format("{0:0.00}", 0);
                txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
                txtTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
                lbISelectedItems.Items.Clear();
                lvDisbursements.Items.Clear();

                fMaxDisbursementDate = DateTime.MinValue;

                disbursements.Clear();

                cmdCancel_Click(null, null);

                if (!EditingExistingInvestment)
                {
                    FundsManager.ReportForms.DibursementCreatedForm createdDisbursementsForm = new ReportForms.DibursementCreatedForm();
                    createdDisbursementsForm.investmentId = _newInvestment.Id;
                    createdDisbursementsForm.Show();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);
            }
        }

        private void checkEnablingAddDisbursementButton()
        {
            try
            {
                decimal _amount = 0;
                decimal _profitShare = 0;

                cmdAddDisbursement.Enabled = cbCurrency.SelectedIndex >= 0
                    && cbClient.SelectedIndex >= 0
                    && cbSector.SelectedIndex >= 0
                    && decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profitShare)
                    && txtNumber.Text.Trim() != ""
                    && (_amount > 0 || _profitShare >= 0);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.checkEnablingAddDisbursementButton: " + _ex.Message);
            }
        }

        private void checkEnablingAddInvestmentButton()
        {
            cmdCreateInvestment.Enabled = disbursements.Count > 0;
        }

        private void cmdDeleteDisbursement_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDisbursements.SelectedIndices.Count > 0)
                {
                    toDelete.Add(disbursements[lvDisbursements.SelectedIndices[0]]);
                    disbursements.RemoveAt(lvDisbursements.SelectedIndices[0]);
                }

                loadDisbursements();

                checkEnablingAddInvestmentButton();

                cmdCancel_Click(null, null);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cmdDeleteDisbursement_Click: " + _ex.Message);
            }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cbCurrency_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cbClient_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbUnderlyingDebtor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cbUnderlyingDebtor_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddInvestmentButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cbSector_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.cbItems_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void dtpDisbursementDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.dtpDisbursementDate_ValueChanged: " + _ex.Message);
            }
        }

        

        private void lvDisbursements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvDisbursements.SelectedIndices.Count > 0)
                {
                    if (lvDisbursements.SelectedIndices[0] == lvDisbursements.Items.Count - 1)
                    {
                        lvDisbursements.SelectedIndices.Clear();
                    }
                    else
                    {
                        Disbursement selected = disbursements[lvDisbursements.SelectedIndices[0]];

                        if (selected.pay_date.HasValue)
                        {
                            lvDisbursements.SelectedIndices.Clear();
                            MessageBox.Show("This disbursement has been already paid.");
                        }
                    }
                }   

                if (lvDisbursements.SelectedIndices.Count > 0)
                {
                    fEditMode = true;
                    cmdDeleteDisbursement.Enabled = true;
                    cmdAddDisbursement.Enabled = true;
                    cmdAddDisbursement.Text = "Save Disbursement";
                    cmdCancel.Visible = true;

                    Disbursement selected = disbursements[lvDisbursements.SelectedIndices[0]];

                    txtAmount.Text = String.Format("{0:0.00}", selected.amount * (decimal)selected.exchange_rate);

                    if (selected.currency_id > 0)
                    {
                        for (int i = 0; i < cbCurrency.Items.Count; i++)
                        {
                            cbCurrency.SelectedIndex = i;

                            if (cbCurrency.SelectedValue.ToString() == selected.currency_id.ToString())
                                break;
                        }
                    }

                    txtExchangeRate.Text = String.Format("{0:0.0000000}", selected.exchange_rate);
                    txtProfitShare.Text = String.Format("{0:0.00}", selected.profit_share);
                    txtNumber.Text = selected.number;
                    txtTotalToBeCollected.Text = String.Format("{0:0.00}", selected.Euro_collection);

                    if (selected.client_id > 0)
                    {
                        for (int i = 0; i < cbClient.Items.Count; i++)
                        {
                            cbClient.SelectedIndex = i;

                            if (cbClient.SelectedValue.ToString() == selected.client_id.ToString())
                                break;
                        }
                    }

                    if (selected.underlying_debtor_id > 0)
                    {
                        for (int i = 0; i < cbUnderlyingDebtor.Items.Count; i++)
                        {
                            cbUnderlyingDebtor.SelectedIndex = i;

                            if (cbUnderlyingDebtor.SelectedValue.ToString() == selected.underlying_debtor_id.ToString())
                                break;
                        }
                    }

                    if (selected.bank_risk_id > 0)
                    {
                        for (int i = 0; i < cbBank.Items.Count; i++)
                        {
                            cbBank.SelectedIndex = i;

                            if (cbBank.SelectedValue.ToString() == selected.bank_risk_id.ToString())
                                break;
                        }
                    }

                    if (selected.shipment_id > 0)
                    {
                        Shipment shipment = manager.My_db.Shipments.FirstOrDefault(x => x.Id == selected.shipment_id);

                        if (shipment != null)
                        {
                            letter_of_credits letter = manager.My_db.letter_of_credits.FirstOrDefault(x => x.Id == shipment.LetterOfCreditId);

                            if (letter != null)
                            {
                                this.letter_of_creditsTableAdapter.FillByBank(this.fundsDBDataSet.letter_of_credits, manager.Selected, int.Parse(cbBank.SelectedValue.ToString()));

                                for (int i = 0; i < cbLetterOfCredit.Items.Count; i++)
                                {
                                    cbLetterOfCredit.SelectedIndex = i;

                                    if (cbLetterOfCredit.SelectedValue.ToString() == letter.Id.ToString())
                                    {
                                        this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));

                                        for (int j = 0; j < cbShipment.Items.Count; j++)
                                        {
                                            cbShipment.SelectedIndex = j;

                                            if (cbShipment.SelectedValue.ToString() == shipment.Id.ToString())
                                                break;
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (selected.sector_id > 0)
                    {
                        for (int i = 0; i < cbSector.Items.Count; i++)
                        {
                            cbSector.SelectedIndex = i;

                            if (cbSector.SelectedValue.ToString() == selected.sector_id.ToString())
                                break;
                        }
                    }

                    fItemIds.Clear();
                    lbISelectedItems.Items.Clear();
                    lbISelectedItems.Text = "";

                    foreach (int itemId in selected.ItemsIds)
                    {
                        fItemIds.Add(itemId);

                        for (int i = 0; i < cbItems.Items.Count; i++)
                        {
                            cbItems.SelectedIndex = i;

                            if (cbItems.SelectedValue.ToString() == itemId.ToString())
                            {
                                string name = ((FundsManager.FundsDBDataSet.ItemsRow)((System.Data.DataRowView)cbItems.Items[i]).Row).name;
                                lbISelectedItems.Items.Add(name);
                            }
                        }                        
                    }

                    dtpCollectionDate.Value = selected.collection_date;

                    dtpDisbursementDate.Value = selected.date;
                }
                else
                {
                    fEditMode = false;
                    cmdDeleteDisbursement.Enabled = false;
                    cmdAddDisbursement.Text = "Add Disbursement";
                    cmdCancel.Visible = false;
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.lvDisbursements_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void lbISelectedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdDeleteItem.Enabled = lbISelectedItems.SelectedIndex >= 0;
        }

        private void cmdDeleteItem_Click(object sender, EventArgs e)
        {
            if (lbISelectedItems.SelectedIndex >= 0)
            {
                fItemIds.RemoveAt(lbISelectedItems.SelectedIndex);
                lbISelectedItems.Items.RemoveAt(lbISelectedItems.SelectedIndex);

                checkEnablingAddDisbursementButton();
            }
        }

        private void DisbursementsForm_Click(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
            checkEnablingAddInvestmentButton();
        }

        




        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtAmount_KeyUp: " + _ex.Message);
            }
        }
        
        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                    

                decimal _result = 0;
                if (!decimal.TryParse(txtAmount.Text, out _result) || _result <= 0)
                {
                    txtAmount.Text = "0";
                }
                else
                {
                    disbursement = _result;
                    txtAmount.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtAmount_Leave: " + _ex.Message);
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtAmount_TextChanged: " + _ex.Message);
            }
        }

        private void txtAmount_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtExchangeRate_KeyUp: " + _ex.Message);
            }
        }

        private void txtExchangeRate_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtExchangeRate.Text, out _result) || _result <= 0)
                {
                    txtExchangeRate.Text = String.Format("{0:0.0000000}", 1);
                }
                else
                {
                    txtExchangeRate.Text = String.Format("{0:0.0000000}", _result);
                }

                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtExchangeRate_Leave: " + _ex.Message);
            }
        }

        private void txtExchangeRate_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtProfitShare_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtProfitShare_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtProfitShare.Text, out _result) || _result < 0)
                {
                    txtProfitShare.Text = String.Format("{0:0.00}", 0);
                }
                else
                {
                    profit = _result;
                    txtProfitShare.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtProfitShare_Leave: " + _ex.Message);
            }
        }

        private void txtProfitShare_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtProfitShare_KeyUp: " + _ex.Message);
            }
        }

        private void txtProfitShare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.txtProfitShare_TextChanged: " + _ex.Message);
            }
        }

        private void txtContract_Enter(object sender, EventArgs e)
        {
            if (txtContract.Text == "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2))
            {
                txtContract.SelectionStart = 0;
                txtContract.SelectionLength = 3;
                txtContract.Select();
            }
        }

        private void txtContract_Click(object sender, EventArgs e)
        {
            if (txtContract.Text == "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2))
            {
                txtContract.SelectionStart = 0;
                txtContract.SelectionLength = 3;
                txtContract.Select();
            }
        }

        private void cbCurrency_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void txtNumber_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbClient_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbUnderlyingDebtor_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbBank_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbSector_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbItems_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void lbISelectedItems_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void dtpDisbursementDate_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void dtpCollectionDate_Leave(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cbLetterOfCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLetterOfCredit.SelectedValue != null)
            {
                this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));
            }
            checkEnablingAddDisbursementButton();
        }

        private void cbShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            lvDisbursements.SelectedIndices.Clear();
            lvDisbursements_SelectedIndexChanged(null, null);
            cmdAddDisbursement.Enabled = false;
            txtAmount.Text = "0";
            cbCurrency.SelectedIndex = 0;
            txtExchangeRate.Text = String.Format("{0:0.00000000}", 1);
            txtProfitShare.Text = String.Format("{0:0.00}", 0);
            txtNumber.Text = "";
            txtTotalToBeCollected.Text = String.Format("{0:0.00}", 0);
            cbClient.SelectedIndex = 0;
            cbUnderlyingDebtor.SelectedIndex = 0;
            cbBank.SelectedIndex = 0;
            cbLetterOfCredit.SelectedIndex = 0;
            cbShipment.SelectedIndex = 0;
            cbSector.SelectedIndex = 0;
            cbItems.SelectedIndex = 0;
            lbISelectedItems.Items.Clear();
            dtpDisbursementDate.Value = DateTime.Now;
            dtpCollectionDate.Value = DateTime.Now;
            cmdDeleteItem.Enabled = false;
            fItemIds.Clear();
        }

        private Disbursement getDisbursementFromGUI()
        {
            try
            {
                Disbursement _disbursement = new Disbursement();

                _disbursement.has_bookings = false;
                _disbursement.is_booking = false;
                _disbursement.delay_interest = 0;


                float exchangeRate = 0;

                if (float.TryParse(txtExchangeRate.Text, out exchangeRate) && exchangeRate > 0)
                {
                    if (fEditMode && lvDisbursements.SelectedIndices.Count > 0)
                    {
                        _disbursement = disbursements[lvDisbursements.SelectedIndices[0]];
                    }

                    _disbursement.fund_id = manager.Selected;

                    int? bankId = null;

                    if (cbBank.SelectedValue.ToString() != "0")
                    {
                        bankId = Convert.ToInt32(cbBank.SelectedValue);
                    }

                    int? underDebtorId = null;

                    if (cbUnderlyingDebtor.SelectedValue.ToString() != "0")
                    {
                        underDebtorId = Convert.ToInt32(cbUnderlyingDebtor.SelectedValue);
                    }

                    int? shipmentId = null;

                    if (cbShipment.SelectedValue.ToString() != "0")
                    {
                        shipmentId = Convert.ToInt32(cbShipment.SelectedValue);
                    }

                    _disbursement.exchange_rate = exchangeRate;
                    _disbursement.amount = Math.Round(Convert.ToDecimal(txtAmount.Text) / (decimal)exchangeRate, 2);
                    _disbursement.profit_share = Math.Round(Convert.ToDecimal(txtProfitShare.Text) / (decimal)exchangeRate, 2);
                    _disbursement.currency_id = Convert.ToInt32(cbCurrency.SelectedValue);

                    _disbursement.bank_risk_id = bankId;

                    _disbursement.client_id = Convert.ToInt32(cbClient.SelectedValue);

                    _disbursement.underlying_debtor_id = underDebtorId;

                    _disbursement.date = Convert.ToDateTime(dtpDisbursementDate.Text);
                    _disbursement.collection_date = Convert.ToDateTime(dtpCollectionDate.Text);
                    _disbursement.sector_id = Convert.ToInt32(cbSector.SelectedValue);
                    _disbursement.number = txtNumber.Text;
                    _disbursement.can_generate_interest = false;

                    _disbursement.TextClient = cbClient.Text;
                    _disbursement.TextUnderlyingDebtor = cbUnderlyingDebtor.Text;

                    _disbursement.Euro_collection = _disbursement.amount + _disbursement.profit_share;

                    _disbursement.shipment_id = shipmentId;

                    _disbursement.ItemsIds.Clear();

                    foreach (int _itemId in fItemIds)
                    {
                        _disbursement.AddItemId(_itemId);
                    }

                    _disbursement.collected = false;

                    return _disbursement;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void addDisbursement(Disbursement toAdd)
        {
            if (toAdd != null)
            {
                int _index = -1;

                for (int i = 0; i < disbursements.Count; i++)
                {
                    Disbursement _item = disbursements[i];

                    if (_item.date > toAdd.date)
                    {
                        disbursements.Insert(i, toAdd);
                        _index = i;
                        break;
                    }
                }

                if (_index == -1)
                {
                    disbursements.Add(toAdd);
                }
            }
        }

        private void txtNumber_KeyUp(object sender, KeyEventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }
    }
}
