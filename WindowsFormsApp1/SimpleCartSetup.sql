-- Simple Cart Setup - Works with existing database structure
-- Run this in SQL Server Management Studio

USE Pet_Shop;
GO

-- Drop existing ShoppingCart table if it exists (to start fresh)
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShoppingCart]') AND type in (N'U'))
BEGIN
    DROP TABLE ShoppingCart;
    PRINT 'Existing ShoppingCart table dropped.';
END

-- Create a simple ShoppingCart table
CREATE TABLE ShoppingCart (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,  -- This stores the UserID directly
    ProductID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    AddedDate DATETIME2 NOT NULL DEFAULT GETDATE()
);

PRINT 'ShoppingCart table created successfully!';

-- Create indexes for better performance
CREATE INDEX IX_ShoppingCart_UserID ON ShoppingCart(UserID);
CREATE INDEX IX_ShoppingCart_ProductID ON ShoppingCart(ProductID);

PRINT 'Indexes created successfully!';

-- Test the table by inserting a sample record (optional)
-- INSERT INTO ShoppingCart (UserID, ProductID, Quantity) VALUES (1, 1, 1);
-- PRINT 'Sample record inserted for testing.';

PRINT 'Cart system setup completed!';
PRINT 'The system now uses UserID directly in the cart.';
