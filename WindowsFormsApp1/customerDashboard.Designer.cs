namespace WindowsFormsApp1
{
    partial class customerDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
        private Guna.UI2.WinForms.Guna2Panel navPanel;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;

        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;

        private Guna.UI2.WinForms.Guna2DragControl dragControl;

        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnOrders;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.DataGridView dgvItems;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.Label lblCartInfo;
        private Guna.UI2.WinForms.Guna2Button btnViewCart;
        private System.Windows.Forms.Label lblInstructions;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();

            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();

            this.navPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrders = new Guna.UI2.WinForms.Guna2Button();
            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();

            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.lblCartInfo = new System.Windows.Forms.Label();
            this.btnViewCart = new Guna.UI2.WinForms.Guna2Button();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);

            this.SuspendLayout();

            // ===== Form Settings =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "customerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard";
            this.MinimumSize = new System.Drawing.Size(1000, 600);

            // ===== Top Panel =====
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.FillColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.topPanel.FillColor2 = System.Drawing.Color.FromArgb(255, 255, 255);
            this.topPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.topPanel.Size = new System.Drawing.Size(1200, 80);
            this.topPanel.ShadowDecoration.Enabled = true;
            this.topPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.topPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);

            // ===== Title Label =====
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Text = "🛍️ Pet Shop";

            // ===== Welcome Label =====
            this.lblWelcome.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Location = new System.Drawing.Point(950, 30);
            this.lblWelcome.Text = "Welcome, User";

            // ===== Control Boxes =====
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.Black;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.IconColor = System.Drawing.Color.Black;
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);

            this.btnClose.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnClose.IconColor = System.Drawing.Color.Black;

            // Add controls to topPanel (right-docked order: Close, Maximize, Minimize)
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.btnMaximize);
            this.topPanel.Controls.Add(this.btnMinimize);
            this.topPanel.Controls.Add(this.lblWelcome);
            this.topPanel.Controls.Add(this.lblTitle);

            // ===== Navigation Panel =====
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.FillColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.navPanel.Size = new System.Drawing.Size(280, 720);
            this.navPanel.ShadowDecoration.Enabled = true;
            this.navPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);
            this.navPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.navPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);

            //Buttons(Home, Orders, Profile, Adoption Pet)
            SetupNavButton(this.btnHome, "🏠 Home", 50);
            SetupNavButton(this.btnOrders, "📋 Order History", 120);
            SetupNavButton(this.btnProfile, "👤 Profile", 190);
            SetupNavButton(this.btnSettings, "🐾 Adoption Pet", 260);
            SetupNavButton(this.btnBack, "← Back", 330);


            // Wire up event handlers
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.navPanel.Controls.Add(this.btnHome);
            this.navPanel.Controls.Add(this.btnOrders);
            this.navPanel.Controls.Add(this.btnProfile);
            this.navPanel.Controls.Add(this.btnBack);
            this.navPanel.Controls.Add(this.btnSettings);

            // ===== Content Panel =====
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.contentPanel.ShadowDecoration.Enabled = false;
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
            // Filters
            this.cbCategory.BorderRadius = 12;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.ItemHeight = 30;
            this.cbCategory.Size = new System.Drawing.Size(200, 40);
            this.cbCategory.Location = new System.Drawing.Point(280, 20);
            this.cbCategory.FillColor = System.Drawing.Color.White;
            this.cbCategory.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.cbCategory.Items.AddRange(new object[] { "All", "Pet", "Pet Products", "Pet Toys" });

            this.txtSearch.BorderRadius = 12;
            this.txtSearch.PlaceholderText = "🔍 Search products...";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.Location = new System.Drawing.Point(500, 20);
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230);

            this.btnSearch.BorderRadius = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.Location = new System.Drawing.Point(820, 20);
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Cart Info Label
            this.lblCartInfo.AutoSize = true;
            this.lblCartInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartInfo.ForeColor = System.Drawing.Color.Black;
            this.lblCartInfo.Location = new System.Drawing.Point(20, 740);
            this.lblCartInfo.Text = "🛒 Cart: 0 items - $0.00";

            // Instructions Label
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInstructions.Location = new System.Drawing.Point(20, 100);
            this.lblInstructions.Text = "💡 Double-click on any product to add it to your cart";

            // View Cart Button
            this.btnViewCart.BorderRadius = 12;
            this.btnViewCart.Text = "🛒 View Cart";
            this.btnViewCart.Size = new System.Drawing.Size(140, 40);
            this.btnViewCart.Location = new System.Drawing.Point(960, 20);
            this.btnViewCart.FillColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnViewCart.ForeColor = System.Drawing.Color.White;
            this.btnViewCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);


            // Grid - Responsive Design
            this.dgvItems.Location = new System.Drawing.Point(20, 120);
            this.dgvItems.Size = new System.Drawing.Size(1100, 600);
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvItems.ColumnHeadersHeight = 50;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.dgvItems.RowTemplate.Height = 50;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);
            this.dgvItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.dgvItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvItems.ShowCellToolTips = true;

            this.contentPanel.Controls.Add(this.cbCategory);
            this.contentPanel.Controls.Add(this.txtSearch);
            this.contentPanel.Controls.Add(this.btnSearch);
            this.contentPanel.Controls.Add(this.lblInstructions);
            this.contentPanel.Controls.Add(this.btnViewCart);
            this.contentPanel.Controls.Add(this.dgvItems);
            this.contentPanel.Controls.Add(this.lblCartInfo);

            // ===== Drag Control (for moving borderless form) =====
            this.dragControl.TargetControl = this.topPanel;
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.UseTransparentDrag = true;

            // ===== Add panels to form =====
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.navPanel);
            this.Controls.Add(this.topPanel);

            this.ResumeLayout(false);
        }

        protected void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, int top)
        {
            btn.Text = text;
            btn.Size = new System.Drawing.Size(220, 50);
            btn.Location = new System.Drawing.Point(15, top);
            btn.BorderRadius = 15;
            btn.FillColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
            btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);

            // Ensure button is enabled and visible
            btn.Enabled = true;
            btn.Visible = true;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion
    }
}
//namespace WindowsFormsApp1
//{
//    partial class customerDashboard
//    {
//        private System.ComponentModel.IContainer components = null;

