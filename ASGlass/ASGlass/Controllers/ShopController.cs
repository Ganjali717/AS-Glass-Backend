using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.ToList(), 
                Products = _context.Products.ToList(), 
                Colors = _context.Colors.ToList(),
                Thicknesses = _context.Thicknesses.ToList()
            };
            return View(shopVM);
        }

        public IActionResult Detail(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }


        public IActionResult AddToCart(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            CartViewModel cartVM = null;
            List<CartViewModel> products = new List<CartViewModel>();

            string productStr;

            if (HttpContext.Request.Cookies["Products"] != null)
            {
                productStr = HttpContext.Request.Cookies["Products"];
                products = JsonConvert.DeserializeObject<List<CartViewModel>>(productStr);

                cartVM = products.FirstOrDefault(x => x.ProductId == id);
            }

            if (cartVM == null)
            {
                cartVM = new CartViewModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.Price,
                    DiscountPrice = product.DiscountPrice,
                    IsAccessory = product.IsAccessory
                };
                products.Add(cartVM);
            }
            productStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("index", "shop");
        }

        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            CartViewModel cartVM = null;
            List<CartViewModel> houses = new List<CartViewModel>();

            string productStr = HttpContext.Request.Cookies["Products"];
            houses = JsonConvert.DeserializeObject<List<CartViewModel>>(productStr);

            cartVM = houses.FirstOrDefault(x => x.ProductId == id);


            houses.Remove(cartVM);

            cartVM.Count--;

            productStr = JsonConvert.SerializeObject(houses);
            HttpContext.Response.Cookies.Append("Products", productStr);

            return RedirectToAction("index", "card");
        }
    }
}
