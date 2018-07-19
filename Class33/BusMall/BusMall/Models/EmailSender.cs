using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BusMall.Models
{
	public class EmailSender : IEmailSender
	{
		IConfiguration Configuration { get; }
		public EmailSender(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var client = new SendGridClient(Configuration["Api_Key"]);

			var msg = new SendGridMessage();

			msg.SetFrom("admin@busmall.com", "Bus Mall Admin");

			msg.AddTo(email);
			msg.SetSubject(subject);
			msg.AddContent(MimeType.Html, htmlMessage);

			var response = await client.SendEmailAsync(msg);

		}
	}
}
