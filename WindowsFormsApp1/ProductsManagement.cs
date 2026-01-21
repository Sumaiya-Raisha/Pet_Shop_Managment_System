using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProductsManagement : UserControl
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
        private string vendorUsername;
        private int vendorId;
        private bool showAllProducts = true;

        public ProductsManagement(string username)
        {
            InitializeComponent();
            vendorUsername = username;
            LoadVendorId();
            LoadProducts();
        }

        public ProductsManagement(int vendorId, string username)
        {
            InitializeComponent();
            this.vendorId = vendorId;
            this.vendorUsername = username;
            showAllProducts = false;
            LoadProducts();
        }

        private void LoadVendorId()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT VendorID FROM Vendors WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", vendorUsername);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            vendorId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading vendor ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    if (showAllProducts)
                    {
                        query = @"SELECT ProductID, ProductName, Description, Price, StockQuantity,
                                    DiscountPercentage, Category, IsActive, VendorID
                                    FROM Products";
                    }
                    else
                    {
                        query = @"SELECT ProductID, ProductName, Description, Price, StockQuantity,
                                    DiscountPercentage, Category, IsActive, VendorID
                                    FROM Products WHERE VendorID = @VendorID";
                    }
                    
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!showAllProducts)
                        {
                            cmd.Parameters.AddWithValue("@VendorID", vendorId);
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            showAllProducts = chkShowAll.Checked;
            LoadProducts();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm(vendorId, null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
                int ownerId = dataGridView1.SelectedRows[0].Cells["VendorID"].Value == DBNull.Value ? 0 : Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["VendorID"].Value);
                if (ownerId != vendorId)
                {
                    MessageBox.Show("You can only update your own products.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ProductForm form = new ProductForm(vendorId, productId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ProductID"].Value);
                string productName = dataGridView1.SelectedRows[0].Cells["ProductName"].Value.ToString();
                
                DialogResult result = MessageBox.Show($"Are you sure you want to delete '{productName}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM Products WHERE ProductID = @ProductID AND VendorID = @VendorID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ProductID", productId);
                                cmd.Parameters.AddWithValue("@VendorID", vendorId);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadProducts();
                                }
                                else
                                {
                                    MessageBox.Show("Product not found or you don't have permission to delete it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}