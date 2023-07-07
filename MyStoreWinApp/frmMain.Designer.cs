namespace MyStoreWinApp
{
    public partial class frmMain
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
            menuStripMain = new MenuStrip();
            toolStripProduct = new ToolStripMenuItem();
            menuItemAddProduct = new ToolStripMenuItem();
            toolStripCategory = new ToolStripMenuItem();
            menuItemAddCategory = new ToolStripMenuItem();
            toolStripMember = new ToolStripMenuItem();
            menuItemAddMember = new ToolStripMenuItem();
            toolStripOrder = new ToolStripMenuItem();
            toolStripReport = new ToolStripMenuItem();
            toolStripProfile = new ToolStripMenuItem();
            menuItemEditProfile = new ToolStripMenuItem();
            menuItemLogout = new ToolStripMenuItem();
            toolStripShopping = new ToolStripMenuItem();
            dgv_Main = new DataGridView();
            btnNew = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            cbSearchChoice = new ComboBox();
            txtSpec2 = new TextBox();
            txtSpec3 = new TextBox();
            txtSpec4 = new TextBox();
            txtItemId = new TextBox();
            txtItemName = new TextBox();
            txtSpec1 = new TextBox();
            lbId = new Label();
            lbName = new Label();
            lbSpec1 = new Label();
            lbSpec4 = new Label();
            lbSpec3 = new Label();
            lbSpec2 = new Label();
            cbShowAll = new CheckBox();
            btnSearch = new Button();
            datePickEnd = new DateTimePicker();
            datePickStart = new DateTimePicker();
            btnSearchReport = new Button();
            lbStartDate = new Label();
            lbEndDate = new Label();
            txtStartDate = new TextBox();
            txtEndDate = new TextBox();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) dgv_Main).BeginInit();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            menuStripMain.Items.AddRange(new ToolStripItem[] { toolStripProduct, toolStripCategory, toolStripMember, toolStripOrder, toolStripReport, toolStripProfile, toolStripShopping });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.MdiWindowListItem = toolStripProduct;
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1047, 33);
            menuStripMain.TabIndex = 1;
            menuStripMain.Text = "menuStrip1";
            // 
            // toolStripProduct
            // 
            toolStripProduct.BackColor = SystemColors.ActiveCaption;
            toolStripProduct.DropDownItems.AddRange(new ToolStripItem[] { menuItemAddProduct });
            toolStripProduct.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripProduct.Name = "toolStripProduct";
            toolStripProduct.Size = new Size(96, 29);
            toolStripProduct.Text = "Product";
            toolStripProduct.Click += toolStrip_Click;
            // 
            // menuItemAddProduct
            // 
            menuItemAddProduct.Name = "menuItemAddProduct";
            menuItemAddProduct.Size = new Size(166, 30);
            menuItemAddProduct.Text = "Add New";
            menuItemAddProduct.Click += menuItemAddProduct_Click;
            // 
            // toolStripCategory
            // 
            toolStripCategory.DropDownItems.AddRange(new ToolStripItem[] { menuItemAddCategory });
            toolStripCategory.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripCategory.Name = "toolStripCategory";
            toolStripCategory.Size = new Size(106, 29);
            toolStripCategory.Text = "Category";
            toolStripCategory.Visible = false;
            toolStripCategory.Click += toolStrip_Click;
            // 
            // menuItemAddCategory
            // 
            menuItemAddCategory.Name = "menuItemAddCategory";
            menuItemAddCategory.Size = new Size(166, 30);
            menuItemAddCategory.Text = "Add New";
            menuItemAddCategory.Click += menuItemAddCategory_Click;
            // 
            // toolStripMember
            // 
            toolStripMember.DropDownItems.AddRange(new ToolStripItem[] { menuItemAddMember });
            toolStripMember.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripMember.Name = "toolStripMember";
            toolStripMember.Size = new Size(99, 29);
            toolStripMember.Text = "Member";
            toolStripMember.Visible = false;
            toolStripMember.Click += toolStrip_Click;
            // 
            // menuItemAddMember
            // 
            menuItemAddMember.Name = "menuItemAddMember";
            menuItemAddMember.Size = new Size(166, 30);
            menuItemAddMember.Text = "Add New";
            menuItemAddMember.Click += menuItemAddMember_Click;
            // 
            // toolStripOrder
            // 
            toolStripOrder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripOrder.Name = "toolStripOrder";
            toolStripOrder.Size = new Size(76, 29);
            toolStripOrder.Text = "Order";
            toolStripOrder.Visible = false;
            toolStripOrder.Click += toolStrip_Click;
            // 
            // toolStripReport
            // 
            toolStripReport.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripReport.Name = "toolStripReport";
            toolStripReport.Size = new Size(160, 29);
            toolStripReport.Text = "Report Statistic";
            toolStripReport.Visible = false;
            toolStripReport.Click += toolStrip_Click;
            // 
            // toolStripProfile
            // 
            toolStripProfile.Alignment = ToolStripItemAlignment.Right;
            toolStripProfile.BackColor = SystemColors.AppWorkspace;
            toolStripProfile.DropDownItems.AddRange(new ToolStripItem[] { menuItemEditProfile, menuItemLogout });
            toolStripProfile.Name = "toolStripProfile";
            toolStripProfile.Size = new Size(218, 29);
            toolStripProfile.Text = "Welcome, {Username}";
            toolStripProfile.Click += Login_Click;
            // 
            // menuItemEditProfile
            // 
            menuItemEditProfile.Name = "menuItemEditProfile";
            menuItemEditProfile.Size = new Size(182, 30);
            menuItemEditProfile.Text = "Edit Profile";
            menuItemEditProfile.Visible = false;
            menuItemEditProfile.Click += menuItemEditProfile_Click;
            // 
            // menuItemLogout
            // 
            menuItemLogout.Name = "menuItemLogout";
            menuItemLogout.Size = new Size(182, 30);
            menuItemLogout.Text = "Logout";
            menuItemLogout.Click += menuItemLogout_Click;
            // 
            // toolStripShopping
            // 
            toolStripShopping.Name = "toolStripShopping";
            toolStripShopping.Size = new Size(111, 29);
            toolStripShopping.Text = "Shopping";
            toolStripShopping.Click += toolStrip_Click;
            // 
            // dgv_Main
            // 
            dgv_Main.AllowUserToAddRows = false;
            dgv_Main.AllowUserToDeleteRows = false;
            dgv_Main.AllowUserToOrderColumns = true;
            dgv_Main.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Main.BackgroundColor = SystemColors.Control;
            dgv_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Main.Location = new Point(12, 352);
            dgv_Main.Name = "dgv_Main";
            dgv_Main.ReadOnly = true;
            dgv_Main.RowTemplate.Height = 25;
            dgv_Main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Main.Size = new Size(1023, 176);
            dgv_Main.TabIndex = 5;
            dgv_Main.CellDoubleClick += Dgv_CellDoubleClick;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Right;
            btnNew.BackColor = SystemColors.ActiveCaption;
            btnNew.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNew.Location = new Point(396, 314);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(91, 33);
            btnNew.TabIndex = 6;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Visible = false;
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(  255,   192,   192);
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(493, 314);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 33);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left;
            txtSearch.CharacterCasing = CharacterCasing.Lower;
            txtSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSearch.Location = new Point(12, 314);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter to Search";
            txtSearch.Size = new Size(281, 33);
            txtSearch.TabIndex = 7;
            txtSearch.KeyPress += Enter_KeyPress;
            // 
            // cbSearchChoice
            // 
            cbSearchChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchChoice.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbSearchChoice.FormattingEnabled = true;
            cbSearchChoice.Location = new Point(12, 275);
            cbSearchChoice.Name = "cbSearchChoice";
            cbSearchChoice.Size = new Size(281, 33);
            cbSearchChoice.TabIndex = 9;
            // 
            // txtSpec2
            // 
            txtSpec2.Anchor = AnchorStyles.Left;
            txtSpec2.Enabled = false;
            txtSpec2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec2.Location = new Point(596, 76);
            txtSpec2.Name = "txtSpec2";
            txtSpec2.Size = new Size(307, 33);
            txtSpec2.TabIndex = 7;
            // 
            // txtSpec3
            // 
            txtSpec3.Anchor = AnchorStyles.Left;
            txtSpec3.Enabled = false;
            txtSpec3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec3.Location = new Point(596, 143);
            txtSpec3.Name = "txtSpec3";
            txtSpec3.Size = new Size(307, 33);
            txtSpec3.TabIndex = 7;
            // 
            // txtSpec4
            // 
            txtSpec4.Anchor = AnchorStyles.Left;
            txtSpec4.Enabled = false;
            txtSpec4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec4.Location = new Point(596, 208);
            txtSpec4.Name = "txtSpec4";
            txtSpec4.Size = new Size(307, 33);
            txtSpec4.TabIndex = 7;
            // 
            // txtItemId
            // 
            txtItemId.Anchor = AnchorStyles.Left;
            txtItemId.Enabled = false;
            txtItemId.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtItemId.Location = new Point(129, 76);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(307, 33);
            txtItemId.TabIndex = 7;
            // 
            // txtItemName
            // 
            txtItemName.Anchor = AnchorStyles.Left;
            txtItemName.Enabled = false;
            txtItemName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtItemName.Location = new Point(129, 143);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(307, 33);
            txtItemName.TabIndex = 7;
            // 
            // txtSpec1
            // 
            txtSpec1.Anchor = AnchorStyles.Left;
            txtSpec1.Enabled = false;
            txtSpec1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec1.Location = new Point(129, 208);
            txtSpec1.Name = "txtSpec1";
            txtSpec1.Size = new Size(307, 33);
            txtSpec1.TabIndex = 7;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.BackColor = SystemColors.AppWorkspace;
            lbId.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbId.ForeColor = Color.Black;
            lbId.Location = new Point(129, 48);
            lbId.Name = "lbId";
            lbId.Size = new Size(73, 25);
            lbId.TabIndex = 11;
            lbId.Text = "Item id";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.BackColor = SystemColors.AppWorkspace;
            lbName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbName.ForeColor = Color.Black;
            lbName.Location = new Point(129, 115);
            lbName.Name = "lbName";
            lbName.Size = new Size(105, 25);
            lbName.TabIndex = 11;
            lbName.Text = "Item name";
            // 
            // lbSpec1
            // 
            lbSpec1.AutoSize = true;
            lbSpec1.BackColor = SystemColors.AppWorkspace;
            lbSpec1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec1.ForeColor = Color.Black;
            lbSpec1.Location = new Point(129, 180);
            lbSpec1.Name = "lbSpec1";
            lbSpec1.Size = new Size(58, 25);
            lbSpec1.TabIndex = 11;
            lbSpec1.Text = "spec1";
            // 
            // lbSpec4
            // 
            lbSpec4.AutoSize = true;
            lbSpec4.BackColor = SystemColors.AppWorkspace;
            lbSpec4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec4.ForeColor = Color.Black;
            lbSpec4.Location = new Point(596, 180);
            lbSpec4.Name = "lbSpec4";
            lbSpec4.Size = new Size(61, 25);
            lbSpec4.TabIndex = 12;
            lbSpec4.Text = "spec4";
            // 
            // lbSpec3
            // 
            lbSpec3.AutoSize = true;
            lbSpec3.BackColor = SystemColors.AppWorkspace;
            lbSpec3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec3.ForeColor = Color.Black;
            lbSpec3.Location = new Point(596, 115);
            lbSpec3.Name = "lbSpec3";
            lbSpec3.Size = new Size(61, 25);
            lbSpec3.TabIndex = 13;
            lbSpec3.Text = "spec3";
            // 
            // lbSpec2
            // 
            lbSpec2.AutoSize = true;
            lbSpec2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec2.ForeColor = Color.Black;
            lbSpec2.Location = new Point(596, 48);
            lbSpec2.Name = "lbSpec2";
            lbSpec2.Size = new Size(61, 25);
            lbSpec2.TabIndex = 14;
            lbSpec2.Text = "spec2";
            // 
            // cbShowAll
            // 
            cbShowAll.AutoSize = true;
            cbShowAll.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbShowAll.Location = new Point(396, 279);
            cbShowAll.Name = "cbShowAll";
            cbShowAll.Size = new Size(182, 29);
            cbShowAll.TabIndex = 18;
            cbShowAll.Text = "Show all Products";
            cbShowAll.UseVisualStyleBackColor = true;
            cbShowAll.Visible = false;
            cbShowAll.CheckedChanged += cbShowAll_CheckedChanged;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Right;
            btnSearch.BackColor = Color.Silver;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Location = new Point(299, 275);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(91, 72);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // datePickEnd
            // 
            datePickEnd.CalendarFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            datePickEnd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            datePickEnd.Location = new Point(919, 317);
            datePickEnd.Name = "datePickEnd";
            datePickEnd.Size = new Size(19, 29);
            datePickEnd.TabIndex = 21;
            datePickEnd.Visible = false;
            datePickEnd.ValueChanged += datePick_ValueChanged;
            // 
            // datePickStart
            // 
            datePickStart.CalendarFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            datePickStart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            datePickStart.Location = new Point(919, 283);
            datePickStart.Name = "datePickStart";
            datePickStart.Size = new Size(19, 29);
            datePickStart.TabIndex = 21;
            datePickStart.Visible = false;
            datePickStart.ValueChanged += datePick_ValueChanged;
            // 
            // btnSearchReport
            // 
            btnSearchReport.Anchor = AnchorStyles.Right;
            btnSearchReport.BackColor = Color.Silver;
            btnSearchReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchReport.Location = new Point(944, 283);
            btnSearchReport.Name = "btnSearchReport";
            btnSearchReport.Size = new Size(91, 64);
            btnSearchReport.TabIndex = 19;
            btnSearchReport.Text = "Search";
            btnSearchReport.UseVisualStyleBackColor = false;
            btnSearchReport.Visible = false;
            btnSearchReport.Click += btnSearchReport_Click;
            // 
            // lbStartDate
            // 
            lbStartDate.AutoSize = true;
            lbStartDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbStartDate.ForeColor = Color.Black;
            lbStartDate.Location = new Point(604, 286);
            lbStartDate.Name = "lbStartDate";
            lbStartDate.Size = new Size(53, 25);
            lbStartDate.TabIndex = 14;
            lbStartDate.Text = "Start";
            lbStartDate.Visible = false;
            lbStartDate.Click += DateTimeTextBox_Click;
            // 
            // lbEndDate
            // 
            lbEndDate.AutoSize = true;
            lbEndDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbEndDate.ForeColor = Color.Black;
            lbEndDate.Location = new Point(604, 320);
            lbEndDate.Name = "lbEndDate";
            lbEndDate.Size = new Size(44, 25);
            lbEndDate.TabIndex = 14;
            lbEndDate.Text = "End";
            lbEndDate.Visible = false;
            lbEndDate.Click += DateTimeTextBox_Click;
            // 
            // txtStartDate
            // 
            txtStartDate.Anchor = AnchorStyles.Left;
            txtStartDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtStartDate.Location = new Point(657, 283);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.PlaceholderText = "Select Date";
            txtStartDate.Size = new Size(281, 29);
            txtStartDate.TabIndex = 7;
            txtStartDate.Visible = false;
            txtStartDate.Click += DateTimeTextBox_Click;
            txtStartDate.MouseClick += DateTimeTextBox_MouseClick;
            // 
            // txtEndDate
            // 
            txtEndDate.Anchor = AnchorStyles.Left;
            txtEndDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtEndDate.Location = new Point(657, 317);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.PlaceholderText = "Select Date";
            txtEndDate.Size = new Size(281, 29);
            txtEndDate.TabIndex = 7;
            txtEndDate.Visible = false;
            txtEndDate.Click += DateTimeTextBox_Click;
            txtEndDate.MouseClick += DateTimeTextBox_MouseClick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1047, 540);
            Controls.Add(datePickStart);
            Controls.Add(datePickEnd);
            Controls.Add(btnSearchReport);
            Controls.Add(btnSearch);
            Controls.Add(cbShowAll);
            Controls.Add(lbSpec4);
            Controls.Add(lbSpec3);
            Controls.Add(lbEndDate);
            Controls.Add(lbStartDate);
            Controls.Add(lbSpec2);
            Controls.Add(lbSpec1);
            Controls.Add(lbName);
            Controls.Add(lbId);
            Controls.Add(cbSearchChoice);
            Controls.Add(txtSpec1);
            Controls.Add(txtEndDate);
            Controls.Add(txtStartDate);
            Controls.Add(txtSpec4);
            Controls.Add(txtItemName);
            Controls.Add(txtItemId);
            Controls.Add(txtSpec3);
            Controls.Add(txtSpec2);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnNew);
            Controls.Add(dgv_Main);
            Controls.Add(menuStripMain);
            IsMdiContainer = true;
            MainMenuStrip = menuStripMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMain";
            Load += Form_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) dgv_Main).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem toolStripMember;
        private ToolStripMenuItem toolStripCategory;
        private ToolStripMenuItem toolStripProduct;
        private ToolStripMenuItem toolStripOrder;
        private ToolStripMenuItem menuItemAddMember;
        private ToolStripMenuItem menuItemAddCategory;
        private ToolStripMenuItem menuItemAddProduct;
        private ToolStripMenuItem toolStripReport;
        private ToolStripMenuItem toolStripProfile;
        private ToolStripMenuItem menuItemEditProfile;
        private ToolStripMenuItem menuItemLogout;
        private DataGridView dgv_Main;
        private Button btnNew;
        private Button btnDelete;
        private TextBox txtSearch;
        private ComboBox cbSearchChoice;
        private TextBox txtSpec2;
        private TextBox txtSpec3;
        private TextBox txtSpec4;
        private TextBox txtItemId;
        private TextBox txtItemName;
        private TextBox txtSpec1;
        private Label lbId;
        private Label lbName;
        private Label lbSpec1;
        private Label lbSpec4;
        private Label lbSpec3;
        private Label lbSpec2;
        private CheckBox cbShowAll;
        private Button btnSearch;
        private ToolStripMenuItem toolStripShopping;
        private DateTimePicker datePickEnd;
        private DateTimePicker datePickStart;
        private Button btnSearchReport;
        private Label lbStartDate;
        private Label lbEndDate;
        private TextBox txtStartDate;
        private TextBox txtEndDate;
    }
}