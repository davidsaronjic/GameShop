using GameShop.Models;
using GameShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameShop.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<Users> _signInManager;
		private readonly UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Username or password is incorrect");
					return View(model);
				}
			}

            return View(model);
        }

        public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if(ModelState.IsValid)
			{
				Users users = new Users
				{
					FullName = model.Name,
					Email = model.Email,
					UserName = model.UserName
				};

				var result = await _userManager.CreateAsync(users, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Login", "Account");
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
					return View(model);
				}
				
			}
            return View(model);
        }


		public IActionResult VerifyEmail()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
		{
			if(ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);

				if (user == null)
				{
					ModelState.AddModelError("", "Something is wrong!");
					return View(model);
				}
				else
				{
					return RedirectToAction("ChangePassword", "Account", new {email = user.Email});
				}

			}
			return View(model);
		}

		public IActionResult ChangePassword(string email)
		{
			if (string.IsNullOrEmpty(email))
			{
				return RedirectToAction("VerifyEmail", "Account");
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user != null)
				{
					var result = await _userManager.RemovePasswordAsync(user);
					if(result.Succeeded)
					{
						result = await _userManager.AddPasswordAsync(user,model.NewPassword);
						return RedirectToAction("Login", "Account");
					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
						return View(model);
					}
				}
				else
				{
					ModelState.AddModelError("", "Email not found!");
					return View(model);
				}
			}
			else
			{
				return View(model);
			}
		}


		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
