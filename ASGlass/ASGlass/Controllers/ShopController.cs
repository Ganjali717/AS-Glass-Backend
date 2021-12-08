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
        public IActionResult Index(int? categoryId = null)
        {

            AppUser member = User.Identity.IsAuthenticated ? _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin) : null;

            var query = _context.Products.AsQueryable();

            ViewBag.CategoryId = categoryId;

            if (categoryId != null)
                query = query.Where(x => x.ProductCategories.Any(c => c.CategoryId == categoryId));
           

            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Include(x => x.ProductCategories).ThenInclude(x => x.Product).ToList(), 
                Products = query.ToList(), 
                Colors = _context.Colors.Include(x => x.Product).ToList(),
                Thicknesses = _context.Thicknesses.Include(x => x.Products).ToList()
            };
            return View(shopVM);
        }

        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(x => x.Shape).Include(x => x.Colors).FirstOrDefault(x => x.Id == id);
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
                        Image = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image,
                        Price = product.Price,
                        DiscountPrice = product.DiscountPrice,
                        IsAccessory = product.IsAccessory,
                        Uzunluq = product.Uzunluq,
                        En = product.En,
                        Diametr = product.Diametr
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
                    .Select(x => new CartViewModel { ProductId = x.ProductId, Name = x.Product.Name, Price = x.Product.Price, DiscountPrice = x.Product.DiscountPrice, Image = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image }).ToList();
            }

            

            return RedirectToAction("index", "shop");
        }

        public IActionResult DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            CartViewModel cartVM = null;

            if (product == null) return RedirectToAction("index", "error");

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<CartViewModel> houses = new List<CartViewModel>();

            if (member == null)
            {
                string productStr = HttpContext.Request.Cookies["Products"];
                houses = JsonConvert.DeserializeObject<List<CartViewModel>>(productStr);

                cartVM = houses.FirstOrDefault(x => x.ProductId == id);


                houses.Remove(cartVM);

                cartVM.Count--;

                productStr = JsonConvert.SerializeObject(houses);
                HttpContext.Response.Cookies.Append("Products", productStr);
            }
            else
            {
                CartItem cartItem = _context.CartItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);


                _context.CartItems.Remove(cartItem);


                cartItem.Count--;


                _context.SaveChanges();

                houses = _context.CartItems.Include(x => x.Product).Where(x => x.AppUserId == member.Id)
                    .Select(x => new CartViewModel { ProductId = x.ProductId, Count = x.Count, Name = x.Product.Name, Price = x.Product.Price, DiscountPrice = x.Product.DiscountPrice, Image = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image }).ToList();
            }

            return RedirectToAction("index", "card");
        }
    }
}
