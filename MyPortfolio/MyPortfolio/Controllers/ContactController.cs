using Contracts;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using Services.Abstraction;

namespace MyPortfolio.Controllers;

[Route("/contact")]
public class ContactController : Controller
{
    private readonly IServiceManager _serviceManager;

    public ContactController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromForm] RequestMessageVM requestMessageVm)
    {
        await _serviceManager.RequestMessageService.AddAsync(new RequestMessageDto
        {
            Message = requestMessageVm.Message,
            Subject = requestMessageVm.Subject,
            UserEmail = requestMessageVm.UserEmail,
            UserName = requestMessageVm.UserName
        });

        return Ok("OK");
    }
    
    public IActionResult Contact()
    {
        return View();
    }
}