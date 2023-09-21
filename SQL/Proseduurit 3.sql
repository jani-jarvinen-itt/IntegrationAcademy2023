-- DROP PROCEDURE InsertProductFromCSV
-- GO

CREATE PROCEDURE InsertProductFromCSV
@CSVString NVARCHAR(MAX)
AS
BEGIN
    -- Declare a table variable to store the split values
    DECLARE @ParsedTable TABLE (
        [Value] NVARCHAR(MAX)
    );

    -- Split CSV into rows
    DECLARE @RowSeparator CHAR(1) = CHAR(10); -- Assuming newline separates rows
    DECLARE @StartIndex INT = 1;
    DECLARE @EndIndex INT;

    WHILE CHARINDEX(@RowSeparator, @CSVString, @StartIndex) > 0
    BEGIN
        SET @EndIndex = CHARINDEX(@RowSeparator, @CSVString, @StartIndex);
        INSERT INTO @ParsedTable ([Value])
        SELECT SUBSTRING(@CSVString, @StartIndex, @EndIndex - @StartIndex);

        SET @StartIndex = @EndIndex + 1;
    END

    -- Parse each row and insert into Products table
    DECLARE @CurrentRow NVARCHAR(MAX);
    DECLARE @ProductName NVARCHAR(40);
    DECLARE @SupplierID INT;
    DECLARE @CategoryID INT;

    DECLARE csv_cursor CURSOR FOR 
    SELECT [Value] FROM @ParsedTable;

    OPEN csv_cursor;
    FETCH NEXT FROM csv_cursor INTO @CurrentRow;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Parse ProductName
        SET @EndIndex = CHARINDEX(',', @CurrentRow, 0);
        SET @ProductName = LEFT(@CurrentRow, @EndIndex - 1);
        SET @CurrentRow = RIGHT(@CurrentRow, LEN(@CurrentRow) - @EndIndex);

        -- Parse SupplierID
        SET @EndIndex = CHARINDEX(',', @CurrentRow, 0);
        SET @SupplierID = CAST(LEFT(@CurrentRow, @EndIndex - 1) AS INT);
        SET @CurrentRow = RIGHT(@CurrentRow, LEN(@CurrentRow) - @EndIndex);

        -- Parse CategoryID (last remaining part of @CurrentRow minus possible line break)
        SET @CategoryID = CAST(REPLACE(REPLACE(@CurrentRow, CHAR(13), ''), CHAR(10), '') AS INT);

        -- Insert into Products
        INSERT INTO Products (ProductName, SupplierID, CategoryID) VALUES (@ProductName, @SupplierID, @CategoryID);

        FETCH NEXT FROM csv_cursor INTO @CurrentRow;
    END

    CLOSE csv_cursor;
    DEALLOCATE csv_cursor;
END;
