using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(maximumLength:150)]
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 1500)]
        public string SubTitle { get; set; }
        public string RedirectUrl { get; set; }
    }
}
