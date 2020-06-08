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
using FundsManager.ReportForms;
using System.Threading;
using System.Globalization;

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
            FundsForm form = new FundsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void countriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CountriesForm form = new CountriesForm();
            form.MdiParent = this;
            form.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ItemsForm form = new ItemsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void sectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SectorsForm form = new SectorsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void creditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CreditorsForm form = new CreditorsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ClientsForm form = new ClientsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            AccountsForm form = new AccountsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BanksForm form = new BanksForm();
            form.MdiParent = this;
            form.Show();
        }

        private void bankingAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BankingAccountsForm form = new BankingAccountsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            CurrenciesForm form = new CurrenciesForm();
            form.MdiParent = this;
            form.Show();
        }

        private void movementToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            this.IsMdiContainer = true;
            GeneralLedgerForm form = new GeneralLedgerForm();
            form.MdiParent = this;
            form.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            EmployeesForm form = new EmployeesForm();
            form.MdiParent = this;
            form.Show();
        }

        private void movementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            MovementReportForm form = new MovementReportForm();
            form.MdiParent = this;
            form.Show();
        }

        private void subaccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            SubaccountsForm form = new SubaccountsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void otherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            OtherDetailsForm form = new OtherDetailsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void investorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvestorsForm form = new InvestorsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void bondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFFForm form = new BondsTFFForm();
            form.MdiParent = this;
            form.Show();
        }

        private void generateInterestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            GenerateBondInterestForm form = new GenerateBondInterestForm();
            form.MdiParent = this;
            form.Show();
        }

        private void underlyingDebtorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UnderlyingDebtorsForm form = new UnderlyingDebtorsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void generalBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ReportForms.GeneralBalanceForm form = new ReportForms.GeneralBalanceForm();
            form.MdiParent = this;
            form.Show();
        }

        private void returnsStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ReportForms.ReturnsState form = new ReportForms.ReturnsState();
            form.MdiParent = this;
            form.Show();
        }

        private void makePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondPayments form = new BondPayments();
            form.MdiParent = this;
            form.Show();
        }

        private void shareholdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ShareholdersForm form = new ShareholdersForm();
            form.MdiParent = this;
            form.Show();
        }

        private void disbursemetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DisbursementsForm form = new DisbursementsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void profitShareAccruedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ProfitShareToAccrueForm form = new ProfitShareToAccrueForm();
            form.MdiParent = this;
            form.Show();
        }

        private void createInvestmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvestmentsForm form = new InvestmentsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            FundSelectionForm fundSelection = new FundSelectionForm();
            fundSelection.ShowDialog();
        }

        private void letterOfCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            LetterOfCreditForm form = new LetterOfCreditForm();
            form.MdiParent = this;
            form.Show();
        }

        private void shipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ShipmentForm form = new ShipmentForm();
            form.MdiParent = this;
            form.Show();
        }

        private void collectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DisbursementCollectionForm form = new DisbursementCollectionForm();
            form.MdiParent = this;
            form.Show();
        }

        private void investmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            InvesmentReportForm form = new InvesmentReportForm();
            form.MdiParent = this;
            form.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void delayInterestToAccrueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            AddendumsLauncher form = new AddendumsLauncher();
            form.MdiParent = this;
            form.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BookReportForm form = new BookReportForm();
            form.MdiParent = this;
            form.Show();
        }

        private void delayInterestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DelayInterestToAccrueForm form = new DelayInterestToAccrueForm();
            form.MdiParent = this;
            form.Show();
        }

        private void unknownRoutineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            UnknownRoutine form = new UnknownRoutine();
            form.MdiParent = this;
            form.Show();
        }

        private void serviceSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ServiceSupplierForm form = new ServiceSupplierForm();
            form.MdiParent = this;
            form.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            LoanCreate form = new LoanCreate();
            form.MdiParent = this;
            form.Show();
        }

        private void loanInterestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            LoanInterest form = new LoanInterest();
            form.MdiParent = this;
            form.Show();
        }

        private void repaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.IsMdiContainer = true;
            //LoanRepayment form = new LoanRepayment();
            //form.MdiParent = this;
            //form.Show();

            this.IsMdiContainer = true;
            LoanRepaymentForm form = new LoanRepaymentForm();
            form.MdiParent = this;
            form.Show();
        }

        private void loanRenegotiationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            LoanRenegotiation form = new LoanRenegotiation();
            form.MdiParent = this;
            form.Show();
        }

        private void bondsTFAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFAMForm form = new BondsTFAMForm();
            form.MdiParent = this;
            form.Show();
        }

        private void activateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFAMActivation form = new BondsTFAMActivation();
            form.MdiParent = this;
            form.Show();
        }

        private void generateInterestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFAMInterest form = new BondsTFAMInterest();
            form.MdiParent = this;
            form.Show();
        }

        private void closePeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            ClosePeriodForm form = new ClosePeriodForm();
            form.MdiParent = this;
            form.Show();
        }

        private void accountReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            AccountReport form = new AccountReport();
            form.MdiParent = this;
            form.Show();
        }

        private void bondsToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsList form = new BondsList();
            form.MdiParent = this;
            form.Show();
        }

        private void bondsTFAMToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFAMListForm form = new BondsTFAMListForm();
            form.MdiParent = this;
            form.Show();
        }

        private void overdueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            DisbursementToBeOverdueForm form = new DisbursementToBeOverdueForm();
            form.MdiParent = this;
            form.Show();
        }

        private void repaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            BondsTFAMRepaymentForm form = new BondsTFAMRepaymentForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}