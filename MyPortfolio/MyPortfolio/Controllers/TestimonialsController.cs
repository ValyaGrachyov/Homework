using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/testimonials")]
public class TestimonialsController : Controller
{
    private readonly IServiceManager _serviceManager;
    
    public TestimonialsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IActionResult> Testimonials()
    {
        var testimonialDtos = await _serviceManager.TestimonialService.GetAllAsync();

        var testimonialVms = testimonialDtos.Select(x => new TestimonialVM
        {
            Content = x.Content,
            AuthorName = x.AuthorName,
            AuthorOccupation = x.AuthorOccupation
        }).ToList();

        return View(testimonialVms);
    }
}