using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;
using System.Globalization;

namespace MyPortfolio.Controllers;

[Route("/resume")]
public class ResumeController : Controller
{
    private readonly IServiceManager _serviceManager;

    public ResumeController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> Resume()
    {
        var educations = await _serviceManager.EducationService.GetAllAsync();
        var experiences = await _serviceManager.ExperienceService.GetAllAsync();

        var educationModels = educations.Select(e => new EducationVm
        {
            StartDate = e.StartDate.Year,
            Description = e.Description,
            OrganizationName = e.OrganizationName,
            EndDate = e.EndDate?.Year,
            Specialization = e.Specialization,
            Degree = e.Degree
        });

        var experienceModels = experiences.Select(e => new ExperienceVm
        {
            StartDate = e.StartDate.Year,
            Description = e.Description,
            OrganizationName = e.OrganizationName,
            EndDate = e.EndDate?.Year,
            Specialization = e.Specialization,
        });
        List<Object> a = new List<object> {educationModels, experienceModels}; 
        
        return View(a);
    }

    [HttpGet("[action]")]
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1)
        });
        return RedirectToAction("resume", "resume");
    }


}