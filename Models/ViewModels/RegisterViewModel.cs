using System.ComponentModel.DataAnnotations;

namespace _Net_Identity.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} character")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The Password and Confirmation do not match")]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }
    
    

}