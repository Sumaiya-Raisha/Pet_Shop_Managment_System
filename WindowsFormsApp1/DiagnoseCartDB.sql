-- SQL Script to diagnose column existence in Pet_Shop database
USE Pet_Shop;
GO

PRINT '--- Diagnosing Customers Table ---';
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
BEGIN
    PRINT 'Customers table exists. Checking columns:';
    SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Customers'
    AND COLUMN_NAME IN ('CustomerID', 'UserID', 'FirstName', 'LastName');
END
ELSE
BEGIN
    PRINT 'Customers table DOES NOT exist.';
END
GO

PRINT '--- Diagnosing ShoppingCart Table ---';
IF OBJECT_ID('dbo.ShoppingCart', 'U') IS NOT NULL
BEGIN
    PRINT 'ShoppingCart table exists. Checking columns:';
    SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'ShoppingCart'
    AND COLUMN_NAME IN ('CartID', 'CustomerID', 'ProductID', 'Quantity');
END
ELSE
BEGIN
    PRINT 'ShoppingCart table DOES NOT exist.';
END
GO

PRINT '--- Diagnosing Users Table ---';
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
BEGIN
    PRINT 'Users table exists. Checking columns:';
    SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Users'
    AND COLUMN_NAME IN ('UserID', 'FirstName', 'LastName', 'Email');
END
ELSE
BEGIN
    PRINT 'Users table DOES NOT exist.';
END
GO

PRINT '--- All Tables in Database ---';
SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE' 
ORDER BY TABLE_NAME;
