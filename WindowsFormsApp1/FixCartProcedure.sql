-- Fix for the sp_AddToCart procedure parameter mismatch
-- Run this script to fix the stored procedure

USE Pet_Shop;
GO

-- Drop the existing procedure if it exists
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_AddToCart')
    DROP PROCEDURE sp_AddToCart;
GO

-- Create the corrected procedure
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

-- Also create an alternative procedure with @UserID parameter in case that's what's expected
CREATE PROCEDURE sp_AddToCartByUserID
    @UserID INT,
    @ProductID INT,
    @Quantity INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Check if item already exists in cart
        IF EXISTS (SELECT 1 FROM ShoppingCart WHERE CustomerID = @UserID AND ProductID = @ProductID)
        BEGIN
            -- Update quantity
            UPDATE ShoppingCart 
            SET Quantity = Quantity + @Quantity,
                AddedDate = GETDATE()
            WHERE CustomerID = @UserID AND ProductID = @ProductID;
        END
        ELSE
        BEGIN
            -- Add new item to cart
            INSERT INTO ShoppingCart (CustomerID, ProductID, Quantity)
            VALUES (@UserID, @ProductID, @Quantity);
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

PRINT 'Cart procedures fixed successfully!';
