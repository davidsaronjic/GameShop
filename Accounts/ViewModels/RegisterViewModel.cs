using System.ComponentModel.DataAnnotations;

namespace GameShop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        //
        [Required(ErrorMessage = "Username is required")]        
        public string UserName { get; set; }
        //


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, MinimumLength = 6, ErrorMessage ="The {0} must be between {2} and {1} characters")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        public string Password { get; set; }


        [Required(ErrorMessage ="Confirm Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
