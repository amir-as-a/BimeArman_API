namespace FRMJX.Core.SecurityDomain.Services
{
	using FRMJX.Core.SecurityDomain.Models;
	using System.Threading.Tasks;

	public interface IMailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
	}
}
