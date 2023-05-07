using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/services")]
public class ServicesController : Controller
{
    private readonly IServiceManager _serviceManager;
    
    public ServicesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IActionResult> Services()
    {
        var servicesDtos = await _serviceManager.ServiceService.GetAllAsync();

        var serviceVms = servicesDtos.Select(x => new ServiceVM
        {
            Description = x.Description,
            Name = x.Name
        }).ToList();

        return View(serviceVms);
    }
}