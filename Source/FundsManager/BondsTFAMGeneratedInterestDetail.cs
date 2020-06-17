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
    
    public partial class BondsTFAMGeneratedInterestDetail
    {
        public int Id { get; set; }
        public int bond_id { get; set; }
        public decimal generated_bond_interest { get; set; }
        public decimal generated_tff_interest { get; set; }
        public System.DateTime generated_interest_date { get; set; }
        public Nullable<System.DateTime> payment_interest_date { get; set; }
        public Nullable<int> interest_accounting_movement_id { get; set; }
        public Nullable<int> payment_accounting_movement_id { get; set; }
        public Nullable<int> interest_id { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        public virtual AccountingMovement AccountingMovement1 { get; set; }
        public virtual BondsTFAMGeneratedInterest BondsTFAMGeneratedInterest { get; set; }
        public virtual BondsTFAM BondsTFAM { get; set; }
    }
}
