namespace MyStoreWinApp
{
    partial class frmMember
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
            btnProfile = new Button();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            txtCompany = new TextBox();
            label5 = new Label();
            txtCity = new TextBox();
            label6 = new Label();
            txtCountry = new TextBox();
            btnInsertOrUpdate = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(  255,   192,   128);
            btnProfile.Dock = DockStyle.Top;
            btnProfile.Enabled = false;
            btnProfile.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnProfile.Location = new Point(0, 0);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(400, 49);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "MEMBER PROFILE";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(43, 63);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtEmail.Location = new Point(43, 91);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(310, 33);
            txtEmail.TabIndex = 2;
            txtEmail.KeyPress += Enter_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(43, 130);
            label3.Name = "label3";
            label3.Size = new Size(97, 25);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(43, 158);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(310, 33);
            txtPassword.TabIndex = 3;
            txtPassword.KeyPress += Enter_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(43, 203);
            label4.Name = "label4";
            label4.Size = new Size(154, 25);
            label4.TabIndex = 1;
            label4.Text = "Company Name";
            // 
            // txtCompany
            // 
            txtCompany.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtCompany.Location = new Point(43, 231);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(310, 33);
            txtCompany.TabIndex = 4;
            txtCompany.KeyPress += Enter_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(43, 267);
            label5.Name = "label5";
            label5.Size = new Size(46, 25);
            label5.TabIndex = 1;
            label5.Text = "City";
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtCity.Location = new Point(43, 295);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(310, 33);
            txtCity.TabIndex = 5;
            txtCity.KeyPress += Enter_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(43, 337);
            label6.Name = "label6";
            label6.Size = new Size(86, 25);
            label6.TabIndex = 1;
            label6.Text = "Country";
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtCountry.Location = new Point(43, 365);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(310, 33);
            txtCountry.TabIndex = 6;
            txtCountry.KeyPress += Enter_KeyPress;
            // 
            // btnInsertOrUpdate
            // 
            btnInsertOrUpdate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnInsertOrUpdate.Location = new Point(154, 416);
            btnInsertOrUpdate.Name = "btnInsertOrUpdate";
            btnInsertOrUpdate.Size = new Size(103, 37);
            btnInsertOrUpdate.TabIndex = 7;
            btnInsertOrUpdate.Text = "Save";
            btnInsertOrUpdate.UseVisualStyleBackColor = true;
            btnInsertOrUpdate.Visible = false;
            btnInsertOrUpdate.Click += btnInsertOrUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(263, 416);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 37);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmMember
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 474);
            Controls.Add(txtCountry);
            Controls.Add(label6);
            Controls.Add(txtCity);
            Controls.Add(label5);
            Controls.Add(txtCompany);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnInsertOrUpdate);
            Controls.Add(btnProfile);
            Name = "frmMember";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMember";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtCompany;
        private Label label5;
        private TextBox txtCity;
        private Label label6;
        private TextBox txtCountry;
        private Button btnInsertOrUpdate;
        private Button btnCancel;
        internal Button btnProfile;
    }
}