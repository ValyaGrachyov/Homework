using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using MyPortfolio.Areas.Admin.ViewModels.SkillVms;
using Contracts.Admin.Skill;
using Microsoft.AspNetCore.Localization;
using Persistence.Services.LanguageService;
using MyPortfolio.Areas.Admin.ViewModels.ExperienceVms;

namespace MyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public SkillController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.SkillService.DeleteAsync(id);
            return RedirectToAction("index","skill");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] EditSkillVm skillVm ,[FromQuery] int id)
        {
            if(ModelState.IsValid)
            {
                var skill = new EditSkillDto
                {
                    Id = id,
                    Name = skillVm.Name,
                    Score = skillVm.Score,
                };
                await _serviceManager.SkillService.EditAsync(skill);
                return RedirectToAction("index", "skill");
            }
            return await Edit(id);            
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromQuery] int id)
        {
            var editSkill = await _serviceManager.SkillService.GetAllAsync();
            var editSkillModel = editSkill.Select(x => x).Where(x => x.Id == id).ToList();
            var editSkillVm = new EditSkillVm
            {
                Name = editSkillModel[0].Name,
                Score = editSkillModel[0].Score
            };

            return View(editSkillVm);
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromForm] AddSkillVm skill )
        {
            if(ModelState.IsValid)
            {
                var newSkill = new AddSkillDto
                {
                    Name = skill.Name,
                    Score = skill.Score,
                };

                await _serviceManager.SkillService.AddAsync(newSkill);
                return RedirectToAction("index", "skill");
            }
            return RedirectToAction("index", "skill");
            
        }

        

        [HttpGet]
        public async Task<IActionResult> Index()        
        {
            var skills = await _serviceManager.SkillService.GetAllAsync();

            var skillsModel = skills.Select(e => new SkillVm
            {
                Id = e.Id,
                Name = e.Name,
                Score = e.Score,
            });

            return View(skillsModel);
        }

        #region Localization
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return RedirectToAction("index", "skill");
        }
        #endregion

    }
}
