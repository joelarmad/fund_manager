using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FundsManager.Classes.Task
{
    public static class GlobalProcess
    {
        /// <summary>
        /// Performs a bond profits update in related accounts if it is neccesary
        /// </summary>
        public static void performBondProfitsUpdate()
        {
            try
            {

                MyFundsManager _manager = MyFundsManager.SingletonInstance;

                Account _bondInterestAcruedAccount = _manager.My_db.Accounts.FirstOrDefault(x => x.number == "515");
                Subaccount _bondInvestorInterestAcct = _manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == _bondInterestAcruedAccount.Id && x.name == "Bond Investor Interests");
                Subaccount _bondTFFInterestAcct = _manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == _bondInterestAcruedAccount.Id && x.name == "Bond TFF Interests");

                DateTime _now = DateTime.Now.Date;

                List<Bond> _bonds = _manager.My_db.Bonds.Where(x => x.issued <= _now && x.active == 1).ToList();

                foreach (Bond _bond in _bonds)
                {
                    List<BondsInvestor> _bondInvestors = _manager.My_db.BondsInvestors.Where(x => x.FK_BondsInvestors_Bonds == _bond.Id).ToList();

                    foreach (BondsInvestor _bondInvestor in _bondInvestors)
                    {                        
                        if (_bondInterestAcruedAccount != null)
                        {
                            DateTime _profitDate = _bond.issued.AddMonths(1);

                            while (_profitDate <= _bond.expired && _profitDate <= DateTime.Now.Date)
                            {
                                InvestorBondProfit _profit = _manager.My_db.InvestorBondProfits.FirstOrDefault(x => x.BondId == _bond.Id && x.InvestorId == _bondInvestor.FK_BondsInvestors_Investors && x.date == _profitDate);

                                if (_profit == null)
                                {
                                    decimal _investorProfit = _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_on_bond / 100;
                                    decimal _fundProfit = _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_tff_contribution / 100;

                                    InvestorBondProfit _newInvestorProfit = new InvestorBondProfit();
                                    _newInvestorProfit.date = _profitDate;
                                    _newInvestorProfit.BondId = _bond.Id;
                                    _newInvestorProfit.InvestorId = _bondInvestor.FK_BondsInvestors_Investors;
                                    _newInvestorProfit.Income = _investorProfit;

                                    FundBondProfit _newFundBondProfit = new FundBondProfit();
                                    _newFundBondProfit.date = _profitDate;
                                    _newFundBondProfit.BondId = _bond.Id;
                                    _newFundBondProfit.Income = _fundProfit;

                                    _manager.My_db.InvestorBondProfits.Add(_newInvestorProfit);
                                    _manager.My_db.FundBondProfits.Add(_newFundBondProfit);

                                    if (_bondInterestAcruedAccount != null)
                                    {
                                        _bondInterestAcruedAccount.amount += _newInvestorProfit.Income + _newFundBondProfit.Income;
                                    }

                                    if (_bondInvestorInterestAcct != null)
                                    {
                                        _bondInvestorInterestAcct.amount += _newInvestorProfit.Income;
                                    }

                                    if (_bondTFFInterestAcct != null)
                                    {
                                        _bondTFFInterestAcct.amount += _newFundBondProfit.Income;
                                    }
                                }

                                _profitDate = _profitDate.AddMonths(1);
                            }
                        }
                    }

                    if (DateTime.Now.Date >= _bond.expired)
                    {
                        _bond.active = 0;
                    }
                }

                _manager.My_db.SaveChanges();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GlobalProcess: " + _ex.Message);
            }
        }
    }
}
