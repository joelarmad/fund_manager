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
    public partial class Form1 : Form
    {
        private MyFundsManager manager;
        public Form1()
        {
            manager = new MyFundsManager();
            InitializeComponent();
        }

        private void fundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            FundsForm funds_form = new FundsForm(manager);
            funds_form.MdiParent = this;
            funds_form.Show();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CountriesForm countries_form = new CountriesForm(manager);
            countries_form.MdiParent = this;
            countries_form.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ItemsForm items_form = new ItemsForm(manager);
            items_form.MdiParent = this;
            items_form.Show();
        }

        private void sectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SectorsForm sectors_form = new SectorsForm(manager);
            sectors_form.MdiParent = this;
            sectors_form.Show();
        }

        private void creditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CreditorsForm creditors_form = new CreditorsForm(manager);
            creditors_form.MdiParent = this;
            creditors_form.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ClientsForm clients_form = new ClientsForm(manager);
            clients_form.MdiParent = this;
            clients_form.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            AccountsForm accounts_form = new AccountsForm(manager);
            accounts_form.MdiParent = this;
            accounts_form.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BanksForm banks_form = new BanksForm(manager);
            banks_form.MdiParent = this;
            banks_form.Show();
        }

        private void bankingAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BankingAccountsForm banking_form = new BankingAccountsForm(manager);
            banking_form.MdiParent = this;
            banking_form.Show();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CurrenciesForm currency_form = new CurrenciesForm(manager);
            currency_form.MdiParent = this;
            currency_form.Show();
        }

        private void movementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            GeneralLedgerForm general_ledger_form = new GeneralLedgerForm(manager);
            general_ledger_form.MdiParent = this;
            general_ledger_form.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EmployeesForm employee_form = new EmployeesForm(manager);
            employee_form.MdiParent = this;
            employee_form.Show();
        }

        private void movementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            MovementReportForm mreport_form = new MovementReportForm(manager);
            mreport_form.MdiParent = this;
            mreport_form.Show();
        }

        private void subaccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SubaccountsForm subaccount_form = new SubaccountsForm(manager);
            subaccount_form.MdiParent = this;
            subaccount_form.Show();
        }

        private void otherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            OtherDetailsForm otherdetail_form = new OtherDetailsForm(manager);
            otherdetail_form.MdiParent = this;
            otherdetail_form.Show();
        }

        private void investorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvestorsForm investor_form = new InvestorsForm(manager);
            investor_form.MdiParent = this;
            investor_form.Show();
        }

        private void bondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsForm bond_form = new BondsForm(manager);
            bond_form.MdiParent = this;
            bond_form.Show();
        }

        private void bondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsList bondlist_form = new BondsList(manager);
            bondlist_form.MdiParent = this;
            bondlist_form.Show();
        }

        private void generateInterestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            GenerateBondInterestForm interest_form = new GenerateBondInterestForm(manager);
            interest_form.MdiParent = this;
            interest_form.Show();
        }

        private void investmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DisbursementsForm disbursements_form = new DisbursementsForm(manager);
            disbursements_form.MdiParent = this;
            disbursements_form.Show();
            /*
            InvestmentsForm investments_form = new InvestmentsForm(manager);
            investments_form.MdiParent = this;
            investments_form.Show();*/
        }

        private void underlyingDebtorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UnderlyingDebtorsForm underlyingdebtor_form = new UnderlyingDebtorsForm(manager);
            underlyingdebtor_form.MdiParent = this;
            underlyingdebtor_form.Show();
        }
    }
}