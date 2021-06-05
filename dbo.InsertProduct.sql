CREATE PROCEDURE [dbo].[InsertProduct]
	@ProductCategoryID int,
	@ProductModelID int,
	@Name NVarChar(50),
	@ProductNumber NVarChar(25),
	@StandardCost money,
	@ListPrice money,
	@SellStartDate datetime,
	@ModifiedDate datetime

AS
	PRINT @Name; 
	INSERT INTO SalesLT.Product
	(ProductCategoryID, ProductModelID,Name,ProductNumber,StandardCost,ListPrice,SellStartDate,Rowguid,ModifiedDate)
	VALUES
	(@ProductCategoryID,@ProductModelID,@Name,@ProductNumber,@StandardCost,
	@ListPrice,
	@SellStartDate,
	NEWID() ,
	@ModifiedDate);