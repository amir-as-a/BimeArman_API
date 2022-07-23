namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class Insurance : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int? ImageId { get; set; }

	public int IconId { get; set; }

	public CustomFile CustomFile { get; set; }

	public ICollection<InsuranceInfo> InsuranceInfos { get; set; }
}
