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
    
    public partial class BookingGeneratedInterestView
    {
        public int fund_id { get; set; }
        public string contract { get; set; }
        public int disbursement_id { get; set; }
        public int investment_id { get; set; }
        public string disbursement_number { get; set; }
        public System.DateTime collection_date { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<System.DateTime> disbursement_pay_date { get; set; }
        public bool can_generate_interest { get; set; }
        public decimal amount { get; set; }
        public decimal profit_share { get; set; }
        public decimal generated_interest { get; set; }
        public int booking_generated_interest_id { get; set; }
        public System.DateTime GeneratedDate { get; set; }
    }
}
