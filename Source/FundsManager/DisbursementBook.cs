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
    
    public partial class DisbursementBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisbursementBook()
        {
            this.DisbursementBookings = new HashSet<DisbursementBooking>();
        }
    
        public int Id { get; set; }
        public System.DateTime date { get; set; }
        public int accounting_movement_id { get; set; }
        public int movement125_id { get; set; }
        public int movement128_id { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBooking> DisbursementBookings { get; set; }
        public virtual Movements_Accounts Movements_Accounts { get; set; }
        public virtual Movements_Accounts Movements_Accounts1 { get; set; }
    }
}
