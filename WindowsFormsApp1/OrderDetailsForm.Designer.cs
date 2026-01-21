namespace WindowsFormsApp1
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;

        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private Guna.UI2.WinForms.Guna2Button btnCloseForm;
        private Guna.UI2.WinForms.Guna2Button btnPrint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();

            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.btnCloseForm = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);

            this.SuspendLayout();

            // ===== Form Settings =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Details";
            this.MinimumSize = new System.Drawing.Size(800, 600);

            // ===== Top Panel =====
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.FillColor = System.Drawing.Color.White;
            this.topPanel.FillColor2 = System.Drawing.Color.White;
            this.topPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.topPanel.Size = new System.Drawing.Size(900, 60);
            this.topPanel.ShadowDecoration.Enabled = true;
            this.topPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);

            // ===== Title Label =====
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "📄 Order Details";

            // ===== Control Boxes =====
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.Black;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);

            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.IconColor = System.Drawing.Color.Black;
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);

            this.btnClose.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnClose.IconColor = System.Drawing.Color.Black;

            // Add controls to topPanel
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.btnMaximize);
            this.topPanel.Controls.Add(this.btnMinimize);
            this.topPanel.Controls.Add(this.lblTitle);

            // ===== Content Panel =====
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.contentPanel.ShadowDecoration.Enabled = false;
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);

            // ===== Order Information Labels =====
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderId.ForeColor = System.Drawing.Color.Black;
            this.lblOrderId.Location = new System.Drawing.Point(20, 20);
            this.lblOrderId.Text = "Order ID: #";

            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblOrderDate.ForeColor = System.Drawing.Color.Black;
            this.lblOrderDate.Location = new System.Drawing.Point(20, 50);
            this.lblOrderDate.Text = "Order Date: ";

            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 80);
            this.lblTotalAmount.Text = "Total Amount: $";

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(20, 110);
            this.lblStatus.Text = "Status: ";

            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblShippingAddress.ForeColor = System.Drawing.Color.Black;
            this.lblShippingAddress.Location = new System.Drawing.Point(20, 140);
            this.lblShippingAddress.Text = "Shipping Address: ";

            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblPaymentMethod.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 170);
            this.lblPaymentMethod.Text = "Payment Method: ";

            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblNotes.ForeColor = System.Drawing.Color.Black;
            this.lblNotes.Location = new System.Drawing.Point(20, 200);
            this.lblNotes.Text = "Notes: ";
            this.lblNotes.Visible = false;

            // ===== Data Grid View =====
            this.dgvOrderItems.Location = new System.Drawing.Point(20, 240);
            this.dgvOrderItems.Size = new System.Drawing.Size(840, 350);
            this.dgvOrderItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.RowHeadersVisible = false;
            this.dgvOrderItems.ReadOnly = true;
            this.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrderItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrderItems.ColumnHeadersHeight = 40;
            this.dgvOrderItems.EnableHeadersVisualStyles = false;
            this.dgvOrderItems.GridColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.dgvOrderItems.RowTemplate.Height = 35;
            this.dgvOrderItems.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.dgvOrderItems.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvOrderItems.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            // ===== Buttons =====
            this.btnPrint.BorderRadius = 8;
            this.btnPrint.Text = "🖨️ Print";
            this.btnPrint.Size = new System.Drawing.Size(120, 40);
            this.btnPrint.Location = new System.Drawing.Point(20, 610);
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            this.btnCloseForm.BorderRadius = 8;
            this.btnCloseForm.Text = "❌ Close";
            this.btnCloseForm.Size = new System.Drawing.Size(100, 40);
            this.btnCloseForm.Location = new System.Drawing.Point(160, 610);
            this.btnCloseForm.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.Click += new System.EventHandler(this.btnClose_Click);

            // Add controls to content panel
            this.contentPanel.Controls.Add(this.lblOrderId);
            this.contentPanel.Controls.Add(this.lblOrderDate);
            this.contentPanel.Controls.Add(this.lblTotalAmount);
            this.contentPanel.Controls.Add(this.lblStatus);
            this.contentPanel.Controls.Add(this.lblShippingAddress);
            this.contentPanel.Controls.Add(this.lblPaymentMethod);
            this.contentPanel.Controls.Add(this.lblNotes);
            this.contentPanel.Controls.Add(this.dgvOrderItems);
            this.contentPanel.Controls.Add(this.btnPrint);
            this.contentPanel.Controls.Add(this.btnCloseForm);

            // ===== Drag Control =====
            this.dragControl.TargetControl = this.topPanel;
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.UseTransparentDrag = true;

            // ===== Add panels to form =====
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);

            this.ResumeLayout(false);
        }
    }
}
