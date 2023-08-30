-- Harjoitus 1a
SELECT *
FROM Customers
WHERE Country = 'Finland'

-- Harjoitus 1b
SELECT CustomerID
FROM Customers
WHERE CompanyName = 'Que Del�cia'

SELECT *
FROM Orders
WHERE CustomerID = 'QUEDE'


-- JOIN-esimerkki (liitos)
SELECT o.*
FROM Customers c
INNER JOIN Orders o ON
    c.CustomerID = o.CustomerID
WHERE c.CompanyName = 'Que Del�cia'

-- alikysely (subquery)
SELECT *
FROM Orders
WHERE CustomerID = (SELECT CustomerID
                    FROM Customers
                    WHERE CompanyName = 'Que Del�cia')

/*
SELECT CompanyName AS YrityksenNimi, ContactName AS Yhteyshenkil�
FROM Customers
*/

-- Harjoitus 1c
SELECT *
FROM Employees
WHERE City = 'London' -- AND Country = 'UK'
