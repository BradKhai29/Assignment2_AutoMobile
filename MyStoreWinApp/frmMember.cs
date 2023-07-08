using BusinessObject;
using DataAccess.Repository;
using DataAccess.Services;
using MyStoreWinApp.Utility;
using System.ComponentModel.DataAnnotations;

namespace MyStoreWinApp
{
    public partial class frmMember : Form
    {
        public IMemberRepository _repo;
        public IAuthService<Member> _auth;
        public bool DoInsert { get; set; } = false;
        public int UpdateMemberId { get; set; }

        public frmMember()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var loginMember = SessionService.Instance.GetSessionData<Member>(SessionId.LoginMember);
            bool isAdmin = loginMember.MemberId == 0;

            bool updateProfileByMember = UpdateMemberId != null
                                && UpdateMemberId == loginMember.MemberId;
            bool updateProfileByAdmin = UpdateMemberId != null && isAdmin && !DoInsert;

            if (!DoInsert && (updateProfileByMember || updateProfileByAdmin))
            {
                btnProfile.Text = $"Member ID: {UpdateMemberId}";
                btnInsertOrUpdate.Visible = true;
                btnInsertOrUpdate.Text = "Update";
            }
            else if (DoInsert)
            {
                txtEmail.Enabled = true;
                btnInsertOrUpdate.Visible = true;
                btnInsertOrUpdate.Text = "Add new";
            }
            else btnInsertOrUpdate.Visible = false;

            var displayMember = _repo.GetById(UpdateMemberId);
            txtEmail.Text = $"{displayMember?.Email}";
            txtPassword.Text = $"{displayMember?.Password}";
            txtCompany.Text = $"{displayMember?.CompanyName}";
            txtCity.Text = $"{displayMember?.City}";
            txtCountry.Text = $"{displayMember?.Country}";
        }

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnInsertOrUpdate_Click(sender, e);
            }
        }

        private void btnInsertOrUpdate_Click(object sender, EventArgs e)
        {
            var loginMember = SessionService.Instance.GetSessionData<Member>(SessionId.LoginMember);
            if (loginMember != null)
            {
                var member = new Member
                {
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Country = txtCountry.Text.ToCapitalCase(),
                    City = txtCity.Text.ToCapitalCase(),
                    CompanyName = txtCompany.Text.ToCapitalCase(),
                };

                if (ValidateInputData(member))
                {
                    if (DoInsert) _repo.Insert(member);
                    else
                    {
                        member.MemberId = UpdateMemberId;
                        _repo.Update(member);
                    }
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Validate input receive from frmMember
        /// </summary>
        /// <param name="member"></param>
        /// <returns>true: if all inputs are valid format and not conflict in data</returns>
        private bool ValidateInputData(Member member)
        {
            try
            {
                Validator.ValidateObject(
                    instance: member,
                    validationContext: new ValidationContext(member),
                validateAllProperties: true);

                bool isExistedEmail = _auth.CheckExistEmail(member.Email);
                if (DoInsert is false)
                {
                    member.MemberId = UpdateMemberId;
                    string oldEmail = _repo.GetById(member.MemberId).Email;
                    string newEmail = member.Email;
                    bool updateEmail = oldEmail != newEmail;
                    if (updateEmail is false)
                    {
                        isExistedEmail = false;
                    }
                }

                if (isExistedEmail) MessageBox.Show("Email is already existed", "Error");
                return !isExistedEmail;
            }
            catch (ValidationException ex)
            {
                var errorAttribute = ex.ValidationAttribute;

                if (errorAttribute is RequiredAttribute)
                {
                    MessageBox.Show($"{ex.ValidationResult.ErrorMessage}", "Error");
                }
                else MessageBox.Show($"{errorAttribute?.ErrorMessage} is not valid format", "Error");
                return false;
            }
        }
    }
}
