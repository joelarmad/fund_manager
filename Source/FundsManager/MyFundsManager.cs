using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundsManager
{
    public class MyFundsManager
    {
        private static MyFundsManager fInstance;

        private FundsDBEntities my_db;
        private int selected;

        public int Selected { get => selected; set => selected = value; }
        public FundsDBEntities My_db { get => my_db; set => my_db = value; }

        public static MyFundsManager SingletonInstance
        {
            get
            {
                if (fInstance == null)
                {
                    fInstance = new MyFundsManager();
                }

                return fInstance;
            }
        }

        private MyFundsManager()
        {
            selected = 1;
            My_db = new FundsDBEntities();
        }

        public Fund SelectedFund()
        {
            return my_db.Funds.Find(selected);
        }

        public void AddFund(String _name)
        {

            Fund fund = new Fund();
            fund.name = _name;
            My_db.Funds.Add(fund);
            My_db.SaveChanges();

        }

        public void DeleteFund(int _id)
        {
            Fund _fund = new Fund();
            _fund = My_db.Funds.Find(_id);
            My_db.Funds.Remove(_fund);
            My_db.SaveChanges();
        }

        public void DeleteCountry(int _id)
        {
            Country _country = new Country();
            _country = My_db.Countries.Find(_id);
            My_db.Countries.Remove(_country);
            My_db.SaveChanges();
        }

        public void DeleteItem(int _id)
        {
            Item _item = new Item();
            _item = My_db.Items.Find(_id);
            My_db.Items.Remove(_item);
            My_db.SaveChanges();
        }

        public void DeleteSector(int _id)
        {
            Sector _sector = new Sector();
            _sector = My_db.Sectors.Find(_id);
            My_db.Sectors.Remove(_sector);
            My_db.SaveChanges();
        }

        public void DeleteCreditor(int _id)
        {
            Creditor _creditor = new Creditor();
            _creditor = My_db.Creditors.Find(_id);
            My_db.Creditors.Remove(_creditor);
            My_db.SaveChanges();
        }

        public void DeleteInvestor(int _id)
        {
            Investor _investor = new Investor();
            _investor = My_db.Investors.Find(_id);
            My_db.Investors.Remove(_investor);
            My_db.SaveChanges();
        }

        public void DeleteClient(int _id)
        {
            Client _client = new Client();
            _client = My_db.Clients.Find(_id);
            My_db.Clients.Remove(_client);
            My_db.SaveChanges();
        }

        public void DeleteEmployee(int _id)
        {
            Employee _employee = new Employee();
            _employee = My_db.Employees.Find(_id);
            My_db.Employees.Remove(_employee);
            My_db.SaveChanges();
        }

        public void DeleteAccount(int _id)
        {
            Account _account = new Account();
            _account = My_db.Accounts.Find(_id);
            My_db.Accounts.Remove(_account);
            My_db.SaveChanges();
        }

        public void DeleteBank(int _id)
        {
            Bank _bank = new Bank();
            _bank = My_db.Banks.Find(_id);
            My_db.Banks.Remove(_bank);
            My_db.SaveChanges();
        }

        public void DeleteBankingAccount(int _id)
        {
            BankingAccount _banking = new BankingAccount();
            _banking = My_db.BankingAccounts.Find(_id);
            My_db.BankingAccounts.Remove(_banking);
            My_db.SaveChanges();
        }
        
        public void DeleteCurrency(int _id)
        {
            Currency _currency = new Currency();
            _currency = My_db.Currencies.Find(_id);
            My_db.Currencies.Remove(_currency);
            My_db.SaveChanges();
        }

        public List<Bank> OwnBanks()
        {
            List<Bank> own_banks = new List<Bank>();

            foreach (Bank _bank in My_db.Banks)
                if (_bank.own == 1)
                    own_banks.Add(_bank);

            return own_banks;
        }

        public void DeleteSubaccount(int _id)
        {
            Subaccount _subaccount = new Subaccount();
            _subaccount = My_db.Subaccounts.Find(_id);
            My_db.Subaccounts.Remove(_subaccount);
            My_db.SaveChanges();
        }

        public void DeleteOtherDetails(int _id)
        {
            OtherDetail _otherdetail = new OtherDetail();
            _otherdetail = My_db.OtherDetails.Find(_id);
            My_db.OtherDetails.Remove(_otherdetail);
            My_db.SaveChanges();
        }

        public void deleteUnderlyingDebtors(int _id)
        {
            UnderlyingDebtor _debtor = new UnderlyingDebtor();
            _debtor = My_db.UnderlyingDebtors.Find(_id);
            My_db.UnderlyingDebtors.Remove(_debtor);
            My_db.SaveChanges();
        }


    }
}
