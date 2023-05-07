using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.Areas.Admin.ViewModels
{
    public class RegisterVM
    {
		[Required(ErrorMessage = "Ты не воин")]
		[Display(Name= "Кто ты воин?")]
        public string Name { get; set; }

		[Required]
		[Display(Name= "Оставьте почту для рассылки")]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль должен быть длинною от 1 до 256 символов," +
			" иметь буквы в нижнем и верхнем регистре и спецсимволы")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password",
			ErrorMessage = "Password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
