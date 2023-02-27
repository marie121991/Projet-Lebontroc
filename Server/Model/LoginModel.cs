using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

public class LoginModel
{

    [Required]
    [EmailAddress]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
    public string ConfirmPassword { get; set; }
}