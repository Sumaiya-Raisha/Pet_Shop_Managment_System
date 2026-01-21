using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class OrderDetailsForm : Form
    {
        private int _orderId;
        private int _userId;
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public OrderDetailsForm()
            : this(0, 0)
        {
        }

        public OrderDetailsForm(int orderId, int userId)
        {
            InitializeComponent();
            _orderId = orderId;
            _userId = userId;
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            try
            {
                // Load order information
                LoadOrderInfo();
                
                // Load order items
                LoadOrderItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Check if Orders table exists
                    string checkTableQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = 'Orders'";
                    
                    using (SqlCommand checkCmd = new SqlCommand(checkTableQuery, conn))
                    {
                        int tableExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (tableExists == 0)
                        {
                            MessageBox.Show("No orders found. The Orders table doesn't exist yet.", "No Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    
                    string query = @"
                        SELECT 
                            OrderID,
                            OrderDate,
                            TotalAmount,
                            Status,
                            ShippingAddress,
                            PaymentMethod,
                            Notes
                        FROM Orders 
                        WHERE OrderID = @OrderID AND UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", _orderId);
                        cmd.Parameters.AddWithValue("@UserID", _userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblOrderId.Text = $"Order ID: #{reader["OrderID"]}";
                                lblOrderDate.Text = $"Order Date: {Convert.ToDateTime(reader["OrderDate"]):MMM dd, yyyy HH:mm}";
                                lblTotalAmount.Text = $"Total Amount: ${Convert.ToDecimal(reader["TotalAmount"]):F2}";
                                lblStatus.Text = $"Status: {reader["Status"]}";
                                lblShippingAddress.Text = $"Shipping Address: {reader["ShippingAddress"]}";
                                lblPaymentMethod.Text = $"Payment Method: {reader["PaymentMethod"]}";
                                
                                string notes = reader["Notes"].ToString();
                                if (!string.IsNullOrEmpty(notes))
                                {
                                    lblNotes.Text = $"Notes: {notes}";
                                    lblNotes.Visible = true;
                                }
                                else
                                {
                                    lblNotes.Visible = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Order not found or you don't have permission to view this order.", "Order Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading order information: " + ex.Message);
            }
        }

        private void LoadOrderItems()
        {
            try
            {
                List<OrderItemDetail> orderItems = GetOrderItems(_orderId);
                
                // Bind to DataGridView
                dgvOrderItems.DataSource = orderItems;
                dgvOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvOrderItems.RowHeadersVisible = false;
                dgvOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOrderItems.ReadOnly = true;
                dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
                dgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
                dgvOrderItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
                dgvOrderItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
                dgvOrderItems.ColumnHeadersHeight = 40;
                dgvOrderItems.EnableHeadersVisualStyles = false;
                dgvOrderItems.GridColor = System.Drawing.Color.FromArgb(222, 226, 230);
                dgvOrderItems.RowTemplate.Height = 35;
                dgvOrderItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(40, 167, 69);
                dgvOrderItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                dgvOrderItems.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading order items: " + ex.Message);
            }
        }

        private List<OrderItemDetail> GetOrderItems(int orderId)
        {
            List<OrderItemDetail> orderItems = new List<OrderItemDetail>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Check if OrderItems table exists
                    string checkTableQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = 'OrderItems'";
                    
                    using (SqlCommand checkCmd = new SqlCommand(checkTableQuery, conn))
                    {
                        int tableExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (tableExists == 0)
                        {
                            // Return empty list if table doesn't exist
                            return orderItems;
                        }
                    }
                    
                    string query = @"
                        SELECT 
                            p.ProductName,
                            p.Description,
                            oi.Quantity,
                            oi.UnitPrice,
                            oi.DiscountPercentage,
                            oi.TotalPrice,
                            v.VendorName
                        FROM OrderItems oi
                        INNER JOIN Products p ON oi.ProductID = p.ProductID
                        LEFT JOIN Vendors v ON p.VendorID = v.VendorID
                        WHERE oi.OrderID = @OrderID
                        ORDER BY p.ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orderItems.Add(new OrderItemDetail
                                {
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                    DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                    TotalPrice = Convert.ToDecimal(reader["TotalPrice"]),
                                    VendorName = reader["VendorName"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order items: " + ex.Message);
            }

            return orderItems;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print functionality would be implemented here.", "Print Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class OrderItemDetail
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }
        public string VendorName { get; set; }
    }
}
