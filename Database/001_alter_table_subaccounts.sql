ALTER TABLE [dbo].[Subaccounts]
    ADD [amount] MONEY NOT NULL DEFAULT 0;

Insert into [dbo].[Runscripts] (Name) values ('001_alter_table_subaccounts');