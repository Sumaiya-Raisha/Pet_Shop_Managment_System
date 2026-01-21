namespace WindowsFormsApp1
{
    partial class VendorAdoptionRequestsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView gridRequests;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel panelBottom;

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
            this.gridRequests = new System.Windows.Forms.DataGridView();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRequests
            // 
            this.gridRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRequests.ColumnHeadersHeight = 29;
            this.gridRequests.Location = new System.Drawing.Point(0, 0);
            this.gridRequests.MultiSelect = false;
            this.gridRequests.Name = "gridRequests";
            this.gridRequests.ReadOnly = true;
            this.gridRequests.RowHeadersWidth = 51;
            this.gridRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRequests.Size = new System.Drawing.Size(2118, 763);
            this.gridRequests.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(12, 10);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 35);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(148, 10);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(120, 35);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // VendorAdoptionRequestsControl
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 56;
            this.panelBottom.Controls.Add(this.btnReject);
            this.panelBottom.Controls.Add(this.btnAccept);

            this.Controls.Add(this.gridRequests);
            this.Controls.Add(this.panelBottom);
            this.Name = "VendorAdoptionRequestsControl";
            this.Size = new System.Drawing.Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)(this.gridRequests)).EndInit();
            this.ResumeLayout(false);

        }
    }
}


