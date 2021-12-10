using ASGlass.Areas.Manage.ViewModels;
using ASGlass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            /* AppUser admin = new AppUser
             {
                 UserName = "SuperAdmin",
                 FullName = "Ali Imanov"
             };

             var result = await _userManager.CreateAsync(admin, "Admin123");

             List<string> errors = new List<string>();
             if (!result.Succeeded)
             {
                 foreach (var item in result.Errors)
                 {
                     errors.Add(item.Description);
                 }

                 return Ok(errors);
             }*/

            /*AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");
            await _userManager.AddToRoleAsync(appUser, "SuperAdmin");*/

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser admin = _userManager.Users.FirstOrDefault(x => x.UserName == loginVM.UserName && x.IsAdmin == true);

            if (admin == null)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }


        [Authorize(Roles = "SuperAdmin")]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminRegisterViewModel adminRegisterVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser admin = await _userManager.FindByNameAsync(adminRegisterVM.UserName);
            if (admin != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            admin = await _userManager.FindByEmailAsync(adminRegisterVM.Email);
            if (admin != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }


            admin = new AppUser
            {
                FullName = adminRegisterVM.FullName,
                UserName = adminRegisterVM.UserName,
                Email = adminRegisterVM.Email,
                IsAdmin = true
            };

            var result = await _userManager.CreateAsync(admin, adminRegisterVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(admin, "Admin");
            await _signInManager.SignInAsync(admin, true);

            return RedirectToAction("index", "dashboard");
        }
    }
}
