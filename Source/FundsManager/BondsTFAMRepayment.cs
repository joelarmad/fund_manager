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
    
    public partial class BondsTFAMRepayment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BondsTFAMRepayment()
        {
            this.BondsTFAMRepaymentDetails = new HashSet<BondsTFAMRepaymentDetail>();
        }
    
        public int Id { get; set; }
        public System.DateTime repayment_date { get; set; }
        public Nullable<int> accounting_movement_id { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BondsTFAMRepaymentDetail> BondsTFAMRepaymentDetails { get; set; }
    }
}