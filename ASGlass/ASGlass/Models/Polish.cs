using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Polish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
