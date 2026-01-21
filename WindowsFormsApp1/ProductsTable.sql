-- SQL Script to create Products table for Pet Shop Management System
-- Run this script in Microsoft SQL Server Management Studio

USE Pet_Shop;
GO

-- Create Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    VendorID INT NOT NULL,
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    DiscountPercentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
    Category NVARCHAR(100),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    
    -- Constraints
    CONSTRAINT CHK_Price CHECK (Price > 0),
    CONSTRAINT CHK_StockQuantity CHECK (StockQuantity >= 0),
    CONSTRAINT CHK_DiscountPercentage CHECK (DiscountPercentage >= 0 AND DiscountPercentage <= 100),
    
    -- Foreign Key
    CONSTRAINT FK_Products_Vendors FOREIGN KEY (VendorID) REFERENCES Vendors(VendorID)
        ON DELETE CASCADE
);

-- Create indexes for better performance
CREATE INDEX IX_Products_VendorID ON Products(VendorID);
CREATE INDEX IX_Products_Category ON Products(Category);
CREATE INDEX IX_Products_IsActive ON Products(IsActive);
CREATE INDEX IX_Products_ProductName ON Products(ProductName);

-- Insert sample data (optional)
INSERT INTO Products (VendorID, ProductName, Description, Price, StockQuantity, DiscountPercentage, Category, IsActive)
VALUES 
(1, 'Premium Dog Food', 'High-quality dry dog food with chicken and rice', 45.99, 50, 10.00, 'Pet Food', 1),
(1, 'Cat Litter', 'Clumping cat litter, 20lb bag', 25.50, 30, 5.00, 'Cat Supplies', 1),
(1, 'Dog Leash', 'Durable nylon dog leash, 6 feet', 15.99, 25, 0.00, 'Dog Accessories', 1),
(2, 'Fish Tank Filter', 'Aquarium filter for 20-50 gallon tanks', 35.75, 15, 15.00, 'Aquarium Supplies', 1),
(2, 'Bird Cage', 'Large bird cage with accessories', 89.99, 8, 20.00, 'Bird Supplies', 1);

-- Create a view for active products with calculated prices
CREATE VIEW vw_ActiveProducts AS
SELECT 
    p.ProductID,
    p.VendorID,
    v.Username AS VendorName,
    p.ProductName,
    p.Description,
    p.Price,
    p.StockQuantity,
    p.DiscountPercentage,
    p.Category,
    p.CreatedDate,
    p.UpdatedDate,
    -- Calculate discounted price
    CASE 
        WHEN p.DiscountPercentage > 0 
        THEN p.Price - (p.Price * p.DiscountPercentage / 100)
        ELSE p.Price 
    END AS DiscountedPrice
FROM Products p
INNER JOIN Vendors v ON p.VendorID = v.VendorID
WHERE p.IsActive = 1;

-- Create a stored procedure to get products by vendor
CREATE PROCEDURE sp_GetProductsByVendor
    @VendorID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ProductID,
        ProductName,
        Description,
        Price,
        StockQuantity,
        DiscountPercentage,
        Category,
        IsActive,
        CreatedDate,
        UpdatedDate,
        -- Calculate discounted price
        CASE 
            WHEN DiscountPercentage > 0 
            THEN Price - (Price * DiscountPercentage / 100)
            ELSE Price 
        END AS DiscountedPrice
    FROM Products 
    WHERE VendorID = @VendorID
    ORDER BY ProductName;
END;

-- Create a stored procedure to update product stock
CREATE PROCEDURE sp_UpdateProductStock
    @ProductID INT,
    @VendorID INT,
    @NewStockQuantity INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Products 
    SET StockQuantity = @NewStockQuantity,
        UpdatedDate = GETDATE()
    WHERE ProductID = @ProductID AND VendorID = @VendorID;
    
    SELECT @@ROWCOUNT AS RowsAffected;
END;

-- Create a trigger to automatically update UpdatedDate when a product is modified
CREATE TRIGGER tr_Products_UpdateDate
ON Products
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Products 
    SET UpdatedDate = GETDATE()
    WHERE ProductID IN (SELECT ProductID FROM inserted);
END;

PRINT 'Products table and related objects created successfully!';
