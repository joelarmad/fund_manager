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
    
    public partial class Investor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Investor()
        {
            this.BondsTFFInvestors = new HashSet<BondsTFFInvestor>();
            this.InvestorBondInterests = new HashSet<InvestorBondInterest>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public int FK_Investors_Funds { get; set; }
        public string number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BondsTFFInvestor> BondsTFFInvestors { get; set; }
        public virtual Fund Fund { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvestorBondInterest> InvestorBondInterests { get; set; }
    }
}
