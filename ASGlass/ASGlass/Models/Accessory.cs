using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Accessory
    {
        public int Id { get; set; }
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
