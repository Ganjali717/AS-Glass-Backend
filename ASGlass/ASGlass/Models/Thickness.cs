using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Thickness
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public List<Product> Products { get; set; }
    }
}
