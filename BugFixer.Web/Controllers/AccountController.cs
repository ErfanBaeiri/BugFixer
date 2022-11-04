using BugFixer.Application.Services.Interface;
using BugFixer.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Ctor
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        #endregion
        #region Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        #endregion

        #region Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterResult.EmailExists:
                    TempData[ErrorMessage] = "ایمیل وارد شده ، موجود است";
                    break;
                case RegisterResult.Success:
                    TempData[SucessMessage] = "عملیات با موفقیت انجام شد";
                    break;
                    return RedirectToAction("Login", "Account");
            }

            return View(register);
        }


        #endregion
    }
}
