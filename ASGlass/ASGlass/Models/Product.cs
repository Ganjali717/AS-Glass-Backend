using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? ThicknessId { get; set; }
        public int? PolishId { get; set; }
        public int? ShapeId { get; set; }
        public int? ColorId { get; set; }
        public int? CornerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int Count { get; set; }
        public double? DiscountPrice { get; set; }
        [Required]
        public string Desc { get; set; }
        public bool IsAccessory { get; set; }
        public double? Uzunluq { get; set; }
        public double? En { get; set; }
        public double? Diametr { get; set; }



        public Thickness Thickness { get; set; }
        public Corner Corner { get; set; }
        public Polish Polish { get; set; }
        public Color Colors { get; set; }
        public Shape Shape { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Order> Orders { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<CartItem> CartItems { get; set; }

        [NotMapped]
        public IFormFile PosterFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }

        [NotMapped]
        public List<int> ProductImageIds { get; set; } = new List<int>();

        [NotMapped]
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}
