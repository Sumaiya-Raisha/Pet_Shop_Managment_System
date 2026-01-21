using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PetAdoptionRequestForm : Form
    {
        private readonly int _userId;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";
        private DataTable _petsTable = new DataTable();

        public PetAdoptionRequestForm(int userId)
        {
            InitializeComponent();
            Theme.Apply(this);
            _userId = userId;
            LoadPets();
        }

        private void LoadPets()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Pet_list", conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        _petsTable.Clear();
                        da.Fill(_petsTable);
                        cmbPets.DisplayMember = _petsTable.Columns.Contains("PetName") ? "PetName" : _petsTable.Columns[1].ColumnName;
                        cmbPets.ValueMember = _petsTable.Columns.Contains("PetID") ? "PetID" : _petsTable.Columns[0].ColumnName;
                        cmbPets.DataSource = _petsTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureAdoptionRequestsTable(SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"
                IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdoptionRequests]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [dbo].[AdoptionRequests](
                        [RequestID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        [UserID] INT NOT NULL,
                        [PetID] INT NOT NULL,
                        [Notes] NVARCHAR(500) NULL,
                        [RequestDate] DATETIME NOT NULL DEFAULT(GETDATE()),
                        [Status] NVARCHAR(50) NOT NULL DEFAULT('Pending')
                    );
                END";
            using (var cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbPets.SelectedValue == null)
            {
                MessageBox.Show("Please select a pet.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        EnsureAdoptionRequestsTable(conn, tx);

                        using (var cmd = new SqlCommand(@"
                            INSERT INTO AdoptionRequests(UserID, PetID, Notes)
                            VALUES (@UserID, @PetID, @Notes);", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@UserID", _userId);
                            cmd.Parameters.AddWithValue("@PetID", cmbPets.SelectedValue);
                            cmd.Parameters.AddWithValue("@Notes", (object)(txtNotes.Text ?? string.Empty));
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Adoption request submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting request: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


