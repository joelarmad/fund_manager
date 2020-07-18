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
    
    public partial class Disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement()
        {
            this.BookingGeneratedInterestDetails = new HashSet<BookingGeneratedInterestDetail>();
            this.DisbursementCollectionsDetails = new HashSet<DisbursementCollectionsDetail>();
            this.DisbursementGeneratedInterestDetails = new HashSet<DisbursementGeneratedInterestDetail>();
            this.DisbursementOverdueDetails = new HashSet<DisbursementOverdueDetail>();
            this.DisbursementPayments = new HashSet<DisbursementPayment>();
        }
    
        public int Id { get; set; }
        public int investment_id { get; set; }
        public int currency_id { get; set; }
        public float exchange_rate { get; set; }
        public int client_id { get; set; }
        public Nullable<int> underlying_debtor_id { get; set; }
        public Nullable<int> bank_risk_id { get; set; }
        public decimal profit_share { get; set; }
        public decimal amount { get; set; }
        public int fund_id { get; set; }
        public System.DateTime date { get; set; }
        public int sector_id { get; set; }
        public string number { get; set; }
        public System.DateTime collection_date { get; set; }
        public Nullable<System.DateTime> pay_date { get; set; }
        public bool can_generate_interest { get; set; }
        public Nullable<int> shipment_id { get; set; }
        public Nullable<bool> collected { get; set; }
        public Nullable<bool> has_bookings { get; set; }
        public Nullable<bool> is_booking { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> group_parent_id { get; set; }
        public Nullable<int> book_id { get; set; }
        public Nullable<decimal> delay_interest { get; set; }
        public Nullable<int> movement125_id { get; set; }
        public Nullable<int> movement128_id { get; set; }
        public string contract { get; set; }
    
        public virtual Bank Bank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingGeneratedInterestDetail> BookingGeneratedInterestDetails { get; set; }
        public virtual Client Client { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual DisbursementBook DisbursementBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementCollectionsDetail> DisbursementCollectionsDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementGeneratedInterestDetail> DisbursementGeneratedInterestDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementOverdueDetail> DisbursementOverdueDetails { get; set; }
        public virtual Fund Fund { get; set; }
        public virtual Investment Investment { get; set; }
        public virtual Movements_Accounts Movements_Accounts { get; set; }
        public virtual Movements_Accounts Movements_Accounts1 { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual UnderlyingDebtor UnderlyingDebtor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementPayment> DisbursementPayments { get; set; }
    }
}
