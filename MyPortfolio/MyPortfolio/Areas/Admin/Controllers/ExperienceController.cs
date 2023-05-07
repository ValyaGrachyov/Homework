using Contracts.Admin.Education;
using Contracts.Admin.Experience;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Areas.Admin.ViewModels.EducationVms;
using MyPortfolio.Areas.Admin.ViewModels.ExperienceVms;
using Services.Abstraction;

namespace MyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ExperienceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.ExperienceService.DeleteAsync(id);
            return RedirectToAction("index", "experience");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditExperienceVm experienceVm, [FromQuery] int id)
        {
            if(ModelState.IsValid)
            {
                var newEditExperience = new EditExperienceDto
                {
                    Id = id,
                    Specialization = experienceVm.Specialization,
                    Description = experienceVm.Description,
                    EndDate = experienceVm.EndDate,
                    OrganizationName = experienceVm.OrganizationName,
                    StartDate = experienceVm.StartDate,
                };

                await _serviceManager.ExperienceService.EditAsync(newEditExperience);
                return RedirectToAction("index", "experience");
            }
            return await Edit(id);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int id)
        {
            var editExperience = await _serviceManager.ExperienceService.GetAllAsync();
            var editExperienceModel = editExperience.Select(x => x).Where(x => x.Id == id).ToList();
            var editexperienceVm = new EditExperienceVm
            {
                Specialization = editExperienceModel[0].Specialization,               
                StartDate = editExperienceModel[0].StartDate,
                EndDate = (DateTime)editExperienceModel[0].EndDate,
                OrganizationName = editExperienceModel[0].OrganizationName,
                Description = editExperienceModel[0].Description
            };

            return View(editexperienceVm);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var experiences = await _serviceManager.ExperienceService.GetAllAsync();

            var experiencesModels = experiences.Select(e => new ExperienceVM
            {
                Id = e.Id,
                StartDate = e.StartDate.Year,
                Description = e.Description,
                OrganizationName = e.OrganizationName,
                EndDate = e.EndDate?.Year,
                Specialization = e.Specialization,
            });

            return View(experiencesModels);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] AddExperiencenVm educationVm)
        {
            if(ModelState.IsValid)
            {
                var education = new AddExperienceDto
                {
                    Specialization = educationVm.Specialization,
                    StartDate = educationVm.StartDate,
                    EndDate = educationVm.EndDate,
                    Description = educationVm.Description,
                    OrganizationName = educationVm.OrganizationName
                };

                await _serviceManager.ExperienceService.AddAsync(education);
                return RedirectToAction("index", "experience");
            }
            return NotFound();            
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return RedirectToAction("index", "experience");
        }
    }
}
