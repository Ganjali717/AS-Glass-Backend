using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }


        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
