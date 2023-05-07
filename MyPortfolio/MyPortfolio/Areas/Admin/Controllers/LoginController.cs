using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Areas.Admin.ViewModels;

namespace MyPortfolio.Areas.Store.Controllers;

[Area("Admin")]
public class LoginController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
    {
        _userManager = userManager;
        _signInManager = signManager;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] LoginVM loginVm)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser(loginVm.Name);
            var result = await _signInManager.PasswordSignInAsync(loginVm.Name, loginVm.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(_userManager.GetUserIdAsync(user));
            }

            return NotFound();
        }
        return RedirectToAction("index","login");

    }
}


    