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
    
    public partial class LoanGeneratedInterestView
    {
        public int Id { get; set; }
        public int loan_generated_interest_id { get; set; }
        public System.DateTime GeneratedDate { get; set; }
        public int loan_id { get; set; }
        public decimal generated_interest { get; set; }
        public System.DateTime generated_interest_date { get; set; }
        public decimal interest { get; set; }
        public decimal amount { get; set; }
        public string reference { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end { get; set; }
        public int fund_id { get; set; }
        public int currency_id { get; set; }
        public Nullable<bool> renegotiated { get; set; }
        public Nullable<int> loan_origin_id { get; set; }
        public int interest_base { get; set; }
        public int lender_id { get; set; }
    }
}