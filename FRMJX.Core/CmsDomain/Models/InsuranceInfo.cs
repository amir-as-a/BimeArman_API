namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.Infrastructure;

public class InsuranceInfo : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int InsuranceId { get; set; }

	public Insurance Insurance { get; set; }
}
