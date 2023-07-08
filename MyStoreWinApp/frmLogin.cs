using BusinessObject;
using DataAccess.Services;
using MyStoreWinApp.Utility;
using System.ComponentModel.DataAnnotations;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        public ISessionService _session;
        public IAuthService<Member> _auth;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Enter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ProcessLogin();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            Login login = new Login
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim(),
            };

            try
            {
                Validator.ValidateObject(
                    instance: login,
                    validationContext: new ValidationContext(login),
                    validateAllProperties: true);

                var response = _auth.ValidateLogin(login.Email, login.Password);
                if (response.IsSuccess)
                {
                    _session.AddSessionData(SessionId.LoginMember, response.Response);
                    Close();
                }
                else MessageBox.Show(response.Message, "Login Error");
            }
            catch (ValidationException ex)
            {
                var errorAttribute = ex.ValidationAttribute;
                if (errorAttribute is RequiredAttribute)
                {
                    MessageBox.Show($"{ex.ValidationResult.ErrorMessage}", "Login Error");
                }
                else MessageBox.Show("Email format is invalid", "Login Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }

    public class Login
    {
        [Required]
        [RegularExpression("^[a-zA-Z]+[0-9]*[.]?[a-zA-Z]+[0-9]*[@][a-zA-Z]+[0-9]*[.]?[a-zA-Z]+[0-9]*$")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
