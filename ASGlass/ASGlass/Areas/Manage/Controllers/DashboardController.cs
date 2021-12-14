using ASGlass.Areas.Manage.ViewModels;
using ASGlass.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DashboardController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel()
            {
                CartItems = _context.CartItems.Include(x => x.Product).ToList()
            };
            return View(dashboardVM);
        }
    }
}
