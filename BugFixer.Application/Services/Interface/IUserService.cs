using BugFixer.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Interface
{
    public interface IUserService
    {
        #region Register
        Task<RegisterResult> RegisterUser(RegisterViewModel register);
        #endregion

        #region Login
        Task<LoginResult> CheckUserForLogin(LoginViewModel login);
        #endregion
    }
}
