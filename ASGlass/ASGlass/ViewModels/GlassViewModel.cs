﻿using ASGlass.Models;
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

        public List<CartViewModel> CartViewModels { get; set; }

    }
}
