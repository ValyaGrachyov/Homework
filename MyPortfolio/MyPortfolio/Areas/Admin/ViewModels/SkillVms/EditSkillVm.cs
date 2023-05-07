using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels.SkillVms
{
    public class EditSkillVm
    {
        [Required(ErrorMessage ="Неверное имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Неверный стаж")]
        public int Score { get; set; }
    }
}
