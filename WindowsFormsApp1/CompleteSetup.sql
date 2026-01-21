-- Complete Setup Script for Pet Shop E-commerce System
-- Run this script to set up all required tables and procedures

USE Pet_Shop;
GO

-- First, let's check if we have a Customers table, if not create it
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
    CREATE TABLE Customers (
        CustomerID INT IDENTITY(1,1) PRIMARY KEY,
        UserID INT NOT NULL, -- Reference to Users table
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255),
        Phone NVARCHAR(20),
        Address NVARCHAR(MAX),
        CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
        
        -- Foreign Key to Users table
        CONSTRAINT FK_Customers_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    
    PRINT 'Customers table created successfully!';
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
        
        -- Constraints
        CONSTRAINT CHK_CartQuantity CHECK (Quantity > 0),
        
        -- Foreign Keys
        CONSTRAINT FK_Cart_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
            ON DELETE CASCADE,
        CONSTRAINT FK_Cart_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
            ON DELETE CASCADE,
        
        -- Unique constraint to prevent duplicate items in cart
        CONSTRAINT UK_Cart_Customer_Product UNIQUE (CustomerID, ProductID)
    );
    
    PRINT 'ShoppingCart table created successfully!';
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
        
        -- Constraints
        CONSTRAINT CHK_OrderTotal CHECK (TotalAmount > 0),
        CONSTRAINT CHK_OrderStatus CHECK (Status IN ('Pending', 'Confirmed', 'Shipped', 'Delivered', 'Cancelled')),
        
        -- Foreign Key
        CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
            ON DELETE CASCADE
    );
    
    PRINT 'Orders table created successfully!';
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
        
        -- Constraints
        CONSTRAINT CHK_OrderItemQuantity CHECK (Quantity > 0),
        CONSTRAINT CHK_OrderItemUnitPrice CHECK (UnitPrice > 0),
        CONSTRAINT CHK_OrderItemTotalPrice CHECK (TotalPrice > 0),
        
        -- Foreign Keys
        CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
            ON DELETE CASCADE,
        CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
            ON DELETE CASCADE
    );
    
    PRINT 'OrderItems table created successfully!';
END
ELSE
BEGIN
    PRINT 'OrderItems table already exists.';
END

-- Drop existing procedures if they exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_AddToCart')
    DROP PROCEDURE sp_AddToCart;
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_AddToCartByUserID')
    DROP PROCEDURE sp_AddToCartByUserID;
GO

-- Create the main AddToCart procedure
CREATE PROCEDURE sp_AddToCart
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if item already exists in cart
        IF EXISTS (SELECT 1 FROM ShoppingCart WHERE CustomerID = @CustomerID AND ProductID = @ProductID)
        BEGIN
            -- Update quantity
            UPDATE ShoppingCart 
            SET Quantity = Quantity + @Quantity,
                AddedDate = GETDATE()
            WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
        END
        ELSE
        BEGIN
            -- Add new item to cart
            INSERT INTO ShoppingCart (CustomerID, ProductID, Quantity)
            VALUES (@CustomerID, @ProductID, @Quantity);
        END
        
        COMMIT TRANSACTION;
        SELECT 'SUCCESS' AS Result, 'Item added to cart successfully' AS Message;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 'ERROR' AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

-- Create alternative procedure that works with UserID directly
CREATE PROCEDURE sp_AddToCartByUserID
    @UserID INT,
    @ProductID INT,
    @Quantity INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Get CustomerID from UserID
        DECLARE @CustomerID INT;
        SELECT @CustomerID = CustomerID FROM Customers WHERE UserID = @UserID;
        
        IF @CustomerID IS NULL
        BEGIN
            -- If customer doesn't exist, create one
            INSERT INTO Customers (UserID, FirstName, LastName, Email)
            SELECT UserID, FirstName, LastName, Email FROM Users WHERE UserID = @UserID;
            
            SET @CustomerID = SCOPE_IDENTITY();
        END
        
        -- Check if item already exists in cart
        IF EXISTS (SELECT 1 FROM ShoppingCart WHERE CustomerID = @CustomerID AND ProductID = @ProductID)
        BEGIN
            -- Update quantity
            UPDATE ShoppingCart 
            SET Quantity = Quantity + @Quantity,
                AddedDate = GETDATE()
            WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
        END
        ELSE
        BEGIN
            -- Add new item to cart
            INSERT INTO ShoppingCart (CustomerID, ProductID, Quantity)
            VALUES (@CustomerID, @ProductID, @Quantity);
        END
        
        COMMIT TRANSACTION;
        SELECT 'SUCCESS' AS Result, 'Item added to cart successfully' AS Message;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 'ERROR' AS Result, ERROR_MESSAGE() AS Message;
    END CATCH
END;
GO

-- Create other required procedures
CREATE PROCEDURE sp_RemoveFromCart
    @CustomerID INT,
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM ShoppingCart 
    WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
    
    SELECT @@ROWCOUNT AS RowsAffected;
END;
GO

CREATE PROCEDURE sp_UpdateCartQuantity
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @Quantity <= 0
    BEGIN
        -- Remove item if quantity is 0 or negative
        DELETE FROM ShoppingCart 
        WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
    END
    ELSE
    BEGIN
        -- Update quantity
        UPDATE ShoppingCart 
        SET Quantity = @Quantity
        WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
    END
    
    SELECT @@ROWCOUNT AS RowsAffected;
END;
GO

CREATE PROCEDURE sp_GetCartTotal
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        COUNT(*) AS ItemCount,
        SUM(
            CASE 
                WHEN p.DiscountPercentage > 0 
                THEN (p.Price - (p.Price * p.DiscountPercentage / 100)) * sc.Quantity
                ELSE p.Price * sc.Quantity
            END
        ) AS TotalAmount
    FROM ShoppingCart sc
    INNER JOIN Products p ON sc.ProductID = p.ProductID
    WHERE sc.CustomerID = @CustomerID AND p.IsActive = 1;
END;
GO

-- Create indexes for better performance
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_ShoppingCart_CustomerID')
    CREATE INDEX IX_ShoppingCart_CustomerID ON ShoppingCart(CustomerID);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_ShoppingCart_ProductID')
    CREATE INDEX IX_ShoppingCart_ProductID ON ShoppingCart(ProductID);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_CustomerID')
    CREATE INDEX IX_Orders_CustomerID ON Orders(CustomerID);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Orders_OrderDate')
    CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate);

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_OrderItems_OrderID')
    CREATE INDEX IX_OrderItems_OrderID ON OrderItems(OrderID);

PRINT 'All tables, procedures, and indexes created successfully!';
PRINT 'The system is now ready to use.';
