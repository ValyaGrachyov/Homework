using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels.EducationVms
{
    public class EditEducationVm
    {
        [Required(ErrorMessage = "Не указали специализацию")]
        [MaxLength(256)]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Не указали степень")]
        [MaxLength(256)]
        public string Degree { get; set; }
        [Required(ErrorMessage = "Не указали дату начала")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Не указали дату конца")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Не указали имя организации")]
        [MaxLength(256)]
        public string OrganizationName { get; set; }
        [Required(ErrorMessage = "Не указали описание")]
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
