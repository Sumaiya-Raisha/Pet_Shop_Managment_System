-- Check by ID (replace <catId> with the number from step 1)
SELECT COUNT(*) AS ProductCountByID
FROM dbo.Products
WHERE CategoryID = 1;

-- Also check by text name (replace TheMissingCategoryName)
SELECT COUNT(*) AS ProductCountByText
FROM dbo.Products
WHERE LTRIM(RTRIM(Category)) = 'Pet';



