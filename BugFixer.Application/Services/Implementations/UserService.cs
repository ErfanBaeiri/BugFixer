using BugFixer.Application.Generators;
using BugFixer.Application.Security;
using BugFixer.Application.Services.Interface;
using BugFixer.Application.Statics;
using BugFixer.Domain.Entities.Account;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Ctor
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Register

        public async Task<RegisterResult> RegisterUser(RegisterViewModel register)
        {
            // Check Email Exists
            if (await _userRepository.IsExistsUserByEmail(register.Email.Trim().ToLower()))
            {
                return RegisterResult.EmailExists;
            }

            // hash password 
            var password = PasswordHelper.EncodePasswordMd5(register.Password);

            // Create user 

            var user = new User
            {
                Avatar = PathTools.DefaultUserAvatar,
                Email = register.Email.Trim().ToLower(),
                Password = password,
                EmailActivation = CodeGenerator.CreateActivationCode(),

            };

            // add To Database 

            await _userRepository.CreateUser(user);
            await _userRepository.Save();


            return RegisterResult.Success;
        }
        #endregion
    }
}
