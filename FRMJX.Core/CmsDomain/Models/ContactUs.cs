namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class ContactUs : BaseLocalizedExtendedEntity
{
	public string FullName { get; set; }

	public string MobileNumber { get; set; }

	public string Text { get; set; }
}
