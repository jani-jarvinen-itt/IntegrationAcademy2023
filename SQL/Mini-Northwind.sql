-- Mini-versio Northwind-esimerkkitietokannasta esim. SqlFiddle.com-palveluun

CREATE TABLE "Customers" (
	"CustomerID" nchar (5) NOT NULL ,
	"CompanyName" nvarchar (40) NOT NULL ,
	"ContactName" nvarchar (30) NULL ,
	"ContactTitle" nvarchar (30) NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"Phone" nvarchar (24) NULL ,
	"Fax" nvarchar (24) NULL ,
	CONSTRAINT "PK_Customers" PRIMARY KEY  CLUSTERED 
	(
		"CustomerID"
	)
)
GO

CREATE TABLE "Products" (
	"ProductID" "int" IDENTITY (1, 1) NOT NULL ,
	"ProductName" nvarchar (40) NOT NULL ,
	"SupplierID" "int" NULL ,
	"CategoryID" "int" NULL ,
	"QuantityPerUnit" nvarchar (20) NULL ,
	"UnitPrice" "money" NULL CONSTRAINT "DF_Products_UnitPrice" DEFAULT (0),
	"UnitsInStock" "smallint" NULL CONSTRAINT "DF_Products_UnitsInStock" DEFAULT (0),
	"UnitsOnOrder" "smallint" NULL CONSTRAINT "DF_Products_UnitsOnOrder" DEFAULT (0),
	"ReorderLevel" "smallint" NULL CONSTRAINT "DF_Products_ReorderLevel" DEFAULT (0),
	"Discontinued" "bit" NOT NULL CONSTRAINT "DF_Products_Discontinued" DEFAULT (0),
	CONSTRAINT "PK_Products" PRIMARY KEY  CLUSTERED 
	(
		"ProductID"
	),
	CONSTRAINT "CK_Products_UnitPrice" CHECK (UnitPrice >= 0),
	CONSTRAINT "CK_ReorderLevel" CHECK (ReorderLevel >= 0),
	CONSTRAINT "CK_UnitsInStock" CHECK (UnitsInStock >= 0),
	CONSTRAINT "CK_UnitsOnOrder" CHECK (UnitsOnOrder >= 0)
)
GO

INSERT "Customers" VALUES('ALFKI','Alfreds Futterkiste','Maria Anders','Sales Representative','Obere Str. 57','Berlin',NULL,'12209','Germany','030-0074321','030-0076545')
INSERT "Customers" VALUES('ANATR','Ana Trujillo Emparedados y helados','Ana Trujillo','Owner','Avda. de la Constitución 2222','México D.F.',NULL,'05021','Mexico','(5) 555-4729','(5) 555-3745')
INSERT "Customers" VALUES('ANTON','Antonio Moreno Taquería','Antonio Moreno','Owner','Mataderos  2312','México D.F.',NULL,'05023','Mexico','(5) 555-3932',NULL)
GO


SET IDENTITY_INSERT "Products" ON;
GO

INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(1,'Chai',1,1,'10 boxes x 20 bags',18,39,0,10,0)
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(2,'Chang',1,1,'24 - 12 oz bottles',19,17,40,25,0)
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(3,'Aniseed Syrup',1,2,'12 - 550 ml bottles',10,13,70,25,0)
INSERT "Products"("ProductID","ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES(4,'Chef Anton''s Cajun Seasoning',2,2,'48 - 6 oz jars',22,53,0,0,0)
GO

SET IDENTITY_INSERT "Products" OFF;
GO
