using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using DataAccess.Services;
using MyStoreWinApp.Database;
using MyStoreWinApp.Utility;

namespace MyStoreWinApp
{
    public partial class frmMain : Form
    {
        #region Form
        private frmMember memberForm;
        private frmCategory categoryForm;
        private frmProduct productForm;
        private frmOrder orderForm;
        private frmShopping shoppingForm;
        #endregion

        #region Database_Repository
        private readonly AppDbContext dbContext;
        private IRepository<Category> _category;
        private IRepository<Product> _product;
        private IMemberRepository _member;
        private IRepository<Order> _order;
        private IRepository<OrderDetail> _orderDetail;
        #endregion

        // In App Attribute
        private readonly ISessionService sessionService = SessionService.Instance;
        private string currentToolStrip = nameof(toolStripProduct);
        private static Color defaultToolStripColor = default;
        private static Color activeToolStripColor = default;

        public frmMain()
        {
            // Get ConnectionString from appsettings.json
            string ConnectionString = AppSettings.Instance.ConnectionString;
            dbContext = new AppDbContext(ConnectionString);

            if (dbContext.Database.CanConnect() == false)
            {
                dbContext.Database.EnsureCreated();
            }

            MemberDAO.Admin = AppSettings.Instance.Admin;
            _member = new MemberRepository(dbContext);
            _category = new CategoryRepository(dbContext);
            _product = new ProductRepository(dbContext);
            _order = new OrderRepository(dbContext);
            _orderDetail = new OrderDetailRepository(dbContext);

            InitializeComponent();
        }

        #region Load Form
        private void Form_Load(object sender, EventArgs e)
        {
            var loginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            if (loginMember != null)
            {
                // Display menuStrip
                string memberName = loginMember.Email.Substring(0, loginMember.Email.IndexOf("@"));
                toolStripProfile.Text = $"Welcome, {memberName}";
                var menuItems = toolStripProfile.DropDownItems;
                foreach (var item in menuItems)
                {
                    if (item is ToolStripItem toolStripItem)
                    {
                        toolStripItem.Visible = true;
                    }
                }

                // Check if admin
                bool isAdmin = loginMember.MemberId == 0;
                toolStripShopping.Visible = !isAdmin;
                if (isAdmin) LoadFormAsAdmin();
                else LoadFormAs(isGuest: false);
            }
            else
            {
                toolStripShopping.Visible = true;
                LoadFormAs(isGuest: true);
            }
            DataGridView_LoadWithSection(_product, null, "Product");
        }

        private void LoadFormAsAdmin()
        {
            // Load MenuStrip and ToolStrip section
            var subMenus = menuStripMain.Items;
            foreach (var menu in subMenus)
            {
                if (menu is ToolStripMenuItem toolStrip)
                {
                    toolStrip.Visible = toolStrip != toolStripShopping;
                }
            }
            subMenus = toolStripProduct.DropDownItems;
            foreach (var menu in subMenus) (menu as ToolStripMenuItem).Visible = true;
            menuItemEditProfile.Visible = false;
            toolStripOrder.Text = "Orders";
            // Load check all
            cbShowAll.Visible = true;
            // Load button section
            btnNew.Visible = true;
            btnDelete.Visible = true;
        }

        private void LoadFormAs(bool isGuest)
        {
            // Load Button section
            DisplayDeleteAndNewButton(isDisplay: false);

            // Load ToolStrip section
            toolStripShopping.Visible = true;
            toolStripOrder.Visible = !isGuest;
            toolStripOrder.Text = "Order History";
            if (isGuest)
            {
                toolStripProfile.Text = "Login";
            }

            // Load menu item section
            menuItemEditProfile.Visible = !isGuest;
            menuItemLogout.Visible = !isGuest;

            // Load other component
            cbShowAll.Visible = false;
            cbShowAll.Checked = false;
            if (isGuest) Reload_MenuStrip();
        }

