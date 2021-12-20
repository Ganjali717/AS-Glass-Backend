using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public string Name { get; set; }
        public double? Uzunluq { get; set; }
        public double? En { get; set; }
        public double? Diametr { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public string Polish { get; set; }
        public string Corner { get; set; }
        public string Thickness { get; set; }
        public bool? IsAccessory { get; set; }


        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
