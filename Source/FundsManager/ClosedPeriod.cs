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
    
    public partial class ClosedPeriod
    {
        public int year { get; set; }
        public System.DateTime closing_date { get; set; }
        public int accounting_movement_id { get; set; }
        public int fund_id { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        public virtual Fund Fund { get; set; }
    }
}
