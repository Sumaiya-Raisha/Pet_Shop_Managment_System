using System.Windows.Forms;

namespace WindowsFormsApp1
{
	partial class OrderReceiptForm
	{
		private System.ComponentModel.IContainer components = null;

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
			this.lblOrderId = new System.Windows.Forms.Label();
			this.lblCustomer = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.dgvItems = new System.Windows.Forms.DataGridView();
			this.panelBottom = new System.Windows.Forms.Panel();
			this.btnCopy = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
			this.panelBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblOrderId
			// 
			this.lblOrderId.AutoSize = true;
			this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
			this.lblOrderId.Location = new System.Drawing.Point(12, 9);
			this.lblOrderId.Name = "lblOrderId";
			this.lblOrderId.Size = new System.Drawing.Size(74, 21);
			this.lblOrderId.TabIndex = 0;
			this.lblOrderId.Text = "Order #";
			// 
			// lblCustomer
			// 
			this.lblCustomer.AutoSize = true;
			this.lblCustomer.Location = new System.Drawing.Point(13, 38);
			this.lblCustomer.Name = "lblCustomer";
			this.lblCustomer.Size = new System.Drawing.Size(64, 15);
			this.lblCustomer.TabIndex = 1;
			this.lblCustomer.Text = "Customer:";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Location = new System.Drawing.Point(13, 59);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(34, 15);
			this.lblDate.TabIndex = 2;
			this.lblDate.Text = "Date";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(300, 38);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(42, 15);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "Status";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point(300, 59);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(34, 15);
			this.lblTotal.TabIndex = 4;
			this.lblTotal.Text = "Total";
			// 
			// dgvItems
			// 
			this.dgvItems.AllowUserToAddRows = false;
			this.dgvItems.AllowUserToDeleteRows = false;
			this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			|
			System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvItems.Location = new System.Drawing.Point(16, 87);
			this.dgvItems.MultiSelect = false;
			this.dgvItems.Name = "dgvItems";
			this.dgvItems.ReadOnly = true;
			this.dgvItems.RowHeadersVisible = false;
			this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvItems.Size = new System.Drawing.Size(556, 274);
			this.dgvItems.TabIndex = 5;
			// 
			// panelBottom
			// 
			this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.panelBottom.Controls.Add(this.btnCopy);
			this.panelBottom.Controls.Add(this.btnClose);
			this.panelBottom.Location = new System.Drawing.Point(0, 367);
			this.panelBottom.Name = "panelBottom";
			this.panelBottom.Size = new System.Drawing.Size(587, 44);
			this.panelBottom.TabIndex = 6;
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(16, 9);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(132, 27);
			this.btnCopy.TabIndex = 1;
			this.btnCopy.Text = "Copy to Clipboard";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(481, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 27);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// OrderReceiptForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 411);
			this.Controls.Add(this.panelBottom);
			this.Controls.Add(this.dgvItems);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblCustomer);
			this.Controls.Add(this.lblOrderId);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OrderReceiptForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Receipt";
			((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
			this.panelBottom.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label lblOrderId;
		private System.Windows.Forms.Label lblCustomer;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.DataGridView dgvItems;
		private System.Windows.Forms.Panel panelBottom;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.Button btnClose;
	}
}