//        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
//        private Guna.UI2.WinForms.Guna2Panel navPanel;
//        private Guna.UI2.WinForms.Guna2Panel contentPanel;

//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblWelcome;

//        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
//        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
//        private Guna.UI2.WinForms.Guna2ControlBox btnClose;

//        private Guna.UI2.WinForms.Guna2DragControl dragControl;

//        private Guna.UI2.WinForms.Guna2Button btnHome;
//        private Guna.UI2.WinForms.Guna2Button btnOrders;
//        private Guna.UI2.WinForms.Guna2Button btnProfile;
//        private Guna.UI2.WinForms.Guna2Button btnSettings;
//        private Guna.UI2.WinForms.Guna2Button btnBack;
//        private System.Windows.Forms.DataGridView dgvItems;
//        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
//        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
//        private Guna.UI2.WinForms.Guna2Button btnSearch;
//        private System.Windows.Forms.Label lblCartInfo;
//        private Guna.UI2.WinForms.Guna2Button btnViewCart;
//        private System.Windows.Forms.Label lblInstructions;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblWelcome = new System.Windows.Forms.Label();

//            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
//            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
//            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();

//            this.navPanel = new Guna.UI2.WinForms.Guna2Panel();
//            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
//            this.btnOrders = new Guna.UI2.WinForms.Guna2Button();
//            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
//            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
//            this.btnBack = new Guna.UI2.WinForms.Guna2Button();

