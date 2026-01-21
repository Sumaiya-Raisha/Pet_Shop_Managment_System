using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class OrderReceiptForm : Form
	{
		private readonly int _orderId;
		private readonly string _vendorUsername;
		private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

		public OrderReceiptForm()
			: this(0, string.Empty)
		{
		}

		public OrderReceiptForm(int orderId, string vendorUsername)
		{
			InitializeComponent();
			_orderId = orderId;
			_vendorUsername = vendorUsername ?? string.Empty;
			Theme.Apply(this);
			if (_orderId > 0) LoadReceipt();
		}

		private void LoadReceipt()
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(_connectionString))
				{
					conn.Open();

					// Header
					string headerQuery = @"
						SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, u.Username AS Customer
						FROM Orders o
						INNER JOIN Users u ON o.UserID = u.UserID
						WHERE o.OrderID = @OrderID";
					using (SqlCommand cmd = new SqlCommand(headerQuery, conn))
					{
						cmd.Parameters.AddWithValue("@OrderID", _orderId);
						using (SqlDataReader r = cmd.ExecuteReader())
						{
							if (r.Read())
							{
								lblOrderId.Text = "Order #" + r["OrderID"].ToString();
								lblCustomer.Text = "Customer: " + r["Customer"].ToString();
								lblDate.Text = Convert.ToDateTime(r["OrderDate"]).ToString("yyyy-MM-dd HH:mm");
								lblStatus.Text = "Status: " + r["Status"].ToString();
								lblTotal.Text = string.Format("Total: ${0:F2}", Convert.ToDecimal(r["TotalAmount"]));
							}
						}
					}

					// Items (only this vendor's items)
					string itemsQuery = @"
						SELECT p.ProductName, oi.Quantity, oi.UnitPrice, oi.DiscountPercentage, oi.TotalPrice
						FROM OrderItems oi
						INNER JOIN Products p ON oi.ProductID = p.ProductID
						INNER JOIN Vendors v ON p.VendorID = v.VendorID
						WHERE oi.OrderID = @OrderID AND v.Username = @VendorUsername";
					using (SqlCommand cmd = new SqlCommand(itemsQuery, conn))
					{
						cmd.Parameters.AddWithValue("@OrderID", _orderId);
						cmd.Parameters.AddWithValue("@VendorUsername", _vendorUsername);
						SqlDataAdapter da = new SqlDataAdapter(cmd);
						DataTable dt = new DataTable();
						da.Fill(dt);
						dgvItems.DataSource = dt;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine(lblOrderId.Text);
				sb.AppendLine(lblCustomer.Text);
				sb.AppendLine(lblDate.Text);
				sb.AppendLine(lblStatus.Text);
				sb.AppendLine(lblTotal.Text);
				sb.AppendLine();
				sb.AppendLine("Items:");
				foreach (DataGridViewRow row in dgvItems.Rows)
				{
					if (row.IsNewRow) continue;
					sb.AppendLine($"- {row.Cells["ProductName"].Value} x{row.Cells["Quantity"].Value} = ${row.Cells["TotalPrice"].Value}");
				}
				Clipboard.SetText(sb.ToString());
				MessageBox.Show("Receipt copied to clipboard.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error copying: " + ex.Message);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}


