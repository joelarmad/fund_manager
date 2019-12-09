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
    
    public partial class AccountingMovement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountingMovement()
        {
            this.BookingGeneratedInterestDetails = new HashSet<BookingGeneratedInterestDetail>();
            this.DisbursementBooks = new HashSet<DisbursementBook>();
            this.DisbursementCollections = new HashSet<DisbursementCollection>();
            this.DisbursementGeneratedInterestDetails = new HashSet<DisbursementGeneratedInterestDetail>();
            this.DisbursementPayments = new HashSet<DisbursementPayment>();
            this.LoanGeneratedInterestDetails = new HashSet<LoanGeneratedInterestDetail>();
            this.Loans = new HashSet<Loan>();
            this.Movements_Accounts = new HashSet<Movements_Accounts>();
            this.Loan_Repayments = new HashSet<Loan_Repayments>();
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
        public virtual ICollection<BookingGeneratedInterestDetail> BookingGeneratedInterestDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementBook> DisbursementBooks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollection> DisbursementCollections { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementGeneratedInterestDetail> DisbursementGeneratedInterestDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementPayment> DisbursementPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanGeneratedInterestDetail> LoanGeneratedInterestDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movements_Accounts> Movements_Accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan_Repayments> Loan_Repayments { get; set; }
    }
}
