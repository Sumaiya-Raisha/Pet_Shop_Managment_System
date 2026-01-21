using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    public class CartItem
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public string Category { get; set; }
        public string VendorName { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ShoppingCartManager
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public List<CartItem> GetCartItems(int userId)
        {
            List<CartItem> cartItems = new List<CartItem>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            sc.CartID,
                            sc.ProductID,
                            p.ProductName,
                            p.Description,
                            p.Price,
                            p.DiscountPercentage,
                            p.Category,
                            v.Username AS VendorName,
                            sc.Quantity,
                            sc.AddedDate,
                            CASE 
                                WHEN p.DiscountPercentage > 0 
                                THEN p.Price - (p.Price * p.DiscountPercentage / 100)
                                ELSE p.Price 
                            END AS DiscountedPrice,
                            CASE 
                                WHEN p.DiscountPercentage > 0 
                                THEN (p.Price - (p.Price * p.DiscountPercentage / 100)) * sc.Quantity
                                ELSE p.Price * sc.Quantity
                            END AS TotalPrice
                        FROM ShoppingCart sc
                        INNER JOIN Products p ON sc.ProductID = p.ProductID
                        INNER JOIN Vendors v ON p.VendorID = v.VendorID
                        WHERE sc.UserID = @UserID AND p.IsActive = 1
                        ORDER BY sc.AddedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cartItems.Add(new CartItem
                                {
                                    CartID = Convert.ToInt32(reader["CartID"]),
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                    Category = reader["Category"].ToString(),
                                    VendorName = reader["VendorName"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    AddedDate = Convert.ToDateTime(reader["AddedDate"]),
                                    DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"]),
                                    TotalPrice = Convert.ToDecimal(reader["TotalPrice"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading cart items: " + ex.Message);
            }

            return cartItems;
        }

        public bool AddToCart(int userId, int productId, int quantity = 1)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Use UserID directly - no need for CustomerID conversion
                    string query = @"
                        -- Check if ShoppingCart table exists, create if not
                        IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShoppingCart')
                        BEGIN
                            CREATE TABLE ShoppingCart (
                                CartID INT IDENTITY(1,1) PRIMARY KEY,
                                UserID INT NOT NULL,
                                ProductID INT NOT NULL,
                                Quantity INT NOT NULL DEFAULT 1,
                                AddedDate DATETIME2 NOT NULL DEFAULT GETDATE()
                            );
                        END
                        
                        -- Add or update item in cart
                        IF EXISTS (SELECT 1 FROM ShoppingCart WHERE UserID = @UserID AND ProductID = @ProductID)
                        BEGIN
                            UPDATE ShoppingCart 
                            SET Quantity = Quantity + @Quantity,
                                AddedDate = GETDATE()
                            WHERE UserID = @UserID AND ProductID = @ProductID;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO ShoppingCart (UserID, ProductID, Quantity)
                            VALUES (@UserID, @ProductID, @Quantity);
                        END
                        
                        SELECT 'SUCCESS' AS Result;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string result = reader["Result"].ToString();
                                return result == "SUCCESS";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding item to cart: " + ex.Message);
            }

            return false;
        }

        public bool RemoveFromCart(int userId, int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ShoppingCart WHERE UserID = @UserID AND ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error removing item from cart: " + ex.Message);
            }
        }

        public bool UpdateCartQuantity(int userId, int productId, int quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ShoppingCart SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@ProductID", productId);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating cart quantity: " + ex.Message);
            }
        }

        public (int itemCount, decimal totalAmount) GetCartTotal(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
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
                        WHERE sc.UserID = @UserID AND p.IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int itemCount = Convert.ToInt32(reader["ItemCount"]);
                                decimal totalAmount = reader["TotalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["TotalAmount"]);
                                return (itemCount, totalAmount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting cart total: " + ex.Message);
            }

            return (0, 0);
        }

        public void ClearCart(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ShoppingCart WHERE UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error clearing cart: " + ex.Message);
            }
        }
    }
}
