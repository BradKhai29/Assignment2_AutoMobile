namespace MyStoreWinApp
{
    partial class frmReport
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
            datePickStart = new DateTimePicker();
            datePickEnd = new DateTimePicker();
            btnSearchReport = new Button();
            txtEndDate = new TextBox();
            txtStartDate = new TextBox();
            dgv_Main = new DataGridView();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            lbSpec3 = new Label();
            lbTotal = new Label();
            txtTotalOrders = new TextBox();
            txtTotalIncome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize) dgv_Main).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // datePickStart
            // 
            datePickStart.CalendarFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            datePickStart.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            datePickStart.Location = new Point(274, 263);
            datePickStart.Name = "datePickStart";
            datePickStart.Size = new Size(19, 29);
            datePickStart.TabIndex = 27;
            datePickStart.ValueChanged += datePick_ValueChanged;
            // 
            // datePickEnd
            // 
            datePickEnd.CalendarFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            datePickEnd.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            datePickEnd.Location = new Point(561, 263);
            datePickEnd.Name = "datePickEnd";
            datePickEnd.Size = new Size(19, 29);
            datePickEnd.TabIndex = 28;
            datePickEnd.ValueChanged += datePick_ValueChanged;
            // 
            // btnSearchReport
            // 
            btnSearchReport.BackColor = Color.Silver;
            btnSearchReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchReport.Location = new Point(586, 261);
            btnSearchReport.Name = "btnSearchReport";
            btnSearchReport.Size = new Size(280, 31);
            btnSearchReport.TabIndex = 26;
            btnSearchReport.Text = "Search";
            btnSearchReport.UseVisualStyleBackColor = false;
            btnSearchReport.Click += btnSearchReport_Click;
            // 
            // txtEndDate
            // 
            txtEndDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtEndDate.Location = new Point(299, 263);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.PlaceholderText = "Select EndDate";
            txtEndDate.Size = new Size(281, 29);
            txtEndDate.TabIndex = 22;
            txtEndDate.Click += DateTimeTextBox_Click;
            // 
            // txtStartDate
            // 
            txtStartDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtStartDate.Location = new Point(12, 263);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.PlaceholderText = "Select StartDate";
            txtStartDate.Size = new Size(281, 29);
            txtStartDate.TabIndex = 23;
            txtStartDate.Click += DateTimeTextBox_Click;
            // 
            // dgv_Main
            // 
            dgv_Main.AllowUserToAddRows = false;
            dgv_Main.AllowUserToDeleteRows = false;
            dgv_Main.AllowUserToOrderColumns = true;
            dgv_Main.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Main.BackgroundColor = SystemColors.Control;
            dgv_Main.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Main.Location = new Point(12, 299);
            dgv_Main.Name = "dgv_Main";
            dgv_Main.ReadOnly = true;
            dgv_Main.RowTemplate.Height = 25;
            dgv_Main.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Main.Size = new Size(854, 176);
            dgv_Main.TabIndex = 29;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveBorder;
            menuStrip1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(878, 33);
            menuStrip1.TabIndex = 30;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.AccessibleRole = AccessibleRole.None;
            exitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(119, 29);
            exitToolStripMenuItem.Text = "Exit Report";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // lbSpec3
            // 
            lbSpec3.AutoSize = true;
            lbSpec3.BackColor = SystemColors.Control;
            lbSpec3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpec3.ForeColor = Color.Black;
            lbSpec3.Location = new Point(13, 57);
            lbSpec3.Name = "lbSpec3";
            lbSpec3.Size = new Size(115, 25);
            lbSpec3.TabIndex = 35;
            lbSpec3.Text = "Total Orders";
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbTotal.ForeColor = Color.Black;
            lbTotal.Location = new Point(13, 149);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(372, 25);
            lbTotal.TabIndex = 36;
            lbTotal.Text = "Total Income (From StartDate to EndDate)";
            // 
            // txtTotalOrders
            // 
            txtTotalOrders.Anchor = AnchorStyles.Left;
            txtTotalOrders.Enabled = false;
            txtTotalOrders.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotalOrders.Location = new Point(13, 85);
            txtTotalOrders.Name = "txtTotalOrders";
            txtTotalOrders.Size = new Size(853, 33);
            txtTotalOrders.TabIndex = 32;
            // 
            // txtTotalIncome
            // 
            txtTotalIncome.Anchor = AnchorStyles.Left;
            txtTotalIncome.Enabled = false;
            txtTotalIncome.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotalIncome.Location = new Point(13, 177);
            txtTotalIncome.Name = "txtTotalIncome";
            txtTotalIncome.Size = new Size(853, 33);
            txtTotalIncome.TabIndex = 33;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 235);
            label1.Name = "label1";
            label1.Size = new Size(206, 25);
            label1.TabIndex = 35;
            label1.Text = "Start Date (OrderDate)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(299, 235);
            label2.Name = "label2";
            label2.Size = new Size(197, 25);
            label2.TabIndex = 35;
            label2.Text = "End Date (OrderDate)";
            // 
            // frmReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 487);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbSpec3);
            Controls.Add(lbTotal);
            Controls.Add(txtTotalOrders);
            Controls.Add(txtTotalIncome);
            Controls.Add(dgv_Main);
            Controls.Add(datePickStart);
            Controls.Add(datePickEnd);
            Controls.Add(btnSearchReport);
            Controls.Add(txtEndDate);
            Controls.Add(txtStartDate);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmReport";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize) dgv_Main).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker datePickStart;
        private DateTimePicker datePickEnd;
        private Button btnSearchReport;
        private TextBox txtEndDate;
        private TextBox txtStartDate;
        private DataGridView dgv_Main;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label lbSpec3;
        private Label lbTotal;
        private TextBox txtTotalOrders;
        private TextBox txtTotalIncome;
        private Label label1;
        private Label label2;
    }
}