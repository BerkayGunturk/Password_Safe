using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

       
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
            _signInManager = signInManager;
        }

		[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
		public async Task<IActionResult> SignUp(UserViewModel appModel)
		{
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = appModel.UserName,
                    Email = appModel.Email,
                    FirstName = appModel.FirstName,
                    LastName = appModel.LastName,

                };
                var result = await _userManager.CreateAsync(user, appModel.Password);
                if (result.Succeeded)
                {
                    return Json(Url.Action("Login", "Login"));
                }
            }
			return View(appModel);
		}
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel appModel)
        {
            var user = await _userManager.FindByEmailAsync(appModel.Email);
            if (user!=null)
            {
                var result =await _signInManager.PasswordSignInAsync(user, appModel.Password, true, false);
                if (result.Succeeded)
                {
                    return Json(Url.Action("Index", "Account"));

                }
            }
            return View(appModel);
        }
    }
}
