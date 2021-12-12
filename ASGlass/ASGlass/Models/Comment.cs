using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
