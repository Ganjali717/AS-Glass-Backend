using ASGlass.Models;
using ASGlass.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.ViewModels
{
    public class OrderViewModel
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public double Price { get; set; }
    }
}
