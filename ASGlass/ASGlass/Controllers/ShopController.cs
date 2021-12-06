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
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
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
            }
            else
            {
                CartItem cartItem = _context.CartItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);
                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        AppUserId = member.Id,
                        ProductId = id,
                        Count = 1,

                    };
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Count++;
                }

                _context.SaveChanges();
                products = _context.CartItems.Include(x => x.Product).Where(x => x.AppUserId == member.Id)
                    .Select(x => new CartViewModel { ProductId = x.ProductId, Name = x.Product.Name, Price = x.Product.Price, DiscountPrice = x.Product.DiscountPrice, Image = x.Product.Image }).ToList();
            }

            

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
