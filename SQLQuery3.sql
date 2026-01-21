USE Pet_Shop;
GO

INSERT INTO dbo.Categories (CategoryName)
SELECT CategoryName
FROM Categories.dbo.Categories;
