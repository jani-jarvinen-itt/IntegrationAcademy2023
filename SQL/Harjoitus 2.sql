-- Harjoitus 2a
SELECT COUNT(*) AS 'Asiakkaiden lukum‰‰r‰'
FROM Customers

-- Harjoitus 2c
/*
SELECT ProductName, UnitPrice, UnitsInStock,
       UnitPrice * UnitsInStock
FROM Products
*/

SELECT SUM(UnitPrice * UnitsInStock) AS Varastoarvo
FROM Products

-- Harjoitus 2c
SELECT *
FROM [Order Details]
WHERE ProductID = 14

SELECT SUM(UnitPrice * Quantity)
FROM [Order Details]
WHERE ProductID = 14

SELECT SUM(UnitPrice * Quantity * (1-Discount))
FROM [Order Details]
WHERE ProductID = 14

SELECT *
FROM Products

SELECT SUM(UnitPrice * Quantity)
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74

SELECT SUM(UnitPrice * Quantity * (1-Discount))
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74



SELECT ProductID
FROM Products
WHERE ProductName LIKE '%tofu%'




SELECT SUM(UnitPrice * Quantity * (1-Discount))
FROM [Order Details]
WHERE ProductID = 14 OR ProductID = 74



SELECT SUM(UnitPrice * Quantity * (1-Discount))
FROM [Order Details]
WHERE ProductID IN (SELECT ProductID
				    FROM Products
				    WHERE ProductName LIKE '%tofu%')
