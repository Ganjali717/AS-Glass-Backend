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
    [Authorize(Roles="Admin, SuperAdmin")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about);
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return NotFound();

            var about = _context.Abouts.FirstOrDefault(x => x.Id == id);
            return View(about);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(About about)
        {
            About existAbout = _context.Abouts.FirstOrDefault(x => x.Id == about.Id);

            if (existAbout == null) return NotFound();

            existAbout.Title = about.Title;
            existAbout.Image = about.Image;

            _context.SaveChanges();
            return RedirectToAction("index", "about");
        }
    }
}
