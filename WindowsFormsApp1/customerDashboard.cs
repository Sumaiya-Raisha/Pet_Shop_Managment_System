//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using System.Linq;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class customerDashboard : Form
//    {
//        private int _userId;
//        private string _fullName;
//        private List<ProductView> _allProducts = new List<ProductView>();
//        private ShoppingCartManager _cartManager;
//        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public customerDashboard(int userId, string fullName)
//        {
//            InitializeComponent();
//            _userId = userId;
//            _fullName = fullName;
//            _cartManager = new ShoppingCartManager();
//            Theme.Apply(this);

//            this.Load += CustomerDashboard_Load;
//        }

//        private void CustomerDashboard_Load(object sender, EventArgs e)
//        {
//            lblWelcome.Text = $"Welcome, {_fullName}";
//            LoadProductsFromDatabase();
//            LoadCategories();
//            BindGrid();
//            UpdateCartDisplay();
//        }

//        private void btnLogout_Click(object sender, EventArgs e) => this.Close();

//        private void btnHome_Click(object sender, EventArgs e)
//        {
//            LoadProductsFromDatabase();
//            BindGrid();
//        }

//        private void btnOrders_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var orderHistoryForm = new OrderHistoryForm(_userId))
//                {
//                    orderHistoryForm.ShowDialog();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening order history: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnProfile_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var profile = new CustomerProfileForm(_userId))
//                {
//                    profile.ShowDialog(this);
//                    UpdateCartDisplay();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening profile: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnSettings_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var form = new PetAdoptionRequestForm(_userId))
//                {
//                    form.ShowDialog(this);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening adoption: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnBack_Click(object sender, EventArgs e)
//        {
//            var login = new Login();
//            login.Show();
//            this.Close();
//        }

//        private void btnSearch_Click(object sender, EventArgs e) => BindGrid();

//        private void BindGrid()
//        {
//            if (cbCategory == null || dgvItems == null) return;

//            string category = (cbCategory.SelectedItem as string) ?? "All";
//            string query = (txtSearch?.Text ?? string.Empty).Trim().ToLowerInvariant();

//            var filtered = _allProducts;

//            if (category != "All")
//            {
//                filtered = filtered.FindAll(p =>
//                    string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
//            }

//            if (!string.IsNullOrEmpty(query))
//            {
//                filtered = filtered.FindAll(p =>
//                    p.ProductName.ToLowerInvariant().Contains(query) ||
//                    p.Description.ToLowerInvariant().Contains(query) ||
//                    p.VendorName.ToLowerInvariant().Contains(query));
//            }

//            dgvItems.DataSource = null;
//            dgvItems.DataSource = filtered;

//            // Format Price as currency
//            if (dgvItems.Columns.Contains("Price"))
//            {
//                dgvItems.Columns["Price"].DefaultCellStyle.Format = "C2";
//            }
//        }

//        private void LoadProductsFromDatabase()
//        {
//            try
//            {
//                _allProducts.Clear();

//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    string productsQuery = @"
//                SELECT 
//                    pr.ProductID,
//                    pr.ProductName,
//                    pr.Description,
//                    pr.Price,
//                    pr.StockQuantity,
//                    pr.DiscountPercentage,
//                    c.CategoryName AS Category,
//                    'Vendor' AS VendorName,
//                    pr.Price * (1 - pr.DiscountPercentage / 100.0) AS DiscountedPrice
//                FROM Products pr
//                INNER JOIN Categories c ON pr.CategoryID = c.CategoryID
//                WHERE pr.IsActive = 1 AND pr.StockQuantity > 0
//            ";

