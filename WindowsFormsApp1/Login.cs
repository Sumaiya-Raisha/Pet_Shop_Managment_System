using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //Theme.Apply(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Admin quick login
            if (username == "admin" && password == "admin")
            {
                new Admin().Show();
                Hide();
                return;
            }

            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // --- CUSTOMER LOGIN ---
                    string userQuery = @"
                        SELECT UserID, FullName, Status
                        FROM Users
                        WHERE LTRIM(RTRIM(Username)) = LTRIM(RTRIM(@Username))
                          AND LTRIM(RTRIM(Password)) = LTRIM(RTRIM(@Password))";
                    using (SqlCommand cmd = new SqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                if (r["Status"].ToString().Equals("Blocked", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Your account is blocked.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                int uid = Convert.ToInt32(r["UserID"]);
                                string fullname = r["FullName"].ToString();
                                new customerDashboard(uid, fullname).Show();
                                Hide();
                                return;
                            }
                        }
                    }

                    // --- VENDOR LOGIN ---
                    string vendorQuery = @"
                        SELECT VendorID, Username, Status
                        FROM Vendors
                        WHERE LTRIM(RTRIM(Username)) = LTRIM(RTRIM(@Username))
                          AND LTRIM(RTRIM(Password)) = LTRIM(RTRIM(@Password))";
                    using (SqlCommand cmd = new SqlCommand(vendorQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                if (!r["Status"].ToString().Equals("Approved", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Your vendor account is not approved yet.",
                                        "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                int vendorId = Convert.ToInt32(r["VendorID"]);
                                string vendorUser = r["Username"].ToString();

                                // Pass BOTH vendorId and username
                                new VendorDashboard(vendorId, vendorUser).Show();
                                Hide();
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new role().Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
