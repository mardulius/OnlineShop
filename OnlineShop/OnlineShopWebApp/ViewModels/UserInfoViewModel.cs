﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.ViewModels
{
    public class UserInfoViewModel
    {
        [Required(ErrorMessage = "не указано имя")]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 16 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "не указана фамилия")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 25 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "не указан email")]
        [EmailAddress(ErrorMessage = "некорректный формат email")]
        public string Email { get; set; }   
        [Required]
        public string Id { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; }
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
