using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IHubContext<ASGlassHub> _hubContext;


        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, AppDbContext context, IHubContext<ASGlassHub> hubContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            AppUser member = new AppUser
            {
                UserName = "Ganjali717",
                FullName = "Ganjali Imanov"
            };

            var result = await _userManager.CreateAsync(member, "Genceli717");



            return View(result);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();


            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == loginVM.UserName && x.IsAdmin == false);

            if (member == null)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }

            await _hubContext.Clients.All.SendAsync("Login");


            return RedirectToAction("index", "home");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if (member != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            member = await _userManager.FindByEmailAsync(registerVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }

            member = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                Phone = registerVM.Phone,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(member, "Member");
            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "home");
        }

        public IActionResult ShowAccount(string id)
        {
            AppUser appUsers = _context.AppUsers.Include(x => x.Orders).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);

            if (appUsers == null || appUsers.Id != id) return RedirectToAction("index", "error");

            ChangePasswordViewModel passwordVM = new ChangePasswordViewModel
            {
                appUser = appUsers
            };

            return View(passwordVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowAccount(ChangePasswordViewModel model)
        {
            AppUser existUser = _context.AppUsers.Include(x => x.Orders).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == model.appUser.Id);
            var result = await _userManager.RemovePasswordAsync(existUser);
            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(existUser, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

            }
            else
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
            }

            if (_context.AppUsers.Any(x => x.UserName == model.appUser.UserName && x.Id != model.appUser.Id)) return RedirectToAction("index", "error");

            existUser.FullName = model.appUser.FullName ?? existUser.FullName;
            existUser.Email = model.appUser.Email ?? existUser.Email;
            existUser.UserName = model.appUser.UserName ?? existUser.UserName;




            await _userManager.UpdateAsync(existUser);
            await _signInManager.SignInAsync(existUser, true);

            return RedirectToAction("index", "home");
        }
    }
}
