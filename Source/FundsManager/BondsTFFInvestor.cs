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
    
    public partial class BondsTFFInvestor
    {
        public int Id { get; set; }
        public int FK_BondsInvestors_Bonds { get; set; }
        public int FK_BondsInvestors_Investors { get; set; }
        public double quantity { get; set; }
    
        public virtual BondsTFF BondsTFF { get; set; }
        public virtual Investor Investor { get; set; }
    }
}
