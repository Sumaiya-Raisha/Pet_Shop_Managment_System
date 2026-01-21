using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorDashboard : Form
    {
        private readonly int _vendorId;
        private readonly string _username;

        public VendorDashboard()
        {
            InitializeComponent();
            Theme.Apply(this);
            _vendorId = 0;
            _username = string.Empty;
            lblWelcome.Text = "Welcome";
        }

        public VendorDashboard(int vendorId, string username)
        {
            InitializeComponent();
            Theme.Apply(this);

            _vendorId = vendorId;
            _username = username ?? string.Empty;

            lblWelcome.Text = $"Welcome, {_username}";
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Products";
            contentPanel.Controls.Clear();
            // Pass vendorId to controls that need vendor lookup
            var products = new ProductsManagement(_vendorId, _username);
            products.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(products);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Orders";
            contentPanel.Controls.Clear();
            var orders = new VendorOrdersControl(_vendorId, _username);
            orders.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(orders);
        }

        private void btnManagePets_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Manage Pets";
            contentPanel.Controls.Clear();
            var pets = new VendorPetsControl(_vendorId, _username);
            pets.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(pets);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Profile - {_username}";
            using (var profile = new VendorProfileForm(_vendorId, _username))
            {
                profile.ShowDialog(this);
            }
        }

        private void btnAdoptionRequests_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Adoption Requests";
            contentPanel.Controls.Clear();
            var requests = new VendorAdoptionRequestsControl(_vendorId, _username);
            requests.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(requests);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
