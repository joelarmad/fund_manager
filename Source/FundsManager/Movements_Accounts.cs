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
    
    public partial class Movements_Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movements_Accounts()
        {
            this.DisbursementBookings = new HashSet<DisbursementBooking>();
            this.DisbursementBookings1 = new HashSet<DisbursementBooking>();
            this.DisbursementBooks = new HashSet<DisbursementBook>();
            this.DisbursementBooks1 = new HashSet<DisbursementBook>();
            this.DisbursementCollectionsDetails = new HashSet<DisbursementCollectionsDetail>();
            this.DisbursementCollectionsDetails1 = new HashSet<DisbursementCollectionsDetail>();
            this.DisbursementCollectionsDetails2 = new HashSet<DisbursementCollectionsDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> FK_Movements_Accounts_Subaccounts { get; set; }
        public int FK_Movements_Accounts_AccountingMovements { get; set; }
        public decimal credit { get; set; }
        public decimal debit { get; set; }
        public Nullable<int> subaccount { get; set; }
        public Nullable<int> subaccount_type { get; set; }
        public int FK_Movements_Accounts_Funds { get; set; }
        public Nullable<int> FK_Movements_Accounts_Accounts { get; set; }
        public Nullable<decimal> shift_amount { get; set; }
    
        public virtual AccountingMovement AccountingMovement { get; set; }
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBooking> DisbursementBookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBooking> DisbursementBookings1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBook> DisbursementBooks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBook> DisbursementBooks1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollectionsDetail> DisbursementCollectionsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollectionsDetail> DisbursementCollectionsDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollectionsDetail> DisbursementCollectionsDetails2 { get; set; }
        public virtual Fund Fund { get; set; }
        public virtual Subaccount Subaccount1 { get; set; }
    }
}
