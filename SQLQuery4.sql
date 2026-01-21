BEGIN TRAN;

DELETE FROM dbo.Categories
WHERE CategoryID = 40;

-- Check how many rows were deleted
SELECT @@ROWCOUNT AS DeletedRows;

COMMIT TRAN;
