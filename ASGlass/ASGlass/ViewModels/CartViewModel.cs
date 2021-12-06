using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.ViewModels
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double? Uzunluq { get; set; }
        public double? En { get; set; }
        public double? Diametr { get; set; }
        public int? ThincknessId { get; set; }
        public int? PolishId { get; set; }
        public int? ColorId { get; set; }
        public int? CornerId { get; set; }
        public bool? IsAccessory { get; set; }
    }
}
