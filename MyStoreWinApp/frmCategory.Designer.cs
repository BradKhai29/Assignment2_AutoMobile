namespace MyStoreWinApp
{
    partial class frmCategory
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
            btnCancel = new Button();
            btnCreateOrSave = new Button();
            txtCategoryName = new TextBox();
            btnCategory = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(209, 212);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(111, 34);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnCreateOrSave
            // 
            btnCreateOrSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreateOrSave.Location = new Point(46, 212);
            btnCreateOrSave.Name = "btnCreateOrSave";
            btnCreateOrSave.Size = new Size(118, 34);
            btnCreateOrSave.TabIndex = 10;
            btnCreateOrSave.Text = "Create";
            btnCreateOrSave.UseVisualStyleBackColor = true;
            btnCreateOrSave.Click += btnCreateOrSave_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtCategoryName.Location = new Point(46, 118);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(274, 29);
            txtCategoryName.TabIndex = 8;
            txtCategoryName.KeyPress += Enter_KeyPress;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.FromArgb(  255,   192,   128);
            btnCategory.Dock = DockStyle.Top;
            btnCategory.Enabled = false;
            btnCategory.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCategory.Location = new Point(0, 0);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(361, 50);
            btnCategory.TabIndex = 9;
            btnCategory.Text = "CATEGORY FORM";
            btnCategory.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(46, 94);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 12;
            label1.Text = "Category Name";
            // 
            // frmCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 268);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnCreateOrSave);
            Controls.Add(txtCategoryName);
            Controls.Add(btnCategory);
            Name = "frmCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCategory";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnCreateOrSave;
        private TextBox txtCategoryName;
        private Button btnCategory;
        private Label label1;
    }
}