using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult Index()
        {
            int? ordercode = Convert.ToInt32(HttpContext.Request.Form["orderstatus"]);
            var query = _context.Orders.Include(x => x.Product).AsQueryable();

            if (ordercode != null)
            {
                query = query.Include(x => x.Product).Where(x => x.OrderNumber == ordercode);
            }
            else
            {
                return BadRequest(404);
            }
                

            OrderViewModel orderVM = new OrderViewModel()
            {
                ProductName = query.FirstOrDefault().ProductName, 
                ProductImage = query.FirstOrDefault().ProductImage, 
                Status = query.FirstOrDefault().Status, 
                Price = query.FirstOrDefault().Price,
                CreatedAt = query.FirstOrDefault().CreatedAt
            };
                 
            return View(orderVM);
        }

        


    }
}
