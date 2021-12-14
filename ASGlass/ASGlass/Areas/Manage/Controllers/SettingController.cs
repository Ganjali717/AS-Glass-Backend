using ASGlass.DAL;
using ASGlass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly AppDbContext _context;

        public SettingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var settings = _context.Settings.First();
            if (settings == null) return NotFound();
            return View(settings);
        }

        public IActionResult Edit(int id)
        {
            var setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (setting == null) return NotFound();
            return View(setting);
        }

        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);

            if (existSetting == null) return NotFound();

            existSetting.HeaderLogo = setting.HeaderLogo;
            existSetting.FooterLogo = setting.FooterLogo;
            existSetting.Email = setting.Email;
            existSetting.SupportPhone = setting.SupportPhone;
            existSetting.Address = setting.Address;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}
