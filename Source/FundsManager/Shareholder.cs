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
    
    public partial class Shareholder
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int FK_Creditors_Funds { get; set; }
        public string number { get; set; }
    
        public virtual Fund Fund { get; set; }
    }
}
