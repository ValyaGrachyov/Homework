using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels.SkillVms
{
    public class SkillVm
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]        
        public int Score { get; set; }
    }
}
