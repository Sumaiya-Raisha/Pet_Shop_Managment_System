using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class vendormanagement : Form
    {
        public vendormanagement()
        {
            InitializeComponent();
            Theme.Apply(this);
            LoadPendingVendors();
        }

        private void StyleButton(Button btn, string text)
        {
            btn.Text = text;
            btn.Dock = DockStyle.Top;
            btn.Height = 45;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.RoyalBlue;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void vendormanagement_Load(object sender, EventArgs e)
        {

        }

        private void LoadPendingVendors()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT VendorID, Username, FullName,Location, Status FROM Vendors WHERE Status = 'Pending'";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a vendor to approve.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int vendorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["VendorID"].Value);
            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Vendors SET Status = 'Approved' WHERE VendorID = @VendorID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vendor approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingVendors(); // Refresh 
                    }
                    else
                    {
                        MessageBox.Show("Approval failed. Vendor may already be approved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a vendor to reject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vendorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["VendorID"].Value);

            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Vendors SET Status = 'Rejected' WHERE VendorID = @VendorID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vendor rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingVendors(); // Refresh DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Rejection failed. Vendor may already be processed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a vendor to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int vendorId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["VendorID"].Value);

           
            DialogResult result = MessageBox.Show("Are you sure you want to delete this vendor?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Vendors WHERE VendorID = @VendorID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@VendorID", vendorId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Vendor deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingVendors(); // Refresh
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. Vendor may not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();

        }
    }
}
