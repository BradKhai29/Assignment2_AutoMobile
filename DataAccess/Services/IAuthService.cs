using BusinessObject;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public interface IAuthService<T> where T : Member
    {
        bool CheckExistEmail(string email);
        DatabaseResponse<Member> ValidateLogin(string email, string password); 
    }
}
