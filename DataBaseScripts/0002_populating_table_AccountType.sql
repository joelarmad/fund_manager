INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (0, N'Asset', 1)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (1, N'Liability', 0)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (2, N'Equity', 0)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (3, N'Income', 0)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (4, N'Expense', 1)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (5, N'Contingency Asset', 1)
INSERT INTO [dbo].[AccountType] ([Id], [AccountType], [Passive]) VALUES (6, N'Contingency Liability', 0)

Insert into [dbo].[RunScripts] (Script, Date) Values ('0002_populating_table_AccountType', getdate())