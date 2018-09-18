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

        private Double disbursement;
        private Double profit;

        //private List<DisbursementForInvestement> disbursements;
        private List<Disbursement> disbursements;
        private List<int> fItemIds = new List<int>();

        private DateTime fMaxDisbursementDate;

        private string fContractPreffix = "";

        public InvestmentsForm()
        {
            try
            {
                disbursement = 0;
                profit = 0;

                //disbursements = new List<DisbursementForInvestement>();
                disbursements = new List<Disbursement>();

                manager = MyFundsManager.SingletonInstance;
                InitializeComponent();

                cbCurrency.SelectedValueChanged += getExchangeRate;
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

                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Clients' Puede moverla o quitarla según sea necesario.
                this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Items' table. You can move, or remove it, as needed.
                this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Sectors' table. You can move, or remove it, as needed.
                this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
                this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.UnderlyingDebtors' Puede moverla o quitarla según sea necesario.
                this.underlyingDebtorsTableAdapter.FillAddingEmptyRow(this.fundsDBDataSet.UnderlyingDebtors, manager.Selected);
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Banks' Puede moverla o quitarla según sea necesario.
                this.banksTableAdapter.FillExcludingOwnBanks(this.fundsDBDataSet.Banks, manager.Selected);
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.letter_of_credits' Puede moverla o quitarla según sea necesario.
                this.letter_of_creditsTableAdapter.FillByBank(this.fundsDBDataSet.letter_of_credits, manager.Selected, int.Parse(cbBank.SelectedValue.ToString()));
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Shipments' Puede moverla o quitarla según sea necesario.
                this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));

                Fund fund = manager.My_db.Funds.FirstOrDefault(x => x.Id == manager.Selected);

                if (fund != null)
                {
                    fContractPreffix = fund.contract_prefix + " - ";
                    lblContractPrefix.Text = "Contract:  " + fContractPreffix;
                }


                txtContract.Text = "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.InvestmentsForm_Load: " + _ex.Message);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value;
                if (Double.TryParse(txtAmount.Text, out value))
                    disbursement = value;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.textBox1_Leave: " + _ex.Message);
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value;
                if (Double.TryParse(txtProfitShare.Text, out value))
                    profit = value;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.textBox3_Leave: " + _ex.Message);
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
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", ((_amount + _profit) / _exchange));
                }
                else
                {
                    txtTotalToBeCollected.Text = "0.0";
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.calculate_total_collection: " + _ex.Message);
            }
        }

        private void getExchangeRate(object sender, EventArgs e)
        {
            try
            {
                Double value = 0;

                if (disbursement > 0 && profit > 0 && double.TryParse(txtExchangeRate.Text, out value))
                {
                    value = (disbursement + profit) / value;
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", value);
                }
                else
                {
                    txtTotalToBeCollected.Text = "0.0";
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in InvestmentsForm.getExchangeRate: " + _ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbBank.SelectedValue != null)
                {
                    // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.letter_of_credits' Puede moverla o quitarla según sea necesario.
                    this.letter_of_creditsTableAdapter.FillByBank(this.fundsDBDataSet.letter_of_credits, manager.Selected, int.Parse(cbBank.SelectedValue.ToString()));
                }

                if (cbLetterOfCredit.SelectedValue != null)
                {
                    // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Shipments' Puede moverla o quitarla según sea necesario.
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();

                if (!cmdAddDisbursement.Enabled)
                {
                    return;
                }

                Decimal total_amount = 0;
                Decimal total_profit = 0;
                Decimal total_euro_collection = 0;
                TimeSpan day = new TimeSpan();
                float exchangeRate = 0;

                if (float.TryParse(txtExchangeRate.Text, out exchangeRate) && exchangeRate > 0)
                {
                    Disbursement _disbursement = new Disbursement();

                    _disbursement.fund_id = manager.Selected;

                    int bankId = Convert.ToInt32(cbBank.SelectedValue);

                    int underDebtorId = Convert.ToInt32(cbUnderlyingDebtor.SelectedValue);

                    int shipmentId = Convert.ToInt32(cbShipment.SelectedValue);

                    _disbursement.exchange_rate = exchangeRate;
                    _disbursement.amount = Convert.ToDecimal(txtAmount.Text) / (decimal)exchangeRate;
                    _disbursement.profit_share = Convert.ToDecimal(txtProfitShare.Text) / (decimal)exchangeRate;
                    _disbursement.currency_id = Convert.ToInt32(cbCurrency.SelectedValue);                    

                    if (bankId > 0)
                    {
                        _disbursement.bank_risk_id = bankId;
                    }

                    _disbursement.client_id = Convert.ToInt32(cbClient.SelectedValue);

                    if (underDebtorId > 0)
                    {
                        _disbursement.underlying_debtor_id = underDebtorId;
                    }
                                        
                    _disbursement.date = Convert.ToDateTime(dtpDisbursementDate.Text);
                    _disbursement.collection_date = Convert.ToDateTime(dtpCollectionDate.Text);
                    _disbursement.sector_id = Convert.ToInt32(cbSector.SelectedValue);
                    _disbursement.number = txtNumber.Text;
                    _disbursement.can_generate_interest = false;

                    _disbursement.TextClient = cbClient.Text;
                    _disbursement.TextUnderlyingDebtor = cbUnderlyingDebtor.Text;

                    _disbursement.Euro_collection = _disbursement.amount + _disbursement.profit_share;

                    if (shipmentId > 0)
                    {
                        _disbursement.shipment_id = shipmentId;
                    }

                    foreach (int _itemId in fItemIds)
                    {
                        _disbursement.ItemsIds.Add(_itemId);
                    }

                    int _index = -1;

                    for (int i = 0; i < disbursements.Count; i++)
                    {
                        Disbursement _item = disbursements[i];

                        if (_item.date > _disbursement.date)
                        {
                            disbursements.Insert(i, _disbursement);
                            _index = i;
                            break;
                        }
                    }

                    if (_index == -1)
                    {
                        disbursements.Add(_disbursement);
                    }

                    if (disbursements.First<Disbursement>().date != _disbursement.date)
                        day = _disbursement.date.Subtract(disbursements.First<Disbursement>().date);

                    if (lvDisbursements.Items.Count > 0)
                        lvDisbursements.Items.RemoveAt(lvDisbursements.Items.Count - 1);

                    string[] row = { cbClient.Text, cbUnderlyingDebtor.Text,
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.amount),
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", _disbursement.profit_share),
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", _disbursement.Euro_collection),
                        dtpCollectionDate.Text,
                        dtpDisbursementDate.Text,
                        Convert.ToString(day.Days) };
                    ListViewItem my_item = new ListViewItem(row);

                    if (_index == -1)
                    {
                        lvDisbursements.Items.Add(my_item);
                    }
                    else
                    {
                        lvDisbursements.Items.Insert(_index, my_item);
                    }

                    foreach (Disbursement _dis in disbursements)
                    {
                        total_amount += _dis.amount;
                        total_profit += _dis.profit_share;
                        total_euro_collection += _dis.Euro_collection;
                    }

                    string[] totales = { "Total", "",
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount),
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", total_profit),
                        String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", total_euro_collection) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvDisbursements.Items.Add(listViewItemTotal);

                    txtAmount.Text = "0";
                    txtProfitShare.Text = "1";
                    txtExchangeRate.Text = "0.0";
                    txtTotalToBeCollected.Text = "0.0";
                    lbISelectedItems.Items.Clear();
                    fItemIds.Clear();
                    txtNumber.Clear();
                    cmdAddDisbursement.Enabled = false;

                    checkEnablingAddInvestmentButton();
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

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            int created_investment_id = 0;

            try
            {
                decimal _totalDisbursement = 0;
                decimal _totalProfitShare = 0;

                Investment _newInvestment = new Investment();

                _newInvestment.contract = fContractPreffix + txtContract.Text;
                _newInvestment.date = DateTime.Now.Date;
                _newInvestment.fund_id = manager.Selected;
                //TODO: definir cual number debe ir en Investment
                _newInvestment.number = DateTime.Now.Ticks.ToString();

                manager.My_db.Investments.Add(_newInvestment);
                manager.My_db.SaveChanges();

                created_investment_id = _newInvestment.Id;

                foreach (Disbursement _disbursement in disbursements)
                {
                    _disbursement.investment_id = _newInvestment.Id;

                    _totalDisbursement += _disbursement.Euro_collection;
                    _totalProfitShare += _disbursement.profit_share;

                    manager.My_db.Disbursements.Add(_disbursement);
                    manager.My_db.SaveChanges();

                    foreach (int _itemId in _disbursement.ItemsIds)
                    {
                        Item _item = manager.My_db.Items.FirstOrDefault(x => x.Id == _itemId);
                        
                        if (_item != null)
                        {
                            DisbursementItem _disbursementItem = new DisbursementItem();
                            _disbursementItem.ItemId = _item.Id;
                            _disbursementItem.DisbursementId = _disbursement.Id;

                            manager.My_db.DisbursementItems.Add(_disbursementItem);
                            manager.My_db.SaveChanges();
                        }
                    }

                    
                }

                _newInvestment.total_disbursement = _totalDisbursement;
                _newInvestment.profit_share = _totalProfitShare;

                manager.My_db.SaveChanges();

                fItemIds.Clear();

                txtAmount.Text = "0";
                txtNumber.Text = "";
                txtContract.Text = "xxx/" + DateTime.Now.Year.ToString().Substring(2, 2);
                txtProfitShare.Text = "1";
                txtExchangeRate.Text = "0.0";
                txtTotalToBeCollected.Text = "0.0";
                lbISelectedItems.Items.Clear();
                lvDisbursements.Items.Clear();

                fMaxDisbursementDate = DateTime.MinValue;

                disbursements.Clear();
                
                FundsManager.ReportForms.DibursementCreatedForm createdDisbursementsForm = new ReportForms.DibursementCreatedForm();
                createdDisbursementsForm.investmentId = _newInvestment.Id;
                createdDisbursementsForm.Show();
                
            }
            catch (Exception _ex)
            {
                ErrorMessage.showErrorMessage(_ex);

                //rollback
                try
                {

                    Investment inv = manager.My_db.Investments.FirstOrDefault(x => x.Id == created_investment_id);


                    if (inv != null)
                    {
                        foreach (Disbursement disb in inv.Disbursements)
                        {

                            if (disb != null)
                            {
                                List<DisbursementItem> disbItms = manager.My_db.DisbursementItems.Where(x => x.DisbursementId == disb.Id).ToList();

                                foreach (DisbursementItem disbItem in disbItms)
                                {
                                    manager.My_db.DisbursementItems.Remove(disbItem);
                                }

                                manager.My_db.SaveChanges();

                                manager.My_db.Disbursements.Remove(disb);

                                manager.My_db.SaveChanges();
                            }
                        }

                        manager.My_db.Investments.Remove(inv);
                        manager.My_db.SaveChanges();
                    }

                }
                catch (Exception _ex2)
                {
                    ErrorMessage.showErrorMessage(_ex2);
                }
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
                ArrayList _disbursementToDelete = new ArrayList();

                foreach (int _index in lvDisbursements.SelectedIndices)
                {
                    _disbursementToDelete.Add(disbursements[_index]);
                }

                foreach (Disbursement _disbursement in _disbursementToDelete)
                {
                    disbursements.Remove(_disbursement);
                }

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

                    string[] row = { _disbursement.TextClient, _disbursement.TextUnderlyingDebtor, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", _disbursement.profit_share), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", _totalToBeCollected), _disbursement.collection_date.ToLongDateString(), _disbursement.date.ToLongDateString(), Convert.ToString(day.Days) };
                    ListViewItem my_item = new ListViewItem(row);
                    lvDisbursements.Items.Add(my_item);

                    total_amount += _disbursement.amount;
                    total_profit += _disbursement.profit_share;
                    total_euro_collection += _disbursement.Euro_collection;
                }

                if (disbursements.Count > 0)
                {
                    string[] totales = { "Total", "", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C7}", total_euro_collection) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvDisbursements.Items.Add(listViewItemTotal);
                }

                checkEnablingAddInvestmentButton();
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
                foreach (int _index in lvDisbursements.SelectedIndices)
                {
                    if (_index == lvDisbursements.Items.Count - 1)
                    {
                        lvDisbursements.SelectedIndices.Remove(_index);
                    }
                }

                cmdDeleteDisbursement.Enabled = lvDisbursements.SelectedIndices.Count > 0;
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
                    txtExchangeRate.Text = "0.00";
                }
                else
                {
                    txtExchangeRate.Text = String.Format("{0:0.00}", _result);
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
                    txtProfitShare.Text = "1";
                }
                else
                {
                    txtProfitShare.Text = String.Format("{0:0.0000000}", _result);
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
                // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Shipments' Puede moverla o quitarla según sea necesario.
                this.shipmentsTableAdapter.FillByLetterWithEmpty(this.fundsDBDataSet.Shipments, int.Parse(cbLetterOfCredit.SelectedValue.ToString()));
            }
            checkEnablingAddDisbursementButton();
        }

        private void cbShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkEnablingAddDisbursementButton();
        }
    }
}
