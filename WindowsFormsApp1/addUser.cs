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
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            manageUser a = new manageUser();
            a.Show();
            this.Hide();
        }
        string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                string fullname = textBox3.Text;
                string email = textBox4.Text;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"INSERT INTO Users (Username, Password, FullName, Email)
                             VALUES (@Username, @Password, @FullName, @Email)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); 
                        cmd.Parameters.AddWithValue("@FullName", fullname);
                        cmd.Parameters.AddWithValue("@Email", email);

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                            MessageBox.Show("User added successfully!");
                        else
                            MessageBox.Show("Failed to save customer.");
                    }
                }


            }
        }
    }
}
