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
    
    public partial class DisbursementCollectionsDetail
    {
        public int disbursement_collection_id { get; set; }
        public int disbursement_id { get; set; }
        public decimal amount_collected { get; set; }
        public Nullable<int> movement125_id { get; set; }
        public Nullable<int> movement128_id { get; set; }
        public Nullable<int> movement130_id { get; set; }
    
        public virtual DisbursementCollection DisbursementCollection { get; set; }
        public virtual Movements_Accounts Movements_Accounts_125 { get; set; }
        public virtual Movements_Accounts Movements_Accounts_128 { get; set; }
        public virtual Movements_Accounts Movements_Accounts_130 { get; set; }
        public virtual Disbursement Disbursement { get; set; }
    }
}
