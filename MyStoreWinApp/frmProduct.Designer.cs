namespace MyStoreWinApp
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProduct = new Button();
            txtProductName = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnCreateOrUpdate = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            txtInStock = new TextBox();
            label5 = new Label();
            txtWeight = new TextBox();
            cbCategory = new ComboBox();
            cbAvailable = new CheckBox();
            SuspendLayout();
            // 
            // btnProduct
            // 
            btnProduct.BackColor = Color.FromArgb(  255,   192,   128);
            btnProduct.Dock = DockStyle.Top;
            btnProduct.Enabled = false;
            btnProduct.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnProduct.Location = new Point(0, 0);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(361, 50);
            btnProduct.TabIndex = 3;
            btnProduct.Text = "PRODUCT FORM";
            btnProduct.UseVisualStyleBackColor = false;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtProductName.Location = new Point(46, 88);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(274, 29);
            txtProductName.TabIndex = 1;
            txtProductName.KeyPress += Enter_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(46, 64);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 4;
            label1.Text = "Product Name";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(209, 410);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(111, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreateOrUpdate
            // 
            btnCreateOrUpdate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateOrUpdate.Location = new Point(46, 410);
            btnCreateOrUpdate.Name = "btnCreateOrUpdate";
            btnCreateOrUpdate.Size = new Size(118, 34);
            btnCreateOrUpdate.TabIndex = 6;
            btnCreateOrUpdate.Text = "Create";
            btnCreateOrUpdate.UseVisualStyleBackColor = true;
            btnCreateOrUpdate.Click += btnCreateOrUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(46, 134);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 8;
            label2.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(46, 200);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 8;
            label3.Text = "Unit Price";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtPrice.Location = new Point(46, 224);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(274, 29);
            txtPrice.TabIndex = 3;
            txtPrice.KeyPress += Enter_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(46, 265);
            label4.Name = "label4";
            label4.Size = new Size(110, 21);
            label4.TabIndex = 8;
            label4.Text = "Units In Stock";
            // 
            // txtInStock
            // 
            txtInStock.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtInStock.Location = new Point(46, 289);
            txtInStock.Name = "txtInStock";
            txtInStock.Size = new Size(274, 29);
            txtInStock.TabIndex = 4;
            txtInStock.KeyPress += Enter_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(46, 335);
            label5.Name = "label5";
            label5.Size = new Size(63, 21);
            label5.TabIndex = 8;
            label5.Text = "Weight";
            // 
            // txtWeight
            // 
            txtWeight.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtWeight.Location = new Point(46, 359);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(274, 29);
            txtWeight.TabIndex = 5;
            txtWeight.KeyPress += Enter_KeyPress;
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(46, 158);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(274, 29);
            cbCategory.TabIndex = 2;
            // 
            // cbAvailable
            // 
            cbAvailable.AutoSize = true;
            cbAvailable.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cbAvailable.Location = new Point(209, 264);
            cbAvailable.Name = "cbAvailable";
            cbAvailable.Size = new Size(111, 25);
            cbAvailable.TabIndex = 9;
            cbAvailable.Text = "Is Available";
            cbAvailable.UseVisualStyleBackColor = true;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 468);
            Controls.Add(cbAvailable);
            Controls.Add(cbCategory);
            Controls.Add(txtWeight);
            Controls.Add(label5);
            Controls.Add(txtInStock);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnCreateOrUpdate);
            Controls.Add(txtProductName);
            Controls.Add(label1);
            Controls.Add(btnProduct);
            Name = "frmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProduct";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnProduct;
        private TextBox txtProductName;
        private Label label1;
        private Button btnCancel;
        private Button btnCreateOrUpdate;
        private Label label2;
        private Label label3;
        private TextBox txtPrice;
        private Label label4;
        private TextBox txtInStock;
        private Label label5;
        private TextBox txtWeight;
        private ComboBox cbCategory;
        private CheckBox cbAvailable;
    }
}