CREATE VIEW [dbo].[AccountBalance]
	AS 
select 
	a.number acct_number, 
	a.name acct_name, 
	at.AccountType acct_type,  
	at.Passive acct_passive,
	a.amount acct_amount
from Accounts a
inner join AccountType at on a.type = at.Id

go

Insert into [dbo].[RunScripts] (Script, Date) Values ('0003_creating_view_AccountBalance', getdate())