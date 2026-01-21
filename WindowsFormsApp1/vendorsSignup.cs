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
    public partial class vendorsSignup : Form
    {
        public vendorsSignup()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            role a = new role();
            a.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string email = textBox1.Text;
            string fullname = textBox3.Text;
            string password = textBox4.Text;
            string location = richTextBox1.Text;

            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Vendors (Username, Email, FullName, Password, Location, Status, DateCreated)
                             VALUES (@Username, @Email, @FullName, @Password, @Location, @Status, @DateCreated)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Password", password); 
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@Status", "Pending"); 
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Registration submitted. Awaiting admin approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
