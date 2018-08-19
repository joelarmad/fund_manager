﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundsManager.ReportForms;

namespace FundsManager
{
    public partial class ProfitShareToAccrueForm : Form
    {
        MyFundsManager manager = MyFundsManager.SingletonInstance;

        public ProfitShareToAccrueForm()
        {
            InitializeComponent();
        }

        private void cmdGenerateInterest_Click(object sender, EventArgs e)
        {
            try
            {
                cmdGenerateInterest.Enabled = false;

                DateTime _date = Convert.ToDateTime(dtpDate.Text);

                List<ProfitShareToAccrue> _profitShareToAccrueList = manager.My_db.ProfitShareToAccrues.Where(x => x.pay_date <= _date).ToList();

                if (_profitShareToAccrueList.Count > 0)
                {
                    DisbursementGeneratedInterest _generatedInterest = new DisbursementGeneratedInterest();
                    _generatedInterest.GeneratedDate = Convert.ToDateTime(dtpDate.Text);

                    manager.My_db.DisbursementGeneratedInterests.Add(_generatedInterest);
                    manager.My_db.SaveChanges();

                    decimal _totalInterest = 0;

                    foreach (ProfitShareToAccrue _profitShareToAccrue in _profitShareToAccrueList)
                    {
                        decimal _interest = AccrueInterest(_profitShareToAccrue);

                        _totalInterest += _interest;

                        DisbursementGeneratedInterestDetail _detail = new DisbursementGeneratedInterestDetail();
                        _detail.disbursement_generated_interest_id = _generatedInterest.Id;
                        _detail.disbursement_id = _profitShareToAccrue.Id;
                        _detail.generated_interest = _interest;

                        manager.My_db.DisbursementGeneratedInterestDetails.Add(_detail);
                        manager.My_db.SaveChanges();
                    }

                    //TODO: Generar movimientos de cuenta
                    
                    DisbursementGeneratedInterestForm disbursement_generated_interest_form = new DisbursementGeneratedInterestForm();
                    disbursement_generated_interest_form.generated_interest_id = _generatedInterest.Id;
                    disbursement_generated_interest_form.Show();
                }
                else
                {
                    MessageBox.Show("Disbursements not found.");
                }

            }
            catch (Exception _ex)
            {
                Console.WriteLine("Error at ProfitShareToAccrueForm.cmdGenerateInterest_Click: " + _ex.Message);
            }

            cmdGenerateInterest.Enabled = true;
        }

        private decimal AccrueInterest(ProfitShareToAccrue aProfitShareToAccrue)
        {
            //TODO: Calcular la acumulacion de intereses

            return 1;
        }
    }
}
