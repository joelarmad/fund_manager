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
    
    public partial class MovementsView
    {
        public int FundId { get; set; }
        public int Id { get; set; }
        public string Reference { get; set; }
        public string description { get; set; }
        public int account_id { get; set; }
        public int TypeId { get; set; }
        public string AccountType { get; set; }
        public string Account { get; set; }
        public string SubAccount { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Nullable<decimal> Shift_Amount { get; set; }
        public string Detail { get; set; }
        public string Currency { get; set; }
        public int MovementId { get; set; }
        public Nullable<int> SubAccountId { get; set; }
        public Nullable<int> detail_type { get; set; }
        public Nullable<int> detail_id { get; set; }
    }
}
