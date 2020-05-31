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
    
    public partial class DisbursementsToBeCollected
    {
        public string row_key { get; set; }
        public int fund_id { get; set; }
        public string contract { get; set; }
        public int investment_id { get; set; }
        public int disbursement_id { get; set; }
        public string number { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public System.DateTime collection_date { get; set; }
        public decimal amount { get; set; }
        public decimal profit_share { get; set; }
        public Nullable<decimal> profit_share_accrued { get; set; }
        public decimal delay_interest { get; set; }
        public Nullable<decimal> delay_interest_accrued { get; set; }
        public Nullable<decimal> amount_collected { get; set; }
        public Nullable<decimal> profit_share_collected { get; set; }
        public Nullable<decimal> delay_interest_collected { get; set; }
        public Nullable<decimal> amount_remainig { get; set; }
        public Nullable<decimal> profit_share_accrued_remaining { get; set; }
        public Nullable<decimal> delay_interest_accrued_remaining { get; set; }
        public bool can_generate_interest { get; set; }
        public int is_booking { get; set; }
    }
}
