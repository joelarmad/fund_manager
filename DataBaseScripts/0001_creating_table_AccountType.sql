CREATE TABLE [dbo].[AccountType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AccountType] VARCHAR(50) NOT NULL, 
    [Passive] BIT NOT NULL DEFAULT 0
);

Insert into [dbo].[RunScripts] (Script, Date) Values ('0001_creating_table_AccountType', getdate());