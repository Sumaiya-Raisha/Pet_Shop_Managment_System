using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class CheckoutForm : Form
    {
        private int _customerId;
        private List<CartItem> _cartItems;
        private decimal _totalAmount;
        private ShoppingCartManager _cartManager;

        public CheckoutForm()
            : this(0, new List<CartItem>(), 0m)
        {
        }

        public CheckoutForm(int customerId, List<CartItem> cartItems, decimal totalAmount)
        {
            InitializeComponent();
            _customerId = customerId;
            _cartItems = cartItems;
            _totalAmount = totalAmount;
            _cartManager = new ShoppingCartManager();
            
            LoadCheckoutData();
        }

        private void LoadCheckoutData()
        {
            try
            {
                // Ensure cart items is not null
                if (_cartItems == null)
                {
                    _cartItems = new List<CartItem>();
                }

                // Load cart items with null check
                dgvCartItems.DataSource = null; // Clear first to prevent binding errors
                dgvCartItems.DataSource = _cartItems;
                dgvCartItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCartItems.RowHeadersVisible = false;
                dgvCartItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCartItems.MultiSelect = false;

                // Set total amount
                lblTotalAmount.Text = $"Total: ${_totalAmount:F2}";

                // Load payment methods
                cmbPaymentMethod.Items.Clear();
                cmbPaymentMethod.Items.AddRange(new string[] { "Credit Card", "Debit Card", "PayPal", "Cash on Delivery" });
                if (cmbPaymentMethod.Items.Count > 0)
                {
                    cmbPaymentMethod.SelectedIndex = 0;
                }

                // Set default shipping address (you can load from customer profile)
                txtShippingAddress.Text = "Enter your shipping address here...";
                
                // Enable/disable quantity buttons based on selection
                UpdateQuantityButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading checkout data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True"))
                    {
                        conn.Open();
                        
                        // Use direct SQL instead of stored procedure for better compatibility
                        string query = @"
                            BEGIN TRY
                                BEGIN TRANSACTION;
                                
                                -- Create Orders table if it doesn't exist
                                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Orders')
                                BEGIN
                                    CREATE TABLE Orders (
                                        OrderID INT IDENTITY(1,1) PRIMARY KEY,
                                        UserID INT NOT NULL,
                                        OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
                                        TotalAmount DECIMAL(10,2) NOT NULL,
                                        Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
                                        ShippingAddress NVARCHAR(MAX),
                                        PaymentMethod NVARCHAR(50),
                                        Notes NVARCHAR(MAX)
                                    );
                                END
                                
                                -- Create OrderItems table if it doesn't exist
                                IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'OrderItems')
                                BEGIN
                                    CREATE TABLE OrderItems (
                                        OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
                                        OrderID INT NOT NULL,
                                        ProductID INT NOT NULL,
                                        Quantity INT NOT NULL,
                                        UnitPrice DECIMAL(10,2) NOT NULL,
                                        DiscountPercentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
                                        TotalPrice DECIMAL(10,2) NOT NULL
                                    );
                                END
                                
                                -- Create order
                                INSERT INTO Orders (UserID, TotalAmount, ShippingAddress, PaymentMethod, Notes)
                                VALUES (@UserID, @TotalAmount, @ShippingAddress, @PaymentMethod, @Notes);
                                
                                DECLARE @OrderID INT = SCOPE_IDENTITY();
                                
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
                                WHERE sc.UserID = @UserID AND p.IsActive = 1;
                                
                                -- Clear cart
                                DELETE FROM ShoppingCart WHERE UserID = @UserID;
                                
                                COMMIT TRANSACTION;
                                SELECT 'SUCCESS' AS Result, @OrderID AS OrderID, @TotalAmount AS TotalAmount;
                            END TRY
                            BEGIN CATCH
                                ROLLBACK TRANSACTION;
                                SELECT 'ERROR' AS Result, ERROR_MESSAGE() AS ErrorMessage;
                            END CATCH";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserID", _customerId);
                            cmd.Parameters.AddWithValue("@TotalAmount", _totalAmount);
                            cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string result = reader["Result"].ToString();
                                    if (result == "SUCCESS")
                                    {
                                        int orderId = Convert.ToInt32(reader["OrderID"]);
                                        decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                                        
                                        MessageBox.Show($"Order placed successfully!\nOrder ID: {orderId}\nTotal Amount: ${totalAmount:F2}", 
                                            "Order Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        string errorMessage = reader["ErrorMessage"].ToString();
                                        MessageBox.Show($"Error placing order: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error placing order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtShippingAddress.Text) || txtShippingAddress.Text == "Enter your shipping address here...")
            {
                MessageBox.Show("Please enter a valid shipping address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtShippingAddress.Focus();
                return false;
            }

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMethod.Focus();
                return false;
            }

            if (_cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtShippingAddress_Enter(object sender, EventArgs e)
        {
            if (txtShippingAddress.Text == "Enter your shipping address here...")
            {
                txtShippingAddress.Text = "";
                txtShippingAddress.ForeColor = Color.Black;
            }
        }

        private void txtShippingAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtShippingAddress.Text))
            {
                txtShippingAddress.Text = "Enter your shipping address here...";
                txtShippingAddress.ForeColor = Color.Gray;
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to clear your cart?\n\nThis action cannot be undone.",
                "Clear Cart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    _cartManager.ClearCart(_customerId);
                    _cartItems.Clear();
                    _totalAmount = 0;
                    
                    // Refresh the display
                    LoadCheckoutData();
                    
                    MessageBox.Show("Cart cleared successfully!", "Cart Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error clearing cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                var cartItem = selectedRow.DataBoundItem as CartItem;
                
                if (cartItem != null)
                {
                    try
                    {
                        bool success = _cartManager.UpdateCartQuantity(_customerId, cartItem.ProductID, cartItem.Quantity + 1);
                        if (success)
                        {
                            RefreshCartData();
                            // Show success feedback
                            MessageBox.Show($"✅ {cartItem.ProductName} quantity increased to {cartItem.Quantity + 1}", 
                                "Quantity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"❌ Failed to update quantity for {cartItem.ProductName}", 
                                "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to modify its quantity.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCartItems.SelectedRows[0];
                var cartItem = selectedRow.DataBoundItem as CartItem;
                
                if (cartItem != null)
                {
                    try
                    {
                        if (cartItem.Quantity > 1)
                        {
                            bool success = _cartManager.UpdateCartQuantity(_customerId, cartItem.ProductID, cartItem.Quantity - 1);
                            if (success)
                            {
                                RefreshCartData();
                                // Show success feedback
                                MessageBox.Show($"✅ {cartItem.ProductName} quantity decreased to {cartItem.Quantity - 1}", 
                                    "Quantity Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"❌ Failed to update quantity for {cartItem.ProductName}", 
                                    "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            var result = MessageBox.Show(
                                $"Remove {cartItem.ProductName} from cart?",
                                "Remove Item",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );
                            
                            if (result == DialogResult.Yes)
                            {
                                bool success = _cartManager.RemoveFromCart(_customerId, cartItem.ProductID);
                                if (success)
                                {
                                    RefreshCartData();
                                    MessageBox.Show($"✅ {cartItem.ProductName} removed from cart", 
                                        "Item Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"❌ Failed to remove {cartItem.ProductName} from cart", 
                                        "Remove Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating quantity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to modify its quantity.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshCartData()
        {
            try
            {
                _cartItems = _cartManager.GetCartItems(_customerId);
                _totalAmount = _cartManager.GetCartTotal(_customerId).totalAmount;
                LoadCheckoutData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing cart data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQuantityButtonStates()
        {
            bool hasSelection = dgvCartItems.SelectedRows.Count > 0;
            btnIncreaseQuantity.Enabled = hasSelection;
            btnDecreaseQuantity.Enabled = hasSelection;
        }

        private void dgvCartItems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateQuantityButtonStates();
        }

        private void dgvCartItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle DataGridView binding errors gracefully
            e.ThrowException = false;
            
            // Log the error for debugging
            System.Diagnostics.Debug.WriteLine($"DataGridView Error: {e.Exception.Message}");
            
            // Show user-friendly message
            MessageBox.Show("There was an issue displaying cart data. Please try refreshing the cart.", 
                "Display Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
