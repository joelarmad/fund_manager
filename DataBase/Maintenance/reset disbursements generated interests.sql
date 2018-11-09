SELECT dgid.accounting_movement_id INTO #temp FROM dbo.DisbursementGeneratedInterestDetails dgid

DELETE FROM dbo.DisbursementGeneratedInterestDetails
DELETE FROM dbo.DisbursementGeneratedInterests
DELETE FROM dbo.Movements_Accounts WHERE FK_Movements_Accounts_AccountingMovements IN (SELECT accounting_movement_id FROM #temp)
DELETE FROM dbo.AccountingMovements WHERE id IN (SELECT accounting_movement_id FROM #temp)

UPDATE dbo.Disbursements SET can_generate_interest = 1 WHERE pay_date IS NOT NULL


DROP TABLE #temp