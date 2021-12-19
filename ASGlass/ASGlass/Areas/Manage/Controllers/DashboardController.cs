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
                Orders = _context.Orders.ToList()
            };

            double acceptedCount = _context.Orders.Where(x => x.Status == Models.Enums.OrderStatus.Accepted).Count();
            double totalCount = _context.Orders.Count();
            ViewBag.AcceptedOrdersPercent = Math.Ceiling(acceptedCount / totalCount * 100);
            return View(dashboardVM);
        }

        public IActionResult GetProperty()
        {
            PieChartViewModel pieChartVM = new PieChartViewModel
            {
               
            };

            return Json(pieChartVM);
        }


        public IActionResult AddChart()
        {
            Dictionary<string, double> permonth = new Dictionary<string, double>();


            permonth.Add("January", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 1).Sum(x => x.Price));
            permonth.Add("February", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 2).Sum(x => x.Price));
            permonth.Add("March", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 3).Sum(x => x.Price));
            permonth.Add("April", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 4).Sum(x => x.Price));
            permonth.Add("May", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 5).Sum(x => x.Price));
            permonth.Add("June", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 6).Sum(x => x.Price));
            permonth.Add("July", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 7).Sum(x => x.Price));
            permonth.Add("August", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 8).Sum(x => x.Price));
            permonth.Add("September", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 9).Sum(x => x.Price));
            permonth.Add("October", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 10).Sum(x => x.Price));
            permonth.Add("November", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 11).Sum(x => x.Price));
            permonth.Add("December", _context.Orders.Where(x => x.CreatedAt.Year == DateTime.UtcNow.Year && x.CreatedAt.Month == 12).Sum(x => x.Price));


            return Json(permonth);
        }
    }
}
