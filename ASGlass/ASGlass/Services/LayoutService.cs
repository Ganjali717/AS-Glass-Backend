using ASGlass.DAL;
using ASGlass.Models;
using ASGlass.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }


        public List<CartViewModel> GetCartItems()
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
                        Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                        if (product != null)
                        {
                            item.Name = product.Name;   
                            item.Price = product.Price;
                            item.DiscountPrice = product.DiscountPrice;
                            item.Image = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                        }
                    }
                }
            }
            else
            {
                List<CartItem> cartItems = _context.CartItems.Include(x => x.Product).ThenInclude(x => x.ProductImages ).Where(x => x.AppUserId == member.Id).ToList();
                items = cartItems.Select(x => new CartViewModel
                {
                    ProductId = x.ProductId,
                    Name = x.ProductId != null ? x.Product.Name: x.Name,
                    Price = x.ProductId !=null ? x.Product.Price: x.Price,
                    DiscountPrice = x.ProductId != null ? x.Product.DiscountPrice: x.DiscountPrice,
                    Image = x.ProductId != null ? x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image: x.Image
                }).ToList();
            }

            return items;
        }


        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();

            return categories;
        }
    }
}
