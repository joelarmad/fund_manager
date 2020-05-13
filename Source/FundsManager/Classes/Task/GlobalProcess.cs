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

                List<BondsTFF> _bonds = _manager.My_db.BondsTFFs.Where(x => x.issued <= _now && x.active == 1).ToList();

                foreach (BondsTFF _bond in _bonds)
                {
                    List<BondsTFFInvestor> _bondInvestors = _manager.My_db.BondsTFFInvestors.Where(x => x.FK_BondsInvestors_Bonds == _bond.Id).ToList();

                    foreach (BondsTFFInvestor _bondInvestor in _bondInvestors)
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

        private static void generateRegistryForBondInterest(BondsTFF aBond, BondsTFFInvestor aInvestor, DateTime aInterestDate, decimal aInvestorAmount, decimal aFundAmount)
        {
            try
            {
                MyFundsManager _manager = MyFundsManager.SingletonInstance;

                InvestorBondInterest _newInvestorInterest = new InvestorBondInterest();
                _newInvestorInterest.InterestDate = aInterestDate;
                _newInvestorInterest.BondId = aBond.Id;
                _newInvestorInterest.InvestorId = aInvestor.FK_BondsInvestors_Investors;
                _newInvestorInterest.Amount = Math.Round(aInvestorAmount, 2);
                _newInvestorInterest.Extracted = false;

                FundBondInterest _newFundBondInterest = new FundBondInterest();
                _newFundBondInterest.InterestDate = aInterestDate;
                _newFundBondInterest.BondId = aBond.Id;
                _newFundBondInterest.Amount = Math.Round(aFundAmount, 2);
                _newFundBondInterest.Extracted = false;

                _manager.My_db.InvestorBondInterests.Add(_newInvestorInterest);
                _manager.My_db.FundBondInterests.Add(_newFundBondInterest);
                
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GlobalProcess.performBondProfitsUpdate: " + _ex.Message);
            }
        }
    }
}
