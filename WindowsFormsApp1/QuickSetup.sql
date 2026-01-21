-- Quick Setup Script for Cart System
-- Run this in SQL Server Management Studio

USE Pet_Shop;
GO

-- Create Customers table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
    CREATE TABLE Customers (
        CustomerID INT IDENTITY(1,1) PRIMARY KEY,
        UserID INT NOT NULL,
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255),
        Phone NVARCHAR(20),
        Address NVARCHAR(MAX),
        CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
        
        CONSTRAINT FK_Customers_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Customers table created.';
END
ELSE
BEGIN
    PRINT 'Customers table already exists.';
END

-- Create ShoppingCart table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShoppingCart]') AND type in (N'U'))
BEGIN
    CREATE TABLE ShoppingCart (
        CartID INT IDENTITY(1,1) PRIMARY KEY,
        CustomerID INT NOT NULL,
        ProductID INT NOT NULL,
        Quantity INT NOT NULL DEFAULT 1,
        AddedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
        
        CONSTRAINT CHK_CartQuantity CHECK (Quantity > 0),
        CONSTRAINT FK_Cart_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE,
        CONSTRAINT FK_Cart_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE,
        CONSTRAINT UK_Cart_Customer_Product UNIQUE (CustomerID, ProductID)
    );
    PRINT 'ShoppingCart table created.';
END
ELSE
BEGIN
    PRINT 'ShoppingCart table already exists.';
END

-- Create Orders table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
    CREATE TABLE Orders (
        OrderID INT IDENTITY(1,1) PRIMARY KEY,
        CustomerID INT NOT NULL,
        OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
        TotalAmount DECIMAL(10,2) NOT NULL,
        Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
        ShippingAddress NVARCHAR(MAX),
        PaymentMethod NVARCHAR(50),
        Notes NVARCHAR(MAX),
        
        CONSTRAINT CHK_OrderTotal CHECK (TotalAmount > 0),
        CONSTRAINT CHK_OrderStatus CHECK (Status IN ('Pending', 'Confirmed', 'Shipped', 'Delivered', 'Cancelled')),
        CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE
    );
    PRINT 'Orders table created.';
END
ELSE
BEGIN
    PRINT 'Orders table already exists.';
END

-- Create OrderItems table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItems]') AND type in (N'U'))
BEGIN
    CREATE TABLE OrderItems (
        OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
        OrderID INT NOT NULL,
        ProductID INT NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(10,2) NOT NULL,
        DiscountPercentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
        TotalPrice DECIMAL(10,2) NOT NULL,
        
        CONSTRAINT CHK_OrderItemQuantity CHECK (Quantity > 0),
        CONSTRAINT CHK_OrderItemUnitPrice CHECK (UnitPrice > 0),
        CONSTRAINT CHK_OrderItemTotalPrice CHECK (TotalPrice > 0),
        CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
        CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
    );
    PRINT 'OrderItems table created.';
END
ELSE
BEGIN
    PRINT 'OrderItems table already exists.';
END

-- Create indexes for better performance
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_ShoppingCart_CustomerID')
    CREATE INDEX IX_ShoppingCart_CustomerID ON ShoppingCart(CustomerID);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_ShoppingCart_ProductID')
    CREATE INDEX IX_ShoppingCart_ProductID ON ShoppingCart(ProductID);

PRINT 'Setup completed successfully!';
PRINT 'You can now test the cart functionality.';
