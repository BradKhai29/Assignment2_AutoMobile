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
            lbMemberId = new Label();
            txtMemberId = new TextBox();
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
            btnProfile.Enabled = false;
            btnProfile.Font = new Font("Segoe UI Semibold", 13.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnProfile.Location = new Point(12, 12);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(376, 49);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "MEMBER PROFILE";
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // lbMemberId
            // 
            lbMemberId.AutoSize = true;
            lbMemberId.Enabled = false;
            lbMemberId.Location = new Point(1, 432);
            lbMemberId.Name = "lbMemberId";
            lbMemberId.Size = new Size(63, 15);
            lbMemberId.TabIndex = 1;
            lbMemberId.Text = "MemberID";
            lbMemberId.Visible = false;
            // 
            // txtMemberId
            // 
            txtMemberId.Enabled = false;
            txtMemberId.Location = new Point(1, 450);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(63, 23);
            txtMemberId.TabIndex = 2;
            txtMemberId.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 81);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(78, 99);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(239, 23);
            txtEmail.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 134);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(78, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(239, 23);
            txtPassword.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 194);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 1;
            label4.Text = "Company Name";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(78, 212);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(239, 23);
            txtCompany.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(78, 251);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 1;
            label5.Text = "City";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(78, 269);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(239, 23);
            txtCity.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(78, 312);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 1;
            label6.Text = "Country";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(78, 330);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(239, 23);
            txtCountry.TabIndex = 6;
            // 
            // btnInsertOrUpdate
            // 
            btnInsertOrUpdate.Location = new Point(128, 369);
            btnInsertOrUpdate.Name = "btnInsertOrUpdate";
            btnInsertOrUpdate.Size = new Size(93, 31);
            btnInsertOrUpdate.TabIndex = 7;
            btnInsertOrUpdate.Text = "Save";
            btnInsertOrUpdate.UseVisualStyleBackColor = true;
            btnInsertOrUpdate.Visible = false;
            btnInsertOrUpdate.Click += btnInsertOrUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(227, 369);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 31);
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
            Controls.Add(txtMemberId);
            Controls.Add(lbMemberId);
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
        private Label lbMemberId;
        private TextBox txtMemberId;
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