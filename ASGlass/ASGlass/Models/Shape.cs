using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Shape
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public List<Product> Products { get; set; }
    }
}
