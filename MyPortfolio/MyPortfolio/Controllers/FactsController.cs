using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/facts")]
public class FactsController : Controller
{
    private readonly IServiceManager _serviceManager;
    
    public FactsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IActionResult> Facts()
    {
        var factDtos = await _serviceManager.FactService.GetAllAsync();

        var factVms = factDtos.Select(x => new FactVM
        {
            Description = x.Description,
            Count = x.Count,
            Name = x.Name
        }).ToList();

        return View(factVms);
    }
}