//            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
//            this.dgvItems = new System.Windows.Forms.DataGridView();
//            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
//            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
//            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
//            this.lblCartInfo = new System.Windows.Forms.Label();
//            this.btnViewCart = new Guna.UI2.WinForms.Guna2Button();
//            this.lblInstructions = new System.Windows.Forms.Label();
//            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);

//            this.SuspendLayout();

//            // ===== Form Settings =====
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
//            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            this.ClientSize = new System.Drawing.Size(1400, 800);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Name = "customerDashboard";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Customer Dashboard";
//            this.MinimumSize = new System.Drawing.Size(1000, 600);

//            // ===== Top Panel =====
//            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
//            this.topPanel.FillColor = System.Drawing.Color.White;
//            this.topPanel.FillColor2 = System.Drawing.Color.White;
//            this.topPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
//            this.topPanel.Size = new System.Drawing.Size(1200, 80);
//            this.topPanel.ShadowDecoration.Enabled = true;
//            this.topPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 5);
//            this.topPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);

//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.ForeColor = System.Drawing.Color.Black;
//            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
//            this.lblTitle.Location = new System.Drawing.Point(30, 25);
//            this.lblTitle.Text = "🛍️ Pet Shop";

//            this.lblWelcome.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
//            this.lblWelcome.AutoSize = true;
//            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
//            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
//            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
//            this.lblWelcome.Location = new System.Drawing.Point(950, 30);
//            this.lblWelcome.Text = "Welcome, User";

//            // Control boxes
//            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
//            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
//            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
//            this.btnMinimize.IconColor = System.Drawing.Color.Black;
//            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);

//            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
//            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
//            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
//            this.btnMaximize.IconColor = System.Drawing.Color.Black;
//            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);

//            this.btnClose.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;
//            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
//            this.btnClose.FillColor = System.Drawing.Color.Transparent;
//            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
//            this.btnClose.IconColor = System.Drawing.Color.Black;

//            this.topPanel.Controls.Add(this.btnClose);
//            this.topPanel.Controls.Add(this.btnMaximize);
//            this.topPanel.Controls.Add(this.btnMinimize);
//            this.topPanel.Controls.Add(this.lblWelcome);
//            this.topPanel.Controls.Add(this.lblTitle);

//            // ===== Navigation Panel =====
//            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
//            this.navPanel.FillColor = System.Drawing.Color.White;
//            this.navPanel.Size = new System.Drawing.Size(280, 720);

//            // Initialize buttons safely
//            InitializeNavButtons();

//            this.navPanel.Controls.Add(this.btnHome);
//            this.navPanel.Controls.Add(this.btnOrders);
//            this.navPanel.Controls.Add(this.btnProfile);
//            this.navPanel.Controls.Add(this.btnSettings);
//            this.navPanel.Controls.Add(this.btnBack);

//            // ===== Content Panel =====
//            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);

//            // Filters
//            this.cbCategory.BorderRadius = 12;
//            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
//            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cbCategory.ItemHeight = 30;
//            this.cbCategory.Size = new System.Drawing.Size(200, 40);
//            this.cbCategory.Location = new System.Drawing.Point(280, 20);
//            this.cbCategory.FillColor = System.Drawing.Color.White;
//            this.cbCategory.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230);
//            this.cbCategory.Items.AddRange(new object[] { "All", "Pet", "Pet Products", "Pet Toys" });

//            this.txtSearch.BorderRadius = 12;
//            this.txtSearch.PlaceholderText = "🔍 Search products...";
//            this.txtSearch.Size = new System.Drawing.Size(300, 40);
//            this.txtSearch.Location = new System.Drawing.Point(500, 20);
//            this.txtSearch.FillColor = System.Drawing.Color.White;
//            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(222, 226, 230);

//            this.btnSearch.BorderRadius = 12;
//            this.btnSearch.Text = "Search";
//            this.btnSearch.Size = new System.Drawing.Size(120, 40);
//            this.btnSearch.Location = new System.Drawing.Point(820, 20);
//            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
//            this.btnSearch.ForeColor = System.Drawing.Color.White;
//            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

