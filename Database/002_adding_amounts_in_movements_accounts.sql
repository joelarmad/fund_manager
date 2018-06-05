ALTER TABLE [dbo].[Movements_Accounts]
    ADD [acc_amount]    MONEY DEFAULT 0 NOT NULL,
        [subacc_amount] MONEY DEFAULT 0 NOT NULL;

Insert into [dbo].[Runscripts] (Name) Values ('002_adding_amounts_in_movements_accounts');