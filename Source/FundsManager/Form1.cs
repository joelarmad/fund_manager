using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.Classes.Task;

namespace FundsManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalProcess.performBondProfitsUpdate();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in Form1.Form1_Load: " + _ex.Message);
            }
        }

        private void fundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            FundsForm funds_form = new FundsForm();
            funds_form.MdiParent = this;
            funds_form.Show();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CountriesForm countries_form = new CountriesForm();
            countries_form.MdiParent = this;
            countries_form.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ItemsForm items_form = new ItemsForm();
            items_form.MdiParent = this;
            items_form.Show();
        }

        private void sectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SectorsForm sectors_form = new SectorsForm();
            sectors_form.MdiParent = this;
            sectors_form.Show();
        }

        private void creditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CreditorsForm creditors_form = new CreditorsForm();
            creditors_form.MdiParent = this;
            creditors_form.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ClientsForm clients_form = new ClientsForm();
            clients_form.MdiParent = this;
            clients_form.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            AccountsForm accounts_form = new AccountsForm();
            accounts_form.MdiParent = this;
            accounts_form.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BanksForm banks_form = new BanksForm();
            banks_form.MdiParent = this;
            banks_form.Show();
        }

        private void bankingAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BankingAccountsForm banking_form = new BankingAccountsForm();
            banking_form.MdiParent = this;
            banking_form.Show();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CurrenciesForm currency_form = new CurrenciesForm();
            currency_form.MdiParent = this;
            currency_form.Show();
        }

        private void movementToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.IsMdiContainer = true;
            GeneralLedgerForm general_ledger_form = new GeneralLedgerForm();
            general_ledger_form.MdiParent = this;
            general_ledger_form.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EmployeesForm employee_form = new EmployeesForm();
            employee_form.MdiParent = this;
            employee_form.Show();
        }

        private void movementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            MovementReportForm mreport_form = new MovementReportForm();
            mreport_form.MdiParent = this;
            mreport_form.Show();
        }

        private void subaccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SubaccountsForm subaccount_form = new SubaccountsForm();
            subaccount_form.MdiParent = this;
            subaccount_form.Show();
        }

        private void otherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            OtherDetailsForm otherdetail_form = new OtherDetailsForm();
            otherdetail_form.MdiParent = this;
            otherdetail_form.Show();
        }

        private void investorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvestorsForm investor_form = new InvestorsForm();
            investor_form.MdiParent = this;
            investor_form.Show();
        }

        private void bondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsForm bond_form = new BondsForm();
            bond_form.MdiParent = this;
            bond_form.Show();
        }

        private void bondsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsList bondlist_form = new BondsList();
            bondlist_form.MdiParent = this;
            bondlist_form.Show();
        }

        private void generateInterestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            GenerateBondInterestForm interest_form = new GenerateBondInterestForm();
            interest_form.MdiParent = this;
            interest_form.Show();
        }

        private void investmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvestmentsForm investments_form = new InvestmentsForm();
            investments_form.MdiParent = this;
            investments_form.Show();
        }

        private void underlyingDebtorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UnderlyingDebtorsForm underlyingdebtor_form = new UnderlyingDebtorsForm();
            underlyingdebtor_form.MdiParent = this;
            underlyingdebtor_form.Show();
        }

        private void generalBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ReportForms.GeneralBalanceForm _generalBalance = new ReportForms.GeneralBalanceForm();
            _generalBalance.MdiParent = this;
            _generalBalance.Show();
        }

        private void returnsStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ReportForms.ReturnsState _returnsState = new ReportForms.ReturnsState();
            _returnsState.MdiParent = this;
            _returnsState.Show();
        }

        private void makePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondPayments _bondPayments = new BondPayments();
            _bondPayments.MdiParent = this;
            _bondPayments.Show();
        }

        private void shareholdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ShareholdersForm _shareholdersForm = new ShareholdersForm();
            _shareholdersForm.MdiParent = this;
            _shareholdersForm.Show();
        }

        private void disbursemetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DisbursementsForm disbursements_form = new DisbursementsForm();
            disbursements_form.MdiParent = this;
            disbursements_form.Show();
        }
    }
}