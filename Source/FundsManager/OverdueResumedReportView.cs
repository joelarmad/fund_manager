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
    
    public partial class OverdueResumedReportView
    {
        public Nullable<int> client_id { get; set; }
        public string client { get; set; }
        public Nullable<int> investment_id { get; set; }
        public string contract { get; set; }
        public int disbursement_id { get; set; }
        public Nullable<int> booking_id { get; set; }
        public Nullable<decimal> montly_rate_avg { get; set; }
        public Nullable<decimal> total_generated_overdue { get; set; }
        public Nullable<int> generation_count { get; set; }
        public Nullable<System.DateTime> overdue_date_from { get; set; }
        public Nullable<System.DateTime> overdue_date_to { get; set; }
        public Nullable<decimal> delay_interest_accrued { get; set; }
        public Nullable<decimal> delay_interest_collected { get; set; }
        public Nullable<int> fund_id { get; set; }
    }
}