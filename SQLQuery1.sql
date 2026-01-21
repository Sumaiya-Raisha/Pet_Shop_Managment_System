-- 1. Insert a new product with a new Category
INSERT INTO dbo.Products (VendorID, ProductName, Description, Price, StockQuantity, DiscountPercentage, Category, IsActive, CreatedDate)
VALUES (1, 'Premium Rabbit Food', 'Healthy rabbit pellets', 500, 20, 5, 'Pet Food', 1, GETDATE());

-- 2. Check if "Pet Food" was auto-added into Categories
SELECT * FROM dbo.Categories WHERE CategoryName = 'Pet Food';
