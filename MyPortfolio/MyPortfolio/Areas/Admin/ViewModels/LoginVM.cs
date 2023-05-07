using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels;

public class LoginVM
{
    [Required]
    [Display(Name = "Кто ты по масти?")]
    public string Name { get; set; }
    [Required]
    [Display(Name = "3 Цифры на обороте")]
    public string Password { get; set; }
}