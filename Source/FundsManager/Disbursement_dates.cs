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
    
    public partial class Disbursement_dates
    {
        public int Id { get; set; }
        public System.DateTime date { get; set; }
        public int day { get; set; }
        public int disbursement_id { get; set; }
        public int fund_id { get; set; }
    
        public virtual Fund Fund { get; set; }
        public virtual Disbursement Disbursement { get; set; }
    }
}
