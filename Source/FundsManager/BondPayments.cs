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
    public partial class BondPayments : Form
    {
        private MyFundsManager manager = MyFundsManager.SingletonInstance;

        private int fBondId = 0;
        private int fInvestorId = 0;

        public BondPayments()
        {
            InitializeComponent();

            cbInvestor.SelectedIndexChanged += OnInvestorChanged;
            cbBond.SelectedIndexChanged += OnBondChanged;
        }
        
        private void BondPayments_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Investors' Puede moverla o quitarla según sea necesario.
            this.investorsTableAdapter.FillByFund(this.fundsDBDataSet.Investors, manager.Selected);

            if (cbInvestor.Items.Count > 0)
            {
                cbInvestor.SelectedIndex = 0;
                OnInvestorChanged(null, null);
            }
        }

        private void OnInvestorChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();

            int _investorId = fInvestorId = Convert.ToInt32(cbInvestor.SelectedValue);

            foreach (BondsInvestor _bondInvestor in manager.My_db.BondsInvestors.Where(x => x.FK_BondsInvestors_Investors == _investorId))
            {
                foreach (Bond _bond in manager.My_db.Bonds.Where(x => x.Id == _bondInvestor.FK_BondsInvestors_Bonds && x.FK_Bonds_Funds == manager.Selected))
                {
                    comboSource.Add(_bond.Id, _bond.number);
                }
            }

            if (comboSource.Count > 0)
            {

                cbBond.Enabled = true;
                cbBond.DisplayMember = "Value";
                cbBond.ValueMember = "Key";

                cbBond.DataSource = new BindingSource(comboSource, null);
            }
            else
            {
                cbBond.DataSource = null;
                cbBond.Items.Clear();
                cbBond.Text = "";
                cbBond.SelectedItem = null;
                cbBond.SelectedText = "Select bond";
                cbBond.Enabled = false;

                clearBondData();
            }
        }

        private void OnBondChanged(object sender, EventArgs e)
        {
            clearBondData();

            int _investorId = fInvestorId = Convert.ToInt32(cbInvestor.SelectedValue);
            int _bondId = fBondId = Convert.ToInt32(cbBond.SelectedValue);

            Bond _bond = manager.My_db.Bonds.FirstOrDefault(x => x.Id == _bondId);
            BondsInvestor _bondInvestor = manager.My_db.BondsInvestors.FirstOrDefault(x => x.FK_BondsInvestors_Bonds == _bondId && x.FK_BondsInvestors_Investors == _investorId);
            
            if (_bond != null && _bondInvestor != null)
            {

                lblNumber.Text = _bond.number;
                lblPrice.Text = _bond.price.ToString();
                lblPieces.Text = _bond.pieces.ToString();
                lblInterest.Text = _bond.interest_on_bond.ToString();
                lblTFF.Text = _bond.interest_tff_contribution.ToString();
                lblIssuingDate.Text = _bond.issued.ToLongDateString();
                lblExpirationDate.Text = _bond.expired.HasValue ? _bond.expired.Value.ToLongDateString() : "";
                lblInvestorPieces.Text = _bondInvestor.quantity.ToString();

                loadInterests();

                lblExpired.Visible = _bond.active == 0;
                
            }
        }

        private void clearBondData()
        {
            lblNumber.Text = "";
            lblPrice.Text = "";
            lblPieces.Text = "";
            lblInterest.Text = "";
            lblTFF.Text = "";
            lblIssuingDate.Text = "";
            lblExpirationDate.Text = "";
            lblInvestorPieces.Text = "";
            lblExpired.Visible = false;
            lvGeneratedInterest.Items.Clear();
        }

        private void loadInterests()
        {
            if (fBondId > 0 && fInvestorId > 0)
            {
                lvGeneratedInterest.Items.Clear();

                List<InvestorBondInterest> _interests = manager.My_db.InvestorBondInterests.Where(x => x.BondId == fBondId && x.InvestorId == fInvestorId).ToList();

                foreach (InvestorBondInterest _interest in _interests)
                {
                    string[] _row = { _interest.Id.ToString(), _interest.InterestDate.ToLongDateString(), String.Format("{0:0.00}", _interest.Amount), _interest.Extracted ? "PAID" : "Waitting", _interest.ExtractionDate.HasValue ? _interest.ExtractionDate.Value.ToLongDateString() : "" };

                    ListViewItem _itemRow = new ListViewItem(_row);

                    lvGeneratedInterest.Items.Add(_itemRow);
                }

                checkEnablingPayAllInterestButton();
            }

            cmdPayInterest.Enabled = false;
        }

        private void lvGeneratedInterest_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdPayInterest.Enabled = false;

            if (lvGeneratedInterest.SelectedIndices.Count > 0 && lvGeneratedInterest.SelectedIndices[0] >= 0)
            {
                int _index = lvGeneratedInterest.SelectedIndices[0];

                int _interestId = Convert.ToInt32(lvGeneratedInterest.Items[_index].Text);

                InvestorBondInterest _interest = manager.My_db.InvestorBondInterests.FirstOrDefault(x => x.Id == _interestId);

                if (_interest != null)
                {
                    cmdPayInterest.Enabled = !_interest.Extracted;
                }

            }
        }

        private void cmdPayInterest_Click(object sender, EventArgs e)
        {
            if (lvGeneratedInterest.SelectedIndices.Count > 0 && lvGeneratedInterest.SelectedIndices[0] >= 0)
            {
                int _index = lvGeneratedInterest.SelectedIndices[0];

                int _interestId = Convert.ToInt32(lvGeneratedInterest.Items[_index].Text);

                InvestorBondInterest _interest = manager.My_db.InvestorBondInterests.FirstOrDefault(x => x.Id == _interestId);

                if (_interest != null && !_interest.Extracted)
                {
                    _interest.Extracted = true;
                    _interest.ExtractionDate = DateTime.Now.Date;

                    //TODO: Generar los movimientos de cuenta para el pago del interes.

                    manager.My_db.SaveChanges();

                    loadInterests();

                    lvGeneratedInterest.SelectedIndices.Clear();
                }

            }
        }

        private void checkEnablingPayAllInterestButton()
        {
            if (fBondId > 0 && fInvestorId > 0)
            {
                
                List<InvestorBondInterest> _interests = manager.My_db.InvestorBondInterests.Where(x => x.BondId == fBondId && x.InvestorId == fInvestorId && !x.Extracted).ToList();

                cmdPayAllInterest.Enabled = _interests.Count > 0;
            }
        }

        private void cmdPayAllInterest_Click(object sender, EventArgs e)
        {
            if (fBondId > 0 && fInvestorId > 0)
            {

                List<InvestorBondInterest> _interests = manager.My_db.InvestorBondInterests.Where(x => x.BondId == fBondId && x.InvestorId == fInvestorId && !x.Extracted).ToList();

                foreach (InvestorBondInterest _interest in _interests) {
                    _interest.Extracted = true;
                    _interest.ExtractionDate = DateTime.Now.Date;

                    //TODO: Generar el movimiento de cuenta necesario

                    manager.My_db.SaveChanges();
                }

                loadInterests();
            }
        }

        private void cmdPayBond_Click(object sender, EventArgs e)
        {
            //TODO: generar el movimiento de cuenta necesario
        }
    }
}
