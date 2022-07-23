namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class Faq : BaseLocalizedExtendedEntity
{
	public string Question { get; set; }

	public string Answer { get; set; }
}
