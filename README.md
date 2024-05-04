# Download the branch
  RSMCHALLANGE
  
## Views SQL
```sql
USE [AdventureWorks2022]
CREATE VIEW [dbo].[vSalesReport] AS 

WITH SalesOrderDetails AS (
    SELECT 
        so.SalesOrderID AS OrderID,
        so.OrderDate,
        so.CustomerID,
        sod.ProductID,
        p.Name AS ProductName,
        pc.Name AS ProductCategory,
        sod.UnitPrice,
        sod.OrderQty AS Quantity,
        (sod.UnitPrice * sod.OrderQty) AS TotalPrice,
        so.SalesPersonID,
        CONCAT(pp.FirstName, ' ', pp.LastName) AS SalesPersonName,
        ship.AddressLine1 AS ShippingAddress,
        bill.AddressLine1 AS BillingAddress
    FROM 
        Sales.SalesOrderHeader so
    INNER JOIN 
        Sales.SalesOrderDetail sod ON so.SalesOrderID = sod.SalesOrderID
    INNER JOIN 
        Production.Product p ON sod.ProductID = p.ProductID
    INNER JOIN 
        Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
    INNER JOIN 
        Production.ProductCategory pc ON psc.ProductCategoryID = pc.ProductCategoryID
    INNER JOIN 
        Person.Address ship ON so.ShipToAddressID = ship.AddressID
    INNER JOIN 
        Person.Address bill ON so.BillToAddressID = bill.AddressID
    INNER JOIN 
        Person.Person pp ON so.SalesPersonID = pp.BusinessEntityID
    WHERE 
        pp.PersonType = 'SP'
)

SELECT 
    TOP(10) 
    OrderID, 
    OrderDate, 
    CustomerID, 
    ProductID, 
    ProductName, 
    ProductCategory, 
    UnitPrice, 
    Quantity, 
    TotalPrice, 
    SalesPersonID, 
    SalesPersonName, 
    ShippingAddress, 
    BillingAddress 
FROM 
    SalesOrderDetails;
GO



```


```sql
USE [AdventureWorks2022]

CREATE VIEW [dbo].[vTotalofSalesByRegion] AS 
WITH SalesbyRegionCategory AS (
    SELECT
        p.Name AS Product,
        pc.Name AS Category,
        st.Name AS Region,
        DATEPART(QUARTER, soh.OrderDate) AS TheTrimester,
        SUM(sod.LineTotal) AS SalesbyProduct,
        SUM(SUM(sod.LineTotal)) OVER (PARTITION BY st.Name, pc.Name, DATEPART(QUARTER, soh.OrderDate)) AS SalesbyQuarter
    FROM
        Sales.SalesOrderDetail AS sod
    INNER JOIN
        Sales.SalesOrderHeader AS soh ON sod.SalesOrderID = soh.SalesOrderID
    INNER JOIN
        Production.Product AS p ON sod.ProductID = p.ProductID
    INNER JOIN
        Production.ProductSubcategory AS psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
    INNER JOIN
        Production.ProductCategory AS pc ON psc.ProductCategoryID = pc.ProductCategoryID
    INNER JOIN
        Sales.SalesTerritory AS st ON soh.TerritoryID = st.TerritoryID
    GROUP BY
        st.Name, pc.Name, p.Name, DATEPART(QUARTER, soh.OrderDate)
),
ContributionbyProduct AS (
    SELECT
        Region,
        Category,
        Product,
        TheTrimester,
        SalesbyProduct,
        SalesbyQuarter,
        (SalesbyProduct / NULLIF(SalesbyQuarter, 0)) * 100.0 AS ContribucionPorcentual,
        LAG(SalesbyProduct) OVER (PARTITION BY Region, Category, Product ORDER BY TheTrimester) AS SalesbyProductTheTrimesterAnterior,
        CAST(SalesbyProduct * 100.0 / SUM(SalesbyProduct) OVER(PARTITION BY Region) AS DECIMAL(10, 2)) AS PercentageOfTotalSalesInRegion,
        CAST(SalesbyProduct * 100.0 / SUM(SalesbyProduct) OVER(PARTITION BY Category, Region) AS DECIMAL(10, 2)) AS PercentajeOfTotalCategorySalesInRegion
    FROM
        SalesbyRegionCategory
)
SELECT
    Product,
    Category,
    SalesbyProduct AS TotalSales,
    PercentageOfTotalSalesInRegion,
    PercentajeOfTotalCategorySalesInRegion
FROM
    ContributionbyProduct;
GO



```