//                    using (SqlCommand cmd = new SqlCommand(productsQuery, conn))
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            _allProducts.Add(new ProductView
//                            {
//                                ProductID = Convert.ToInt32(reader["ProductID"]),
//                                ProductName = reader["ProductName"].ToString(),
//                                Description = reader["Description"].ToString(),
//                                Price = Convert.ToDecimal(reader["Price"]),
//                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
//                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
//                                Category = reader["Category"].ToString(),
//                                VendorName = reader["VendorName"].ToString(),
//                                DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"])
//                            });
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading products: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private void LoadCategories()
//        {
//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    string query = "SELECT CategoryName FROM Categories ORDER BY CategoryName ASC";

//                    var categories = new List<string> { "All" };

//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            categories.Add(reader["CategoryName"].ToString());
//                        }
//                    }

//                    cbCategory.Items.Clear();
//                    cbCategory.Items.AddRange(categories.ToArray());
//                    cbCategory.SelectedIndex = 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }


//        private void UpdateCartDisplay()
//        {
//            try
//            {
//                var (itemCount, totalAmount) = _cartManager.GetCartTotal(_userId);
//                lblCartInfo.Text = $"Cart: {itemCount} items - ${totalAmount:F2}";
//            }
//            catch
//            {
//                lblCartInfo.Text = "Cart: Error loading";
//            }
//        }

//        private void ShowCartAndCheckout()
//        {
//            try
//            {
//                var cartItems = _cartManager.GetCartItems(_userId);
//                if (cartItems.Count == 0)
//                {
//                    MessageBox.Show("Your cart is empty. Add some products first!",
//                        "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    return;
//                }

//                var totalAmount = cartItems.Sum(item => item.TotalPrice);
//                using (var checkoutForm = new CheckoutForm(_userId, cartItems, totalAmount))
//                {
//                    if (checkoutForm.ShowDialog() == DialogResult.OK)
//                    {
//                        UpdateCartDisplay();
//                        MessageBox.Show("Order placed successfully!", "Success",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error showing cart: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void AddToCart(int productId)
//        {
//            try
//            {
//                var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
//                string productName = product?.ProductName ?? "Product";

//                bool success = _cartManager.AddToCart(_userId, productId, 1);
//                if (success)
//                {
//                    UpdateCartDisplay();
//                    var result = MessageBox.Show(
//                        $"✅ {productName} has been added to your cart!\n\nWould you like to view your cart now?",
//                        "Added to Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

//                    if (result == DialogResult.Yes) ShowCartAndCheckout();
//                }
//                else
//                {
//                    MessageBox.Show($"❌ Failed to add {productName} to cart.\n\nPlease try again.",
//                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"❌ Error adding to cart:\n{ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                var product = dgvItems.Rows[e.RowIndex].DataBoundItem as ProductView;
//                if (product != null) AddToCart(product.ProductID);
//            }
//        }

//        private void btnViewCart_Click(object sender, EventArgs e) => ShowCartAndCheckout();

//        public class ProductView
//        {
//            public int ProductID { get; set; }
//            public string ProductName { get; set; }
//            public string Description { get; set; }
//            public decimal Price { get; set; }
//            public int StockQuantity { get; set; }
//            public decimal DiscountPercentage { get; set; }
//            public string Category { get; set; }
//            public string VendorName { get; set; }
//            public decimal DiscountedPrice { get; set; }
//        }
//    }
//}

//22222
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Windows.Forms;
//using System.Drawing;

//namespace WindowsFormsApp1
//{
//    public partial class customerDashboard : Form
//    {
//        private int _userId;
//        private string _fullName;
//        private List<ProductView> _allProducts = new List<ProductView>();
//        private ShoppingCartManager _cartManager;
//        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public customerDashboard(int userId, string fullName)
//        {
//            InitializeComponent();

//            _userId = userId;
//            _fullName = fullName;
//            _cartManager = new ShoppingCartManager();

//            lblWelcome.Text = $"Welcome, {_fullName}";

//            // Setup buttons and events safely at runtime
//            InitializeNavButtons();

//            LoadProductsFromDatabase();
//            LoadCategories();
//            BindGrid();
//            UpdateCartDisplay();
//        }

//        private void InitializeNavButtons()
//        {
//            SetupNavButton(btnHome, "🏠 Home", 50);
//            SetupNavButton(btnOrders, "📋 Order History", 120);
//            SetupNavButton(btnProfile, "👤 Profile", 190);
//            SetupNavButton(btnSettings, "🐾 Adoption Pet", 260);
//            SetupNavButton(btnBack, "← Back", 330);

//            btnHome.Click += btnHome_Click;
//            btnOrders.Click += btnOrders_Click;
//            btnProfile.Click += btnProfile_Click;
//            btnSettings.Click += btnSettings_Click;
//            btnBack.Click += btnBack_Click;
//        }

//        private void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, int top)
//        {
//            if (btn == null) return;
//            btn.Text = text;
//            btn.Size = new Size(220, 50);
//            btn.Location = new Point(15, top);
//            btn.BorderRadius = 15;
//            btn.FillColor = Color.Transparent;
//            btn.ForeColor = Color.FromArgb(108, 117, 125);
//            btn.Font = new Font("Segoe UI", 12F);
//            btn.TextAlign = HorizontalAlignment.Left;
//            btn.HoverState.FillColor = Color.FromArgb(248, 249, 250);
//            btn.HoverState.ForeColor = Color.FromArgb(0, 123, 255);
//            btn.Cursor = Cursors.Hand;
//        }

//        // --- Rest of your existing code (LoadProductsFromDatabase, BindGrid, AddToCart, etc.) ---

//        public class ProductView
//        {
//            public int ProductID { get; set; }
//            public string ProductName { get; set; }
//            public string Description { get; set; }
//            public decimal Price { get; set; }
//            public int StockQuantity { get; set; }
//            public decimal DiscountPercentage { get; set; }
//            public string Category { get; set; }
//            public string VendorName { get; set; }
//            public decimal DiscountedPrice { get; set; }
//        }
//    }
//}
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class customerDashboard : Form
//    {
//        private int _userId;
//        private string _fullName;
//        private List<ProductView> _allProducts = new List<ProductView>();
//        private ShoppingCartManager _cartManager;
//        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public customerDashboard(int userId, string fullName)
//        {
//            InitializeComponent();
//            _userId = userId;
//            _fullName = fullName;
//            _cartManager = new ShoppingCartManager();
//            Theme.Apply(this);
//            this.Load += CustomerDashboard_Load;
//        }

//        private void CustomerDashboard_Load(object sender, EventArgs e)
//        {
//            lblWelcome.Text = $"Welcome, {_fullName}";
//            LoadProductsFromDatabase();
//            LoadCategories();
//            BindGrid();
//            UpdateCartDisplay();
//        }

//        private void btnLogout_Click(object sender, EventArgs e) => this.Close();

//        private void btnHome_Click(object sender, EventArgs e)
//        {
//            LoadProductsFromDatabase();
//            BindGrid();
//        }

//        private void btnOrders_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var orderHistoryForm = new OrderHistoryForm(_userId))
//                    orderHistoryForm.ShowDialog();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening order history: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnProfile_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var profile = new CustomerProfileForm(_userId))
//                {
//                    profile.ShowDialog(this);
//                    UpdateCartDisplay();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening profile: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnSettings_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var form = new PetAdoptionRequestForm(_userId))
//                    form.ShowDialog(this);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error opening adoption: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnBack_Click(object sender, EventArgs e)
//        {
//            var login = new Login();
//            login.Show();
//            this.Close();
//        }

//        private void btnSearch_Click(object sender, EventArgs e) => BindGrid();

//        private void BindGrid()
//        {
//            if (cbCategory == null || dgvItems == null) return;

//            string category = (cbCategory.SelectedItem as string) ?? "All";
//            string query = (txtSearch?.Text ?? string.Empty).Trim().ToLowerInvariant();

//            var filtered = _allProducts;

//            if (category != "All")
//                filtered = filtered.FindAll(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));

//            if (!string.IsNullOrEmpty(query))
//                filtered = filtered.FindAll(p =>
//                    p.ProductName.ToLowerInvariant().Contains(query) ||
//                    p.Description.ToLowerInvariant().Contains(query) ||
//                    p.VendorName.ToLowerInvariant().Contains(query));

//            dgvItems.DataSource = null;
//            dgvItems.DataSource = filtered;

//            if (dgvItems.Columns.Contains("Price"))
//                dgvItems.Columns["Price"].DefaultCellStyle.Format = "C2";
//        }

//        private void LoadProductsFromDatabase()
//        {
//            try
//            {
//                _allProducts.Clear();

//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    // Combine Products + Pets
//                    string query = @"
//                        SELECT 
//                            ProductID AS ItemID,
//                            ProductName AS Name,
//                            Description,
//                            Price,
//                            StockQuantity,
//                            DiscountPercentage,
//                            c.CategoryName AS Category,
//                            'Vendor' AS VendorName,
//                            Price * (1 - DiscountPercentage / 100.0) AS DiscountedPrice
//                        FROM Products pr
//                        INNER JOIN Categories c ON pr.CategoryID = c.CategoryID
//                        WHERE pr.IsActive = 1 AND pr.StockQuantity > 0

//                        UNION ALL

//                        SELECT
//                            PetID AS ItemID,
//                            Name,
//                            Breed AS Description,
//                            Price,
//                            Quantity AS StockQuantity,
//                            0 AS DiscountPercentage,
//                            Type AS Category,
//                            'Vendor' AS VendorName,
//                            Price AS DiscountedPrice
//                        FROM Pet_list
//                        WHERE Quantity > 0
//                    ";

//                    using (SqlCommand cmd = new SqlCommand(query, conn))
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            _allProducts.Add(new ProductView
//                            {
//                                ProductID = Convert.ToInt32(reader["ItemID"]),
//                                ProductName = reader["Name"].ToString(),
//                                Description = reader["Description"].ToString(),
//                                Price = Convert.ToDecimal(reader["Price"]),
//                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
//                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
//                                Category = reader["Category"].ToString(),
//                                VendorName = reader["VendorName"].ToString(),
//                                DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"])
//                            });
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading products: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void LoadCategories()
//        {
//            try
//            {
//                using (SqlConnection conn = new SqlConnection(connectionString))
//                {
//                    conn.Open();

//                    var categories = new List<string> { "All" };

//                    // Load Categories from Products
//                    string prodQuery = "SELECT DISTINCT CategoryName FROM Categories";
//                    using (var cmd = new SqlCommand(prodQuery, conn))
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                            categories.Add(reader["CategoryName"].ToString());
//                    }

//                    // Load Types from Pets
//                    string petQuery = "SELECT DISTINCT Type FROM Pet_list";
//                    using (var cmd = new SqlCommand(petQuery, conn))
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            string type = reader["Type"].ToString();
//                            if (!categories.Contains(type))
//                                categories.Add(type);
//                        }
//                    }

//                    cbCategory.Items.Clear();
//                    cbCategory.Items.AddRange(categories.ToArray());
//                    cbCategory.SelectedIndex = 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateCartDisplay()
//        {
//            try
//            {
//                var (itemCount, totalAmount) = _cartManager.GetCartTotal(_userId);
//                lblCartInfo.Text = $"Cart: {itemCount} items - ${totalAmount:F2}";
//            }
//            catch
//            {
//                lblCartInfo.Text = "Cart: Error loading";
//            }
//        }

//        private void ShowCartAndCheckout()
//        {
//            try
//            {
//                var cartItems = _cartManager.GetCartItems(_userId);
//                if (cartItems.Count == 0)
//                {
//                    MessageBox.Show("Your cart is empty. Add some products first!",
//                        "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    return;
//                }

//                var totalAmount = cartItems.Sum(item => item.TotalPrice);
//                using (var checkoutForm = new CheckoutForm(_userId, cartItems, totalAmount))
//                {
//                    if (checkoutForm.ShowDialog() == DialogResult.OK)
//                    {
//                        UpdateCartDisplay();
//                        MessageBox.Show("Order placed successfully!", "Success",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error showing cart: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void AddToCart(int productId)
//        {
//            try
//            {
//                var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
//                string productName = product?.ProductName ?? "Product";

//                bool success = _cartManager.AddToCart(_userId, productId, 1);
//                if (success)
//                {
//                    UpdateCartDisplay();
//                    var result = MessageBox.Show(
//                        $"✅ {productName} has been added to your cart!\n\nWould you like to view your cart now?",
//                        "Added to Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

//                    if (result == DialogResult.Yes) ShowCartAndCheckout();
//                }
//                else
//                {
//                    MessageBox.Show($"❌ Failed to add {productName} to cart.\n\nPlease try again.",
//                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"❌ Error adding to cart:\n{ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex >= 0)
//            {
//                var product = dgvItems.Rows[e.RowIndex].DataBoundItem as ProductView;
//                if (product != null) AddToCart(product.ProductID);
//            }
//        }

//        private void btnViewCart_Click(object sender, EventArgs e) => ShowCartAndCheckout();

//        public class ProductView
//        {
//            public int ProductID { get; set; }
//            public string ProductName { get; set; }
//            public string Description { get; set; }
//            public decimal Price { get; set; }
//            public int StockQuantity { get; set; }
//            public decimal DiscountPercentage { get; set; }
//            public string Category { get; set; }
//            public string VendorName { get; set; }
//            public decimal DiscountedPrice { get; set; }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class customerDashboard : Form
    {
        private int _userId;
        private string _fullName;
        private List<ProductView> _allProducts = new List<ProductView>();
        private ShoppingCartManager _cartManager;
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public customerDashboard(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _cartManager = new ShoppingCartManager();
            Theme.Apply(this);
            this.Load += CustomerDashboard_Load;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_fullName}";
            LoadProductsFromDatabase();
            LoadCategories();
            BindGrid();
            UpdateCartDisplay();
        }

        private void btnLogout_Click(object sender, EventArgs e) => this.Close();

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadProductsFromDatabase();
            BindGrid();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                using (var orderHistoryForm = new OrderHistoryForm(_userId))
                    orderHistoryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening order history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var profile = new CustomerProfileForm(_userId))
                {
                    profile.ShowDialog(this);
                    UpdateCartDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new PetAdoptionRequestForm(_userId))
                    form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening adoption: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e) => BindGrid();

        private void BindGrid()
        {
            if (cbCategory == null || dgvItems == null) return;

            string category = (cbCategory.SelectedItem as string) ?? "All";
            string query = (txtSearch?.Text ?? string.Empty).Trim().ToLowerInvariant();

            var filtered = _allProducts;

            if (category != "All")
                filtered = filtered.FindAll(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(query))
                filtered = filtered.FindAll(p =>
                    p.ProductName.ToLowerInvariant().Contains(query) ||
                    p.Description.ToLowerInvariant().Contains(query) ||
                    p.VendorName.ToLowerInvariant().Contains(query));

            dgvItems.DataSource = null;
            dgvItems.DataSource = filtered;

            if (dgvItems.Columns.Contains("Price"))
                dgvItems.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                _allProducts.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Combine Products + Pets
                    string query = @"
                        SELECT 
                            pr.ProductID AS ItemID,
                            pr.ProductName AS Name,
                            pr.Description,
                            pr.Price,
                            pr.StockQuantity,
                            pr.DiscountPercentage,
                            c.CategoryName AS Category,
                            'Vendor' AS VendorName,
                            pr.Price * (1 - pr.DiscountPercentage / 100.0) AS DiscountedPrice
                        FROM Products pr
                        INNER JOIN Categories c ON pr.CategoryID = c.CategoryID
                        WHERE pr.IsActive = 1 AND pr.StockQuantity > 0

                        UNION ALL

                        SELECT
                            PetID AS ItemID,
                            Name,
                            Breed AS Description,
                            Price,
                            Quantity AS StockQuantity,
                            0 AS DiscountPercentage,
                            Type AS Category,
                            'Vendor' AS VendorName,
                            Price AS DiscountedPrice
                        FROM Pet_list
                        WHERE Quantity > 0
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _allProducts.Add(new ProductView
                            {
                                ProductID = Convert.ToInt32(reader["ItemID"]),
                                ProductName = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                Category = reader["Category"].ToString(),
                                VendorName = reader["VendorName"].ToString(),
                                DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    var categories = new List<string> { "All" };

                    string query = @"
                SELECT CategoryName AS Category FROM Categories
                UNION
                SELECT DISTINCT Type AS Category FROM Pet_list WHERE Quantity > 0
            ";

                    using (var cmd = new SqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cat = reader["Category"].ToString();
                            if (!categories.Contains(cat))
                                categories.Add(cat);
                        }
                    }

                    cbCategory.Items.Clear();
                    cbCategory.Items.AddRange(categories.OrderBy(c => c).ToArray());
                    cbCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateCartDisplay()
        {
            try
            {
                var (itemCount, totalAmount) = _cartManager.GetCartTotal(_userId);
                lblCartInfo.Text = $"Cart: {itemCount} items - ${totalAmount:F2}";
            }
            catch
            {
                lblCartInfo.Text = "Cart: Error loading";
            }
        }

        private void ShowCartAndCheckout()
        {
            try
            {
                var cartItems = _cartManager.GetCartItems(_userId);
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Your cart is empty. Add some products first!",
                        "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var totalAmount = cartItems.Sum(item => item.TotalPrice);
                using (var checkoutForm = new CheckoutForm(_userId, cartItems, totalAmount))
                {
                    if (checkoutForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateCartDisplay();
                        MessageBox.Show("Order placed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing cart: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(int productId)
        {
            try
            {
                var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
                string productName = product?.ProductName ?? "Product";

                bool success = _cartManager.AddToCart(_userId, productId, 1);
                if (success)
                {
                    UpdateCartDisplay();
                    var result = MessageBox.Show(
                        $"✅ {productName} has been added to your cart!\n\nWould you like to view your cart now?",
                        "Added to Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes) ShowCartAndCheckout();
                }
                else
                {
                    MessageBox.Show($"❌ Failed to add {productName} to cart.\n\nPlease try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error adding to cart:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var product = dgvItems.Rows[e.RowIndex].DataBoundItem as ProductView;
                if (product != null) AddToCart(product.ProductID);
            }
        }

        private void btnViewCart_Click(object sender, EventArgs e) => ShowCartAndCheckout();

        public class ProductView
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public decimal DiscountPercentage { get; set; }
            public string Category { get; set; }
            public string VendorName { get; set; }
            public decimal DiscountedPrice { get; set; }
        }
    }
}

