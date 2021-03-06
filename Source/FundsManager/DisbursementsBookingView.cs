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
    
    public partial class DisbursementsBookingView
    {
        public int Id { get; set; }
        public int investment_id { get; set; }
        public int currency_id { get; set; }
        public float exchange_rate { get; set; }
        public int client_id { get; set; }
        public Nullable<int> underlying_debtor_id { get; set; }
        public Nullable<int> bank_risk_id { get; set; }
        public decimal profit_share { get; set; }
        public decimal amount { get; set; }
        public int fund_id { get; set; }
        public System.DateTime date { get; set; }
        public int sector_id { get; set; }
        public string number { get; set; }
        public System.DateTime collection_date { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public bool can_generate_interest { get; set; }
        public Nullable<int> shipment_id { get; set; }
        public Nullable<bool> collected { get; set; }
        public Nullable<bool> has_bookings { get; set; }
        public Nullable<bool> is_booking { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> group_parent_id { get; set; }
        public Nullable<int> book_id { get; set; }
        public Nullable<decimal> delay_interest { get; set; }
        public Nullable<int> movement125_id { get; set; }
        public Nullable<int> movement128_id { get; set; }
        public string contract { get; set; }
    }
}