        /// <summary>
        /// Filter Orders List if LoginMember is not Admin and return
        /// </summary>
        /// <param name="orders"></param>
        /// <returns>The Order List after filter</returns>
        private IList<Order> ResolveOrders(IList<Order> orders)
        {
            var loginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            if (loginMember != null)
            {
                bool isMember = loginMember.MemberId != 0;
                if (isMember)
                {
                    return orders.Where(o => o.MemberId == loginMember.MemberId).ToList();
                }
            }

            return orders;
        }

        private void Reload_MenuStrip()
        {
            // Reload all toolStrip
            foreach (var item in menuStripMain.Items)
            {
                if (item is ToolStripMenuItem toolStripItem)
                {
                    toolStripItem.Visible = false;
                }
            }
            toolStripProduct.Visible = true;
            toolStripShopping.Visible = true;
            toolStripProfile.Visible = true;
            toolStripProfile.Text = "Login";

            menuItemAddProduct.Visible = false;
            var menuItems = toolStripProfile.DropDownItems;
            foreach (var item in menuItems)
            {
                if (item is ToolStripItem toolStripItem)
                {
                    toolStripItem.Visible = false;
                }
            }
        }

        private void Form_Load(string section)
        {
            switch (section)
            {
                case "Category":
                    DataGridView_LoadWithSection(_category, null, section);
                    break;
                case "Product":
                    DataGridView_LoadWithSection(_product, null, section);
                    break;
                case "Member":
                    DataGridView_LoadWithSection(_member, null, section);
                    break;
                case "Order":
                    DataGridView_LoadWithSection(_order, null, section);
                    break;
            }
        }

        private void DisposeForm(object form)
        {
            string toStringMessage = $"{form}";
            string extractedToken = "Text: ";
            int formNameIndex = toStringMessage.LastIndexOf(extractedToken) + extractedToken.Length;
            var formName = toStringMessage.Substring(formNameIndex);

            // Dispose form based one form name
            switch (formName)
            {
                case "frmMember":
                    memberForm = null;
                    break;
                case "frmCategory":
                    categoryForm = null;
                    break;
                case "frmProduct":
                    productForm = null;
                    break;
                case "frmOrder":
                    orderForm = null;
                    break;
            }
        }
        #endregion