//            this.lblCartInfo.AutoSize = true;
//            this.lblCartInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.lblCartInfo.ForeColor = System.Drawing.Color.Black;
//            this.lblCartInfo.Location = new System.Drawing.Point(20, 740);
//            this.lblCartInfo.Text = "🛒 Cart: 0 items - $0.00";

//            this.lblInstructions.AutoSize = true;
//            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
//            this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
//            this.lblInstructions.Location = new System.Drawing.Point(20, 100);
//            this.lblInstructions.Text = "💡 Double-click on any product to add it to your cart";

//            this.btnViewCart.BorderRadius = 12;
//            this.btnViewCart.Text = "🛒 View Cart";
//            this.btnViewCart.Size = new System.Drawing.Size(140, 40);
//            this.btnViewCart.Location = new System.Drawing.Point(960, 20);
//            this.btnViewCart.FillColor = System.Drawing.Color.FromArgb(40, 167, 69);
//            this.btnViewCart.ForeColor = System.Drawing.Color.White;
//            this.btnViewCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
//            this.btnViewCart.Click += new System.EventHandler(this.btnViewCart_Click);

//            // Grid
//            this.dgvItems.Location = new System.Drawing.Point(20, 120);
//            this.dgvItems.Size = new System.Drawing.Size(1100, 600);
//            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvItems.RowHeadersVisible = false;
//            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
//            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
//            this.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
//            this.dgvItems.ColumnHeadersHeight = 50;
//            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
//            this.dgvItems.EnableHeadersVisualStyles = false;
//            this.dgvItems.GridColor = System.Drawing.Color.FromArgb(222, 226, 230);
//            this.dgvItems.RowTemplate.Height = 50;
//            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellDoubleClick);
//            this.dgvItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(40, 167, 69);
//            this.dgvItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
//            this.dgvItems.ShowCellToolTips = true;

//            this.contentPanel.Controls.Add(this.cbCategory);
//            this.contentPanel.Controls.Add(this.txtSearch);
//            this.contentPanel.Controls.Add(this.btnSearch);
//            this.contentPanel.Controls.Add(this.lblInstructions);
//            this.contentPanel.Controls.Add(this.btnViewCart);
//            this.contentPanel.Controls.Add(this.dgvItems);
//            this.contentPanel.Controls.Add(this.lblCartInfo);

//            // Drag control
//            this.dragControl.TargetControl = this.topPanel;
//            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
//            this.dragControl.UseTransparentDrag = true;

//            // Add panels
//            this.Controls.Add(this.contentPanel);
//            this.Controls.Add(this.navPanel);
//            this.Controls.Add(this.topPanel);

//            this.ResumeLayout(false);
//        }

//        /// <summary>
//        /// Initialize navigation buttons safely (designer-friendly)
//        /// </summary>
//        private void InitializeNavButtons()
//        {
//            SetupNavButton(this.btnHome, "🏠 Home", 50);
//            SetupNavButton(this.btnOrders, "📋 Order History", 120);
//            SetupNavButton(this.btnProfile, "👤 Profile", 190);
//            SetupNavButton(this.btnSettings, "🐾 Adoption Pet", 260);
//            SetupNavButton(this.btnBack, "← Back", 330);

//            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
//            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
//            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
//            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
//            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
//        }

//        /// <summary>
//        /// Designer-safe button setup
//        /// </summary>
//        private void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, int top)
//        {
//            if (btn == null) return; // Safe guard
//            btn.Text = text;
//            btn.Size = new System.Drawing.Size(220, 50);
//            btn.Location = new System.Drawing.Point(15, top);
//            btn.BorderRadius = 15;
//            btn.FillColor = System.Drawing.Color.Transparent;
//            btn.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
//            btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
//            btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
//            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
//            btn.Enabled = true;
//            btn.Visible = true;
//            btn.Cursor = System.Windows.Forms.Cursors.Hand;
//        }

