//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FundsManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountingMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountingMovement()
        {
            this.Movements_Accounts = new HashSet<Movements_Accounts>();
            this.DisbursementGeneratedInterestDetails1 = new HashSet<DisbursementGeneratedInterestDetail>();
            this.DisbursementPayments = new HashSet<DisbursementPayment>();
            this.DisbursementCollections = new HashSet<DisbursementCollection>();
        }
    
        public int Id { get; set; }
        public int FK_AccountingMovements_Funds { get; set; }
        public string description { get; set; }
        public System.DateTime date { get; set; }
        public string reference { get; set; }
        public int FK_AccountingMovements_Currencies { get; set; }
        public string original_reference { get; set; }
        public string contract { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Fund Fund { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movements_Accounts> Movements_Accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementGeneratedInterestDetail> DisbursementGeneratedInterestDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementPayment> DisbursementPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollection> DisbursementCollections { get; set; }
    }
}
