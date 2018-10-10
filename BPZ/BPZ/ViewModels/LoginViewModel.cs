using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BPZ.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(150)]
        public string email { get; set; }

        [Required]
        [MaxLength(150)]
        public string password { get; set; }

        bool rememberMe { get; set; }
    }
}