using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Product { get; set; }
    }
}
