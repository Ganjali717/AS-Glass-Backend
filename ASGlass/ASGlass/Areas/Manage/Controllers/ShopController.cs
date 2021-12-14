using ASGlass.DAL;
using ASGlass.Helpers;
using ASGlass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin, SuperAdmin")]

    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ShopController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null, int ? categoryId = null, string sort = null)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var query = _context.Products.Include(x => x.Colors).Include(x => x.Shape).Include(x => x.Thickness).Include(x => x.Polish).Include(x => x.Corner).AsQueryable();

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentCategoryId = categoryId;
            ViewBag.CurrentSort = sort;



            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search) || x.Shape.Name.Contains(search));

            if (categoryId != null)
                query = query.Where(x => x.ProductCategories.Any(x => x.CategoryId == categoryId));

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



            var pagenatedProducts = PagenatedList<Product>.Create(query.Include(x => x.ProductImages).Include(x => x.Shape).Include(x => x.Colors).Include(x => x.Polish).Include(x => x.Corner).Include(x => x.Thickness), 4, page);

            return View(pagenatedProducts);
        }


        public IActionResult Create()
        {
            
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Shapes = _context.Shapes.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Thicknesses = _context.Thicknesses.ToList();
            ViewBag.Polishes = _context.Polishes.ToList();
            ViewBag.Corners = _context.Corners.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Product product)
        {

            if (!_context.Colors.Any(x => x.Id == product.ColorId)) ModelState.AddModelError("ColorsId", "Colors not found!");
            if (!_context.Shapes.Any(x => x.Id == product.ShapeId)) ModelState.AddModelError("ShapeId", "Shape not found!");
            if (!_context.Polishes.Any(x => x.Id == product.PolishId)) ModelState.AddModelError("PolishId", "Polish not found!");
            if (!_context.Thicknesses.Any(x => x.Id == product.ThicknessId)) ModelState.AddModelError("ThicknessId", "Thickness not found!");
            if (!_context.Corners.Any(x => x.Id == product.CornerId)) ModelState.AddModelError("CornerId", "Corner not found!");
                  


            product.ProductImages = new List<ProductImage>();
            product.ProductCategories = new List<ProductCategory>();
            foreach (var categoryId in product.CategoryIds)
            {
                Category category = _context.Categories.FirstOrDefault(x => x.Id == categoryId);

                if (category == null)
                {
                    ModelState.AddModelError("CategoryIds", "Category not found!");
                    return View();
                }

                ProductCategory productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };

                product.ProductCategories.Add(productCategory);
            }

            if (product.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
            }
            else
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 15000000)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View(product);
                }

                string newFileName = Guid.NewGuid().ToString() + product.PosterFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/products", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.PosterFile.CopyTo(stream);
                }

                ProductImage poster = new ProductImage
                {
                    Image = newFileName,
                    PosterStatus = true,
                };
                product.ProductImages.Add(poster);
            }


            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/house", file)
                    };

                    product.ProductImages.Add(image);
                }
            }

          
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult DeleteProductFetch(int id)
        {
            Product product = _context.Products.Include(b => b.Colors).Include(t => t.Thickness).Include(x => x.Corner).Include(x => x.Shape).Include(x => x.Polish).FirstOrDefault(x => x.Id == id);
            if (product == null) return Json(new { status = 404 });

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }



        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Include(b => b.ProductImages).Include(c => c.ProductCategories).Include(t => t.Colors).Include(x => x.Shape).Include(x => x.Polish).Include(x => x.Thickness).Include(x => x.Corner).FirstOrDefault(x => x.Id == id);
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Shapes = _context.Shapes.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Thicknesses = _context.Thicknesses.ToList();
            ViewBag.Polishes = _context.Polishes.ToList();
            ViewBag.Corners = _context.Corners.ToList();
            product.CategoryIds = product.ProductCategories.Select(x => x.CategoryId).ToList();
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]

        public IActionResult Edit(Product product)
        {
            Product existProduct = _context.Products.Include(b => b.ProductImages).Include(t => t.ProductCategories).Include(x => x.Colors).Include(x => x.Thickness).Include(x => x.Shape).Include(x => x.Polish).Include(x => x.Corner).FirstOrDefault(x => x.Id == product.Id);

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Shapes = _context.Shapes.ToList();
            ViewBag.Colors = _context.Colors.ToList();
            ViewBag.Thicknesses = _context.Thicknesses.ToList();
            ViewBag.Polishes = _context.Polishes.ToList();
            ViewBag.Corners = _context.Corners.ToList();

            if (existProduct == null) return View();
            product.ProductImages = existProduct.ProductImages;

            if (!_context.Colors.Any(x => x.Id == product.ColorId)) ModelState.AddModelError("ColorsId", "Colors not found!");
            if (!_context.Shapes.Any(x => x.Id == product.ShapeId)) ModelState.AddModelError("ShapeId", "Shape not found!");
            if (!_context.Polishes.Any(x => x.Id == product.PolishId)) ModelState.AddModelError("PolishId", "Polish not found!");
            if (!_context.Thicknesses.Any(x => x.Id == product.ThicknessId)) ModelState.AddModelError("ThicknessId", "Thickness not found!");
            if (!_context.Corners.Any(x => x.Id == product.CornerId)) ModelState.AddModelError("CornerId", "Corner not found!");

            foreach (var item in product.CategoryIds)
            {
                if (!_context.Categories.Any(x => x.Id == item)) ModelState.AddModelError("CategoryIds", "Category not found!");
            }



            /*if (!ModelState.IsValid) return View(product);*/



            if (product.PosterFile != null)
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                ProductImage poster = existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == true);
                string newFileName = FileManager.Save(_env.WebRootPath, "uploads/products", product.PosterFile);

                if (poster == null)
                {
                    poster = new ProductImage
                    {
                        PosterStatus = true,
                        Image = newFileName,
                        ProductId = product.Id
                    };

                    _context.ProductImages.Add(poster);
                }
                else
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/house", existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image);
                    poster.Image = newFileName;
                }
            }


            /* existHouse.HouseAmenitis.RemoveAll((x => !house.AmenitiIds.Contains(x.AmenitiId)));*/

            if (product.CategoryIds != null)
            {
                foreach (var categoryid in product.CategoryIds.Where(x => !existProduct.ProductCategories.Any(bt => bt.CategoryId == x)))
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        CategoryId = categoryid,
                        ProductId = product.Id
                    };
                    existProduct.ProductCategories.Add(productCategory);
                }
            }

            /* existHouse.HouseImages.RemoveAll(x => x.PosterStatus == null && !house.HouseImageIds.Contains(x.Id));*/

            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/house", file)
                    };

                    existProduct.ProductImages.Add(image);
                }
            }

            existProduct.Name = product.Name;
            existProduct.Price = product.Price;
            existProduct.DiscountPrice = product.DiscountPrice;
            existProduct.Diametr = product.Diametr;
            existProduct.En = product.En;
            existProduct.Uzunluq = product.Uzunluq;
            existProduct.ColorId = product.ColorId;
            existProduct.ShapeId = product.ShapeId;
            existProduct.ThicknessId = product.ThicknessId;
            existProduct.CornerId = product.CornerId;
            existProduct.PolishId = product.PolishId;
            existProduct.Desc = product.Desc;
            existProduct.Count = product.Count;
            existProduct.IsAccessory = product.IsAccessory;
            
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Comment(int id)
        {
            Product house = _context.Products.Include(x => x.Comments).FirstOrDefault(x => x.Id == id);

            if (house == null) return NotFound();

            return View(house);
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Include(x => x.Product).FirstOrDefault(x => x.Id == id);

            if (comment == null) return NotFound();

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
