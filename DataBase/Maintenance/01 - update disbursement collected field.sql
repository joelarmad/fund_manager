﻿UPDATE dbo.Disbursements SET collected = 1 WHERE Id IN (SELECT dtbc.disbursement_id FROM dbo.DisbursementsToBeCollected dtbc WHERE dtbc.amount + dtbc.profit_share <= dtbc.profit_share_accrued)
UPDATE dbo.Disbursements SET collected = 0 WHERE Id NOT IN (SELECT dtbc.disbursement_id FROM dbo.DisbursementsToBeCollected dtbc WHERE dtbc.amount + dtbc.profit_share <= dtbc.profit_share_accrued)