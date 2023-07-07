namespace MyStoreWinApp
{
    public partial class frmShopping
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
            toolStripWelcome = new ToolStripMenuItem();
            toolStripExit = new ToolStripMenuItem();
            dgv_Main = new DataGridView();
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
            dgv_OrderDetail = new DataGridView();
            btnRemoveOutOfOrder = new Button();
            btnAddToOrder = new Button();
            btnDecrease = new Button();
            btnIncrease = new Button();
            btnTotalPrice = new Button();
            btnPayment = new Button();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) dgv_Main).BeginInit();
            ((System.ComponentModel.ISupportInitialize) dgv_OrderDetail).BeginInit();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            menuStripMain.Items.AddRange(new ToolStripItem[] { toolStripWelcome, toolStripExit });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.MdiWindowListItem = toolStripWelcome;
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1047, 33);
            menuStripMain.TabIndex = 1;
            menuStripMain.Text = "menuStrip1";
            // 
            // toolStripWelcome
            // 
            toolStripWelcome.BackColor = SystemColors.Control;
            toolStripWelcome.Enabled = false;
            toolStripWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripWelcome.ForeColor = SystemColors.Desktop;
            toolStripWelcome.Name = "toolStripWelcome";
            toolStripWelcome.Size = new Size(71, 29);
            toolStripWelcome.Text = "Hello";
            // 
            // toolStripExit
            // 
            toolStripExit.Alignment = ToolStripItemAlignment.Right;
            toolStripExit.BackColor = SystemColors.AppWorkspace;
            toolStripExit.Name = "toolStripExit";
            toolStripExit.Size = new Size(149, 29);
            toolStripExit.Text = "Exit Shopping";
            toolStripExit.Click += btnExit_Click;
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
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left;
            txtSearch.CharacterCasing = CharacterCasing.Lower;
            txtSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtSearch.Location = new Point(299, 313);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter to Search";
            txtSearch.Size = new Size(570, 33);
            txtSearch.TabIndex = 7;
            txtSearch.KeyPress += Enter_KeyPress;
            // 
            // cbSearchChoice
            // 
            cbSearchChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSearchChoice.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            cbSearchChoice.FormattingEnabled = true;
            cbSearchChoice.Location = new Point(12, 313);
            cbSearchChoice.Name = "cbSearchChoice";
            cbSearchChoice.Size = new Size(281, 33);
            cbSearchChoice.TabIndex = 9;
            // 
            // txtSpec2
            // 
            txtSpec2.Anchor = AnchorStyles.Left;
            txtSpec2.Enabled = false;
            txtSpec2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec2.Location = new Point(299, 89);
            txtSpec2.Name = "txtSpec2";
            txtSpec2.Size = new Size(259, 26);
            txtSpec2.TabIndex = 7;
            // 
            // txtSpec3
            // 
            txtSpec3.Anchor = AnchorStyles.Left;
            txtSpec3.Enabled = false;
            txtSpec3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec3.Location = new Point(299, 156);
            txtSpec3.Name = "txtSpec3";
            txtSpec3.Size = new Size(259, 26);
            txtSpec3.TabIndex = 7;
            // 
            // txtSpec4
            // 
            txtSpec4.Anchor = AnchorStyles.Left;
            txtSpec4.Enabled = false;
            txtSpec4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec4.Location = new Point(299, 221);
            txtSpec4.Name = "txtSpec4";
            txtSpec4.Size = new Size(259, 26);
            txtSpec4.TabIndex = 7;
            // 
            // txtItemId
            // 
            txtItemId.Anchor = AnchorStyles.Left;
            txtItemId.Enabled = false;
            txtItemId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtItemId.Location = new Point(12, 89);
            txtItemId.Name = "txtItemId";
            txtItemId.Size = new Size(259, 26);
            txtItemId.TabIndex = 7;
            // 
            // txtItemName
            // 
            txtItemName.Anchor = AnchorStyles.Left;
            txtItemName.Enabled = false;
            txtItemName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtItemName.Location = new Point(12, 156);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(259, 26);
            txtItemName.TabIndex = 7;
            // 
            // txtSpec1
            // 
            txtSpec1.Anchor = AnchorStyles.Left;
            txtSpec1.Enabled = false;
            txtSpec1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSpec1.Location = new Point(12, 221);
            txtSpec1.Name = "txtSpec1";
            txtSpec1.Size = new Size(259, 26);
            txtSpec1.TabIndex = 7;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.BackColor = SystemColors.AppWorkspace;
            lbId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbId.ForeColor = Color.Black;
            lbId.Location = new Point(12, 66);
            lbId.Name = "lbId";
            lbId.Size = new Size(64, 20);
            lbId.TabIndex = 11;
            lbId.Text = "Item id";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.BackColor = SystemColors.AppWorkspace;
            lbName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbName.ForeColor = Color.Black;
            lbName.Location = new Point(12, 136);
            lbName.Name = "lbName";
            lbName.Size = new Size(94, 20);
            lbName.TabIndex = 11;
            lbName.Text = "Item name";
            // 
            // lbSpec1
            // 
            lbSpec1.AutoSize = true;
            lbSpec1.BackColor = SystemColors.AppWorkspace;
            lbSpec1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec1.ForeColor = Color.Black;
            lbSpec1.Location = new Point(12, 198);
            lbSpec1.Name = "lbSpec1";
            lbSpec1.Size = new Size(57, 20);
            lbSpec1.TabIndex = 11;
            lbSpec1.Text = "spec1";
            // 
            // lbSpec4
            // 
            lbSpec4.AutoSize = true;
            lbSpec4.BackColor = SystemColors.AppWorkspace;
            lbSpec4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec4.ForeColor = Color.Black;
            lbSpec4.Location = new Point(299, 198);
            lbSpec4.Name = "lbSpec4";
            lbSpec4.Size = new Size(57, 20);
            lbSpec4.TabIndex = 12;
            lbSpec4.Text = "spec4";
            // 
            // lbSpec3
            // 
            lbSpec3.AutoSize = true;
            lbSpec3.BackColor = SystemColors.AppWorkspace;
            lbSpec3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec3.ForeColor = Color.Black;
            lbSpec3.Location = new Point(299, 133);
            lbSpec3.Name = "lbSpec3";
            lbSpec3.Size = new Size(57, 20);
            lbSpec3.TabIndex = 13;
            lbSpec3.Text = "spec3";
            // 
            // lbSpec2
            // 
            lbSpec2.AutoSize = true;
            lbSpec2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec2.ForeColor = Color.Black;
            lbSpec2.Location = new Point(299, 66);
            lbSpec2.Name = "lbSpec2";
            lbSpec2.Size = new Size(57, 20);
            lbSpec2.TabIndex = 14;
            lbSpec2.Text = "spec2";
            // 
            // dgv_OrderDetail
            // 
            dgv_OrderDetail.AllowUserToAddRows = false;
            dgv_OrderDetail.AllowUserToDeleteRows = false;
            dgv_OrderDetail.AllowUserToOrderColumns = true;
            dgv_OrderDetail.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_OrderDetail.BackgroundColor = SystemColors.Control;
            dgv_OrderDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_OrderDetail.Location = new Point(619, 89);
            dgv_OrderDetail.Name = "dgv_OrderDetail";
            dgv_OrderDetail.ReadOnly = true;
            dgv_OrderDetail.RowTemplate.Height = 25;
            dgv_OrderDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_OrderDetail.Size = new Size(416, 158);
            dgv_OrderDetail.TabIndex = 16;
            // 
            // btnRemoveOutOfOrder
            // 
            btnRemoveOutOfOrder.Anchor = AnchorStyles.Right;
            btnRemoveOutOfOrder.BackColor = Color.FromArgb(  255,   192,   192);
            btnRemoveOutOfOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoveOutOfOrder.Location = new Point(839, 50);
            btnRemoveOutOfOrder.Name = "btnRemoveOutOfOrder";
            btnRemoveOutOfOrder.Size = new Size(196, 33);
            btnRemoveOutOfOrder.TabIndex = 6;
            btnRemoveOutOfOrder.Text = "Remove out of Order";
            btnRemoveOutOfOrder.UseVisualStyleBackColor = false;
            btnRemoveOutOfOrder.Click += btnRemoveOutOfOrder_Click;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Anchor = AnchorStyles.Right;
            btnAddToOrder.BackColor = SystemColors.ActiveCaption;
            btnAddToOrder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddToOrder.Location = new Point(875, 313);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(160, 33);
            btnAddToOrder.TabIndex = 6;
            btnAddToOrder.Text = "Add to Order";
            btnAddToOrder.UseVisualStyleBackColor = false;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // btnDecrease
            // 
            btnDecrease.Anchor = AnchorStyles.Right;
            btnDecrease.BackColor = SystemColors.ActiveBorder;
            btnDecrease.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDecrease.Location = new Point(619, 50);
            btnDecrease.Name = "btnDecrease";
            btnDecrease.Size = new Size(91, 33);
            btnDecrease.TabIndex = 6;
            btnDecrease.Text = "Decrease";
            btnDecrease.UseVisualStyleBackColor = false;
            btnDecrease.Click += btnDecrease_Click;
            // 
            // btnIncrease
            // 
            btnIncrease.Anchor = AnchorStyles.Right;
            btnIncrease.BackColor = SystemColors.ActiveBorder;
            btnIncrease.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnIncrease.Location = new Point(716, 50);
            btnIncrease.Name = "btnIncrease";
            btnIncrease.Size = new Size(91, 33);
            btnIncrease.TabIndex = 6;
            btnIncrease.Text = "Increase";
            btnIncrease.UseVisualStyleBackColor = false;
            btnIncrease.Click += btnIncrease_Click;
            // 
            // btnTotalPrice
            // 
            btnTotalPrice.Anchor = AnchorStyles.Right;
            btnTotalPrice.BackColor = SystemColors.ActiveCaption;
            btnTotalPrice.Enabled = false;
            btnTotalPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnTotalPrice.Location = new Point(619, 253);
            btnTotalPrice.Name = "btnTotalPrice";
            btnTotalPrice.Size = new Size(319, 33);
            btnTotalPrice.TabIndex = 6;
            btnTotalPrice.Text = "Total Price: ";
            btnTotalPrice.UseVisualStyleBackColor = false;
            btnTotalPrice.Click += btnRemoveOutOfOrder_Click;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = AnchorStyles.Right;
            btnPayment.BackColor = SystemColors.ActiveBorder;
            btnPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPayment.Location = new Point(944, 253);
            btnPayment.Name = "btnPayment";
            btnPayment.Size = new Size(91, 33);
            btnPayment.TabIndex = 6;
            btnPayment.Text = "Payment";
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // frmShopping
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1047, 540);
            Controls.Add(dgv_OrderDetail);
            Controls.Add(lbSpec4);
            Controls.Add(lbSpec3);
            Controls.Add(lbSpec2);
            Controls.Add(lbSpec1);
            Controls.Add(lbName);
            Controls.Add(lbId);
            Controls.Add(cbSearchChoice);
            Controls.Add(txtSpec1);
            Controls.Add(txtSpec4);
            Controls.Add(txtItemName);
            Controls.Add(txtItemId);
            Controls.Add(txtSpec3);
            Controls.Add(txtSpec2);
            Controls.Add(txtSearch);
            Controls.Add(btnAddToOrder);
            Controls.Add(btnTotalPrice);
            Controls.Add(btnRemoveOutOfOrder);
            Controls.Add(btnPayment);
            Controls.Add(btnIncrease);
            Controls.Add(btnDecrease);
            Controls.Add(dgv_Main);
            Controls.Add(menuStripMain);
            IsMdiContainer = true;
            MainMenuStrip = menuStripMain;
            Name = "frmShopping";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shopping Form";
            Load += Form_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) dgv_Main).EndInit();
            ((System.ComponentModel.ISupportInitialize) dgv_OrderDetail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem toolStripMember;
        private ToolStripMenuItem toolStripCategory;
        private ToolStripMenuItem toolStripWelcome;
        private ToolStripMenuItem toolStripOrder;
        private ToolStripMenuItem menuItemAddMember;
        private ToolStripMenuItem menuItemAddCategory;
        private ToolStripMenuItem menuItemAddProduct;
        private ToolStripMenuItem toolStripReport;
        private ToolStripMenuItem toolStripExit;
        private DataGridView dgv_Main;
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
        private DataGridView dgv_OrderDetail;
        private Button btnRemoveOutOfOrder;
        private Button btnAddToOrder;
        private Button btnDecrease;
        private Button btnIncrease;
        private Button btnTotalPrice;
        private Button btnPayment;
        private ToolStripMenuItem shoppingToolStripMenuItem;
    }
}