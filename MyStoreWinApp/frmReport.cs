using BusinessObject;
using DataAccess.Repository;
using MyStoreWinApp.Utility;
using System.Data;

namespace MyStoreWinApp
{
    public partial class frmReport : Form
    {
        public IRepository<Order> _order { get; set; }
        public frmReport()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
            => DataGridView_Load(_order.GetAll());

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void btnSearchReport_Click(object sender, EventArgs e)
            => SearchReport();

        private void SearchReport()
        {
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            bool startDateNotEmpty = !string.IsNullOrEmpty(startDate);
            bool endDateNotEmpty = !string.IsNullOrEmpty(endDate);

            DateTime start = startDateNotEmpty ? datePickStart.Value : datePickStart.MinDate;
            DateTime end = endDateNotEmpty ? datePickEnd.Value : datePickEnd.MaxDate;

            var condition = (Order o) => o.OrderDate.Date >= start.Date && o.OrderDate.Date <= end.Date;
            DataGridView_Load(_order.GetListByCondition(condition));
        }

        #region DataGridView
        private void DataGridView_Load(IList<Order> searchingSource)
        {
            IList<Order> source = searchingSource;
            if (source == null) source = new List<Order>();
            if (source is IList<Order> orders)
            {
                var newSource = orders.Select(o => new { o.OrderId, o.member?.Email, o.OrderDate, o.RequiredDate, o.ShippedDate, o.Freight }).ToList();
                dgv_Main.DataSource = newSource;
            }
            AutoFitDataGridItem(dgv_Main);
        }

        private void AutoFitDataGridItem(DataGridView dataGridView)
        {
            foreach (var item in dataGridView.Columns)
            {
                if (item is DataGridViewColumn column)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
        #endregion

        #region DateTimePicker
        private void datePick_ValueChanged(object sender, EventArgs e)
        {
            var formatter = DateTimeHelper.Instance;
            if (sender is DateTimePicker picker)
            {
                bool pickStart = picker == datePickStart;
                if (pickStart) txtStartDate.Text = formatter.ToStringWithCurrentOutputFormat(datePickStart.Value);
                else txtEndDate.Text = formatter.ToStringWithCurrentOutputFormat(datePickEnd.Value);
            }
        }

        private void DateTimeTextBox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                bool pickStart = textBox == txtStartDate;
                if (pickStart) datePickStart.Select();
                else datePickEnd.Select();
            }
            SendKeys.Send("%{DOWN}");
        }
        #endregion
    }
}
