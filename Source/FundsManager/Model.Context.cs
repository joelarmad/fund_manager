﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FundsDBEntities : DbContext
    {
        public FundsDBEntities()
            : base("name=FundsDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountingMovement> AccountingMovements { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountsBankingAccount> AccountsBankingAccounts { get; set; }
        public virtual DbSet<AccountsClient> AccountsClients { get; set; }
        public virtual DbSet<AccountsCreditor> AccountsCreditors { get; set; }
        public virtual DbSet<AccountsEmployee> AccountsEmployees { get; set; }
        public virtual DbSet<BankingAccount> BankingAccounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BondsInvestor> BondsInvestors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Creditor> Creditors { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Subaccount> Subaccounts { get; set; }
        public virtual DbSet<Movements_Accounts> Movements_Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Bond> Bonds { get; set; }
        public virtual DbSet<Disbursement_dates> Disbursement_dates { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
        public virtual DbSet<OtherDetail> OtherDetails { get; set; }
        public virtual DbSet<FundBondInterest> FundBondInterests { get; set; }
        public virtual DbSet<InvestorBondInterest> InvestorBondInterests { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<UnderlyingDebtor> UnderlyingDebtors { get; set; }
    }
}
