namespace MyStoreWinApp
{
    partial class frmOrder
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
            btnOrderTitle = new Button();
            btnDetail = new Button();
            lbTotal = new Label();
            txtTotal = new TextBox();
            dgv_Detail = new DataGridView();
            btnCancel = new Button();
            btnSave = new Button();
            lbMember = new Label();
            lbOrderDate = new Label();
            txtEmail = new TextBox();
            txtOrderDate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            mtxtRequiredDate = new MaskedTextBox();
            mtxtShipDate = new MaskedTextBox();
            lbFreight = new Label();
            txtFreight = new TextBox();
            datePickRequired = new DateTimePicker();
            datePickShip = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize) dgv_Detail).BeginInit();
            SuspendLayout();
            // 
            // btnOrderTitle
            // 
            btnOrderTitle.BackColor = Color.FromArgb(  255,   192,   128);
            btnOrderTitle.Dock = DockStyle.Top;
            btnOrderTitle.Enabled = false;
            btnOrderTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderTitle.Location = new Point(0, 0);
            btnOrderTitle.Name = "btnOrderTitle";
            btnOrderTitle.Size = new Size(687, 50);
            btnOrderTitle.TabIndex = 4;
            btnOrderTitle.Text = "ORDER DETAIL FORM";
            btnOrderTitle.UseVisualStyleBackColor = false;
            // 
            // btnDetail
            // 
            btnDetail.Enabled = false;
            btnDetail.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDetail.ForeColor = SystemColors.ActiveCaptionText;
            btnDetail.Location = new Point(12, 275);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(663, 37);
            btnDetail.TabIndex = 5;
            btnDetail.Text = "Order Detail";
            btnDetail.UseVisualStyleBackColor = true;
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbTotal.Location = new Point(12, 74);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(128, 25);
            lbTotal.TabIndex = 6;
            lbTotal.Text = "Total Amount";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotal.Location = new Point(141, 74);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(187, 33);
            txtTotal.TabIndex = 7;
            // 
            // dgv_Detail
            // 
            dgv_Detail.AllowUserToAddRows = false;
            dgv_Detail.AllowUserToDeleteRows = false;
            dgv_Detail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Detail.Location = new Point(12, 311);
            dgv_Detail.Name = "dgv_Detail";
            dgv_Detail.ReadOnly = true;
            dgv_Detail.RowTemplate.Height = 25;
            dgv_Detail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Detail.Size = new Size(663, 170);
            dgv_Detail.TabIndex = 8;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.Location = new Point(585, 487);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.Location = new Point(489, 487);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 33);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lbMember
            // 
            lbMember.AutoSize = true;
            lbMember.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbMember.Location = new Point(345, 77);
            lbMember.Name = "lbMember";
            lbMember.Size = new Size(137, 25);
            lbMember.TabIndex = 6;
            lbMember.Text = "Member Email";
            // 
            // lbOrderDate
            // 
            lbOrderDate.AutoSize = true;
            lbOrderDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbOrderDate.Location = new Point(12, 131);
            lbOrderDate.Name = "lbOrderDate";
            lbOrderDate.Size = new Size(107, 25);
            lbOrderDate.TabIndex = 6;
            lbOrderDate.Text = "Order Date";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtEmail.Location = new Point(488, 74);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(181, 33);
            txtEmail.TabIndex = 7;
            // 
            // txtOrderDate
            // 
            txtOrderDate.Enabled = false;
            txtOrderDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtOrderDate.Location = new Point(141, 131);
            txtOrderDate.Name = "txtOrderDate";
            txtOrderDate.Size = new Size(187, 33);
            txtOrderDate.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(345, 190);
            label1.Name = "label1";
            label1.Size = new Size(127, 25);
            label1.TabIndex = 6;
            label1.Text = "Shipped Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(345, 134);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 6;
            label2.Text = "Required Date";
            // 
            // mtxtRequiredDate
            // 
            mtxtRequiredDate.Enabled = false;
            mtxtRequiredDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            mtxtRequiredDate.Location = new Point(489, 131);
            mtxtRequiredDate.Name = "mtxtRequiredDate";
            mtxtRequiredDate.PromptChar = '.';
            mtxtRequiredDate.Size = new Size(181, 33);
            mtxtRequiredDate.TabIndex = 9;
            mtxtRequiredDate.ValidatingType = typeof(DateTime);
            mtxtRequiredDate.Click += DateTimeTextBox_Click;
            // 
            // mtxtShipDate
            // 
            mtxtShipDate.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            mtxtShipDate.Location = new Point(489, 187);
            mtxtShipDate.Name = "mtxtShipDate";
            mtxtShipDate.PromptChar = '.';
            mtxtShipDate.Size = new Size(180, 33);
            mtxtShipDate.TabIndex = 9;
            mtxtShipDate.ValidatingType = typeof(DateTime);
            mtxtShipDate.Click += DateTimeTextBox_Click;
            // 
            // lbFreight
            // 
            lbFreight.AutoSize = true;
            lbFreight.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbFreight.Location = new Point(12, 187);
            lbFreight.Name = "lbFreight";
            lbFreight.Size = new Size(73, 25);
            lbFreight.TabIndex = 6;
            lbFreight.Text = "Freight";
            // 
            // txtFreight
            // 
            txtFreight.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtFreight.Location = new Point(140, 187);
            txtFreight.Name = "txtFreight";
            txtFreight.Size = new Size(188, 33);
            txtFreight.TabIndex = 7;
            // 
            // datePickRequired
            // 
            datePickRequired.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            datePickRequired.Location = new Point(651, 131);
            datePickRequired.Name = "datePickRequired";
            datePickRequired.Size = new Size(19, 33);
            datePickRequired.TabIndex = 10;
            datePickRequired.ValueChanged += datePick_ValueChanged;
            // 
            // datePickShip
            // 
            datePickShip.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            datePickShip.Location = new Point(651, 187);
            datePickShip.Name = "datePickShip";
            datePickShip.Size = new Size(19, 33);
            datePickShip.TabIndex = 10;
            datePickShip.ValueChanged += datePick_ValueChanged;
            // 
            // frmOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 532);
            Controls.Add(datePickShip);
            Controls.Add(datePickRequired);
            Controls.Add(mtxtShipDate);
            Controls.Add(mtxtRequiredDate);
            Controls.Add(dgv_Detail);
            Controls.Add(txtFreight);
            Controls.Add(txtOrderDate);
            Controls.Add(txtEmail);
            Controls.Add(txtTotal);
            Controls.Add(label2);
            Controls.Add(lbFreight);
            Controls.Add(label1);
            Controls.Add(lbOrderDate);
            Controls.Add(lbMember);
            Controls.Add(lbTotal);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(btnDetail);
            Controls.Add(btnOrderTitle);
            Name = "frmOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmOrder";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_Detail).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOrderTitle;
        private Button btnDetail;
        private Label lbTotal;
        private TextBox txtTotal;
        private DataGridView dgv_Detail;
        private Button btnCancel;
        private Button btnSave;
        private Label lbMember;
        private Label lbOrderDate;
        private TextBox txtEmail;
        private TextBox txtOrderDate;
        private Label label1;
        private Label label2;
        private MaskedTextBox mtxtRequiredDate;
        private MaskedTextBox mtxtShipDate;
        private Label lbFreight;
        private TextBox txtFreight;
        private DateTimePicker datePickRequired;
        private DateTimePicker datePickShip;
    }
}