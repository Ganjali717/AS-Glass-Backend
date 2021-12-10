using ASGlass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.ViewModels
{
    public class GlassViewModel
    {
        public List<Color> Colors { get; set; }
        public List<Thickness> Thicknesses { get; set; }
        public List<Polish> Polishes { get; set; }
        public List<Corner> Corners { get; set; }
        public List<Shape> Shapes { get; set; }
      /*  public Product Product { get; set; }*/


        public string Shape { get; set; }

        public double? Uzunluq { get; set; }
        public double? En { get; set; }
    }
}
