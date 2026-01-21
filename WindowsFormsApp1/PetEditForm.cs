//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class PetEditForm : Form
//    {
//        private readonly int? _petId;
//        private readonly string _connectionString =
//            @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public PetEditForm()
//            : this(null)
//        {
//        }

//        public PetEditForm(int? petId)
//        {
//            InitializeComponent();
//            _petId = petId;
//            if (_petId.HasValue) LoadPet();
//        }

//        private void LoadPet()
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand(
//                        "SELECT * FROM Pet_list WHERE PetID=@id", conn))
//                    {
//                        cmd.Parameters.AddWithValue("@id", _petId.Value);
//                        using (var r = cmd.ExecuteReader())
//                        {
//                            if (r.Read())
//                            {
//                                txtName.Text = Convert.ToString(r["Name"]);
//                                txtType.Text = Convert.ToString(r["Type"]);
//                                txtBreed.Text = Convert.ToString(r["Breed"]);
//                                numAge.Value = SafeInt(r["Age"]);
//                                numQty.Value = SafeInt(r["Quantity"]);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading pet: " + ex.Message);
//            }
//        }

//        private int SafeInt(object o)
//        {
//            return int.TryParse(Convert.ToString(o), out int v) ? v : 0;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();

//                    if (_petId.HasValue)
//                    {
//                        // Update existing pet
//                        using (var cmd = new SqlCommand(
//                            "UPDATE Pet_list " +
//                            "SET Name=@n, Type=@t, Breed=@b, Age=@a, Quantity=@q " +
//                            "WHERE PetID=@id", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.Parameters.AddWithValue("@id", _petId.Value);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    else
//                    {
//                        // Insert new pet
//                        using (var cmd = new SqlCommand(
//                            "INSERT INTO Pet_list(Name, Type, Breed, Age, Quantity, DateAdded) " +
//                            "VALUES(@n,@t,@b,@a,@q,GETDATE())", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }

//                this.DialogResult = DialogResult.OK;
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error saving: " + ex.Message);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel;
//            Close();
//        }


//        private void label1_Click(object sender, EventArgs e)
//        {

//        }

//        private void textBox1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void PetEditForm_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class PetEditForm : Form
//    {
//        private readonly int? _petId;
//        private readonly string _connectionString =
//            @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public PetEditForm()
//            : this(null)
//        {
//        }

//        public PetEditForm(int? petId)
//        {
//            InitializeComponent();
//            _petId = petId;
//            if (_petId.HasValue) LoadPet();
//        }

//        private void LoadPet()
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand(
//                        "SELECT * FROM Pet_list WHERE PetID=@id", conn))
//                    {
//                        cmd.Parameters.AddWithValue("@id", _petId.Value);
//                        using (var r = cmd.ExecuteReader())
//                        {
//                            if (r.Read())
//                            {
//                                txtName.Text = Convert.ToString(r["Name"]);
//                                txtType.Text = Convert.ToString(r["Type"]);
//                                txtBreed.Text = Convert.ToString(r["Breed"]);
//                                numAge.Value = SafeInt(r["Age"]);
//                                numQty.Value = SafeInt(r["Quantity"]);
//                                // NEW: Load Price
//                                txtPrice.Text = Convert.ToString(r["Price"]);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading pet: " + ex.Message);
//            }
//        }

//        private int SafeInt(object o)
//        {
//            return int.TryParse(Convert.ToString(o), out int v) ? v : 0;
//        }

//        private decimal SafeDecimal(object o)
//        {
//            return decimal.TryParse(Convert.ToString(o), out decimal v) ? v : 0;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();

//                    if (_petId.HasValue)
//                    {
//                        // Update existing pet
//                        using (var cmd = new SqlCommand(
//                            "UPDATE Pet_list " +
//                            "SET Name=@n, Type=@t, Breed=@b, Age=@a, Quantity=@q, Price=@p " +
//                            "WHERE PetID=@id", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
//                            cmd.Parameters.AddWithValue("@id", _petId.Value);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    else
//                    {
//                        // Insert new pet
//                        using (var cmd = new SqlCommand(
//                            "INSERT INTO Pet_list(Name, Type, Breed, Age, Quantity, Price, DateAdded) " +
//                            "VALUES(@n,@t,@b,@a,@q,@p,GETDATE())", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }

//                this.DialogResult = DialogResult.OK;
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error saving: " + ex.Message);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel;
//            Close();
//        }

//        private void PetEditForm_Load(object sender, EventArgs e)
//        {
//            // Optional: any code on load
//        }

//        private void txtType_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void lblBreed_Click(object sender, EventArgs e)
//        {

//        }

//        private void lblName_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}
//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class PetEditForm : Form
//    {
//        private readonly int? _petId;
//        private readonly string _connectionString =
//            @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

//        public PetEditForm() : this(null) { }

//        public PetEditForm(int? petId)
//        {
//            InitializeComponent();
//            _petId = petId;
//            if (_petId.HasValue) LoadPet();
//        }

//        private void LoadPet()
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();
//                    using (var cmd = new SqlCommand(
//                        "SELECT * FROM Pet_list WHERE PetID=@id", conn))
//                    {
//                        cmd.Parameters.AddWithValue("@id", _petId.Value);
//                        using (var r = cmd.ExecuteReader())
//                        {
//                            if (r.Read())
//                            {
//                                txtName.Text = Convert.ToString(r["Name"]);
//                                txtType.Text = Convert.ToString(r["Type"]);
//                                txtBreed.Text = Convert.ToString(r["Breed"]);
//                                numAge.Value = SafeInt(r["Age"]);
//                                numQty.Value = SafeInt(r["Quantity"]);
//                                txtPrice.Text = Convert.ToString(r["Price"]);
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading pet: " + ex.Message);
//            }
//        }

//        private int SafeInt(object o) => int.TryParse(Convert.ToString(o), out int v) ? v : 0;
//        private decimal SafeDecimal(object o) => decimal.TryParse(Convert.ToString(o), out decimal v) ? v : 0;

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                using (var conn = new SqlConnection(_connectionString))
//                {
//                    conn.Open();

//                    if (_petId.HasValue)
//                    {
//                        using (var cmd = new SqlCommand(
//                            "UPDATE Pet_list SET Name=@n, Type=@t, Breed=@b, Age=@a, Quantity=@q, Price=@p WHERE PetID=@id", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
//                            cmd.Parameters.AddWithValue("@id", _petId.Value);
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                    else
//                    {
//                        using (var cmd = new SqlCommand(
//                            "INSERT INTO Pet_list(Name, Type, Breed, Age, Quantity, Price, DateAdded) VALUES(@n,@t,@b,@a,@q,@p,GETDATE())", conn))
//                        {
//                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
//                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
//                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
//                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
//                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
//                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
//                            cmd.ExecuteNonQuery();
//                        }
//                    }
//                }

//                this.DialogResult = DialogResult.OK;
//                Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error saving pet: " + ex.Message);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            this.DialogResult = DialogResult.Cancel;
//            Close();
//        }

//        // Empty event handlers to fix Designer references
//        private void lblName_Click(object sender, EventArgs e) { }
//        private void txtType_TextChanged(object sender, EventArgs e) { }
//        private void PetEditForm_Load(object sender, EventArgs e) { }

//        // Optional: expose Pet Name to VendorPetsControl
//        public new string ProductName => txtName.Text.Trim();
//    }
//}
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PetEditForm : Form
    {
        private readonly int? _petId;   // For editing existing pets
        //private readonly int _vendorId;  // Vendor ID assigned when adding
        private readonly string _connectionString =
            @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        // Constructor for adding a new pet
        public PetEditForm( )
        {
            InitializeComponent();
            //_vendorId = vendorId;
        }

        // Constructor for editing an existing pet
        public PetEditForm(int petId)
        {
            InitializeComponent();
            _petId = petId;
            //_vendorId = vendorId;
            LoadPet();
        }

        private void LoadPet()
        {
            if (!_petId.HasValue) return;

            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Corrected table: Pet_list and validate VendorID
                    using (var cmd = new SqlCommand(
                        "SELECT * FROM Pet_list WHERE PetID=@id ", conn)) //AND VendorID=@vendorId
                    {
                        cmd.Parameters.AddWithValue("@id", _petId.Value);
                        //cmd.Parameters.AddWithValue("@vendorId", _vendorId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = Convert.ToString(reader["Name"]);
                                txtType.Text = Convert.ToString(reader["Type"]);
                                txtBreed.Text = Convert.ToString(reader["Breed"]);
                                numAge.Value = SafeInt(reader["Age"]);
                                numQty.Value = SafeInt(reader["Quantity"]);
                                txtPrice.Text = Convert.ToString(reader["Price"]);
                            }
                            else
                            {
                                MessageBox.Show("Pet not found or you do not have permission to edit this pet.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pet: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int SafeInt(object o) => int.TryParse(Convert.ToString(o), out int v) ? v : 0;
        private decimal SafeDecimal(object o) => decimal.TryParse(Convert.ToString(o), out decimal v) ? v : 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    if (_petId.HasValue)
                    {
                        // Update existing pet
                        using (var cmd = new SqlCommand(
                            "UPDATE Pet_list SET Name=@n, Type=@t, Breed=@b, Age=@a, Quantity=@q, Price=@p " +
                            "WHERE PetID=@id ", conn)) //AND VendorID=@vendorId
                        {
                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
                            cmd.Parameters.AddWithValue("@id", _petId.Value);
                            //cmd.Parameters.AddWithValue("@vendorId", _vendorId);

                            int rows = cmd.ExecuteNonQuery();
                            if (rows == 0)
                                MessageBox.Show("Failed to update pet. Make sure you have permission.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Insert new pet
                        using (var cmd = new SqlCommand(
                            "INSERT INTO Pet_list(Name, Type, Breed, Age, Quantity, Price, DateAdded) " +
                            "VALUES(@n,@t,@b,@a,@q,@p,GETDATE())", conn)) //VendorID  @vendorId
                        {
                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@t", txtType.Text.Trim());
                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
                            cmd.Parameters.AddWithValue("@p", SafeDecimal(txtPrice.Text));
                            //cmd.Parameters.AddWithValue("@vendorId", _vendorId);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving pet: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PetEditForm_Load(object sender, EventArgs e)
        {
            // Optional: Initialize controls or validations
        }
    }
}

