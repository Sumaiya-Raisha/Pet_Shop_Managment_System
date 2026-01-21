    -- SQL Script to create Shopping Cart and Orders tables for Pet Shop Management System
    -- Run this script in Microsoft SQL Server Management Studio

    USE Pet_Shop;
    GO

    -- Create ShoppingCart table
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

    -- Create Orders table
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

    -- Create OrderItems table
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

    -- Create indexes for better performance
    CREATE INDEX IX_ShoppingCart_CustomerID ON ShoppingCart(CustomerID);
    CREATE INDEX IX_ShoppingCart_ProductID ON ShoppingCart(ProductID);
    CREATE INDEX IX_Orders_CustomerID ON Orders(CustomerID);
    CREATE INDEX IX_Orders_OrderDate ON Orders(OrderDate);
    CREATE INDEX IX_Orders_Status ON Orders(Status);
    CREATE INDEX IX_OrderItems_OrderID ON OrderItems(OrderID);
    CREATE INDEX IX_OrderItems_ProductID ON OrderItems(ProductID);

    -- Create a view for cart items with product details
    CREATE VIEW vw_CartItems AS
    SELECT 
        sc.CartID,
        sc.CustomerID,
        sc.ProductID,
        p.ProductName,
        p.Description,
        p.Price,
        p.DiscountPercentage,
        p.Category,
        v.Username AS VendorName,
        sc.Quantity,
        sc.AddedDate,
        -- Calculate discounted price
        CASE 
            WHEN p.DiscountPercentage > 0 
            THEN p.Price - (p.Price * p.DiscountPercentage / 100)
            ELSE p.Price 
        END AS DiscountedPrice,
        -- Calculate total price for this cart item
        CASE 
            WHEN p.DiscountPercentage > 0 
            THEN (p.Price - (p.Price * p.DiscountPercentage / 100)) * sc.Quantity
            ELSE p.Price * sc.Quantity
        END AS TotalPrice
    FROM ShoppingCart sc
    INNER JOIN Products p ON sc.ProductID = p.ProductID
    INNER JOIN Vendors v ON p.VendorID = v.VendorID
    WHERE p.IsActive = 1;

    -- Create a view for order details
    CREATE VIEW vw_OrderDetails AS
    SELECT 
        o.OrderID,
        o.CustomerID,
        c.FirstName + ' ' + c.LastName AS CustomerName,
        o.OrderDate,
        o.TotalAmount,
        o.Status,
        o.ShippingAddress,
        o.PaymentMethod,
        o.Notes,
        COUNT(oi.OrderItemID) AS ItemCount
    FROM Orders o
    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
    LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
    GROUP BY o.OrderID, o.CustomerID, c.FirstName, c.LastName, o.OrderDate, 
            o.TotalAmount, o.Status, o.ShippingAddress, o.PaymentMethod, o.Notes;

    -- Create stored procedure to add item to cart
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

    -- Create stored procedure to remove item from cart
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

    -- Create stored procedure to update cart item quantity
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

    -- Create stored procedure to get cart total
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

    -- Create stored procedure to create order from cart
    CREATE PROCEDURE sp_CreateOrderFromCart
        @CustomerID INT,
        @ShippingAddress NVARCHAR(MAX),
        @PaymentMethod NVARCHAR(50),
        @Notes NVARCHAR(MAX) = NULL
    AS
    BEGIN
        SET NOCOUNT ON;
        
        BEGIN TRY
            BEGIN TRANSACTION;
            
            DECLARE @OrderID INT;
            DECLARE @TotalAmount DECIMAL(10,2);
            
            -- Calculate total amount
            SELECT @TotalAmount = SUM(
                CASE 
                    WHEN p.DiscountPercentage > 0 
                    THEN (p.Price - (p.Price * p.DiscountPercentage / 100)) * sc.Quantity
                    ELSE p.Price * sc.Quantity
                END
            )
            FROM ShoppingCart sc
            INNER JOIN Products p ON sc.ProductID = p.ProductID
            WHERE sc.CustomerID = @CustomerID AND p.IsActive = 1;
            
            IF @TotalAmount IS NULL OR @TotalAmount <= 0
            BEGIN
                RAISERROR('Cart is empty or contains invalid items', 16, 1);
                RETURN;
            END
            
            -- Create order
            INSERT INTO Orders (CustomerID, TotalAmount, ShippingAddress, PaymentMethod, Notes)
            VALUES (@CustomerID, @TotalAmount, @ShippingAddress, @PaymentMethod, @Notes);
            
            SET @OrderID = SCOPE_IDENTITY();
            
            -- Create order items from cart
            INSERT INTO OrderItems (OrderID, ProductID, Quantity, UnitPrice, DiscountPercentage, TotalPrice)
            SELECT 
                @OrderID,
                sc.ProductID,
                sc.Quantity,
                p.Price,
                p.DiscountPercentage,
                CASE 
                    WHEN p.DiscountPercentage > 0 
                    THEN (p.Price - (p.Price * p.DiscountPercentage / 100)) * sc.Quantity
                    ELSE p.Price * sc.Quantity
                END
            FROM ShoppingCart sc
            INNER JOIN Products p ON sc.ProductID = p.ProductID
            WHERE sc.CustomerID = @CustomerID AND p.IsActive = 1;
            
            -- Clear cart
            DELETE FROM ShoppingCart WHERE CustomerID = @CustomerID;
            
            COMMIT TRANSACTION;
            SELECT 'SUCCESS' AS Result, @OrderID AS OrderID, @TotalAmount AS TotalAmount;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            SELECT 'ERROR' AS Result, ERROR_MESSAGE() AS Message;
        END CATCH
    END;

    PRINT 'Shopping Cart and Orders tables created successfully!';
