-- Replace 1 with the actual VendorID you want to assign
UPDATE Categories
SET VendorID = 1
WHERE VendorID IS NULL;
