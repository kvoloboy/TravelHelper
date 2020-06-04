﻿using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Web.Models.Account
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Enter email, please")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password, please")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
