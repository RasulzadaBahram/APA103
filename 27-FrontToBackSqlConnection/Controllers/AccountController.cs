using FrontToBackSqlConnection.Models;
using FrontToBackSqlConnection.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();


            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginVM.UserNameOrEmail || u.Email == loginVM.UserNameOrEmail);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Username or Email is wrong");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.IsPersistent, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is blocked for 5 minutes");
                return View(loginVM);
            }

            if (result is null)
            {
                ModelState.AddModelError(string.Empty, "Username or Password is wrong");
                return View(loginVM);
            }

            return RedirectToAction(nameof(Index), "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

    }
}