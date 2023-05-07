using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MyPortfolio.Areas.Admin.ViewModels;
using Persistence.Services.EmailService;
using System.Text;

namespace MyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegistrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
		private readonly IUserStore<IdentityUser> _userStore;
		private readonly IEmailService _emailservice;

        public RegistrationController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,IEmailService emailService, IUserStore<IdentityUser> userStore)
        {
			_userStore = userStore;
            _userManager = userManager;
            _signInManager = signInManager;
			_emailservice = emailService;
        }


		[HttpGet]
		public IActionResult Index()
		{
			return  View();	
		}

		[HttpGet]
		public async Task<IActionResult> Confirm([FromQuery]string userId,[FromQuery] string code)
		{
			if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
			if(result.Succeeded == true)
			{
				return View();
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Index([FromForm] RegisterVM model)
        {
			if (ModelState.IsValid)
			{
				// Copy data from RegisterViewModel to IdentityUser
				var user = new IdentityUser
				{
					UserName = model.Name,
					Email = model.Email
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				//P!ssw0rd

				// If user is successfully created, sign-in the user using
				// SignInManager and redirect to index action of HomeController
				if (result.Succeeded)
				{
					var userId = await _userManager.GetUserIdAsync(user);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page("",						
						pageHandler: null,
						values: new { area = "Admin", controller ="registration", action="confirm", userId = userId, code = code },
						protocol: Request.Scheme);
					_emailservice.SendEmailAsync(user.Email,"confirm", $"{callbackUrl}");
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("index", "login","default");
				}

				// If there are any errors, add them to the ModelState object
				// which will be displayed by the validation summary tag helper
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			return View(model);
		}
		private IdentityUser CreateUser()
		{
			try
			{
				return Activator.CreateInstance<IdentityUser>();
			}
			catch
			{
				throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
					$"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
					$"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
			}
		}
	}
}
