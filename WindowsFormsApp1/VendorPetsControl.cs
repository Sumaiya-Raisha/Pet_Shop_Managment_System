using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorPetsControl : UserControl
    {
        private readonly string _username;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public VendorPetsControl()
            : this(string.Empty)
        {
        }

        public VendorPetsControl(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;
            LoadAllPets();
        }

        public VendorPetsControl(int vendorId, string username)
            : this(username)
        {
        }

        private void LoadAllPets()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Pet_list", conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        grid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadAllPets();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PetEditForm())
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadAllPets();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a pet first."); return; }
            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);
            using (var form = new PetEditForm(petId))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadAllPets();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a pet first."); return; }
            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);
            if (MessageBox.Show("Delete this pet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Pet_list WHERE PetID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", petId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadAllPets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting pet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class VendorPetsControl : UserControl
//    {
//        private readonly string _username;
//        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public VendorPetsControl() : this(string.Empty) { }

//        public VendorPetsControl(string username)
//        {
//            InitializeComponent();
//            _username = username ?? string.Empty;
//            LoadAllProducts();
//        }

//        public VendorPetsControl(int vendorId, string username) : this(username) { }

//        // Load all products (pets + other products)
//        private void LoadAllProducts()
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    string query = @"
//                        SELECT pr.ProductID, pr.ProductName, pr.Description, pr.Price, pr.StockQuantity, 
//                               c.CategoryName AS Category, pr.DiscountPercentage, pr.IsActive
//                        FROM Products pr
//                        INNER JOIN Categories c ON pr.CategoryID = c.CategoryID
//                        ORDER BY pr.ProductID DESC";

//                    using (var cmd = new SqlCommand(query, conn))
//                    using (var da = new SqlDataAdapter(cmd))
//                    {
//                        var dt = new DataTable();
//                        da.Fill(dt);
//                        grid.DataSource = dt;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e) => LoadAllProducts();

//        // Add new pet/product
//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            using (var form = new PetEditForm(NULL))
//            {
//                if (form.ShowDialog(FindForm()) == DialogResult.OK)
//                {
//                    InsertOrUpdateProduct(form.ProductName, form.Description, form.Price, form.Quantity, form.CategoryName);
//                    LoadAllProducts();
//                }
//            }
//        }

//        // Update existing pet/product
//        private void btnUpdate_Click(object sender, EventArgs e)
//        {
//            if (grid.CurrentRow == null) { MessageBox.Show("Select a product first."); return; }

//            var row = grid.CurrentRow.DataBoundItem as DataRowView;
//            int productId = Convert.ToInt32(row["ProductID"]);

//            using (var form = new PetEditForm(productId))
//            {
//                if (form.ShowDialog(FindForm()) == DialogResult.OK)
//                {
//                    InsertOrUpdateProduct(form.ProductName, form.Description, form.Price, form.Quantity, form.CategoryName, productId);
//                    LoadAllProducts();
//                }
//            }
//        }

//        // Delete product
//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (grid.CurrentRow == null) { MessageBox.Show("Select a product first."); return; }
//            int productId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["ProductID"]);

//            if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn))
//                    {
//                        cmd.Parameters.AddWithValue("@id", productId);
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//                LoadAllProducts();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Insert or update product with automatic category handling
//        private void InsertOrUpdateProduct(string name, string description, decimal price, int quantity, string categoryName, int? productId = null)
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();

//                    // Step 1: Ensure category exists
//                    string categoryQuery = "IF NOT EXISTS (SELECT 1 FROM Categories WHERE CategoryName=@cat) " +
//                                           "INSERT INTO Categories (CategoryName) VALUES (@cat); " +
//                                           "SELECT CategoryID FROM Categories WHERE CategoryName=@cat;";
//                    int categoryId;
//                    using (var cmd = new SqlCommand(categoryQuery, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@cat", categoryName);
//                        categoryId = Convert.ToInt32(cmd.ExecuteScalar());
//                    }

//                    // Step 2: Insert or update product
//                    if (productId.HasValue)
//                    {
//                        string updateQuery = @"
//                            UPDATE Products
//                            SET ProductName=@name, Description=@desc, Price=@price, StockQuantity=@qty, 
//                                CategoryID=@catId, IsActive=1
//                            WHERE ProductID=@id";
//                        using (var cmd = new SqlCommand(updateQuery, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@name", name);
//                            cmd.Parameters.AddWithValue("@desc", description);
//                            cmd.Parameters.AddWithValue("@price", price);
//                            cmd.Parameters.AddWithValue("@qty", quantity);
//                            cmd.Parameters.AddWithValue("@catId", categoryId);
//                            cmd.Parameters.AddWithValue("@id", productId.Value);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    else
//                    {
//                        string insertQuery = @"
//                            INSERT INTO Products (VendorID, ProductName, Description, Price, StockQuantity, DiscountPercentage, CategoryID, IsActive)
//                            VALUES (@vendor, @name, @desc, @price, @qty, 0, @catId, 1)";
//                        using (var cmd = new SqlCommand(insertQuery, conn))
//                        {
//                            cmd.Parameters.AddWithValue("@vendor", 1); // default vendor ID; replace as needed
//                            cmd.Parameters.AddWithValue("@name", name);
//                            cmd.Parameters.AddWithValue("@desc", description);
//                            cmd.Parameters.AddWithValue("@price", price);
//                            cmd.Parameters.AddWithValue("@qty", quantity);
//                            cmd.Parameters.AddWithValue("@catId", categoryId);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error saving product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class VendorPetsControl : UserControl
//    {
//        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
//        //private int _vendorId;
//        private string _username;

//        // Parameterless constructor for Designer
//        public VendorPetsControl()
//        {
//            InitializeComponent();
//        }

//        // Constructor used by VendorDashboard
//        public VendorPetsControl(string username) : this() //int vendorId
//        {
//            //_vendorId = vendorId;
//            _username = username;
//            LoadAllPets();
//        }

//        // Load pets only for this vendor
//        private void LoadAllPets()
//        {
//            try
//            {
//                using (SqlConnection conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories ", conn))//WHERE VendorID=@vendorId
//                    {
//                        //cmd.Parameters.AddWithValue("@vendorId", _vendorId);
//                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
//                        {
//                            DataTable dt = new DataTable();
//                            da.Fill(dt);
//                            grid.DataSource = dt;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading pets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Refresh button
//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadAllPets();
//        }

//        // Add button
//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            ////PetEditForm form = new PetEditForm(_vendorId); // pass vendor ID
//            if (form.ShowDialog() == DialogResult.OK)
//                LoadAllPets();
//            form.Dispose();
//        }

//        // Update button
//        private void btnUpdate_Click(object sender, EventArgs e)
//        {
//            if (grid.CurrentRow == null)
//            {
//                MessageBox.Show("Select a pet first.");
//                return;
//            }

//            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);

//            PetEditForm form = new PetEditForm(petId); // pass pet ID and vendor ID , _vendorId
//            if (form.ShowDialog() == DialogResult.OK)
//                LoadAllPets();
//            form.Dispose();
//        }

//        // Delete button
//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (grid.CurrentRow == null)
//            {
//                MessageBox.Show("Select a pet first.");
//                return;
//            }

//            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);

//            if (MessageBox.Show("Delete this pet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
//                return;

//            try
//            {
//                using (SqlConnection conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Pet_list WHERE PetID=@id ", conn)) //AND VendorID=@vendorId
//                    {
//                        cmd.Parameters.AddWithValue("@id", petId);
//                        //cmd.Parameters.AddWithValue("@vendorId", _vendorId);
//                        cmd.ExecuteNonQuery();
//                    }
//                }
//                LoadAllPets();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error deleting pet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}

