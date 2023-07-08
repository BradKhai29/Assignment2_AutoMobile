using BusinessObject;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using MyStoreWinApp.Database;
using MyStoreWinApp.Utility;
using System.Data;

namespace MyStoreWinApp
{
    public partial class frmOrder : Form
    {
        public AppDbContext orderContext { get; set; }
        public IRepository<Order> _repo { get; set; }
        public int OrderId { get; set; }
        public bool IsAdmin { get; set; }
        private static readonly DateTimeHelper formatter = DateTimeHelper.Instance;

        public frmOrder()
        {
            InitializeComponent();
        }

        private int GetTotal(Order order)
        {
            decimal total = 0;
            orderContext.Entry(order).Collection(order => order.Details).Load();
            foreach (var detail in order.Details)
            {
                total += (detail.UnitPrice * detail.Quantity) - (decimal) (detail.Discount);
            }
            return decimal.ToInt32(total);
        }

        #region Form and DataGridView Load
        private void Form_Load(object sender, EventArgs e)
        {
            // Load order
            var order = orderContext.Orders.First(o => o.OrderId == OrderId);
            orderContext.Entry(order).Reference(o => o.Member).Load();

            // Load related information to textbox
            txtEmail.Text = order.Member?.Email;
            txtOrderDate.Text = formatter.ToStringWithFormat(order.OrderDate, BuiltInFormat.ddMMyyyy_HHmmss);
            txtTotal.Text = GetTotal(order).ToString();
            if (order.RequiredDate != null) mtxtRequiredDate.Text = formatter.ToStringWithCurrentOutputFormat(order.RequiredDate.Value);
            if (order.ShippedDate != null) mtxtShipDate.Text = formatter.ToStringWithCurrentOutputFormat(order.ShippedDate.Value);
            if (order.Freight != default) txtFreight.Text = decimal.ToInt32(order.Freight.Value).ToString();

            btnOrderTitle.Text = $"Order ID: {OrderId}";
            Form_Load(isAdmin: IsAdmin);
            EnableDateTimePicker(isAdmin: IsAdmin);
            Load_DataGridView(order);
        }

        private void Form_Load(bool isAdmin)
        {
            txtFreight.Enabled = isAdmin;
            mtxtRequiredDate.Enabled = !isAdmin;
            mtxtShipDate.Enabled = isAdmin;
        }

        private void Load_DataGridView(Order order)
        {
            var orderDetails = order.Details;
            if (orderDetails != null)
            {
                var source = orderDetails.Select(detail => new
                {
                    ProductName = orderContext.Products.AsNoTracking().First(p => p.ProductId == detail.ProductId).ProductName,
                    detail.UnitPrice,
                    detail.Quantity,
                    detail.Discount
                }).ToList();
                dgv_Detail.DataSource = source;
                AutoFitDataGridItem(dgv_Detail);
            }
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

        #region Button Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            var order = _repo.GetById(OrderId);
            // Input Helper to Validate input
            IInputHelper<string> inputHelper = new DateTimeInputHelper
            {
                Input = mtxtShipDate.Text,
                CompareDate = order.OrderDate,
                CompareType = DateTimeCompareType.LaterThan
            };
            IInputHelper<object> numberInputHelper = new SearchWithNumberInput<object>
            {
                Input = txtFreight.Text
            };

            if (IsAdmin)
            {
                bool enterShipDate = !string.IsNullOrEmpty(mtxtShipDate.Text);
                bool enterFreight = !string.IsNullOrWhiteSpace(txtFreight.Text.Trim());
                bool isValid = true;
                if (enterShipDate)
                {
                    if (!inputHelper.ValidateInput())
                    {
                        MessageBox.Show("Please enter the Shipped date later than the order date", "Input Error");
                        isValid &= false;
                    }
                    else order.ShippedDate = formatter.ToDateTimeWithFormat(mtxtShipDate.Text);
                }
                if (enterFreight)
                {
                    if (!numberInputHelper.ValidateInput())
                    {
                        MessageBox.Show("Freight must be a number", "Input Error");
                        isValid &= false;
                    }
                    else order.Freight = int.Parse(numberInputHelper.Input);
                }
                if (isValid)
                {
                    _repo.Update(order);
                    Close();
                }
            }
            else
            {
                inputHelper.Input = mtxtRequiredDate.Text;
                if (!inputHelper.ValidateInput()) MessageBox.Show("Please enter the Required Date later than the order date", "Input Error");
                else
                {
                    order.RequiredDate = formatter.ToDateTimeWithFormat(mtxtRequiredDate.Text);
                    _repo.Update(order);
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        #endregion

        #region DateTimePicker
        private void EnableDateTimePicker(bool isAdmin)
        {
            datePickRequired.Enabled = !isAdmin;
            datePickShip.Enabled = isAdmin;
        }

        private void DateTimeTextBox_Click(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox textBox)
            {
                bool pickRequired = textBox == mtxtRequiredDate;
                if (pickRequired) datePickRequired.Select();
                else datePickShip.Select();
            }
            SendKeys.Send("%{DOWN}");
        }

        private void datePick_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker picker)
            {
                bool pickRequired = picker == datePickRequired;
                if (pickRequired) mtxtRequiredDate.Text = formatter.ToStringWithCurrentOutputFormat(datePickRequired.Value);
                else mtxtShipDate.Text = formatter.ToStringWithCurrentOutputFormat(datePickShip.Value);
            }
        }
        #endregion
    }
}
