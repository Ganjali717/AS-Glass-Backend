using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASGlass.Areas.Manage.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "min 6, max 50 ola biler")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "min 6, max 30 ola biler")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; } = false;
    }
}
