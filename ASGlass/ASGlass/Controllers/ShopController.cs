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
        public IActionResult Index(int page = 1, int? categoryId = null, int? thicknessId = null, int? colorId = null, int? shapeId = null, string sort = null)
        {

            AppUser member = User.Identity.IsAuthenticated ? _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin) : null;

            var query = _context.Products.AsQueryable();

            ViewBag.CategoryId = categoryId;
            ViewBag.ThicknessId = thicknessId;
            ViewBag.ShapeId = shapeId;
            ViewBag.ColorId = colorId; 

            if (categoryId != null)
                query = query.Where(x => x.ProductCategories.Any(c => c.CategoryId == categoryId));
            if (thicknessId != null)
                query = query.Where(x => x.Thickness.Id == thicknessId);
            if (colorId != null)
                query = query.Where(x => x.Colors.Id == colorId);
            if (shapeId != null)
                query = query.Where(x => x.ShapeId != null?x.Shape.Id == shapeId:x.ShapeId == null);

            switch (sort)
            {
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                default:
                    query = query.OrderByDescending(x => x.Id);
                    break;
            }

            

            ShopViewModel shopVM = new ShopViewModel
            {
                Categories = _context.Categories.Include(x => x.ProductCategories).ThenInclude(x => x.Product).ToList(),
                Colors = _context.Colors.Include(x => x.Product).ToList(),
                Thicknesses = _context.Thicknesses.Include(x => x.Products).ToList(),
                Products = PagenatedList<Product>.Create(query.Include(x => x.ProductImages), 4, page)
            };
            return View(shopVM);
        }

        public IActionResult Detail(int id)
        {
            DetailViewModel detailVM = new DetailViewModel()
            {
                Product = _context.Products.Include(x => x.ProductImages).Include(x => x.Shape).Include(x => x.Thickness).Include(x => x.Polish).Include(x => x.Corner).Include(x => x.Colors).FirstOrDefault(x => x.Id == id)
            };

           
            return View(detailVM);
        }

        public IActionResult AddToCart(int id)
        {
            Product product = _context.Products.Include(x => x.ProductCategories).Include(x => x.ProductImages).Include(x => x.Colors).Include(x => x.Shape).Include(x=> x.Thickness).Include(x => x.Corner).Include(x => x.Polish).FirstOrDefault(x => x.Id == id);
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
                        DiscountPrice = product.DiscountPrice != null? product.DiscountPrice: null,
                        IsAccessory = product.IsAccessory,
                        Uzunluq = product.Uzunluq != null? product.Uzunluq:null,
                        En = product.En != null? product.En: null,
                        Diametr = product.Diametr != null? product.Diametr:null,
                        Shape = product.ShapeId != null? product.Shape.Name:null, 
                        Color = product.ColorId !=null? product.Colors.Name:null, 
                        Polish = product.PolishId !=null? product.Polish.Name:null, 
                        Thickness = product.ThicknessId !=null? product.Thickness.Size:null, 
                        Corner = product.CornerId != null? product.Corner.Name:null
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
                    .Select(x => new CartViewModel { ProductId = x.ProductId, Name = x.Product.Name, Price = x.Product.Price, DiscountPrice = x.Product.DiscountPrice, Image = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image, Color = x.Product.Colors.Name, Shape = x.Product.Shape.Name, Corner = x.Product.Corner.Name, Thickness = x.Product.Thickness.Size, Polish = x.Product.Polish.Name }).ToList();
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


        [HttpPost]
        public async Task<IActionResult> AddComment(int id, Comment comment)
        {
            var house = _context.Products.FirstOrDefault(x => x.Id == id);

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            Comment comment1 = new Comment
            {
                AppUserId = User.Identity.IsAuthenticated ? member.Id : null,
                Date = DateTime.UtcNow,
                Text = comment.Text,
                Username = comment.Username,
                Rate = Convert.ToInt32(HttpContext.Request.Form["stars"]),
                Email = comment.Email,
                ProductId = id
            };

            _context.Comments.Add(comment1);
            _context.SaveChanges();


            return Redirect(HttpContext.Request.Headers["Referer"].ToString());

        }
    }
}
