using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorOrdersControl : UserControl
    {
        private readonly string _vendorUsername;
        private int _vendorId;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public VendorOrdersControl()
            : this(string.Empty)
        {
        }

        public VendorOrdersControl(string vendorUsername)
        {
            InitializeComponent();
            _vendorUsername = vendorUsername ?? string.Empty;
            LoadVendorId();
            LoadOrders();
        }

        public VendorOrdersControl(int vendorId, string vendorUsername)
        {
            InitializeComponent();
            _vendorUsername = vendorUsername ?? string.Empty;
            _vendorId = vendorId;
            LoadOrders();
        }

        private void LoadVendorId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT VendorID FROM Vendors WHERE Username=@Username", conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", _vendorUsername);
                        var result = cmd.ExecuteScalar();
                        _vendorId = result == null ? 0 : Convert.ToInt32(result);
                    }
                }
            }
            catch { _vendorId = 0; }

            if (_vendorId == 0)
            {
                MessageBox.Show("Vendor not found for username: " + _vendorUsername, "Vendor Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
						SELECT DISTINCT
							o.OrderID,
							o.OrderDate,
							o.TotalAmount,
							o.Status,
							u.Username AS CustomerUsername,
							(
								SELECT COUNT(*) 
								FROM OrderItems oi2 
								WHERE oi2.OrderID = o.OrderID
							) AS ItemCount
						FROM Orders o
						LEFT JOIN Users u ON o.UserID = u.UserID
						ORDER BY o.OrderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // No vendor filter; all vendors can see all orders
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvOrders.DataSource = dt;
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No orders found for this vendor.", "No Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? GetSelectedOrderId()
        {
            if (dgvOrders.SelectedRows.Count == 0) return null;
            return Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
        }

        private void LoadOrderItems(int orderId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
						SELECT 
							oi.OrderItemID,
							p.ProductName,
							oi.Quantity,
							oi.UnitPrice,
							oi.DiscountPercentage,
							oi.TotalPrice
						FROM OrderItems oi
						INNER JOIN Products p ON oi.ProductID = p.ProductID
						WHERE oi.OrderID = @OrderID AND p.VendorID = @VendorID
						ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.Parameters.AddWithValue("@VendorID", _vendorId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvItems.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            var orderId = GetSelectedOrderId();
            if (orderId.HasValue)
            {
                LoadOrderItems(orderId.Value);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var orderId = GetSelectedOrderId();
            if (!orderId.HasValue) { MessageBox.Show("Select an order first."); return; }
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string update = @"UPDATE Orders SET Status = 'Confirmed' WHERE OrderID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadOrders();
                MessageBox.Show("Order confirmed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var orderId = GetSelectedOrderId();
            if (!orderId.HasValue) { MessageBox.Show("Select an order first."); return; }
            var confirm = MessageBox.Show("Reject this order? This will mark the order as Rejected.", "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string reject = @"UPDATE Orders SET Status = 'Cancelled' WHERE OrderID = @OrderID";
                    using (SqlCommand cmd = new SqlCommand(reject, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadOrders();
                MessageBox.Show("Order rejected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            var orderId = GetSelectedOrderId();
            if (!orderId.HasValue) { MessageBox.Show("Select an order first."); return; }
            using (var receipt = new OrderReceiptForm(orderId.Value, _vendorUsername))
            {
                receipt.ShowDialog(FindForm());
            }
        }
    }
}

