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
    
    public partial class DisbursementGeneratedInterestDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisbursementGeneratedInterestDetail()
        {
            this.AccountingMovements = new HashSet<AccountingMovement>();
        }
    
        public int Id { get; set; }
        public int disbursement_generated_interest_id { get; set; }
        public int disbursement_id { get; set; }
        public decimal generated_interest { get; set; }
        public System.DateTime generated_interest_date { get; set; }
        public Nullable<int> accounting_movement_id { get; set; }
    
        public virtual DisbursementGeneratedInterest DisbursementGeneratedInterest { get; set; }
        public virtual Disbursement Disbursement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountingMovement> AccountingMovements { get; set; }
        public virtual AccountingMovement AccountingMovement { get; set; }
    }
}
