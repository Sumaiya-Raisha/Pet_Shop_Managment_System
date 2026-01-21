using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorAdoptionRequestsControl : UserControl
    {
        private readonly string _username;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public VendorAdoptionRequestsControl()
            : this(string.Empty)
        {
        }

        public VendorAdoptionRequestsControl(string username)
        {
            InitializeComponent();
            Theme.Apply(this);
            _username = username ?? string.Empty;
            LoadRequests();
        }

        public VendorAdoptionRequestsControl(int vendorId, string username)
            : this(username)
        {
        }

        private void LoadRequests()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT r.RequestID, r.UserID, u.FullName, r.PetID,
                               COALESCE(p.Name, p.Name) AS PetName,
                               r.Notes, r.RequestDate, r.Status
                        FROM AdoptionRequests r
                        INNER JOIN Pet_list p ON r.PetID = p.PetID
                        INNER JOIN Users u ON r.UserID = u.UserID
                        ORDER BY r.RequestDate DESC";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        var dt = new DataTable();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            gridRequests.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requests: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int? SelectedRequestId()
        {
            if (gridRequests.CurrentRow == null) return null;
            var row = gridRequests.CurrentRow.DataBoundItem as DataRowView;
            if (row == null) return null;
            return Convert.ToInt32(row["RequestID"]);
        }

        private void UpdateStatus(string newStatus)
        {
            var id = SelectedRequestId();
            if (!id.HasValue) { MessageBox.Show("Select a request first."); return; }
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("UPDATE AdoptionRequests SET Status=@s WHERE RequestID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@s", newStatus);
                        cmd.Parameters.AddWithValue("@id", id.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Confirm accept
            var confirm = MessageBox.Show("Accept this adoption request and deduct pet quantity by 1?", "Confirm Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var id = SelectedRequestId();
            if (!id.HasValue) { MessageBox.Show("Select a request first."); return; }

            // Find PetID from current selection
            if (gridRequests.CurrentRow == null) { MessageBox.Show("Select a request first."); return; }
            var rowView = gridRequests.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) { MessageBox.Show("Select a request first."); return; }
            int petId = Convert.ToInt32(rowView["PetID"]);

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        EnsureQuantityColumn(conn, tx);

                        // Lock row and check quantity
                        int qty = 0;
                        using (var getCmd = new SqlCommand("SELECT ISNULL(Quantity,0) FROM Pet_list WITH (UPDLOCK, ROWLOCK) WHERE PetID=@pid", conn, tx))
                        {
                            getCmd.Parameters.AddWithValue("@pid", petId);
                            var obj = getCmd.ExecuteScalar();
                            qty = obj == null || obj == DBNull.Value ? 0 : Convert.ToInt32(obj);
                        }

                        if (qty <= 0)
                        {
                            tx.Rollback();
                            MessageBox.Show("This pet has no available quantity to adopt.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        using (var decCmd = new SqlCommand("UPDATE Pet_list SET Quantity = Quantity - 1 WHERE PetID=@pid AND Quantity > 0", conn, tx))
                        {
                            decCmd.Parameters.AddWithValue("@pid", petId);
                            decCmd.ExecuteNonQuery();
                        }

                        using (var updReq = new SqlCommand("UPDATE AdoptionRequests SET Status='Accepted' WHERE RequestID=@id", conn, tx))
                        {
                            updReq.Parameters.AddWithValue("@id", id.Value);
                            updReq.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }
                LoadRequests();
                MessageBox.Show("Request accepted and quantity deducted.", "Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accepting request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Reject this adoption request?", "Confirm Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            UpdateStatus("Rejected");
        }

        private void EnsureQuantityColumn(SqlConnection conn, SqlTransaction tx)
        {
            // Add Quantity column if it doesn't exist
            string checkAndAdd = @"
                IF COL_LENGTH('dbo.Pet_list','Quantity') IS NULL
                BEGIN
                    ALTER TABLE dbo.Pet_list ADD Quantity INT NOT NULL CONSTRAINT DF_Pet_list_Quantity DEFAULT(0);
                END";
            using (var cmd = new SqlCommand(checkAndAdd, conn, tx))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}


