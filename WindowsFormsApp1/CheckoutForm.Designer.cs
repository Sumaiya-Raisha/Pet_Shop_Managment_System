namespace WindowsFormsApp1
{
    partial class CheckoutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;

        private System.Windows.Forms.DataGridView dgvCartItems;
        private System.Windows.Forms.Label lblTotalAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtShippingAddress;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPaymentMethod;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2Button btnPlaceOrder;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblCartItems;
        private Guna.UI2.WinForms.Guna2Button btnClearCart;
        private Guna.UI2.WinForms.Guna2Button btnIncreaseQuantity;
        private Guna.UI2.WinForms.Guna2Button btnDecreaseQuantity;
        private System.Windows.Forms.Label lblQuantityInstructions;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCartItems = new System.Windows.Forms.Label();
            this.dgvCartItems = new System.Windows.Forms.DataGridView();
            this.lblQuantityInstructions = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnClearCart = new Guna.UI2.WinForms.Guna2Button();
            this.btnIncreaseQuantity = new Guna.UI2.WinForms.Guna2Button();
            this.btnDecreaseQuantity = new Guna.UI2.WinForms.Guna2Button();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.txtShippingAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPlaceOrder = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.topPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.btnMaximize);
            this.topPanel.Controls.Add(this.btnMinimize);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.FillColor = System.Drawing.Color.White;
            this.topPanel.FillColor2 = System.Drawing.Color.White;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(10)))));
            this.topPanel.ShadowDecoration.Enabled = true;
            this.topPanel.Size = new System.Drawing.Size(800, 60);
            this.topPanel.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(665, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 60);
            this.btnClose.TabIndex = 0;
            // 
            // btnMaximize
            // 
            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnMaximize.IconColor = System.Drawing.Color.Black;
            this.btnMaximize.Location = new System.Drawing.Point(710, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(45, 60);
            this.btnMaximize.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnMinimize.IconColor = System.Drawing.Color.Black;
            this.btnMinimize.Location = new System.Drawing.Point(755, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 60);
            this.btnMinimize.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 32);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Checkout";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.SeaShell;
            this.contentPanel.Controls.Add(this.lblCartItems);
            this.contentPanel.Controls.Add(this.dgvCartItems);
            this.contentPanel.Controls.Add(this.lblQuantityInstructions);
            this.contentPanel.Controls.Add(this.lblTotalAmount);
            this.contentPanel.Controls.Add(this.btnClearCart);
            this.contentPanel.Controls.Add(this.btnIncreaseQuantity);
            this.contentPanel.Controls.Add(this.btnDecreaseQuantity);
            this.contentPanel.Controls.Add(this.lblShippingAddress);
            this.contentPanel.Controls.Add(this.txtShippingAddress);
            this.contentPanel.Controls.Add(this.lblPaymentMethod);
            this.contentPanel.Controls.Add(this.cmbPaymentMethod);
            this.contentPanel.Controls.Add(this.lblNotes);
            this.contentPanel.Controls.Add(this.txtNotes);
            this.contentPanel.Controls.Add(this.btnPlaceOrder);
            this.contentPanel.Controls.Add(this.btnCancel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.FillColor = System.Drawing.Color.White;
            this.contentPanel.Location = new System.Drawing.Point(0, 60);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.ShadowDecoration.Enabled = true;
            this.contentPanel.Size = new System.Drawing.Size(800, 540);
            this.contentPanel.TabIndex = 0;
            // 
            // lblCartItems
            // 
            this.lblCartItems.AutoSize = true;
            this.lblCartItems.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartItems.ForeColor = System.Drawing.Color.Black;
            this.lblCartItems.Location = new System.Drawing.Point(20, 20);
            this.lblCartItems.Name = "lblCartItems";
            this.lblCartItems.Size = new System.Drawing.Size(110, 28);
            this.lblCartItems.TabIndex = 0;
            this.lblCartItems.Text = "Cart Items";
            // 
            // dgvCartItems
            // 
            this.dgvCartItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCartItems.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvCartItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCartItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCartItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCartItems.ColumnHeadersHeight = 40;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCartItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCartItems.EnableHeadersVisualStyles = false;
            this.dgvCartItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvCartItems.Location = new System.Drawing.Point(20, 50);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.ReadOnly = true;
            this.dgvCartItems.RowHeadersVisible = false;
            this.dgvCartItems.RowHeadersWidth = 51;
            this.dgvCartItems.RowTemplate.Height = 35;
            this.dgvCartItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartItems.Size = new System.Drawing.Size(760, 200);
            this.dgvCartItems.TabIndex = 1;
            this.dgvCartItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCartItems_DataError);
            this.dgvCartItems.SelectionChanged += new System.EventHandler(this.dgvCartItems_SelectionChanged);
            // 
            // lblQuantityInstructions
            // 
            this.lblQuantityInstructions.AutoSize = true;
            this.lblQuantityInstructions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblQuantityInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblQuantityInstructions.Location = new System.Drawing.Point(12, 250);
            this.lblQuantityInstructions.Name = "lblQuantityInstructions";
            this.lblQuantityInstructions.Size = new System.Drawing.Size(372, 20);
            this.lblQuantityInstructions.TabIndex = 2;
            this.lblQuantityInstructions.Text = "💡 Select an item and use +/- buttons to adjust quantity";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 270);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(147, 32);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "Total: $0.00";
            // 
            // btnClearCart
            // 
            this.btnClearCart.BorderRadius = 8;
            this.btnClearCart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(584, 20);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(120, 40);
            this.btnClearCart.TabIndex = 4;
            this.btnClearCart.Text = "🗑️ Clear Cart";
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // btnIncreaseQuantity
            // 
            this.btnIncreaseQuantity.BorderRadius = 6;
            this.btnIncreaseQuantity.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnIncreaseQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIncreaseQuantity.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseQuantity.Location = new System.Drawing.Point(750, 20);
            this.btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            this.btnIncreaseQuantity.Size = new System.Drawing.Size(30, 30);
            this.btnIncreaseQuantity.TabIndex = 5;
            this.btnIncreaseQuantity.Text = "+";
            this.btnIncreaseQuantity.Click += new System.EventHandler(this.btnIncreaseQuantity_Click);
            // 
            // btnDecreaseQuantity
            // 
            this.btnDecreaseQuantity.BorderRadius = 6;
            this.btnDecreaseQuantity.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDecreaseQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecreaseQuantity.ForeColor = System.Drawing.Color.White;
            this.btnDecreaseQuantity.Location = new System.Drawing.Point(710, 20);
            this.btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            this.btnDecreaseQuantity.Size = new System.Drawing.Size(30, 30);
            this.btnDecreaseQuantity.TabIndex = 6;
            this.btnDecreaseQuantity.Text = "-";
            this.btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblShippingAddress.ForeColor = System.Drawing.Color.Black;
            this.lblShippingAddress.Location = new System.Drawing.Point(20, 320);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(157, 23);
            this.lblShippingAddress.TabIndex = 7;
            this.lblShippingAddress.Text = "Shipping Address:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.txtShippingAddress.BorderRadius = 8;
            this.txtShippingAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShippingAddress.DefaultText = "";
            this.txtShippingAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtShippingAddress.ForeColor = System.Drawing.Color.Black;
            this.txtShippingAddress.Location = new System.Drawing.Point(20, 350);
            this.txtShippingAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.PlaceholderText = "Enter your shipping address here...";
            this.txtShippingAddress.SelectedText = "";
            this.txtShippingAddress.Size = new System.Drawing.Size(400, 36);
            this.txtShippingAddress.TabIndex = 8;
            this.txtShippingAddress.Enter += new System.EventHandler(this.txtShippingAddress_Enter);
            this.txtShippingAddress.Leave += new System.EventHandler(this.txtShippingAddress_Leave);
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 400);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(153, 23);
            this.lblPaymentMethod.TabIndex = 9;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cmbPaymentMethod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.cmbPaymentMethod.BorderRadius = 8;
            this.cmbPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FocusedColor = System.Drawing.Color.Empty;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.cmbPaymentMethod.ItemHeight = 30;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(20, 430);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(200, 36);
            this.cmbPaymentMethod.TabIndex = 10;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotes.ForeColor = System.Drawing.Color.Black;
            this.lblNotes.Location = new System.Drawing.Point(20, 480);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(148, 23);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notes (Optional):";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.txtNotes.BorderRadius = 8;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.Location = new System.Drawing.Point(20, 510);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "Any special instructions...";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(400, 36);
            this.txtNotes.TabIndex = 12;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BorderRadius = 8;
            this.btnPlaceOrder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(255)))));
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlaceOrder.ForeColor = System.Drawing.Color.White;
            this.btnPlaceOrder.Location = new System.Drawing.Point(500, 500);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(150, 40);
            this.btnPlaceOrder.TabIndex = 13;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(680, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dragControl
            // 
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.TargetControl = this.topPanel;
            this.dragControl.UseTransparentDrag = true;
            // 
            // CheckoutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CheckoutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
