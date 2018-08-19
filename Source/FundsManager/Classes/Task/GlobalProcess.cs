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
                
                DateTime _now = DateTime.Now.Date;

                List<Bond> _bonds = _manager.My_db.Bonds.Where(x => x.issued <= _now && x.active == 1).ToList();

                foreach (Bond _bond in _bonds)
                {
                    List<BondsInvestor> _bondInvestors = _manager.My_db.BondsInvestors.Where(x => x.FK_BondsInvestors_Bonds == _bond.Id).ToList();

                    foreach (BondsInvestor _bondInvestor in _bondInvestors)
                    {
                        DateTime _interestDate = _bond.issued.AddMonths(1);

                        while (_interestDate <= _bond.expired && _interestDate <= DateTime.Now.Date)
                        {
                            InvestorBondInterest _investorBondInterest = _manager.My_db.InvestorBondInterests.FirstOrDefault(x => x.BondId == _bond.Id && x.InvestorId == _bondInvestor.FK_BondsInvestors_Investors && x.InterestDate == _interestDate);

                            if (_investorBondInterest == null)
                            {
                                decimal _investorInterest = _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_on_bond / 100;
                                decimal _fundInterest = _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_tff_contribution / 100;

                                generateRegistryForBondInterest(_bond, _bondInvestor, _interestDate, _investorInterest, _fundInterest);
                            }

                            if (_interestDate == _bond.expired)
                            {
                                break;
                            }

                            _interestDate = _interestDate.AddMonths(1);

                            if (_interestDate > _bond.expired && _interestDate <= DateTime.Now.Date)
                            {
                                double _totalDays = (_bond.expired.Value - _bond.issued).TotalDays;
                                double _daysExceeded = (_bond.expired.Value - _interestDate.AddMonths(-1)).TotalDays;

                                decimal _investorInterest = (decimal)_daysExceeded * _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_on_bond / 3000;
                                decimal _fundInterest = (decimal)_daysExceeded * _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_tff_contribution / 3000;

                                generateRegistryForBondInterest(_bond, _bondInvestor, _bond.expired.Value, _investorInterest, _fundInterest);

                                break;
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
                Console.WriteLine("Error in GlobalProcess.performBondProfitsUpdate: " + _ex.Message);
            }
        }

        private static void generateRegistryForBondInterest(Bond aBond, BondsInvestor aInvestor, DateTime aInterestDate, decimal aInvestorAmount, decimal aFundAmount)
        {
            try
            {
                MyFundsManager _manager = MyFundsManager.SingletonInstance;

                //TODO: esto deberia hacerse en el momento de cobrar los intereses
                //Account _bondInterestAcruedAccount = _manager.My_db.Accounts.FirstOrDefault(x => x.number == "515" && x.FK_Accounts_Funds == manager.Selected);
                //Subaccount _bondInvestorInterestAcct = _manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == _bondInterestAcruedAccount.Id && x.name == "Bond Investor Interests");
                //Subaccount _bondTFFInterestAcct = _manager.My_db.Subaccounts.FirstOrDefault(x => x.FK_Subaccounts_Accounts == _bondInterestAcruedAccount.Id && x.name == "Bond TFF Interests");



                InvestorBondInterest _newInvestorInterest = new InvestorBondInterest();
                _newInvestorInterest.InterestDate = aInterestDate;
                _newInvestorInterest.BondId = aBond.Id;
                _newInvestorInterest.InvestorId = aInvestor.FK_BondsInvestors_Investors;
                _newInvestorInterest.Amount = aInvestorAmount;
                _newInvestorInterest.Extracted = false;

                FundBondInterest _newFundBondInterest = new FundBondInterest();
                _newFundBondInterest.InterestDate = aInterestDate;
                _newFundBondInterest.BondId = aBond.Id;
                _newFundBondInterest.Amount = aFundAmount;
                _newFundBondInterest.Extracted = false;

                _manager.My_db.InvestorBondInterests.Add(_newInvestorInterest);
                _manager.My_db.FundBondInterests.Add(_newFundBondInterest);

                //TODO: esto deberia hacerse en el momento de cobrar los intereses
                //if (_bondInterestAcruedAccount != null)
                //{
                //    _bondInterestAcruedAccount.amount += _newInvestorInterest.Income + _newFundBondInterest.Income;
                //}

                //if (_bondInvestorInterestAcct != null)
                //{
                //    _bondInvestorInterestAcct.amount += _newInvestorInterest.Income;
                //}

                //if (_bondTFFInterestAcct != null)
                //{
                //    _bondTFFInterestAcct.amount += _newFundBondInterest.Income;
                //}
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GlobalProcess.performBondProfitsUpdate: " + _ex.Message);
            }
        }
    }
}
