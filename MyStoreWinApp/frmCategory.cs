using BusinessObject;
using DataAccess.Repository;
using MyStoreWinApp.Utility;
using System.ComponentModel.DataAnnotations;

namespace MyStoreWinApp
{
    public partial class frmCategory : Form
    {
        public IRepository<Category> _repo;
        public bool DoInsert { get; set; } = false;
        public int UpdateCategoryId { get; set; }

        public frmCategory()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            btnCreateOrSave.Text = DoInsert ? "Create" : "Update";
            btnCategory.Text = DoInsert ? "CATEGORY FORM" : $"Category ID: {UpdateCategoryId}";
            txtCategoryName.Text = DoInsert ? "" : _repo.GetById(UpdateCategoryId).CategoryName;
        }

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnCreateOrSave_Click(sender, e);
            }
        }

        private void btnCreateOrSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = txtCategoryName.Text.ToNormalCase()
                };

                Validator.ValidateObject(
                    instance: newCategory,
                    validationContext: new ValidationContext(newCategory),
                    validateAllProperties: true);

                // Check similar exist CategoryName
                var condition = (Category c) => string.Compare(c.CategoryName, newCategory.CategoryName, ignoreCase: true) == 0;
                var categoryWithSameName = _repo.GetByCondition(condition) != null;
                if (DoInsert)
                {
                    if (categoryWithSameName)
                    {
                        MessageBox.Show($"The category with the same name is already existed", "Error");
                        return;
                    }
                    _repo.Insert(newCategory);
                }
                else
                {
                    string oldCategoryName = _repo.GetById(UpdateCategoryId).CategoryName;
                    string newCategoryName = newCategory.CategoryName;

                    bool categoryNameIsUpdate = string.Compare(oldCategoryName, newCategoryName, ignoreCase: true) != 0;
                    if (categoryNameIsUpdate && categoryWithSameName)
                    {
                        MessageBox.Show($"The category with the same name is already existed", "Error");
                        return;
                    }
                    newCategory.CategoryId = UpdateCategoryId;
                    _repo.Update(newCategory);
                }
                Close();
            }
            catch (ValidationException ex)
            {
                var errorAttribute = ex.ValidationAttribute;

                if (errorAttribute is RequiredAttribute)
                {
                    MessageBox.Show($"{ex.ValidationResult.ErrorMessage}", "Error");
                }
                else MessageBox.Show($"{errorAttribute?.ErrorMessageResourceName} format is invalid", "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
