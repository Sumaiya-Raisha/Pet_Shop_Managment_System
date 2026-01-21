using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class CustomerProfileForm : Form
	{
		private readonly int _userId;
		private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

		public CustomerProfileForm()
			: this(0)
		{
		}

		public CustomerProfileForm(int userId)
		{
			InitializeComponent();
			_userId = userId;
			Theme.Apply(this);
			LoadProfile();
			LoadSummary();
		}

		private void LoadProfile()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					string query = @"
						SELECT Username, FullName, Email
						FROM Users
						WHERE UserID = @UserID";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@UserID", _userId);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								txtUsername.Text = reader["Username"].ToString();
								txtFullName.Text = reader["FullName"].ToString();
								txtEmail.Text = reader["Email"].ToString();
								// Optional split to show names locally (not persisted unless Users has such columns)
								var parts = (txtFullName.Text ?? string.Empty).Trim().Split(' ');
								txtFirstName.Text = parts.Length > 0 ? parts[0] : string.Empty;
								txtLastName.Text = parts.Length > 1 ? string.Join(" ", parts.Skip(1)) : string.Empty;
								// Phone/Address not stored in Users by default; leave empty
								txtPhone.Text = string.Empty;
								txtAddress.Text = string.Empty;
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

		private void LoadSummary()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					string query = @"
						SELECT 
							COUNT(*) AS OrderCount,
							MAX(OrderDate) AS LastOrderDate,
							ISNULL(SUM(TotalAmount), 0) AS LifetimeSpend
						FROM Orders o
						WHERE o.UserID = @UserID";

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@UserID", _userId);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								lblOrders.Text = Convert.ToInt32(reader["OrderCount"]).ToString();
								var last = reader["LastOrderDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LastOrderDate"]);
								lblLastOrder.Text = last.HasValue ? last.Value.ToString("yyyy-MM-dd HH:mm") : "-";
								lblLifetimeSpend.Text = string.Format("${0:F2}", Convert.ToDecimal(reader["LifetimeSpend"]));
							}
						}
					}
				}
			}
			catch
			{
				// Non-blocking for summary
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();
					using (SqlTransaction tx = conn.BeginTransaction())
					{
						try
						{
							// Update Users basic fields
							string updateUser = @"UPDATE Users SET FullName=@FullName, Email=@Email WHERE UserID=@UserID";
							using (SqlCommand cmd = new SqlCommand(updateUser, conn, tx))
							{
								cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
								cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
								cmd.Parameters.AddWithValue("@UserID", _userId);
								cmd.ExecuteNonQuery();
							}

							// Profile now uses only Users table based on your schema.

							// Change password if both fields provided and match
							if (!string.IsNullOrWhiteSpace(txtNewPassword.Text) || !string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
							{
								if (txtNewPassword.Text != txtConfirmPassword.Text)
								{
									throw new Exception("Passwords do not match.");
								}

								string updatePwd = "UPDATE Users SET Password=@Password WHERE UserID=@UserID";
								using (SqlCommand cmd = new SqlCommand(updatePwd, conn, tx))
								{
									cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
									cmd.Parameters.AddWithValue("@UserID", _userId);
									cmd.ExecuteNonQuery();
								}
							}

							tx.Commit();
							MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						catch (Exception ex2)
						{
							tx.Rollback();
							MessageBox.Show("Error saving profile: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error saving profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}


