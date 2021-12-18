using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.ViewModels
{
    public class CheckoutViewModel
    {
        public List<CartViewModel> CartViewModels { get; set; } = new List<CartViewModel>();

        [Required]
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 250)]
        public string Address { get; set; }
        [StringLength(maximumLength: 100)]
        public string City { get; set; }
        [StringLength(maximumLength: 20)]
        public string ZipCode { get; set; }
        [StringLength(maximumLength: 500)]
        public string Note { get; set; }
    }
}
