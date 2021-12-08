﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.ViewModels
{
    public class AdminRegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
