using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class VendorProfileForm : Form
	{
		private readonly string _vendorUsername;
		private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

		public VendorProfileForm()
			: this(string.Empty)
		{
		}

		public VendorProfileForm(string vendorUsername)
		{
			InitializeComponent();
			_vendorUsername = vendorUsername ?? string.Empty;
			Theme.Apply(this);
			LoadProfile();
		}

		public VendorProfileForm(int vendorId, string vendorUsername)
			: this(vendorUsername)
		{
			// vendorId reserved for future use if we expand profile by id
		}

		private void LoadProfile()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					string query = "SELECT Username, Email FROM Vendors WHERE Username=@Username";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Username", _vendorUsername);
						using (var r = cmd.ExecuteReader())
						{
							if (r.Read())
							{
								txtUsername.Text = r["Username"].ToString();
								txtEmail.Text = r["Email"].ToString();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					string update = "UPDATE Vendors SET Email=@Email WHERE Username=@Username";
					using (SqlCommand cmd = new SqlCommand(update, conn))
					{
						cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
						cmd.Parameters.AddWithValue("@Username", _vendorUsername);
						cmd.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Profile updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnChangePassword_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || txtNewPassword.Text != txtConfirmPassword.Text)
			{
				MessageBox.Show("Passwords do not match.");
				return;
			}
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					string update = "UPDATE Vendors SET Password=@Password WHERE Username=@Username";
					using (SqlCommand cmd = new SqlCommand(update, conn))
					{
						cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
						cmd.Parameters.AddWithValue("@Username", _vendorUsername);
						cmd.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Password changed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error changing password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}


