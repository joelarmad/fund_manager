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
    public partial class BondsForm : Form
    {
        private MyFundsManager manager;
        private List<InvestorForBond> investors;
        private Decimal check_pieces;
        private Color _color;

        private int fBondConsecutive = 0;

        public BondsForm()
        {
            try
            {
                manager = MyFundsManager.SingletonInstance;
                investors = new List<InvestorForBond>();
                InitializeComponent();
                listView1.FullRowSelect = true;
                check_pieces = 0;
                _color = new Color();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.BondsForm: " + _ex.Message);
            }
        }

        private void BondsForm_Load(object sender, EventArgs e)
        {
            try
            {
                fBondConsecutive = 0;

                // TODO: This line of code loads data into the 'fundsDBDataSet.Investors' table. You can move, or remove it, as needed.
                this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);
                cbInvestors.SelectedItem = null;
                cbInvestors.SelectedText = "Select investor";

                Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BOND_CONSECUTIVE_KEY);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count > 0)
                    listView1.Items.RemoveAt(listView1.Items.Count - 1);
                InvestorForBond investor = new InvestorForBond();

                investor.Pieces = (float)Convert.ToDouble(txtInvestorPieces.Text);
                investor.Id = Convert.ToInt32(cbInvestors.SelectedValue);

                investors.Add(investor);
                Decimal pieces_price = Convert.ToDecimal(txtPrice.Text);

                float investor_amount = (float)pieces_price * investor.Pieces;


                string[] row = { cbInvestors.Text, txtInvestorPieces.Text, string.Format("€{0:N2}", investor_amount) };
                ListViewItem my_item = new ListViewItem(row);
                listView1.Items.Add(my_item);

                check_pieces += Convert.ToDecimal(txtInvestorPieces.Text);
                Decimal amount = (pieces_price * Convert.ToDecimal(txtBondPieces.Text));

                string[] totales = { "Total", txtBondPieces.Text, string.Format("€{0:N2}", amount) };
                ListViewItem totales_item = new ListViewItem(totales);


                if (check_pieces == Convert.ToDecimal(txtBondPieces.Text))
                {
                    _color = Color.FromName("Green");
                    cmdCreateBond.Enabled = true;
                }
                else
                {
                    _color = Color.FromName("Red");
                    cmdCreateBond.Enabled = false;
                }

                totales_item.ForeColor = _color;
                listView1.Items.Add(totales_item);
                txtInvestorPieces.Text = "";
                cbInvestors.SelectedIndex = 0;

                txtPrice.ReadOnly = true;
                txtBondPieces.ReadOnly = true;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.button1_Click: " + _ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                txtPrice.ReadOnly = false;
                txtBondPieces.ReadOnly = false;
                cmdCreateBond.Enabled = false;

                ArrayList _investorsToDelete = new ArrayList();

                foreach (int _index in listView1.SelectedIndices)
                {
                    _investorsToDelete.Add(investors[_index]);
                }

                foreach (InvestorForBond _investor in _investorsToDelete)
                {
                    investors.Remove(_investor);
                }

                listView1.Items.Clear();

                check_pieces = 0;
                Decimal pieces_price = Convert.ToDecimal(txtPrice.Text);

                foreach (InvestorForBond _investorForBond in investors)
                {
                    float investor_amount = (float)pieces_price * _investorForBond.Pieces;

                    Investor _investor = manager.My_db.Investors.FirstOrDefault(x => x.Id == _investorForBond.Id);

                    string[] row = { _investor.name, _investorForBond.Pieces.ToString(), string.Format("€{0:N2}", investor_amount) };
                    ListViewItem my_item = new ListViewItem(row);
                    listView1.Items.Add(my_item);

                    check_pieces += (decimal)_investorForBond.Pieces;


                    txtInvestorPieces.Text = "";
                    cbInvestors.ResetText();

                    txtPrice.ReadOnly = true;
                    txtBondPieces.ReadOnly = true;
                }

                if (investors.Count > 0)
                {
                    Decimal amount = (pieces_price * Convert.ToDecimal(txtBondPieces.Text));

                    string[] totales = { "Total", txtBondPieces.Text, string.Format("€{0:N2}", amount) };

                    if (check_pieces == Convert.ToDecimal(txtBondPieces.Text))
                    {
                        _color = Color.FromName("Green");
                        cmdCreateBond.Enabled = true;
                    }
                    else
                    {
                        _color = Color.FromName("Red");
                        cmdCreateBond.Enabled = false;
                    }

                    ListViewItem totales_item = new ListViewItem(totales);

                    totales_item.ForeColor = _color;
                    listView1.Items.Add(totales_item);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.button3_Click: " + _ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Bond bond = new Bond();
                bond.number = txtNumber.Text;
                bond.issued = Convert.ToDateTime(dtpIssuingDate.Text);
                bond.expired = Convert.ToDateTime(dtpExpirationDate.Text);
                bond.FK_Bonds_Funds = manager.Selected;
                bond.price = Convert.ToDecimal(txtPrice.Text);
                bond.pieces = (float)Convert.ToDecimal(txtBondPieces.Text);
                bond.interest_on_bond = Convert.ToInt32(txtBondInterest.Text);
                bond.interest_tff_contribution = Convert.ToInt32(txtTFFInterest.Text);

                bond.active = 1;

                manager.My_db.Bonds.Add(bond);
                manager.My_db.SaveChanges();

                foreach (InvestorForBond _investor in investors)
                {

                    BondsInvestor bond_investor = new BondsInvestor();
                    bond_investor.FK_BondsInvestors_Bonds = bond.Id;
                    bond_investor.FK_BondsInvestors_Investors = _investor.Id;
                    bond_investor.quantity = _investor.Pieces;
                    manager.My_db.BondsInvestors.Add(bond_investor);
                    manager.My_db.SaveChanges();

                }

                Resource _resource = manager.My_db.Resources.FirstOrDefault(x => x.Name == KeyDefinitions.BOND_CONSECUTIVE_KEY);

                fBondConsecutive++;

                _resource.Value = fBondConsecutive.ToString();

                manager.My_db.SaveChanges();

                txtNumber.Text = "Bond " + Conversions.toRomanNumeral(fBondConsecutive);
                txtPrice.Text = "0";
                txtBondInterest.Text = "10";
                txtTFFInterest.Text = "1";
                txtInvestorPieces.Text = "0";
                txtBondPieces.Text = "0";
                cbInvestors.SelectedText = "Select investor";
                listView1.Items.Clear();
                txtPrice.ReadOnly = false;
                txtBondPieces.ReadOnly = false;

                //TODO: Crear un movimiento contable con un debito a 100 y un credito a 510 por el monto del bono

                //Obtener nuevo numero de referencia
                //Crear AccountingMovement
                //Crear Movements_Accounts con un debito a 100
                //Crear Movements_Accounts con un credito a 510

                Account _CashAtBank = manager.My_db.Accounts.FirstOrDefault(x => x.number == "100");
                Account _Bonds = manager.My_db.Accounts.FirstOrDefault(x => x.number == "510");
                Subaccount _CashAtBankEUR = manager.My_db.Subaccounts.FirstOrDefault(x => x.name == "Cash at Bank EUR");
                Subaccount _BondI = manager.My_db.Subaccounts.FirstOrDefault(x => x.name == "Bond I");

                if (_CashAtBank != null 
                    && _Bonds != null
                    && _CashAtBankEUR != null
                    && _BondI != null)
                {
                    AccountingMovement _movement = new AccountingMovement();
                    _movement.FK_AccountingMovements_Funds = manager.Selected;
                    //TODO: Poner description correcta cuando la manden
                    _movement.description = "";
                    _movement.date = bond.issued;
                    _movement.reference = KeyDefinitions.NextAccountMovementReference;
                    _movement.FK_AccountingMovements_Currencies = manager.My_db.Currencies.FirstOrDefault().Id;
                    //TODO: Poner ORIG cuando la manden
                    _movement.original_reference = "";
                    manager.My_db.AccountingMovements.Add(_movement);
                    manager.My_db.SaveChanges();

                    Movements_Accounts _movAcctCashAtBank = new Movements_Accounts();
                    Movements_Accounts _movAcctBond = new Movements_Accounts();

                    _movAcctCashAtBank.FK_Movements_Accounts_AccountingMovements = _movement.Id;
                    _movAcctCashAtBank.FK_Movements_Accounts_Funds = manager.Selected;
                    _movAcctCashAtBank.FK_Movements_Accounts_Accounts = _CashAtBank.Id;
                    _movAcctCashAtBank.FK_Movements_Accounts_Subaccounts = _CashAtBankEUR.Id;
                    //TODO: Poner subaccount type correcto cuando lo manden
                    //_movAcctCashAtBank.subaccount_type = my_movement.Detail_type;
                    //TODO: Poner subaccount type correcto cuando lo manden
                    //_movAcctCashAtBank.subaccount = my_movement.Detail;

                    _movAcctCashAtBank.debit = (decimal)bond.pieces * bond.price;
                    _movAcctCashAtBank.credit = 0;
                    
                    manager.My_db.Movements_Accounts.Add(_movAcctCashAtBank);

                    _movAcctBond.FK_Movements_Accounts_AccountingMovements = _movement.Id;
                    _movAcctBond.FK_Movements_Accounts_Funds = manager.Selected;
                    _movAcctBond.FK_Movements_Accounts_Accounts = _Bonds.Id;
                    _movAcctBond.FK_Movements_Accounts_Subaccounts = _BondI.Id;
                    //TODO: Poner subaccount type correcto cuando lo manden
                    //_movAcctBond.subaccount_type = my_movement.Detail_type;
                    //TODO: Poner subaccount type correcto cuando lo manden
                    //_movAcctBond.subaccount = my_movement.Detail;

                    _movAcctBond.debit = 0;
                    _movAcctBond.credit = (decimal)bond.pieces * bond.price;

                    manager.My_db.Movements_Accounts.Add(_movAcctBond);

                    _CashAtBank.amount += (decimal)bond.pieces * bond.price;
                    _Bonds.amount -= (decimal)bond.pieces * bond.price;
                    
                    manager.My_db.SaveChanges();
                }
                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.button2_Click: " + _ex.Message);
            }
        }

        private void checkEnablingAddButton()
        {
            try
            {
                decimal _price = 0;
                decimal _bondPieces = 0;
                decimal _investorPieces = 0;
                decimal _interestOnBond = 0;
                decimal _interestOnTFF = 0;
                
                cmdAddPiece.Enabled = cbInvestors.SelectedIndex >= 0
                    && decimal.TryParse(txtPrice.Text, out _price)
                    && decimal.TryParse(txtBondPieces.Text, out _bondPieces)
                    && decimal.TryParse(txtBondInterest.Text, out _interestOnBond)
                    && decimal.TryParse(txtTFFInterest.Text, out _interestOnTFF)
                    && decimal.TryParse(txtInvestorPieces.Text, out _investorPieces)
                    && _price > 0 
                    && _bondPieces > 0 
                    && _interestOnBond >= 0
                    && _interestOnTFF >= 0
                    && _investorPieces > 0
                    && dtpExpirationDate.Value > DateTime.Now
                    && dtpIssuingDate.Value > DateTime.Now.Date
                    && dtpIssuingDate.Value < dtpExpirationDate.Value;

                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.checkEnablingAddButton: " + _ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.comboBox1_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtPrice.Text == "0")
                    txtPrice.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox2_Enter: " + _ex.Message);
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtBondPieces.Text == "0")
                    txtBondPieces.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox6_Enter: " + _ex.Message);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtBondInterest.Text == "0")
                    txtBondInterest.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox3_Enter: " + _ex.Message);
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtTFFInterest.Text == "0")
                    txtTFFInterest.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox4_Enter: " + _ex.Message);
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtInvestorPieces.Text == "0")
                    txtInvestorPieces.Text = "";
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox5_Enter: " + _ex.Message);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtPrice.Text, out _result) || _result <= 0)
                {
                    txtPrice.Text = "0";
                }
                else
                {
                    txtPrice.Text = String.Format("{0:0.00}", _result);
                }

                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox2_Leave: " + _ex.Message);
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtBondPieces.Text, out _result) || _result <= 0)
                {
                    txtBondPieces.Text = "0";
                }
                else
                {
                    txtBondPieces.Text = String.Format("{0:0}", _result);
                }

                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox6_Leave: " + _ex.Message);
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtBondInterest.Text, out _result) || _result <= 0)
                {
                    txtBondInterest.Text = "0";
                }
                else
                {
                    txtBondInterest.Text = String.Format("{0:0}", _result);
                }

                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox3_Leave: " + _ex.Message);
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtTFFInterest.Text, out _result) || _result <= 0)
                {
                    txtTFFInterest.Text = "0";
                }
                else
                {
                    txtTFFInterest.Text = String.Format("{0:0}", _result);
                }

                checkEnablingAddButton();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox4_Leave: " + _ex.Message);
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal _result = 0;
                if (!decimal.TryParse(txtInvestorPieces.Text, out _result) || _result <= 0)
                {
                    txtInvestorPieces.Text = "0";
                }
                else
                {
                    txtInvestorPieces.Text = String.Format("{0:0}", _result);
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox5_Leave: " + _ex.Message);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBondPieces.Focus();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox2_KeyUp: " + _ex.Message);
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBondInterest.Focus();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox6_KeyUp: " + _ex.Message);
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtTFFInterest.Focus();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox3_KeyUp: " + _ex.Message);
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbInvestors.Focus();
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox4_KeyUp: " + _ex.Message);
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                checkEnablingAddButton();

                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (cmdAddPiece.Enabled)
                    {
                        cmdAddPiece.Focus();
                    }
                }
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.textBox5_KeyUp: " + _ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (int _index in listView1.SelectedIndices)
                {
                    if (_index == listView1.Items.Count - 1)
                    {
                        listView1.SelectedIndices.Remove(_index);
                    }
                }

                cmdRemovePiece.Enabled = listView1.SelectedIndices.Count > 0;
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in BondsForm.listView1_SelectedIndexChanged: " + _ex.Message);
            }
        }

        private void dtpIssuingDate_ValueChanged(object sender, EventArgs e)
        {
            checkEnablingAddButton();
        }

        private void dtpExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            checkEnablingAddButton();
        }
    }
}
