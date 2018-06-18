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
        public static void performBondProfitsUpdate(MyFundsManager aManager)
        {
            try
            {
                List<Bond> _bonds = aManager.My_db.Bonds.Where(x => x.active == 1).ToList();

                foreach (Bond _bond in _bonds)
                {
                    List<BondsInvestor> _bondInvestors = aManager.My_db.BondsInvestors.Where(x => x.FK_BondsInvestors_Bonds == _bond.Id).ToList();

                    foreach (BondsInvestor _bondInvestor in _bondInvestors)
                    {
                        //TODO: ajustar con la cuenta correcta
                        Account _account = aManager.My_db.Accounts.FirstOrDefault(x => x.number == "900");

                        if (_account != null)
                        {
                            DateTime _profitDate = _bond.issued.AddDays(30);

                            while (_profitDate <= _bond.expired && _profitDate <= DateTime.Now.Date)
                            {
                                InvestorBondProfit _profit = aManager.My_db.InvestorBondProfits.FirstOrDefault(x => x.BondId == _bond.Id && x.InvestorId == _bondInvestor.FK_BondsInvestors_Investors && x.date == _profitDate);

                                if (_profit == null)
                                {
                                    //TODO: MODIFICAR LUEGO DE CONFIRMACION CON EL CLIENTE
                                    decimal _investorProfit = _bond.price * (decimal)_bondInvestor.quantity * (decimal)_bond.interest_on_bond / 100;
                                    decimal _fundProfit = _investorProfit * (decimal)_bond.interest_tff_contribution / 100;
                                    _investorProfit -= _fundProfit;

                                    InvestorBondProfit _newInvestorProfit = new InvestorBondProfit();
                                    _newInvestorProfit.date = _profitDate;
                                    _newInvestorProfit.BondId = _bond.Id;
                                    _newInvestorProfit.InvestorId = _bondInvestor.FK_BondsInvestors_Investors;
                                    _newInvestorProfit.Income = _investorProfit;
                                    _newInvestorProfit.AccountId = _account.Id;

                                    FundBondProfit _newFundBondProfit = new FundBondProfit();
                                    _newFundBondProfit.date = _profitDate;
                                    _newFundBondProfit.BondId = _bond.Id;
                                    _newFundBondProfit.Income = _fundProfit;

                                    aManager.My_db.InvestorBondProfits.Add(_newInvestorProfit);
                                    aManager.My_db.FundBondProfits.Add(_newFundBondProfit);
                                }

                                _profitDate = _profitDate.AddDays(30);
                            }
                        }
                    }

                    if (DateTime.Now.Date >= _bond.expired)
                    {
                        _bond.active = 0;
                    }
                }

                aManager.My_db.SaveChanges();
            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error in GlobalProcess: " + _ex.Message);
            }
        }
    }
}
