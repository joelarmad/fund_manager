//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FundsManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoanGeneratedInterestDetail
    {
        public int Id { get; set; }
        public int loan_generated_interest_id { get; set; }
        public int loan_id { get; set; }
        public decimal generated_interest { get; set; }
        public System.DateTime generated_interest_date { get; set; }
        public Nullable<int> accounting_movement_id { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        public virtual LoanGeneratedInterest LoanGeneratedInterest { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
