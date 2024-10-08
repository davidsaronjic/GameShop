﻿using System.ComponentModel.DataAnnotations;

namespace GameShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name ="Username")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
    }
}