//        #endregion
//    }
//}

// 333333
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    partial class customerDashboard
//    {
//        private System.ComponentModel.IContainer components = null;

//        // Panels
//        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
//        private Guna.UI2.WinForms.Guna2Panel navPanel;
//        private Guna.UI2.WinForms.Guna2Panel contentPanel;

//        // Top panel controls
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label lblWelcome;
//        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
//        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
//        private Guna.UI2.WinForms.Guna2ControlBox btnClose;

//        // Navigation buttons
//        private Guna.UI2.WinForms.Guna2Button btnHome;
//        private Guna.UI2.WinForms.Guna2Button btnOrders;
//        private Guna.UI2.WinForms.Guna2Button btnProfile;
//        private Guna.UI2.WinForms.Guna2Button btnSettings;
//        private Guna.UI2.WinForms.Guna2Button btnBack;

//        // Content controls
//        private System.Windows.Forms.DataGridView dgvItems;
//        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
//        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
//        private Guna.UI2.WinForms.Guna2Button btnSearch;
//        private Guna.UI2.WinForms.Guna2Button btnViewCart;
//        private System.Windows.Forms.Label lblCartInfo;
//        private System.Windows.Forms.Label lblInstructions;

//        // Drag control
//        private Guna.UI2.WinForms.Guna2DragControl dragControl;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null)) components.Dispose();
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();

//            // ===== Panels =====
//            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
//            this.navPanel = new Guna.UI2.WinForms.Guna2Panel();
//            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();

//            // ===== Top panel controls =====
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.lblWelcome = new System.Windows.Forms.Label();
//            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
//            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
//            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();

//            // ===== Navigation buttons =====
//            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
//            this.btnOrders = new Guna.UI2.WinForms.Guna2Button();
//            this.btnProfile = new Guna.UI2.WinForms.Guna2Button();
//            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
//            this.btnBack = new Guna.UI2.WinForms.Guna2Button();

//            // ===== Content controls =====
//            this.dgvItems = new System.Windows.Forms.DataGridView();
//            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
//            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
//            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
//            this.btnViewCart = new Guna.UI2.WinForms.Guna2Button();
//            this.lblCartInfo = new System.Windows.Forms.Label();
//            this.lblInstructions = new System.Windows.Forms.Label();

//            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);

//            // ===== Form settings =====
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
//            this.ClientSize = new System.Drawing.Size(1400, 800);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Customer Dashboard";

//            // ===== Top Panel =====
//            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
//            this.topPanel.FillColor = System.Drawing.Color.White;
//            this.topPanel.FillColor2 = System.Drawing.Color.White;
//            this.topPanel.Size = new System.Drawing.Size(1400, 80);
//            this.topPanel.ShadowDecoration.Enabled = true;
//            this.topPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 5);

//            // ===== Title & Welcome =====
//            this.lblTitle.Text = "🛍️ Pet Shop";
//            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
//            this.lblTitle.Location = new System.Drawing.Point(30, 25);

//            this.lblWelcome.Text = "Welcome, User";
//            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
//            this.lblWelcome.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
//            this.lblWelcome.Location = new System.Drawing.Point(950, 30);

//            // ===== Control Boxes =====
//            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
//            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
//            this.btnClose.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;

//            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
//            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
//            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;

//            this.topPanel.Controls.Add(this.btnClose);
//            this.topPanel.Controls.Add(this.btnMaximize);
//            this.topPanel.Controls.Add(this.btnMinimize);
//            this.topPanel.Controls.Add(this.lblWelcome);
//            this.topPanel.Controls.Add(this.lblTitle);

//            // ===== Navigation Panel =====
//            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
//            this.navPanel.Size = new System.Drawing.Size(280, 720);

