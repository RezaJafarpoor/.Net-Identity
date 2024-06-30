using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace _Net_Identity.Models;

public class ApplicationUser : IdentityUser
{
    [Required] public string Name { get; set; }
    
}