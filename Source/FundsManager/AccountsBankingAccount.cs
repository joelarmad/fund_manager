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
    
    public partial class AccountsBankingAccount
    {
        public int Id { get; set; }
        public int FK_AccountsBankingAccount_Funds { get; set; }
        public int account_id { get; set; }
        public int banking_account_id { get; set; }
        public decimal amount { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Fund Fund { get; set; }
        public virtual BankingAccount BankingAccount { get; set; }
    }
}
