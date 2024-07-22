using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"]= returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model,string returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                if(await userService.Login(model))
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некоректные логин и(или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if(await userService.Logout())
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Error", "Home");
        }

        public IActionResult AccessDenied()
        {
            ViewData["errormessage"] = "Доступ к странице запрещен";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (await userService.Register(model))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин (и)или пароль");
            }
            return View();
        }
    }
}