        #region DataGridView
        private void DataGridView_LoadWithSection<T>(IRepository<T> repository, IList<T> searchingSource, string section) where T : class
        {
            LoadSearchChoice(section);
            cbSearchChoice.SelectedIndex = 0;
            bool doSearch = searchingSource != null;
            IList<T> source = doSearch ? searchingSource : repository.GetAll();
            if (doSearch)
            {
                if (section == nameof(Product) && cbShowAll.Checked == false) source = searchingSource.Where(p => (p as Product).IsAvailable).ToList();
            }
            else if (section == nameof(Product) && cbShowAll.Checked == false)
            {
                source = repository.GetListByCondition(p => (p as Product).IsAvailable);
            }
            if (source == null) source = new List<T>();

            switch (section)
            {
                case "Category":
                    if (source is IList<Category> categories)
                    {
                        var newSource = categories.Select(c => new { c.CategoryId, c.CategoryName }).ToList();
                        dgv_Main.DataSource = newSource;
                        TextFieldBinding(
                            source: newSource,
                            txtIdDataMember: nameof(Category.CategoryId),
                            txtItemNameDataMember: null,
                            txtSpec1DataMember: null,
                            txtSpec2DataMember: nameof(Category.CategoryName),
                            txtSpec3DataMember: null,
                            txtSpec4DataMember: null);
                    }
                    break;
                case "Product":
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
                    break;
                case "Member":
                    if (source is IList<Member> members)
                    {
                        var newSource = members.Select(m => new { m.MemberId, m.Email, m.Password, m.CompanyName, m.City, m.Country }).ToList();
                        dgv_Main.DataSource = newSource;
                        TextFieldBinding(
                            source: newSource,
                            txtIdDataMember: nameof(Member.MemberId),
                            txtItemNameDataMember: nameof(Member.Email),
                            txtSpec1DataMember: nameof(Member.Password),
                            txtSpec2DataMember: nameof(Member.CompanyName),
                            txtSpec3DataMember: nameof(Member.City),
                            txtSpec4DataMember: nameof(Member.Country));
                    }
                    break;
                case nameof(toolStripReport):
                case "Order":
                    if (source is IList<Order> orders)
                    {
                        if (!doSearch) orders = ResolveOrders(_order.GetAll());
                        var newSource = orders.Select(o => new { o.OrderId, o.member?.Email, o.OrderDate, o.RequiredDate, o.ShippedDate, o.Freight }).ToList();
                        dgv_Main.DataSource = newSource;
                        TextFieldBinding(
                            source: newSource,
                            txtIdDataMember: nameof(Order.OrderId),
                            txtItemNameDataMember: nameof(Member.Email),
                            txtSpec1DataMember: nameof(Order.OrderDate),
                            txtSpec2DataMember: nameof(Order.RequiredDate),
                            txtSpec3DataMember: nameof(Order.ShippedDate),
                            txtSpec4DataMember: nameof(Order.Freight));
                    }
                    break;
            }
            AutoFitDataGridItem(dgv_Main);
            SetToolStripBackgroundColor();
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var loginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            if (loginMember == null) return;

            // If DataGridView has no row
            if (dgv_Main.Rows.Count == 0)
            {
                MessageBox.Show("No row to Update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Select first selected row to get the item belong to this row
            int rowIndex = dgv_Main.SelectedRows[0].Index;
            var updateItem = GetItem(rowIndex);
            if (updateItem != null)
            {
                switch (currentToolStrip)
                {
                    case nameof(toolStripProduct):
                        DisplayUpdateForm(updateItem, nameof(Product), false);
                        break;
                    case nameof(toolStripCategory):
                        DisplayUpdateForm(updateItem, nameof(Category), false);
                        break;

                    case nameof(toolStripMember):
                        DisplayUpdateForm(updateItem, nameof(Member), false);
                        break;

                    case nameof(toolStripOrder):
                        DisplayUpdateForm(updateItem, nameof(Order), true);
                        break;
                }
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

            bool nameExist = txtItemNameDataMember != null;
            bool spec1Exist = txtSpec1DataMember != null;
            bool spec2Exist = txtSpec2DataMember != null;
            bool spec3Exist = txtSpec3DataMember != null;
            bool spec4Exist = txtSpec4DataMember != null;

            string textBoxProperty = "Text";
            Binding IdBinding = new Binding(textBoxProperty, source, txtIdDataMember);
            lbId.Text = txtIdDataMember;
            txtItemId.DataBindings.Add(IdBinding);

            Binding nameBinding = new Binding(textBoxProperty, source, txtItemNameDataMember);
            if (nameExist)
            {
                lbName.Visible = true;
                lbName.Text = txtItemNameDataMember;
                txtItemName.Visible = true;
                txtItemName.DataBindings.Add(nameBinding);
            }
            else
            {
                lbName.Visible = false;
                txtItemName.Visible = false;
            }

            Binding spec1Binding = new Binding(textBoxProperty, source, txtSpec1DataMember);
            if (spec1Exist)
            {
                lbSpec1.Visible = true;
                lbSpec1.Text = txtSpec1DataMember;
                txtSpec1.Visible = true;
                txtSpec1.DataBindings.Add(spec1Binding);
            }
            else
            {
                lbSpec1.Visible = false;
                txtSpec1.Visible = false;
            }

            Binding spec2Binding = new Binding(textBoxProperty, source, txtSpec2DataMember);
            if (spec2Exist)
            {
                lbSpec2.Visible = true;
                lbSpec2.Text = txtSpec2DataMember;
                txtSpec2.Visible = true;
                txtSpec2.DataBindings.Add(spec2Binding);
            }
            else
            {
                lbSpec2.Visible = false;
                txtSpec2.Visible = false;
            }

            Binding spec3Binding = new Binding(textBoxProperty, source, txtSpec3DataMember);
            if (spec3Exist)
            {
                lbSpec3.Visible = true;
                lbSpec3.Text = txtSpec3DataMember;
                txtSpec3.Visible = true;
                txtSpec3.DataBindings.Add(spec3Binding);
            }
            else
            {
                lbSpec3.Visible = false;
                txtSpec3.Visible = false;
            }

            Binding spec4Binding = new Binding(textBoxProperty, source, txtSpec4DataMember);
            if (spec4Exist)
            {
                lbSpec4.Visible = true;
                lbSpec4.Text = txtSpec4DataMember;
                txtSpec4.Visible = true;
                txtSpec4.DataBindings.Add(spec4Binding);
            }
            else
            {
                lbSpec4.Visible = false;
                txtSpec4.Visible = false;
            }
        }

        private object GetItem(int rowIndex)
        {
            var row = dgv_Main.Rows[rowIndex];
            var itemIdColumn = row.Cells[0];
            int itemId = 0;
            try
            {
                itemId = int.Parse($"{itemIdColumn.Value}");
                switch (currentToolStrip)
                {
                    case nameof(toolStripProduct):
                        return _product.GetById(itemId);

                    case nameof(toolStripCategory):
                        return _category.GetById(itemId);

                    case nameof(toolStripMember):
                        return _member.GetById(itemId);

                    case nameof(toolStripOrder):
                        return _order.GetById(itemId);

                    default: return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void DisplayUpdateForm<T>(T item, string formName, bool isfrmOrder)
        {
            switch (formName)
            {
                case "Category":
                    DisplayCategoryForm(insert: false, (item as Category)!.CategoryId);
                    break;
                case "Product":
                    DisplayProductForm(insert: false, (item as Product)!.ProductId);
                    break;
                case "Member":
                    DisplayMemberForm(insert: false, (item as Member)!.MemberId);
                    break;
                case "Order":
                    DisplayOrderForm((item as Order)!.OrderId);
                    break;
            }
        }
        #endregion

        #region btn_Event
        private void Login_Click(object sender, EventArgs e)
        {
            if (toolStripProfile.Text == "Login")
            {
                var loginForm = new frmLogin
                {
                    _auth = _member.DAO as MemberDAO,
                    _session = sessionService
                };

                loginForm.Show();
                loginForm.FormClosed += (sender, args) => Form_Load(sender, args);
                loginForm.FormClosed += (sender, args) => shoppingForm?.LoadWelcome();
            }
        }

        private void btnExit_Click(object sender, EventArgs e) => Close();

        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (currentToolStrip)
            {
                case nameof(toolStripProduct):
                    menuItemAddProduct_Click(sender, e);
                    break;
                case nameof(toolStripCategory):
                    menuItemAddCategory_Click(sender, e);
                    break;
                case nameof(toolStripMember):
                    menuItemAddMember_Click(sender, e);
                    break;
                case nameof(toolStripOrder):
                    break;
                case nameof(toolStripReport):
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv_Main.Rows.Count == 0)
            {
                MessageBox.Show("No row to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Do you want to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            try
            {
                int rowIndex = dgv_Main.SelectedRows[0].Index;
                var deleteItem = GetItem(rowIndex);
                if (deleteItem != null)
                {
                    switch (currentToolStrip)
                    {
                        case nameof(toolStripProduct):
                            _product.Delete((deleteItem as Product).ProductId);
                            DataGridView_LoadWithSection(_product, null, nameof(Product));
                            break;

                        case nameof(toolStripCategory):
                            _category.Delete((deleteItem as Category).CategoryId);
                            DataGridView_LoadWithSection(_category, null, nameof(Category));
                            break;

                        case nameof(toolStripMember):
                            _member.Delete((deleteItem as Member).MemberId);
                            DataGridView_LoadWithSection(_member, null, nameof(Member));
                            break;

                        case nameof(toolStripOrder):
                            MessageBox.Show("Cannot Delete Order", "Warning");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex is ArgumentException ? ex.Message
                                                        : "Please select row to delete";

                MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowAll.Checked == true)
            {
                DataGridView_LoadWithSection(_product, null, nameof(Product));
            }
            else DataGridView_LoadWithSection(_product, null, nameof(Product));
        }
        #endregion

        #region Searching
        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selectChoiceIndex = cbSearchChoice.SelectedIndex;
            switch (currentToolStrip)
            {
                case nameof(toolStripCategory):
                    SearchCategory(selectChoiceIndex);
                    break;

                case nameof(toolStripProduct):
                    SearchProduct(selectChoiceIndex);
                    break;

                case nameof(toolStripMember):
                    SearchMember(selectChoiceIndex);
                    break;

                case nameof(toolStripOrder):
                    SearchOrder(selectChoiceIndex);
                    break;
            }
            cbSearchChoice.SelectedIndex = selectChoiceIndex;
            AutoFitDataGridItem(dgv_Main);
        }

        private void SearchCategory(int choiceIndex)
        {
            SearchHelper<Category> searchHelper = null;
            SearchResponse<IList<Category>> searchResponse = null;

            var defaultCondition = (Category c) => c.CategoryName.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase);
            switch (choiceIndex)
            {
                case 0:
                case 1:
                    searchHelper = new SearchByName<Category>
                    {
                        repository = _category,
                        Input = txtSearch.Text,
                        condition = defaultCondition
                    };
                    break;
                case 2:
                    searchHelper = new SearchById<Category>
                    {
                        repository = _category,
                        Input = txtSearch.Text,
                        condition = c => $"{c.CategoryId}".Contains(txtSearch.Text)
                    };
                    break;
                default:
                    searchHelper = new SearchByName<Category>
                    {
                        repository = _category,
                        Input = txtSearch.Text,
                        condition = defaultCondition
                    };
                    break;
            }
            searchResponse = searchHelper.Search();
            if (searchResponse.IsSuccess)
            {
                DataGridView_LoadWithSection(null, searchResponse.Response, "Category");
            }
            else MessageBox.Show(searchResponse.Message, "Search Error");
        }

        private void SearchProduct(int choiceIndex)
        {
            SearchHelper<Product> searchHelper = null;
            SearchResponse<IList<Product>> searchResponse = null;
            var isValidInput = false;
            var isEmptyInput = string.IsNullOrWhiteSpace(txtSearch.Text.Trim());

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
                        searchHelper.condition = isEmptyInput ? p => p.UnitsInStock <= rangeStock
                                                            : p => p.UnitsInStock == rangeStock;
                    }
                    break;
            }
            searchResponse = searchHelper.Search();
            if (searchResponse.IsSuccess)
            {
                DataGridView_LoadWithSection(null, searchResponse.Response, "Product");
            }
            else MessageBox.Show(searchResponse.Message, "Search Error");
        }

        private void SearchMember(int choiceIndex)
        {
            SearchHelper<Member> searchHelper = null;
            SearchResponse<IList<Member>> searchResponse = null;

            var defaultCondition = (Member m) => m.Email.Contains(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase);
            switch (choiceIndex)
            {
                case 0:
                case 1:
                    searchHelper = new SearchByEmail<Member>
                    {
                        repository = _member,
                        Input = txtSearch.Text,
                        condition = defaultCondition
                    };
                    break;
                case 2:
                    searchHelper = new SearchById<Member>
                    {
                        repository = _member,
                        Input = txtSearch.Text,
                        condition = m => $"{m.MemberId}".Contains(txtSearch.Text)
                    };
                    break;
                default:
                    searchHelper = new SearchByName<Member>
                    {
                        repository = _member,
                        Input = txtSearch.Text,
                        condition = m => m.Email.Contains(txtSearch.Text)
                    };
                    break;
            }
            searchResponse = searchHelper.Search();
            if (searchResponse.IsSuccess)
            {
                DataGridView_LoadWithSection(null, searchResponse.Response, "Member");
            }
            else MessageBox.Show(searchResponse.Message, "Search Error");
        }

        private void SearchOrder(int choiceIndex)
        {
            SearchHelper<Order> searchHelper = new SearchById<Order>
            {
                repository = _order,
                Input = txtSearch.Text,
                condition = o => $"{o.OrderId}".Contains(txtSearch.Text)
            };
            var searchResponse = searchHelper.Search();
            if (searchResponse.IsSuccess)
            {
                DataGridView_LoadWithSection(null, searchResponse.Response, "Order");
            }
            else MessageBox.Show(searchResponse.Message, "Search Error");
        }
        #endregion

        #region MenuStrip and MenuItem Event
        private void toolStrip_Click(object sender, EventArgs e)
        {
            var isAdmin = sessionService.GetSessionData<Member>(SessionId.LoginMember)?.MemberId == 0;
            cbShowAll.Visible = false;

            bool allowSearch = currentToolStrip != nameof(toolStripReport)
                                && currentToolStrip != nameof(toolStripOrder);
            DisplaySearchComponents(isDisplay: allowSearch);
            DisplayDeleteAndNewButton(isDisplay: isAdmin);
            DisplayAsReportStatic(isDisplay: false);
            if (sender is ToolStripMenuItem menuStrip)
            {
                if (menuStrip == toolStripProduct)
                {
                    currentToolStrip = nameof(toolStripProduct);
                    cbShowAll.Visible = isAdmin;
                    Form_Load(nameof(Product));
                }
                if (menuStrip == toolStripMember)
                {
                    currentToolStrip = nameof(toolStripMember);
                    Form_Load(nameof(Member));
                }
                if (menuStrip == toolStripCategory)
                {
                    currentToolStrip = nameof(toolStripCategory);
                    Form_Load(nameof(Category));
                }
                if (menuStrip == toolStripOrder)
                {
                    currentToolStrip = nameof(toolStripOrder);
                    DisplayDeleteAndNewButton(isDisplay: false);
                    DisplaySearchComponents(isDisplay: false);
                    Form_Load(nameof(Order));
                }
                if (menuStrip == toolStripReport)
                {
                    DisplayDeleteAndNewButton(isDisplay: false);
                    DisplaySearchComponents(isDisplay: false);
                    DisplayAsReportStatic(isDisplay: true);
                    currentToolStrip = nameof(toolStripReport);
                }
                if (menuStrip == toolStripShopping)
                {
                    currentToolStrip = nameof(toolStripShopping);
                    DisplayShoppingForm();
                }
            }
            SetToolStripBackgroundColor();
        }

        private void DisplaySearchComponents(bool isDisplay)
        {
            cbSearchChoice.Visible = isDisplay;
            txtSearch.Visible = isDisplay;
            btnSearch.Visible = isDisplay;
        }

        private void DisplayDeleteAndNewButton(bool isDisplay)
        {
            btnNew.Visible = isDisplay;
            btnDelete.Visible = isDisplay;
        }

        private void SetToolStripBackgroundColor()
        {
            // Get 2 main colors of the toolStrip
            if (defaultToolStripColor == default) defaultToolStripColor = toolStripOrder.BackColor;
            if (activeToolStripColor == default) activeToolStripColor = toolStripProduct.BackColor;

            toolStripProduct.BackColor = (currentToolStrip == nameof(toolStripProduct)) ? activeToolStripColor : defaultToolStripColor;
            toolStripCategory.BackColor = (currentToolStrip == nameof(toolStripCategory)) ? activeToolStripColor : defaultToolStripColor;
            toolStripMember.BackColor = (currentToolStrip == nameof(toolStripMember)) ? activeToolStripColor : defaultToolStripColor;
            toolStripOrder.BackColor = (currentToolStrip == nameof(toolStripOrder)) ? activeToolStripColor : defaultToolStripColor;
            toolStripReport.BackColor = (currentToolStrip == nameof(toolStripReport)) ? activeToolStripColor : defaultToolStripColor;
            toolStripShopping.BackColor = (currentToolStrip == nameof(toolStripShopping)) ? activeToolStripColor : defaultToolStripColor;
        }

        private void menuItemAddMember_Click(object sender, EventArgs e)
        {
            if (memberForm == null)
            {
                DisplayMemberForm(insert: true, 0);
            }
            else memberForm.Activate();
        }

        private void menuItemAddProduct_Click(object sender, EventArgs e)
        {
            if (productForm == null)
            {
                DisplayProductForm(insert: true, 0);
            }
            else productForm.Activate();
        }

        private void menuItemAddCategory_Click(object sender, EventArgs e)
        {
            if (categoryForm == null)
            {
                DisplayCategoryForm(insert: true, 0);
            }
            else categoryForm.Activate();
        }

        private void menuItemEditProfile_Click(object sender, EventArgs e)
        {
            if (memberForm == null)
            {
                int id = sessionService.GetSessionData<Member>(SessionId.LoginMember).MemberId;
                DisplayMemberForm(insert: false, memberId: id);
            }
            else memberForm.Activate();
        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            // Display MessageBox
            sessionService.DeleteSessionData(SessionId.LoginMember);
            LoadFormAs(isGuest: true);
            Form_Load(sender, e);
        }
        #endregion

        #region Display Search Choices
        private void LoadSearchChoice(string section)
        {
            cbSearchChoice.Items.Clear();
            cbSearchChoice.Items.AddRange(this.GetSearchCriterias(section));
        }
        #endregion

        #region Display SubForm
        private void AddFormClosedSubEvent<T>(Form form, IRepository<T> source, string section) where T : class
        {
            var LoginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            bool isAdmin = (LoginMember != null && LoginMember.MemberId == 0);
            form.FormClosed += (sender, e) => DisposeForm(sender);
            form.FormClosed += (sender, e) => Form_Load(sender, e);
            if (isAdmin) form.FormClosed += (sender, e) => DataGridView_LoadWithSection(source, null, section);
        }

        private void DisplayMemberForm(bool insert, int memberId)
        {
            memberForm = new frmMember
            {
                _repo = _member,
                _auth = _member.DAO as IAuthService<Member>,
                UpdateMemberId = memberId,
                DoInsert = insert
            };
            AddFormClosedSubEvent(memberForm, _member, nameof(Member));
            memberForm.Show();
        }

        private void DisplayCategoryForm(bool insert, int categoryId)
        {
            categoryForm = new frmCategory
            {
                _repo = _category,
                DoInsert = insert,
                UpdateCategoryId = categoryId
            };
            AddFormClosedSubEvent(categoryForm, _category, nameof(Category));
            categoryForm.Show();
        }

        private void DisplayProductForm(bool insert, int productId)
        {
            productForm = new frmProduct
            {
                _repo = _product,
                _category = _category,
                DoInsert = insert,
                UpdateProductId = productId
            };
            AddFormClosedSubEvent(productForm, _product, nameof(Product));
            productForm.Show();
        }

        private void DisplayOrderForm(int orderId)
        {
            var loginMember = sessionService.GetSessionData<Member>(SessionId.LoginMember);
            bool isAdmin = loginMember.MemberId == 0;
            orderForm = new frmOrder
            {
                _repo = _order,
                orderContext = dbContext,
                OrderId = orderId,
                IsAdmin = isAdmin
            };
            AddFormClosedSubEvent(orderForm, _order, nameof(Order));
            orderForm.Show();
        }

        private void DisplayShoppingForm()
        {
            shoppingForm = new frmShopping
            {
                _product = _product,
                _member = _member,
                _order = _order,
                _orderDetail = _orderDetail,
            };
            shoppingForm.Show();
        }
        #endregion

        #region Report Statistic
        private void DisplayAsReportStatic(bool isDisplay)
        {
            lbStartDate.Visible = isDisplay;
            lbEndDate.Visible = isDisplay;
            btnSearchReport.Visible = isDisplay;
            datePickStart.Visible = isDisplay;
            txtStartDate.Visible = isDisplay;
            datePickEnd.Visible = isDisplay;
            txtEndDate.Visible = isDisplay;
        }

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
            DataGridView_LoadWithSection(null, _order.GetListByCondition(condition), nameof(toolStripReport));
        }

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

        private void DateTimeTextBox_MouseClick(object sender, MouseEventArgs e)
            => DateTimeTextBox_Click(sender, e);
        #endregion
    }
}
