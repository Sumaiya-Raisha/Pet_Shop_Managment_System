using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OrderHistoryForm : Form
    {
        private int _userId;
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public OrderHistoryForm() : this(0) { }

        public OrderHistoryForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            try
            {
                List<OrderHistoryItem> orders = GetOrderHistory(_userId);

                // Bind to DataGridView
                dgvOrders.DataSource = null; // Clear first
                dgvOrders.DataSource = orders;
                dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvOrders.RowHeadersVisible = false;
                dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOrders.MultiSelect = false;
                dgvOrders.ReadOnly = true;

                // Update order count
                lblOrderCount.Text = $"Total Orders: {orders.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvOrders.DataSource = new List<OrderHistoryItem>();
                lblOrderCount.Text = "Total Orders: 0";
            }
        }

        private List<OrderHistoryItem> GetOrderHistory(int userId)
        {
            List<OrderHistoryItem> orders = new List<OrderHistoryItem>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Make sure Orders table exists
                    string checkTableQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = 'Orders'";

                    using (SqlCommand checkCmd = new SqlCommand(checkTableQuery, conn))
                    {
                        int tableExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (tableExists == 0)
                        {
                            CreateOrdersTable(conn);
                        }
                    }

                    // Make sure OrderItems table exists
                    string checkOrderItemsQuery = @"
                        SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = 'OrderItems'";

                    using (SqlCommand checkCmd = new SqlCommand(checkOrderItemsQuery, conn))
                    {
                        int tableExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (tableExists == 0)
                        {
                            CreateOrderItemsTable(conn);
                        }
                    }

                    string query = @"
                        SELECT 
                            o.OrderID,
                            o.OrderDate,
                            o.TotalAmount,
                            o.Status,
                            o.ShippingAddress,
                            o.PaymentMethod,
                            o.Notes,
                            COUNT(oi.OrderItemID) as ItemCount
                        FROM Orders o
                        LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                        WHERE o.UserID = @UserID
                        GROUP BY o.OrderID, o.OrderDate, o.TotalAmount, o.Status, o.ShippingAddress, o.PaymentMethod, o.Notes
                        ORDER BY o.OrderDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                orders.Add(new OrderHistoryItem
                                {
                                    OrderID = Convert.ToInt32(reader["OrderID"]),
                                    OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                                    TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                    Status = reader["Status"].ToString(),
                                    ShippingAddress = reader["ShippingAddress"].ToString(),
                                    PaymentMethod = reader["PaymentMethod"].ToString(),
                                    Notes = reader["Notes"].ToString(),
                                    ItemCount = Convert.ToInt32(reader["ItemCount"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order history: " + ex.Message);
            }

            return orders;
        }

        private void CreateOrdersTable(SqlConnection conn)
        {
            string createOrdersQuery = @"
                CREATE TABLE Orders (
                    OrderID INT IDENTITY(1,1) PRIMARY KEY,
                    UserID INT NOT NULL,
                    OrderDate DATETIME2 NOT NULL DEFAULT GETDATE(),
                    TotalAmount DECIMAL(10,2) NOT NULL,
                    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
                    ShippingAddress NVARCHAR(MAX),
                    PaymentMethod NVARCHAR(50),
                    Notes NVARCHAR(MAX)
                )";

            using (SqlCommand cmd = new SqlCommand(createOrdersQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void CreateOrderItemsTable(SqlConnection conn)
        {
            string createOrderItemsQuery = @"
                CREATE TABLE OrderItems (
                    OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
                    OrderID INT NOT NULL,
                    ProductID INT NOT NULL,
                    Quantity INT NOT NULL,
                    UnitPrice DECIMAL(10,2) NOT NULL,
                    DiscountPercentage DECIMAL(5,2) NOT NULL DEFAULT 0.00,
                    TotalPrice DECIMAL(10,2) NOT NULL
                )";

            using (SqlCommand cmd = new SqlCommand(createOrderItemsQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                var selectedRow = dgvOrders.SelectedRows[0];
                var order = selectedRow.DataBoundItem as OrderHistoryItem;

                if (order != null)
                {
                    OrderDetailsForm detailsForm = new OrderDetailsForm(order.OrderID, _userId);
                    detailsForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select an order to view details.", "No Order Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewDetails_Click(sender, e);
            }
        }
    }

    // Put this class OUTSIDE the form but inside the namespace
    public class OrderHistoryItem
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }
        public int ItemCount { get; set; }
    }
}
