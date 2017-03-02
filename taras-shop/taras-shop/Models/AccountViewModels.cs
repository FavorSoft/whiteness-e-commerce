﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taras_shop.Models
{
    public class Auth
    {
        public class LoginModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            public string Firstname { get; set; }

            [Required]
            public string Surname { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Number { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string ConfirmPassword { get; set; }
        }
    }
}