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

        public BondPayments()
        {
            InitializeComponent();

            cbInvestor.SelectedIndexChanged += OnInvestorChanged;
            cbBond.SelectedIndexChanged += OnBondChanged;
        }
        
        private void BondPayments_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'fundsDBDataSet.Investors' Puede moverla o quitarla según sea necesario.
            this.investorsTableAdapter.Fill(this.fundsDBDataSet.Investors);

            if (cbInvestor.Items.Count > 0)
            {
                cbInvestor.SelectedIndex = 0;
                OnInvestorChanged(null, null);
            }
        }

        private void OnInvestorChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();

            int _investorId = Convert.ToInt32(cbInvestor.SelectedValue);

            foreach (BondsInvestor _bondInvestor in manager.My_db.BondsInvestors.Where(x => x.FK_BondsInvestors_Investors == _investorId))
            {
                foreach (Bond _bond in manager.My_db.Bonds.Where(x => x.Id == _bondInvestor.FK_BondsInvestors_Bonds))
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

            int _investorId = Convert.ToInt32(cbInvestor.SelectedValue);
            int _bondId = Convert.ToInt32(cbBond.SelectedValue);

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

                List<InvestorBondInterest> _interests = manager.My_db.InvestorBondInterests.Where(x => x.BondId == _bondId && x.InvestorId == _investorId).ToList();

                foreach (InvestorBondInterest _interest in _interests)
                {
                    string[] _row = { _interest.Id.ToString(), _interest.InterestDate.ToLongDateString(), String.Format("{0:0.00}", _interest.Amount), _interest.Extracted ? "PAID" : "Waitting", _interest.ExtractionDate.HasValue ? _interest.ExtractionDate.Value.ToLongDateString() : "" };

                    ListViewItem _itemRow = new ListViewItem(_row);

                    lvGeneratedInterest.Items.Add(_itemRow);
                }

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
    }
}
