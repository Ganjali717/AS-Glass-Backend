using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Http;
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
    public class CardController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public CardController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<CartViewModel> items = new List<CartViewModel>();

            AppUser member = null;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name && !x.IsAdmin);
            }
            if (member == null)
            {
                var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Products"];

                if (itemsStr != null)
                {
                    items = JsonConvert.DeserializeObject<List<CartViewModel>>(itemsStr);

                    foreach (var item in items)
                    {
                        Product product = _context.Products.Include(x => x.Shape).Include(x => x.Colors).FirstOrDefault(x => x.Id == item.ProductId);
                        if (product != null)
                        {
                            item.Name = product.Name;
                            item.Price = product.Price; 
                            item.Count = product.Count;
                            item.DiscountPrice = product.DiscountPrice;
                            item.IsAccessory = product.IsAccessory;
                            item.Diametr = product.Diametr;
                            item.Uzunluq = product.Uzunluq;
                            item.En = product.En;
                            item.Image = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                            if (product.ShapeId != null || product.ColorId != null)
                            {
                                item.Shape = product.Shape.Name;
                                item.Color = product.Colors.Name;
                            }
                        }
                    }
                }
            }
            else
            {
                List<CartItem> cartItems = _context.CartItems.Include(x => x.Product).Include(x => x.Product.Shape).Include(x => x.Product.Colors).Where(x => x.AppUserId == member.Id).ToList();


                items = cartItems.Select(x => new CartViewModel
                {
                    ProductId = x.ProductId,
                    Image = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image,
                    Name = x.Product.Name,
                    Diametr = x.Product.Diametr,
                    Count = x.Product.Count,
                    IsAccessory = x.Product.IsAccessory,
                    Price = x.Product.Price,
                    Shape = x.Product.ShapeId != null ? x.Product.Shape.Name : null,
                    Uzunluq = x.Product.Uzunluq,
                    En = x.Product.En,
                    Color = x.Product.ShapeId != null ? x.Product.Colors.Name : null,
                    DiscountPrice = x.Product.DiscountPrice
                }).ToList();
            }
            return View(items);
        }
    }
}
