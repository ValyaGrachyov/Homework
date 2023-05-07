using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers;

[Route("/portfolio")]
public class PortfolioController : Controller
{
    public IActionResult Portfolio()
    {
        return View();
    }
}