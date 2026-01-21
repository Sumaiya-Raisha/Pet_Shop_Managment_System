UPDATE p
SET p.CategoryID = c.CategoryID
FROM dbo.Products p
JOIN dbo.Categories c
    ON p.Category = c.CategoryName
WHERE p.CategoryID IS NULL;









