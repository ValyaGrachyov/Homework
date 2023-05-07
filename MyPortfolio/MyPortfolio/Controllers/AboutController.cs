using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/about")]
public class AboutController : Controller
{
    private readonly IServiceManager _serviceManager;
    
    public AboutController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    public async Task<IActionResult> About()
    {
        var userDto = await _serviceManager.UserService.GetByIdAsync(1);

        var userVm = new UserVM
        {
            Age = userDto.Age,
            Degree = userDto.Degree,
            Birthday = userDto.BirthDate.ToString("D"),
            Freelance = userDto.Freelance,
            PhEmailone = userDto.PhEmailone,
            City = userDto.City,
            Phone = userDto.Phone,
            Website = userDto.Website
        };

        return View(userVm);
    }
}