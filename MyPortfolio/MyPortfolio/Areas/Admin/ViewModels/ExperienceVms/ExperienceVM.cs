using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels.ExperienceVms;

public class ExperienceVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Не указали специализацию")]
    [MaxLength(256)]
    public string Specialization { get; set; }

    [Required(ErrorMessage = "Не указали Дату начала")]
    public int StartDate { get; set; }

    [Required(ErrorMessage = "Не указали Дату окончания")]
    public int? EndDate { get; set; }

    [Required(ErrorMessage = "Не указали Имя организации")]
    [MaxLength(256)]
    public string OrganizationName { get; set; }
    [Required(ErrorMessage = "Не указали Как учились")]
    [MaxLength(256)]
    public string Description { get; set; }
}
