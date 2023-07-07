using BusinessObject;
using DataAccess.Repository;
using MyStoreWinApp.Utility;

namespace MyStoreWinApp
{
    public partial class frmShopping : Form
    {
        #region Database_Repository
        public IRepository<Product> _product;
        public IMemberRepository _member;
        public IRepository<Order> _order;
        public IRepository<OrderDetail> _orderDetail;
        #endregion

        private readonly ISessionService sessionService = SessionService.Instance;

        public frmShopping()
        {
            InitializeComponent();
        }

        #region Load Form
        private void Form_Load(object sender, EventArgs e)
        {
            LoadWelcome();
            DataGridView_Load(_product);
            OrderDetail_Load();
        }

        public void LoadWelcome()
        {
            var LoginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            if (LoginMember == null) toolStripWelcome.Text = "Hello, Guest";
            else
            {
                string memberName = LoginMember.Email.Substring(0, LoginMember.Email.IndexOf("@"));
                toolStripWelcome.Text = $"Hello, {memberName}";
            }
        }
        #endregion

        #region DataGridView
        private void DataGridView_Load<T>(IRepository<T> repository) where T : class
        {
            LoadSearchChoice();
            cbSearchChoice.SelectedIndex = 0;

            IList<T> source = repository.GetAll();
            source = repository.GetListByCondition(p => (p as Product).IsAvailable);
            if (source == null) source = new List<T>();

            if (source is IList<Product> products)
            {
                var newSource = products.Select(p => new { p.ProductId, p.ProductName, Category = p.Category?.CategoryName, p.UnitPrice, p.UnitsInStock, p.Weight }).ToList();
                dgv_Main.DataSource = newSource;
                TextFieldBinding(
                    source: newSource,
                    txtIdDataMember: nameof(Product.ProductId),
                    txtItemNameDataMember: nameof(Product.ProductName),
                    txtSpec1DataMember: nameof(Product.Category),
                    txtSpec2DataMember: nameof(Product.UnitPrice),
                    txtSpec3DataMember: nameof(Product.UnitsInStock),
                    txtSpec4DataMember: nameof(Product.Weight));
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

        private void TextFieldBinding<T>(
            IList<T> source,
            string txtIdDataMember,
            string txtItemNameDataMember,
            string txtSpec1DataMember,
            string txtSpec2DataMember,
            string txtSpec3DataMember,
            string txtSpec4DataMember)
        {
            txtItemId.DataBindings.Clear();
            txtItemName.DataBindings.Clear();
            txtSpec1.DataBindings.Clear();
            txtSpec2.DataBindings.Clear();
            txtSpec3.DataBindings.Clear();
            txtSpec4.DataBindings.Clear();
            string textBoxProperty = "Text";

            Binding IdBinding = new Binding(textBoxProperty, source, txtIdDataMember);
            lbId.Text = txtIdDataMember;
            txtItemId.DataBindings.Add(IdBinding);

            Binding nameBinding = new Binding(textBoxProperty, source, txtItemNameDataMember);
            lbName.Text = txtItemNameDataMember;
            txtItemName.DataBindings.Add(nameBinding);

            Binding spec1Binding = new Binding(textBoxProperty, source, txtSpec1DataMember);
            lbSpec1.Text = txtSpec1DataMember;
            txtSpec1.DataBindings.Add(spec1Binding);

            Binding spec2Binding = new Binding(textBoxProperty, source, txtSpec2DataMember);
            lbSpec2.Text = txtSpec2DataMember;
            txtSpec2.DataBindings.Add(spec2Binding);

            Binding spec3Binding = new Binding(textBoxProperty, source, txtSpec3DataMember);
            lbSpec3.Text = txtSpec3DataMember;
            txtSpec3.DataBindings.Add(spec3Binding);

            Binding spec4Binding = new Binding(textBoxProperty, source, txtSpec4DataMember);
            lbSpec4.Text = txtSpec4DataMember;
            txtSpec4.DataBindings.Add(spec4Binding);
        }

        private Product GetItem(int rowIndex)
        {
            var row = dgv_Main.Rows[rowIndex];
            var itemIdColumn = row.Cells[0];
            try
            {
                int itemId = int.Parse($"{itemIdColumn.Value}");
                return _product.GetById(itemId);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region btn_Event
        private void btnExit_Click(object sender, EventArgs e) => Close();
        #endregion

        #region Searching
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selectChoiceIndex = cbSearchChoice.SelectedIndex;
            SearchProduct(selectChoiceIndex);
            AutoFitDataGridItem(dgv_Main);
        }

        private void SearchProduct(int choiceIndex)
        {
            SearchHelper<Product> searchHelper = null;
            SearchResponse<IList<Product>> searchResponse;
            var isValidInput = false;
            var isEmptyInput = string.IsNullOrWhiteSpace(txtSearch.Text);

            var defaultCondition = (Product p) => p.ProductName.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase);
            switch (choiceIndex)
            {
                case 0:
                case 1:
                    searchHelper = new SearchByName<Product>
                    {
                        repository = _product,
                        Input = txtSearch.Text,
                        condition = defaultCondition
                    };
                    break;
                case 2:
                    searchHelper = new SearchById<Product>
                    {
                        repository = _product,
                        Input = txtSearch.Text,
                        condition = p => $"{p.ProductId}".Contains(txtSearch.Text)
                    };
                    break;
                case 3:
                    searchHelper = new SearchByPrice<Product>
                    {
                        repository = _product,
                        Input = txtSearch.Text,
                    };
                    isValidInput = searchHelper.ValidateInput();
                    if (isValidInput)
                    {
                        int rangePrice = isEmptyInput ? int.MaxValue : int.Parse(txtSearch.Text);
                        searchHelper.condition = isEmptyInput ? p => p.UnitPrice <= rangePrice
                                                            : p => p.UnitPrice == rangePrice;
                    }
                    break;
                case 4:
                    searchHelper = new SearchByUnitsInStock<Product>
                    {
                        repository = _product,
                        Input = txtSearch.Text,
                    };
                    isValidInput = searchHelper.ValidateInput();
                    if (isValidInput)
                    {
                        int rangeStock = isEmptyInput ? int.MaxValue : int.Parse(txtSearch.Text);
                        searchHelper.condition = isEmptyInput ? p => p.UnitPrice <= rangeStock
                                                            : p => p.UnitPrice == rangeStock;
                    }
                    break;
            }
            searchResponse = searchHelper.Search();
            if (searchResponse.IsSuccess)
            {
                dgv_Main.DataSource = searchResponse.Response;
            }
            else MessageBox.Show(searchResponse.Message, "Search Error");
        }

        #endregion

        #region Display Search Choices
        private void LoadSearchChoice()
        {
            if (cbSearchChoice.Items.Count == 0)
            {
                cbSearchChoice.Items.AddRange(new frmMain().GetSearchCriterias(nameof(Product)));
            }
        }
        #endregion

        #region AddToOrder
        private void OrderDetail_Load()
        {
            var orderCart = sessionService.GetSessionData<IList<Product>>(SessionId.OrderCart);
            if (orderCart == null) orderCart = new List<Product>();

            var source = orderCart.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.UnitPrice,
                p.OrderQuantity
            }).ToList();

            decimal totalPrice = 0;
            foreach (var product in source)
            {
                totalPrice += (product.OrderQuantity * product.UnitPrice);
            }
            btnTotalPrice.Text = $"Total Price: {totalPrice}";
            dgv_OrderDetail.DataSource = source;

            AutoFitDataGridItem(dgv_OrderDetail);
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dgv_Main.Rows.Count == 0)
            {
                MessageBox.Show("No Product to Add To Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowIndex = dgv_Main.SelectedRows[0].Index;
                var product = GetItem(rowIndex);
                if (product != null)
                {
                    var orderCart = sessionService.GetSessionData<IList<Product>>(SessionId.OrderCart);
                    if (orderCart == null)
                    {
                        orderCart = new List<Product>();
                        sessionService.AddSessionData(SessionId.OrderCart, orderCart);
                    }
                    bool isAlreadyAdd = orderCart.FirstOrDefault(p => p.ProductId == product.ProductId) != null;
                    if (isAlreadyAdd)
                    {
                        orderCart.First(p => p.ProductId == product.ProductId).OrderQuantity++;
                    }
                    else orderCart.Add(product);
                }

                OrderDetail_Load();
            }
            catch (Exception ex)
            {
                string message = ex is ArgumentException ? ex.Message
                                                        : "Please select Product to Add To Order";

                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Product GetProduct(string action)
        {
            var orderCart = sessionService.GetSessionData<IList<Product>>(SessionId.OrderCart);
            if (orderCart == null) orderCart = new List<Product>();
            try
            {
                int rowIndex = dgv_OrderDetail.SelectedRows[0].Index;
                var row = dgv_OrderDetail.Rows[rowIndex];
                var itemIdColumn = row.Cells[0];
                int itemId = int.Parse($"{itemIdColumn.Value}");

                return orderCart.FirstOrDefault(p => p.ProductId == itemId);
            }
            catch (Exception)
            {
                string message = orderCart.Count == 0 ? "Order is Empty" : $"Please Select Product in the Order to {action}";
                MessageBox.Show(message, "Warning");
                return null;
            }
        }

        private void btnRemoveOutOfOrder_Click(object sender, EventArgs e)
        {
            var orderCart = sessionService.GetSessionData<IList<Product>>(SessionId.OrderCart);
            var removeProduct = GetProduct("remove");
            if (removeProduct != null)
            {
                orderCart.Remove(removeProduct);
            }
            OrderDetail_Load();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            var product = GetProduct("increase");
            if (product != null)
            {
                product.OrderQuantity++;
            }
            OrderDetail_Load();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            var product = GetProduct("decrease");
            if (product != null)
            {
                int currentQuantity = product.OrderQuantity;
                product.OrderQuantity = currentQuantity == 1 ? currentQuantity
                                                            : currentQuantity - 1;
            }
            OrderDetail_Load();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var orderCart = sessionService.GetSessionData<IList<Product>>(SessionId.OrderCart);
            orderCart ??= new List<Product>();
            if (orderCart.Count == 0)
            {
                MessageBox.Show("Please add some Product to Order before do Payment", "Do Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var LoginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            if (LoginMember != null)
            {
                var result = MessageBox.Show("Do you want to do payment now ?", "Do Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ProcessPayment(orderCart, LoginMember.MemberId);
                }
            }
            else MessageBox.Show("Please login to do Payment", "Do Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessPayment(IList<Product> orderCart, int memberId)
        {
            Order order = new Order
            {
                MemberId = memberId,
                OrderDate = DateTime.Now,
            };

            var response = _order.Insert(order);
            foreach (var product in orderCart)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = response.Response.OrderId,
                    ProductId = product.ProductId,
                    Quantity = product.OrderQuantity,
                    UnitPrice = product.UnitPrice,
                    Discount = 0
                };
                _orderDetail.Insert(orderDetail);
            }

            orderCart.Clear();
            OrderDetail_Load();
            MessageBox.Show("Payment success, please wait for us to process your order", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
