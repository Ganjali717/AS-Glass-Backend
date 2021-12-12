using ASGlass.DAL;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel()
            {
                Setting = _context.Settings.FirstOrDefault()
            };
            return View(contactVM);
        }
    }
}
