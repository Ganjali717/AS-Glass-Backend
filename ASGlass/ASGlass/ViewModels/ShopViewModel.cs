using ASGlass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.ViewModels
{
    public class ShopViewModel
    {
        public PagenatedList<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; }
        public List<Thickness> Thicknesses { get; set; }
        public List<Corner> Corners { get; set; }
    }
}
