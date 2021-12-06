using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class CardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public CardController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;

        }
        public IActionResult Index()
        {
            List<CartViewModel> items = new List<CartViewModel>();
            var itemsStr = HttpContext.Request.Cookies["Products"];

            if (itemsStr != null)
            {
                items = JsonConvert.DeserializeObject<List<CartViewModel>>(itemsStr);

                foreach (var item in items)
                {
                    Product product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId);
                    if (product != null)
                    {
                        item.Name = product.Name;
                        item.Price = product.Price;
                        item.Image = product.Image;
                        item.DiscountPrice = product.DiscountPrice;
                        item.IsAccessory = product.IsAccessory;
                    }
                }
            }
            return View(items);
        }
    }
}
