using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Persistence.Services.EmailService
{

	public class EmailService : IEmailService
	{

		private readonly IConfiguration _configuration;

		public EmailService(IConfiguration config)
		{
			_configuration = config;
		}

		public async Task SendEmailAsync(string email, string subject, string message)
		{
			try
			{
				// отправитель - устанавливаем адрес и отображаемое в письме имя
				MailAddress from = new MailAddress("testgleb1@gmail.com", "TEST ZAPROS");
				// кому отправляем
				MailAddress to = new MailAddress(email);
				// создаем объект сообщения
				MailMessage m = new MailMessage(from, to);
				// тема письма
				m.Subject = subject;
				// текст письма
				m.Body = message;
				// адрес smtp-сервера и порт, с которого будем отправлять письмо
				SmtpClient smtp = new SmtpClient(_configuration["SMTP"]);
				// Настройка отправителя
				smtp.EnableSsl = true;
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.UseDefaultCredentials = false;
				// логин и пароль
				smtp.Credentials = new NetworkCredential("testgleb1@gmail.com", "oyhjkmnuhagtyifx");
				smtp.Send(m);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
