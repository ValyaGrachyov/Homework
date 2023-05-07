using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/skills")]
public class SkillController : Controller
{
    private readonly IServiceManager _serviceManager;

    public SkillController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IActionResult> Skills()
    {
        var skillDtos = await _serviceManager.SkillService.GetAllAsync();

        var skillVms = skillDtos.Select(x => new SkillVM
        {
            Name = x.Name,
            Score = x.Score
        }).ToList();

        return View(skillVms);
    }
}