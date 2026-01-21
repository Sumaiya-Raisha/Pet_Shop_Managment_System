USE Pet_Shop;
GO

-- Insert only categories that don't already exist
INSERT INTO dbo.Categories (CategoryName)
SELECT DISTINCT c.[Name]
FROM Categories.dbo.Categories c
LEFT JOIN dbo.Categories p
    ON p.CategoryName = c.[Name]
WHERE p.CategoryName IS NULL;
