using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ProductForm : Form
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
        private int vendorId;
        private int? productId;
        private bool isEditMode;

        public ProductForm()
            : this(0, null)
        {
        }

        public ProductForm(int vendorId, int? productId = null)
        {
            InitializeComponent();
            this.vendorId = vendorId;
            this.productId = productId;
            this.isEditMode = productId.HasValue;
            
            
            if (isEditMode)
            {
                this.Text = "Update Product";
                LoadProductData();
            }
            else
            {
                this.Text = "Add New Product";
            }
        }

        private void LoadProductData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Products WHERE ProductID = @ProductID AND VendorID = @VendorID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", productId.Value);
                        cmd.Parameters.AddWithValue("@VendorID", vendorId);
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtProductName.Text = reader["ProductName"].ToString();
                                txtDescription.Text = reader["Description"].ToString();
                                txtPrice.Text = reader["Price"].ToString();
                                txtStock.Text = reader["StockQuantity"].ToString();
                                txtDiscount.Text = reader["DiscountPercentage"].ToString();
                                txtCategory.Text = reader["Category"].ToString();
                                chkIsActive.Checked = Convert.ToBoolean(reader["IsActive"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        
                        string query;
                        if (isEditMode)
                        {
                            query = @"UPDATE Products SET 
                                    ProductName = @ProductName, 
                                    Description = @Description, 
                                    Price = @Price, 
                                    StockQuantity = @StockQuantity, 
                                    DiscountPercentage = @DiscountPercentage, 
                                    Category = @Category, 
                                    IsActive = @IsActive,
                                    UpdatedDate = GETDATE()
                                    WHERE ProductID = @ProductID AND VendorID = @VendorID";
                        }
                        else
                        {
                            query = @"INSERT INTO Products 
                                    (VendorID, ProductName, Description, Price, StockQuantity, 
                                     DiscountPercentage, Category, IsActive, CreatedDate, UpdatedDate) 
                                    VALUES 
                                    (@VendorID, @ProductName, @Description, @Price, @StockQuantity, 
                                     @DiscountPercentage, @Category, @IsActive, GETDATE(), GETDATE())";
                        }
                        
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                            cmd.Parameters.AddWithValue("@StockQuantity", Convert.ToInt32(txtStock.Text));
                            cmd.Parameters.AddWithValue("@DiscountPercentage", Convert.ToDecimal(txtDiscount.Text));
                            cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                            cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                            cmd.Parameters.AddWithValue("@VendorID", vendorId);
                            
                            if (isEditMode)
                            {
                                cmd.Parameters.AddWithValue("@ProductID", productId.Value);
                            }
                            
                            int rowsAffected = cmd.ExecuteNonQuery();
                            
                            if (rowsAffected > 0)
                            {
                                string message = isEditMode ? "Product updated successfully!" : "Product added successfully!";
                                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No changes were made.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter product description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity (0 or greater).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                MessageBox.Show("Please enter a valid discount percentage (0-100).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                MessageBox.Show("Please enter product category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
