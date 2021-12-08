using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public bool? PosterStatus { get; set; }
        public Product  Product { get; set; }
    }
}
