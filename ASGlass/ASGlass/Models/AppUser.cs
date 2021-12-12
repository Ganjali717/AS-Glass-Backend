using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Order> Orders { get; set; }
        public List<Comment> Comments { get; set; }

        public string Phone { get; set; }
        public string ConnectionId { get; set; }
        public DateTime LastConnectedDate { get; set; }
    }
}
