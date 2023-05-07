using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Contracts.Admin.Education;
using MyPortfolio.Areas.Admin.ViewModels.EducationVms;
using Microsoft.AspNetCore.Localization;
using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public EducationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.EducationService.DeleteAsync(id);
            return RedirectToAction("index", "education");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditEducationVm educationVm, [FromQuery] int id)
        {
            if(ModelState.IsValid)
            {
                var newEditEducation = new EditEducationDto
                {
                    Id = id,
                    Specialization = educationVm.Specialization,
                    Degree = educationVm.Degree,
                    Description = educationVm.Description,
                    EndDate = educationVm.EndDate,
                    OrganizationName = educationVm.OrganizationName,
                    StartDate = educationVm.StartDate,
                };

                await _serviceManager.EducationService.EditAsync(newEditEducation);
                return RedirectToAction("index", "education");
            }
            return await Edit(id);

        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int id )
        {
            var editEducation = await _serviceManager.EducationService.GetAllAsync();
            var editEducationModel = editEducation.Select(x => x).Where(x => x.Id == id).ToList();
            var editEducationVM = new EditEducationVm
            {
                 Specialization = editEducationModel[0].Specialization,
                 Degree = editEducationModel[0].Degree,
                 StartDate = editEducationModel[0].StartDate,
                 EndDate = (DateTime)editEducationModel[0].EndDate,
                 OrganizationName = editEducationModel[0].OrganizationName,
                 Description = editEducationModel[0].Description
            };

            return View(editEducationVM);
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var educations = await _serviceManager.EducationService.GetAllAsync();

            var educationModels = educations.Select(e => new EducationVm
            {
                Id = e.Id,
                StartDate = e.StartDate.Year,
                Description = e.Description,
                OrganizationName = e.OrganizationName,
                EndDate = e.EndDate?.Year,
                Specialization = e.Specialization,
                Degree = e.Degree
            });

            return View(educationModels);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] AddEducatiomVm educationVm)
        {
            if (ModelState.IsValid)
            {
				var education = new AddEducationDto
				{
					Specialization = educationVm.Specialization,
					Degree = educationVm.Degree,
					StartDate = educationVm.StartDate,
					EndDate = educationVm.EndDate,
					Description = educationVm.Description,
					OrganizationName = educationVm.OrganizationName
				};

				await _serviceManager.EducationService.AddAsync(education);
				return RedirectToAction("index", "education");
			}
            return RedirectToAction("index","education");
            
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return RedirectToAction("index", "education");
        }
    }
}
