CREATE PROCEDURE NostaHintoja
AS
	UPDATE Products
	SET UnitPrice = UnitPrice * 1.10

-- suorituskomento
SELECT TOP 10 ProductName, UnitPrice
FROM Products

BEGIN TRANSACTION
EXEC NostaHintoja
COMMIT
--ROLLBACK
