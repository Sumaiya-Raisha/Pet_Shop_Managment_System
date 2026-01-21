using System.Windows.Forms;

namespace WindowsFormsApp1
{
	partial class CustomerProfileForm
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
			this.lblHeader = new System.Windows.Forms.Label();
			this.groupAccount = new System.Windows.Forms.GroupBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFullName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupPersonal = new System.Windows.Forms.GroupBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupPassword = new System.Windows.Forms.GroupBox();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupSummary = new System.Windows.Forms.GroupBox();
			this.lblLifetimeSpend = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lblLastOrder = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.lblOrders = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupAccount.SuspendLayout();
			this.groupPersonal.SuspendLayout();
			this.groupPassword.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.groupSummary.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			this.lblHeader.Location = new System.Drawing.Point(12, 9);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(159, 25);
			this.lblHeader.TabIndex = 0;
			this.lblHeader.Text = "Customer Profile";
			// 
			// groupAccount
			// 
			this.groupAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.groupAccount.Controls.Add(this.txtEmail);
			this.groupAccount.Controls.Add(this.label3);
			this.groupAccount.Controls.Add(this.txtFullName);
			this.groupAccount.Controls.Add(this.label2);
			this.groupAccount.Controls.Add(this.txtUsername);
			this.groupAccount.Controls.Add(this.label1);
			this.groupAccount.Location = new System.Drawing.Point(17, 47);
			this.groupAccount.Name = "groupAccount";
			this.groupAccount.Size = new System.Drawing.Size(751, 98);
			this.groupAccount.TabIndex = 1;
			this.groupAccount.TabStop = false;
			this.groupAccount.Text = "Account";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(477, 57);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(250, 23);
			this.txtEmail.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(427, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Email:";
			// 
			// txtFullName
			// 
			this.txtFullName.Location = new System.Drawing.Point(88, 57);
			this.txtFullName.Name = "txtFullName";
			this.txtFullName.Size = new System.Drawing.Size(300, 23);
			this.txtFullName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Full Name:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(88, 28);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.ReadOnly = true;
			this.txtUsername.Size = new System.Drawing.Size(200, 23);
			this.txtUsername.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// groupPersonal
			// 
			this.groupPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.groupPersonal.Controls.Add(this.txtAddress);
			this.groupPersonal.Controls.Add(this.label7);
			this.groupPersonal.Controls.Add(this.txtPhone);
			this.groupPersonal.Controls.Add(this.label6);
			this.groupPersonal.Controls.Add(this.txtLastName);
			this.groupPersonal.Controls.Add(this.label5);
			this.groupPersonal.Controls.Add(this.txtFirstName);
			this.groupPersonal.Controls.Add(this.label4);
			this.groupPersonal.Location = new System.Drawing.Point(17, 151);
			this.groupPersonal.Name = "groupPersonal";
			this.groupPersonal.Size = new System.Drawing.Size(751, 141);
			this.groupPersonal.TabIndex = 2;
			this.groupPersonal.TabStop = false;
			this.groupPersonal.Text = "Personal";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(88, 83);
			this.txtAddress.Multiline = true;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(639, 46);
			this.txtAddress.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(27, 86);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 15);
			this.label7.TabIndex = 6;
			this.label7.Text = "Address:";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(527, 26);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(200, 23);
			this.txtPhone.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(477, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 15);
			this.label6.TabIndex = 4;
			this.label6.Text = "Phone:";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(308, 26);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(150, 23);
			this.txtLastName.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(236, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 15);
			this.label5.TabIndex = 2;
			this.label5.Text = "Last Name:";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(88, 26);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(130, 23);
			this.txtFirstName.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 15);
			this.label4.TabIndex = 0;
			this.label4.Text = "First Name:";
			// 
			// groupPassword
			// 
			this.groupPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.groupPassword.Controls.Add(this.txtConfirmPassword);
			this.groupPassword.Controls.Add(this.label9);
			this.groupPassword.Controls.Add(this.txtNewPassword);
			this.groupPassword.Controls.Add(this.label8);
			this.groupPassword.Location = new System.Drawing.Point(17, 298);
			this.groupPassword.Name = "groupPassword";
			this.groupPassword.Size = new System.Drawing.Size(751, 88);
			this.groupPassword.TabIndex = 3;
			this.groupPassword.TabStop = false;
			this.groupPassword.Text = "Change Password (optional)";
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Location = new System.Drawing.Point(477, 35);
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.PasswordChar = '*';
			this.txtConfirmPassword.Size = new System.Drawing.Size(200, 23);
			this.txtConfirmPassword.TabIndex = 3;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(373, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(98, 15);
			this.label9.TabIndex = 2;
			this.label9.Text = "Confirm New PW:";
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Location = new System.Drawing.Point(147, 35);
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.PasswordChar = '*';
			this.txtNewPassword.Size = new System.Drawing.Size(200, 23);
			this.txtNewPassword.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(124, 15);
			this.label8.TabIndex = 0;
			this.label8.Text = "New Password (clear):";
			// 
			// panelButtons
			// 
			this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.panelButtons.Controls.Add(this.btnClose);
			this.panelButtons.Controls.Add(this.btnSave);
			this.panelButtons.Location = new System.Drawing.Point(0, 460);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(788, 49);
			this.panelButtons.TabIndex = 5;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(680, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(96, 27);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(17, 12);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(120, 27);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save Changes";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// groupSummary
			// 
			this.groupSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			|
			System.Windows.Forms.AnchorStyles.Right)));
			this.groupSummary.Controls.Add(this.lblLifetimeSpend);
			this.groupSummary.Controls.Add(this.label12);
			this.groupSummary.Controls.Add(this.lblLastOrder);
			this.groupSummary.Controls.Add(this.label10);
			this.groupSummary.Controls.Add(this.lblOrders);
			this.groupSummary.Controls.Add(this.label11);
			this.groupSummary.Location = new System.Drawing.Point(17, 392);
			this.groupSummary.Name = "groupSummary";
			this.groupSummary.Size = new System.Drawing.Size(751, 62);
			this.groupSummary.TabIndex = 4;
			this.groupSummary.TabStop = false;
			this.groupSummary.Text = "Account Summary";
			// 
			// lblLifetimeSpend
			// 
			this.lblLifetimeSpend.AutoSize = true;
			this.lblLifetimeSpend.Location = new System.Drawing.Point(651, 28);
			this.lblLifetimeSpend.Name = "lblLifetimeSpend";
			this.lblLifetimeSpend.Size = new System.Drawing.Size(13, 15);
			this.lblLifetimeSpend.TabIndex = 5;
			this.lblLifetimeSpend.Text = "-";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(548, 28);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(95, 15);
			this.label12.TabIndex = 4;
			this.label12.Text = "Lifetime Spend:";
			// 
			// lblLastOrder
			// 
			this.lblLastOrder.AutoSize = true;
			this.lblLastOrder.Location = new System.Drawing.Point(348, 28);
			this.lblLastOrder.Name = "lblLastOrder";
			this.lblLastOrder.Size = new System.Drawing.Size(13, 15);
			this.lblLastOrder.TabIndex = 3;
			this.lblLastOrder.Text = "-";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(271, 28);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 15);
			this.label10.TabIndex = 2;
			this.label10.Text = "Last Order:";
			// 
			// lblOrders
			// 
			this.lblOrders.AutoSize = true;
			this.lblOrders.Location = new System.Drawing.Point(95, 28);
			this.lblOrders.Name = "lblOrders";
			this.lblOrders.Size = new System.Drawing.Size(13, 15);
			this.lblOrders.TabIndex = 1;
			this.lblOrders.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(17, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 15);
			this.label11.TabIndex = 0;
			this.label11.Text = "Total Orders:";
			// 
			// CustomerProfileForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 509);
			this.Controls.Add(this.groupSummary);
			this.Controls.Add(this.panelButtons);
			this.Controls.Add(this.groupPassword);
			this.Controls.Add(this.groupPersonal);
			this.Controls.Add(this.groupAccount);
			this.Controls.Add(this.lblHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomerProfileForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Customer Profile";
			this.groupAccount.ResumeLayout(false);
			this.groupAccount.PerformLayout();
			this.groupPersonal.ResumeLayout(false);
			this.groupPersonal.PerformLayout();
			this.groupPassword.ResumeLayout(false);
			this.groupPassword.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.groupSummary.ResumeLayout(false);
			this.groupSummary.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.GroupBox groupAccount;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFullName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupPersonal;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupPassword;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox groupSummary;
		private System.Windows.Forms.Label lblLifetimeSpend;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblLastOrder;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblOrders;
		private System.Windows.Forms.Label label11;
	}
}


