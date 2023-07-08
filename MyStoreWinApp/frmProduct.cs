using BusinessObject;
using DataAccess.Repository;
using System.ComponentModel.DataAnnotations;

namespace MyStoreWinApp
{
    public partial class frmProduct : Form
    {
        public IRepository<Product> _repo;
        public IRepository<Category> _category;
        public bool DoInsert { get; set; } = false;
        public int UpdateProductId { get; set; }

        public frmProduct()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var product = _repo.GetById(UpdateProductId);
            int? productCategoryId = product?.CategoryId;

            // Text field section
            txtProductName.Text = DoInsert ? "" : product?.ProductName;
            txtPrice.Text = DoInsert ? "" : $"{decimal.ToInt32(product.UnitPrice)}";
            txtInStock.Text = DoInsert ? "" : $"{product?.UnitsInStock}";
            txtWeight.Text = DoInsert ? "" : product?.Weight;
            // Combobox field section
            var categoryNames = _category.GetAll().Select(c => c.CategoryName).ToArray();
            cbCategory.Items.AddRange(categoryNames);
            cbCategory.Text = DoInsert ? "" : _category.GetById(productCategoryId!.Value).CategoryName;
            cbAvailable.Visible = !DoInsert;
            cbAvailable.Checked = DoInsert ? true : product!.IsAvailable;
            // Button section
            btnProduct.Text = DoInsert ? "PRODUCT FORM" : $"Product ID : {UpdateProductId}";
            btnCreateOrUpdate.Text = DoInsert ? "Create" : "Update";
        }

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnCreateOrUpdate_Click(sender, e);
            }
        }

        private void btnCreateOrUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int? selectCategoryId = _category.GetByCondition(c => c.CategoryName == cbCategory.Text)?.CategoryId;
                if (!selectCategoryId.HasValue)
                {
                    string message = "Category Field is required, please Select one";
                    if(cbCategory.Items.Count == 0) message = "No Category found in Database, please create one then comeback the product create progress";
                    MessageBox.Show(message, "Error");
                    return;
                }
                var product = new Product
                {
                    ProductName = txtProductName.Text,
                    CategoryId = selectCategoryId.Value,
                    UnitPrice = Convert.ToInt32(txtPrice.Text),
                    UnitsInStock = int.Parse(txtInStock.Text),
                    Weight = txtWeight.Text,
                    IsAvailable = cbAvailable.Checked
                };

                Validator.ValidateObject(
                    instance: product, 
                    validationContext: new ValidationContext(product), 
                    validateAllProperties: true);
                if (DoInsert) _repo.Insert(product);
                else
                {
                    product.ProductId = UpdateProductId;
                    _repo.Update(product);
                }
                Close();
            }
            catch (Exception ex)
            {
                if (ex is ValidationException validationException)
                {
                    var errorAttribute = validationException.ValidationAttribute;

                    if (errorAttribute is RequiredAttribute)
                    {
                        MessageBox.Show($"{validationException.ValidationResult.ErrorMessage}", "Error");
                    }
                    else MessageBox.Show($"{errorAttribute?.ErrorMessage} format is invalid", "Error");
                }
                if (ex is FormatException formatException) MessageBox.Show($"UnitPrice or UnitsInstock is not integer", "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
