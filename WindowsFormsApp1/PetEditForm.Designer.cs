//namespace WindowsFormsApp1
//{
//    partial class PetEditForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private System.Windows.Forms.Label lblName;
//        private System.Windows.Forms.TextBox txtName;
//        private System.Windows.Forms.Label lblBreed;
//        private System.Windows.Forms.TextBox txtBreed;
//        private System.Windows.Forms.Label lblAge;
//        private System.Windows.Forms.NumericUpDown numAge;
//        private System.Windows.Forms.Label lblQty;
//        private System.Windows.Forms.NumericUpDown numQty;
//        private System.Windows.Forms.Button btnSave;
//        private System.Windows.Forms.Button btnCancel;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.lblName = new System.Windows.Forms.Label();
//            this.txtName = new System.Windows.Forms.TextBox();
//            this.lblBreed = new System.Windows.Forms.Label();
//            this.txtBreed = new System.Windows.Forms.TextBox();
//            this.lblAge = new System.Windows.Forms.Label();
//            this.numAge = new System.Windows.Forms.NumericUpDown();
//            this.lblQty = new System.Windows.Forms.Label();
//            this.numQty = new System.Windows.Forms.NumericUpDown();
//            this.btnSave = new System.Windows.Forms.Button();
//            this.btnCancel = new System.Windows.Forms.Button();
//            this.lblType = new System.Windows.Forms.Label();
//            this.txtType = new System.Windows.Forms.TextBox();
//            this.txtprice = new System.Windows.Forms.TextBox();
//            this.lblPrice = new System.Windows.Forms.Label();
//            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // lblName
//            // 
//            this.lblName.Location = new System.Drawing.Point(20, 20);
//            this.lblName.Name = "lblName";
//            this.lblName.Size = new System.Drawing.Size(100, 23);
//            this.lblName.TabIndex = 0;
//            this.lblName.Text = "Name";
//            // 
//            // txtName
//            // 
//            this.txtName.Location = new System.Drawing.Point(120, 18);
//            this.txtName.Name = "txtName";
//            this.txtName.Size = new System.Drawing.Size(200, 22);
//            this.txtName.TabIndex = 1;
//            // 
//            // lblBreed
//            // 
//            this.lblBreed.Location = new System.Drawing.Point(20, 56);
//            this.lblBreed.Name = "lblBreed";
//            this.lblBreed.Size = new System.Drawing.Size(100, 23);
//            this.lblBreed.TabIndex = 2;
//            this.lblBreed.Text = "Breed";
//            // 
//            // txtBreed
//            // 
//            this.txtBreed.Location = new System.Drawing.Point(126, 57);
//            this.txtBreed.Name = "txtBreed";
//            this.txtBreed.Size = new System.Drawing.Size(200, 22);
//            this.txtBreed.TabIndex = 3;
//            // 
//            // lblAge
//            // 
//            this.lblAge.Location = new System.Drawing.Point(31, 221);
//            this.lblAge.Name = "lblAge";
//            this.lblAge.Size = new System.Drawing.Size(100, 23);
//            this.lblAge.TabIndex = 4;
//            this.lblAge.Text = "Age";
//            // 
//            // numAge
//            // 
//            this.numAge.Location = new System.Drawing.Point(161, 222);
//            this.numAge.Maximum = new decimal(new int[] {
//            1000,
//            0,
//            0,
//            0});
//            this.numAge.Name = "numAge";
//            this.numAge.Size = new System.Drawing.Size(120, 22);
//            this.numAge.TabIndex = 5;
//            // 
//            // lblQty
//            // 
//            this.lblQty.Location = new System.Drawing.Point(31, 279);
//            this.lblQty.Name = "lblQty";
//            this.lblQty.Size = new System.Drawing.Size(100, 23);
//            this.lblQty.TabIndex = 6;
//            this.lblQty.Text = "Quantity";
//            // 
//            // numQty
//            // 
//            this.numQty.Location = new System.Drawing.Point(161, 280);
//            this.numQty.Maximum = new decimal(new int[] {
//            1000000,
//            0,
//            0,
//            0});
//            this.numQty.Name = "numQty";
//            this.numQty.Size = new System.Drawing.Size(120, 22);
//            this.numQty.TabIndex = 7;
//            // 
//            // btnSave
//            // 
//            this.btnSave.Location = new System.Drawing.Point(96, 328);
//            this.btnSave.Name = "btnSave";
//            this.btnSave.Size = new System.Drawing.Size(75, 23);
//            this.btnSave.TabIndex = 8;
//            this.btnSave.Text = "Save";
//            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
//            // 
//            // btnCancel
//            // 
//            this.btnCancel.Location = new System.Drawing.Point(297, 328);
//            this.btnCancel.Name = "btnCancel";
//            this.btnCancel.Size = new System.Drawing.Size(75, 23);
//            this.btnCancel.TabIndex = 9;
//            this.btnCancel.Text = "Cancel";
//            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
//            // 
//            // lblType
//            // 
//            this.lblType.Location = new System.Drawing.Point(20, 107);
//            this.lblType.Name = "lblType";
//            this.lblType.Size = new System.Drawing.Size(100, 23);
//            this.lblType.TabIndex = 10;
//            this.lblType.Text = "Type";
//            this.lblType.Click += new System.EventHandler(this.label1_Click);
//            // 
//            // txtType
//            // 
//            this.txtType.Location = new System.Drawing.Point(126, 108);
//            this.txtType.Name = "txtType";
//            this.txtType.Size = new System.Drawing.Size(200, 22);
//            this.txtType.TabIndex = 11;
//            // 
//            // txtprice
//            // 
//            this.txtprice.Location = new System.Drawing.Point(126, 165);
//            this.txtprice.Name = "txtprice";
//            this.txtprice.Size = new System.Drawing.Size(200, 22);
//            this.txtprice.TabIndex = 12;
//            this.txtprice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
//            // 
//            // lblPrice
//            // 
//            this.lblPrice.Location = new System.Drawing.Point(12, 164);
//            this.lblPrice.Name = "lblPrice";
//            this.lblPrice.Size = new System.Drawing.Size(100, 23);
//            this.lblPrice.TabIndex = 13;
//            this.lblPrice.Text = "Price";
//            // 
//            // PetEditForm
//            // 
//            this.ClientSize = new System.Drawing.Size(461, 383);
//            this.Controls.Add(this.lblPrice);
//            this.Controls.Add(this.txtprice);
//            this.Controls.Add(this.txtType);
//            this.Controls.Add(this.lblType);
//            this.Controls.Add(this.lblName);
//            this.Controls.Add(this.txtName);
//            this.Controls.Add(this.lblBreed);
//            this.Controls.Add(this.txtBreed);
//            this.Controls.Add(this.lblAge);
//            this.Controls.Add(this.numAge);
//            this.Controls.Add(this.lblQty);
//            this.Controls.Add(this.numQty);
//            this.Controls.Add(this.btnSave);
//            this.Controls.Add(this.btnCancel);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Name = "PetEditForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//            this.Text = "Pet";
//            this.Load += new System.EventHandler(this.PetEditForm_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        private System.Windows.Forms.Label lblType;
//        private System.Windows.Forms.TextBox txtType;
//        private System.Windows.Forms.TextBox txtprice;
//        private System.Windows.Forms.Label lblPrice;
//    }
//}
namespace WindowsFormsApp1
{
    partial class PetEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice; // fixed name and single declaration

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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBreed = new System.Windows.Forms.Label();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 1;
            // 
            // lblBreed
            // 
            this.lblBreed.Location = new System.Drawing.Point(20, 60);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(100, 23);
            this.lblBreed.TabIndex = 2;
            this.lblBreed.Text = "Breed";
            // 
            // txtBreed
            // 
            this.txtBreed.Location = new System.Drawing.Point(126, 57);
            this.txtBreed.Name = "txtBreed";
            this.txtBreed.Size = new System.Drawing.Size(200, 22);
            this.txtBreed.TabIndex = 3;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(31, 221);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(100, 23);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Age";
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(161, 222);
            this.numAge.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(120, 22);
            this.numAge.TabIndex = 9;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(31, 279);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(100, 23);
            this.lblQty.TabIndex = 10;
            this.lblQty.Text = "Quantity";
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(161, 280);
            this.numQty.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(120, 22);
            this.numQty.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(96, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(297, 328);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(12, 107);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(126, 108);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(200, 22);
            this.txtType.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(12, 164);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(126, 165);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 22);
            this.txtPrice.TabIndex = 7;
            // 
            // PetEditForm
            // 
            this.ClientSize = new System.Drawing.Size(461, 383);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblBreed);
            this.Controls.Add(this.txtBreed);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PetEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pet";
            this.Load += new System.EventHandler(this.PetEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}