//            // Setup navigation buttons
//            SetupNavButton(this.btnHome, "🏠 Home", 50);
//            SetupNavButton(this.btnOrders, "📋 Order History", 120);
//            SetupNavButton(this.btnProfile, "👤 Profile", 190);
//            SetupNavButton(this.btnSettings, "🐾 Adoption Pet", 260);
//            SetupNavButton(this.btnBack, "← Back", 330);

//            this.navPanel.Controls.AddRange(new Control[] {
//                this.btnHome, this.btnOrders, this.btnProfile, this.btnSettings, this.btnBack
//            });

//            // ===== Content Panel =====
//            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);
//            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);

//            // Category combobox
//            this.cbCategory.Size = new System.Drawing.Size(200, 40);
//            this.cbCategory.Location = new System.Drawing.Point(280, 20);
//            this.cbCategory.BorderRadius = 12;
//            this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
//            this.cbCategory.Items.AddRange(new object[] { "All", "Pet", "Pet Products", "Pet Toys" });

//            // Search textbox
//            this.txtSearch.Size = new System.Drawing.Size(300, 40);
//            this.txtSearch.Location = new System.Drawing.Point(500, 20);
//            this.txtSearch.BorderRadius = 12;
//            this.txtSearch.PlaceholderText = "🔍 Search products...";

//            // Search button
//            this.btnSearch.Size = new System.Drawing.Size(120, 40);
//            this.btnSearch.Location = new System.Drawing.Point(820, 20);
//            this.btnSearch.Text = "Search";
//            this.btnSearch.BorderRadius = 12;
//            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
//            this.btnSearch.ForeColor = System.Drawing.Color.White;

//            // Cart info & view button
//            this.lblCartInfo.AutoSize = true;
//            this.lblCartInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
//            this.lblCartInfo.Location = new System.Drawing.Point(20, 740);
//            this.lblCartInfo.Text = "🛒 Cart: 0 items - $0.00";

//            this.btnViewCart.Size = new System.Drawing.Size(140, 40);
//            this.btnViewCart.Location = new System.Drawing.Point(960, 20);
//            this.btnViewCart.Text = "🛒 View Cart";
//            this.btnViewCart.FillColor = System.Drawing.Color.FromArgb(40, 167, 69);
//            this.btnViewCart.ForeColor = System.Drawing.Color.White;
//            this.btnViewCart.BorderRadius = 12;

//            // Instructions label
//            this.lblInstructions.Text = "💡 Double-click on any product to add it to your cart";
//            this.lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
//            this.lblInstructions.Location = new System.Drawing.Point(20, 100);

//            // DataGridView
//            this.dgvItems.Location = new System.Drawing.Point(20, 120);
//            this.dgvItems.Size = new System.Drawing.Size(1100, 600);
//            this.dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
//            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvItems.RowHeadersVisible = false;

//            // Add controls to content panel
//            this.contentPanel.Controls.AddRange(new Control[] {
//                this.cbCategory, this.txtSearch, this.btnSearch,
//                this.lblInstructions, this.btnViewCart, this.dgvItems, this.lblCartInfo
//            });

//            // ===== Drag control =====
//            this.dragControl.TargetControl = this.topPanel;

//            // ===== Add panels to form =====
//            this.Controls.Add(this.contentPanel);
//            this.Controls.Add(this.navPanel);
//            this.Controls.Add(this.topPanel);

//            this.ResumeLayout(false);
//        }

//        private void SetupNavButton(Guna.UI2.WinForms.Guna2Button btn, string text, int top)
//        {
//            btn.Text = text;
//            btn.Size = new System.Drawing.Size(220, 50);
//            btn.Location = new System.Drawing.Point(15, top);
//            btn.BorderRadius = 15;
//            btn.FillColor = System.Drawing.Color.Transparent;
//            btn.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
//            btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
//            btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
//            btn.HoverState.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
//            btn.HoverState.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
//            btn.Enabled = true;
//            btn.Visible = true;
//            btn.Cursor = Cursors.Hand;
//        }
//    }
//}

