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
    public partial class manageUser : Form
    {
        //private int userId;

        


        public manageUser()
        {
            InitializeComponent();
            Theme.Apply(this);
            LoadUserData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadUserData()
        {
            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT UserID, Username, FullName, Email, Status FROM Users"; 

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            addUser a = new addUser();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);

            
            updateuser updateForm = new updateuser(userId);
            updateForm.ShowDialog();

            
            LoadUserData();
        }
        //block user 
            private void button3_Click(object sender, EventArgs e)
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a user to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET Status = 'Blocked' WHERE UserID = @UserID";
                    int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("User blocked successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Failed to block user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadUserData();
                    }
                }
            }

        //unblock user 
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET Status = 'Active' WHERE UserID = @UserID";
                int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("User unblocked successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to unblock user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadUserData();
                }
            }
        }
    }
}
