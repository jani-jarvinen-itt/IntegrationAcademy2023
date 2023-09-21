CREATE PROCEDURE AsiakkaatMaasta
	@Maa VARCHAR(50)
AS
	SELECT *
	FROM Customers
	WHERE Country = @Maa

-- suorituskomento
EXEC AsiakkaatMaasta
     @Maa = 'Finland'
