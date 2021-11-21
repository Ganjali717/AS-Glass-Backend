using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50)]
        public string HeaderLogo { get; set; }
        [StringLength(maximumLength: 50)]

        public string FooterLogo { get; set; }
        [StringLength(maximumLength: 50)]

        public string SupportPhone { get; set; }
        [StringLength(maximumLength: 70)]

        public string Email { get; set; }
        [StringLength(maximumLength: 150)]

        public string Address { get; set; }
    }
}
