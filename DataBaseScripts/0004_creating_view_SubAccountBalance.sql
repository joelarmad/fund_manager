CREATE VIEW [dbo].[SubAccountBalance]
	AS 
select 
	a.number acct_number, 
	a.name acct_name, 
	at.AccountType acct_type,  
	at.Passive acct_passive,
	a.amount acct_amount,
	sa.name subacct_name, 
	sa.amount subacct_amount
from Accounts a
inner join AccountType at on a.type = at.Id
inner join Subaccounts sa on sa.FK_Subaccounts_Accounts = a.Id

go

Insert into [dbo].[RunScripts] (Script, Date) Values ('0004_creating_view_SubAccountBalance', getdate())