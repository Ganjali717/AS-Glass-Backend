using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
