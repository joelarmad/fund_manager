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
    
    public partial class BondsTFAMToBeRepaid
    {
        public int Id { get; set; }
        public string number { get; set; }
        public System.DateTime issued { get; set; }
        public System.DateTime expired { get; set; }
        public int fund_id { get; set; }
        public decimal amount { get; set; }
        public Nullable<decimal> amount_repaid { get; set; }
        public Nullable<decimal> amount_to_be_repaid { get; set; }
        public double interest_on_bond { get; set; }
        public Nullable<decimal> bond_interest_accrued { get; set; }
        public double interest_tff_contribution { get; set; }
        public Nullable<decimal> tff_interest_accrued { get; set; }
        public Nullable<decimal> interest_repaid { get; set; }
        public Nullable<decimal> interest_to_be_repaid { get; set; }
    }
}
