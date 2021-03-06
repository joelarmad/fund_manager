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
    
    public partial class DealTrackingView
    {
        public int fund_id { get; set; }
        public string row_id { get; set; }
        public Nullable<bool> is_booking { get; set; }
        public Nullable<bool> has_bookings { get; set; }
        public int investment_id { get; set; }
        public int disbursement_id { get; set; }
        public string number { get; set; }
        public string contract { get; set; }
        public string client { get; set; }
        public int client_id { get; set; }
        public string underlying_debtor { get; set; }
        public string bank_name { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public decimal principal { get; set; }
        public decimal interest { get; set; }
        public Nullable<decimal> delay_interest { get; set; }
        public System.DateTime estimated_repay_date { get; set; }
        public Nullable<decimal> principal_collected { get; set; }
        public Nullable<decimal> interest_collected { get; set; }
        public Nullable<decimal> delay_interest_collected { get; set; }
        public Nullable<decimal> principal_remaining { get; set; }
        public Nullable<decimal> interest_remaining { get; set; }
        public Nullable<decimal> delay_interest_remaining { get; set; }
        public bool can_generate_interest { get; set; }
        public Nullable<bool> collected { get; set; }
    }
}
