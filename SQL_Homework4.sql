-- Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. 
-- When inserting, make up info if necessary. Write query for each step.
-- Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.

-- 1.      Create a view named “view_product_order_[your_last_name]”, 
--         list all products and total ordered quantity for that product.
GO
CREATE VIEW view_product_order_Chang
AS 
SELECT  
    p.ProductName, SUM(od.Quantity) [total ordered quantity]
FROM dbo.Products AS p 
LEFT JOIN dbo.[Order Details] AS od 
ON (p.ProductID = od.ProductID)
GROUP BY p.ProductName
GO
SELECT * FROM view_product_order_Chang

-- 2.      Create a stored procedure “sp_product_order_quantity_[your_last_name]” 
--         that accept product id as an input and total quantities of order as output parameter.
GO
CREATE PROC sp_product_order_quantity_Chang(
    @product_id INT,
    @total_quantities INT OUT
)
AS 
BEGIN
    SELECT  
        @total_quantities = SUM(od.Quantity)
    FROM dbo.Products AS p 
    LEFT JOIN dbo.[Order Details] AS od 
    ON (p.ProductID = od.ProductID)
    WHERE p.ProductID = @product_id
    GROUP BY p.ProductID
END
GO

GO
DECLARE @total_quant INT
EXECUTE sp_product_order_quantity_Chang 55, @total_quant OUTPUT
PRINT @total_quant
GO
-- 3.      Create a stored procedure “sp_product_order_city_[your_last_name]”
--         that accept product name as an input and top 5 cities that ordered most that product combined with the total quantity of that product ordered from that city as output.

GO 
CREATE PROC sp_product_order_city_Chang (
    @product_name varchar(30)
)
AS 
BEGIN
     
    SELECT
        TOP 5 c.City,
        SUM(Quantity) AS quantity
    FROM dbo.Products AS p
    LEFT JOIN dbo.[Order Details] AS od
    ON (p.ProductID=od.ProductID)
    JOIN dbo.Orders AS o 
    ON(od.OrderID=o.OrderID)
    JOIN dbo.Customers AS c 
    ON(c.CustomerID=o.CustomerID)
    WHERE p.ProductName = @product_name
    GROUP BY c.City
    ORDER BY 2 DESC
    RETURN
END
GO


EXECUTE  sp_product_order_city_Chang 'Chai'


-- 4.      Create 2 new tables “people_your_last_name” “city_your_last_name”. 
--         City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
--         People has three records: {id:1, Name: Aaron Rodgers, City: 2}, 
--                                   {id:2, Name: Russell Wilson, City:1}, 
--                                   {Id: 3, Name: Jody Nelson, City:2}.
--         Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
--         Create a view “Packers_your_name” lists all people from Green Bay. 
--         If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.

CREATE TABLE CITY_CHANG (
    Id INT PRIMARY KEY,
    City VARCHAR(50) 
)
INSERT INTO CITY_CHANG
VALUES
(1, 'Seattle'),
(2, 'Green Bay')

CREATE TABLE PEOPLE_CHANG (
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    City_Id INT FOREIGN KEY REFERENCES CITY_CHANG(Id)
)
INSERT INTO PEOPLE_CHANG
VALUES
(1, 'Aaron Rodgers', 2),
(2, 'Russell Wilson', 1),
(3, 'Jody Nelson', 2)

BEGIN TRANSACTION

INSERT INTO CITY_CHANG
VALUES
(3, 'Madison')

UPDATE PEOPLE_CHANG
SET City_Id = 3 WHERE City_Id = 1

DELETE FROM CITY_CHANG WHERE Id = 1

COMMIT

GO
CREATE VIEW Packers_ShunAn_Chang
AS 
SELECT p.Name
FROM dbo.PEOPLE_CHANG AS p
JOIN dbo.CITY_CHANG AS c
ON (p.City_Id=c.Id)
WHERE c.City='Green Bay'
GO

SELECT * FROM Packers_ShunAn_Chang


DROP TABLE PEOPLE_CHANG
DROP TABLE CITY_CHANG
DROP VIEW Packers_ShunAn_Chang

-- 5.      Create a stored procedure “sp_birthday_employees_[you_last_name]” 
--         that creates a new table “birthday_employees_your_last_name” and fill it with all employees that have a birthday on Feb.
--         (Make a screen shot) drop the table. Employee table should not be affected.


GO
CREATE PROC sp_birthday_employees_chang
AS 
BEGIN
    CREATE TABLE birthday_employees_your_chang(
        Name varchar(50)
    )
    INSERT INTO birthday_employees_your_chang 
    SELECT 
        FirstName+' '+LastName 
    FROM dbo.Employees
    WHERE MONTH(BirthDate) = 2
END
GO
GO
EXEC sp_birthday_employees_chang
GO
GO
SELECT * FROM dbo.birthday_employees_your_chang
GO

 
-- 6.      How do you make sure two tables have the same data?

-- First, Make sure the two tables have the same structure, for example, same columns and data types
-- Second, Use the SELECT statement with the EXCEPT operator to compare the rows in both tables.
-- The EXCEPT operator returns all rows from the first table that are not in the second table.







