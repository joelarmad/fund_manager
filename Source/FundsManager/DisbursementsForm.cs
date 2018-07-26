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

        private Double disbursement;
        private Double profit;

        //private List<DisbursementForInvestement> disbursements;
        private List<Disbursement> disbursements;
        private List<int> fItemIds = new List<int>();

        private DateTime fMaxDisbursementDate;

        public DisbursementsForm()
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
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm: " + _ex.Message);
            }
        }

        private void DisbursementsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'fundsDBDataSet.Items' table. You can move, or remove it, as needed.
                this.itemsTableAdapter.FillByFund(this.fundsDBDataSet.Items, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Sectors' table. You can move, or remove it, as needed.
                this.sectorsTableAdapter.FillByFund(this.fundsDBDataSet.Sectors, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Banks' table. You can move, or remove it, as needed.
                this.banksTableAdapter.FillExcludingOwnBanks(this.fundsDBDataSet.Banks, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.UnderlyingDebtors' table. You can move, or remove it, as needed.
                this.underlyingDebtorsTableAdapter.FillByFund(this.fundsDBDataSet.UnderlyingDebtors, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Clients' table. You can move, or remove it, as needed.
                this.clientsTableAdapter.FillByFund(this.fundsDBDataSet.Clients, manager.Selected);
                // TODO: This line of code loads data into the 'fundsDBDataSet.Currencies' table. You can move, or remove it, as needed.
                this.currenciesTableAdapter.FillByFund(this.fundsDBDataSet.Currencies, manager.Selected);

            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.DisbursementsForm_Load: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.textBox1_Leave: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.textBox3_Leave: " + _ex.Message);
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
                    && decimal.TryParse(txtExchangeRate.Text, out _exchange))
                {
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", ((_amount + _profit) / _exchange));
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.calculate_total_collection: " + _ex.Message);
            }
        }

        private void getExchangeRate(object sender, EventArgs e)
        {
            try
            {
                Double value = 0;
                if (cbCurrency.SelectedIndex != -1)
                    txtExchangeRate.Text = manager.My_db.Currencies.Find(Convert.ToInt32(cbCurrency.SelectedValue)).exchange.ToString();
                if (disbursement > 0 && profit > 0)
                {
                    value = (disbursement + profit) / Convert.ToDouble(txtExchangeRate.Text);
                    txtTotalToBeCollected.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", value);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.getExchangeRate: " + _ex.Message);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddDisbursementButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.comboBox4_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.button1_Click: " + _ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal total_amount = 0;
                Decimal total_profit = 0;
                Decimal total_euro_collection = 0;
                TimeSpan day = new TimeSpan();

                Disbursement _disbursement = new Disbursement();

                _disbursement.fund_id = manager.Selected;

                _disbursement.amount = Convert.ToDecimal(txtAmount.Text);
                _disbursement.exchange_rate = Convert.ToSingle(txtExchangeRate.Text);
                _disbursement.profit_share = Convert.ToDecimal(txtProfitShare.Text);
                _disbursement.currency_id = Convert.ToInt32(cbCurrency.SelectedValue);
                _disbursement.bank_risk_id = Convert.ToInt32(cbBank.SelectedValue);
                _disbursement.client_id = Convert.ToInt32(cbClient.SelectedValue);
                _disbursement.underlying_debtor_id = Convert.ToInt32(cbUnderlyingDebtor.SelectedValue);
                _disbursement.date = Convert.ToDateTime(dtpDisbursementDate.Text);
                _disbursement.sector_id = Convert.ToInt32(cbSector.SelectedValue);

                _disbursement.TextClient = cbClient.Text;
                _disbursement.TextUnderlyingDebtor = cbUnderlyingDebtor.Text;

                _disbursement.Euro_collection = Convert.ToDecimal((_disbursement.amount + _disbursement.profit_share) / (decimal)_disbursement.exchange_rate);

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


                string[] row = { cbClient.Text, cbUnderlyingDebtor.Text, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", txtAmount.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", txtProfitShare.Text), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", txtTotalToBeCollected.Text), dtpDisbursementDate.Text, Convert.ToString(day.Days) };
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

                string[] totales = { "Total", "", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_euro_collection) };
                ListViewItem listViewItemTotal = new ListViewItem(totales);
                lvDisbursements.Items.Add(listViewItemTotal);

                txtAmount.Clear();
                txtProfitShare.Clear();
                lbISelectedItems.Items.Clear();
                txtTotalToBeCollected.Clear();
                lbISelectedItems.Items.Clear();
                lbISelectedItems.Items.Clear();
                fItemIds.Clear();

                checkEnablingAddInvestmentButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.button2_Click: " + _ex.Message);
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal _totalDisbursement = 0;
                decimal _totalProfitShare = 0;

                Investment _newInvestment = new Investment();

                _newInvestment.contract = "";
                _newInvestment.date = DateTime.Now.Date;
                _newInvestment.fund_id = manager.Selected;

                manager.My_db.Investments.Add(_newInvestment);
                manager.My_db.SaveChanges();

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
                            _disbursement.Items.Add(_item);
                        }
                    }

                    manager.My_db.SaveChanges();
                }

                _newInvestment.total_disbursement = _totalDisbursement;
                _newInvestment.profit_share = _totalProfitShare;

                manager.My_db.SaveChanges();

                fItemIds.Clear();

                txtAmount.Text = "";
                txtProfitShare.Text = "";
                txtTotalToBeCollected.Text = "";
                lbISelectedItems.Items.Clear();
                lvDisbursements.Items.Clear();

                fMaxDisbursementDate = DateTime.MinValue;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.cmdCreate_Click: " + _ex.Message);
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtAmount.Text, out _result) || _result <= 0)
                {
                    txtAmount.Text = "";
                }
                else
                {
                    txtAmount.Text = String.Format("{0:0.00}", _result);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.txtAmount_Leave: " + _ex.Message);
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
                    && cbBank.SelectedIndex >= 0
                    && cbSector.SelectedIndex >= 0
                    && decimal.TryParse(txtAmount.Text, out _amount)
                    && decimal.TryParse(txtProfitShare.Text, out _profitShare)
                    && (_amount > 0 || _profitShare >= 0);
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.checkEnablingAddDisbursementButton: " + _ex.Message);
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
                    decimal _totalToBeCollected = (_disbursement.amount + _disbursement.profit_share) / (decimal)_disbursement.exchange_rate;

                    if (disbursements.First<Disbursement>().date != _disbursement.date)
                        day = _disbursement.date.Subtract(disbursements.First<Disbursement>().date);

                    string[] row = { _disbursement.TextClient, _disbursement.TextUnderlyingDebtor, String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.amount.ToString()), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _disbursement.profit_share.ToString()), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", _totalToBeCollected), _disbursement.date.ToLongDateString(), Convert.ToString(day.Days) };
                    ListViewItem my_item = new ListViewItem(row);
                    lvDisbursements.Items.Add(my_item);

                    total_amount += _disbursement.amount;
                    total_profit += _disbursement.profit_share;
                    total_euro_collection += _disbursement.Euro_collection;
                }

                if (disbursements.Count > 0)
                {
                    string[] totales = { "Total", "", String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_amount), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_profit), String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"), "{0:C2}", total_euro_collection) };
                    ListViewItem listViewItemTotal = new ListViewItem(totales);
                    lvDisbursements.Items.Add(listViewItemTotal);
                }

                checkEnablingAddInvestmentButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.cmdDeleteDisbursement_Click: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.txtAmount_TextChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.cbCurrency_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.txtProfitShare_TextChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.cbClient_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.cbUnderlyingDebtor_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.cbSector_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.cbItems_SelectedIndexChanged: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.dtpDisbursementDate_ValueChanged: " + _ex.Message);
            }
        }

        private void txtProfitShare_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtProfitShare.Text, out _result) || _result <= 0)
                {
                    txtProfitShare.Text = "";
                }
                else
                {
                    txtProfitShare.Text = String.Format("{0:0.00}", _result);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.txtProfitShare_Leave: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.txtProfitShare_KeyUp: " + _ex.Message);
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
                Console.WriteLine("Error in DisbursementsForm.lvDisbursements_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                calculate_total_collection();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in DisbursementsForm.txtAmount_KeyUp: " + _ex.Message);
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
    }
}
