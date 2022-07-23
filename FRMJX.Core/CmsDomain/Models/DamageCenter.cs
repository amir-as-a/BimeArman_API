namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.Infrastructure;

public class DamageCenter : BaseLocalizedExtendedEntity
{
	public string BranchName { get; set; }

	public string BranchManager { get; set; }

	public string PhoneNumber { get; set; }

	public int StateId { get; set; }

	public int CityId { get; set; }

	public string ExactAddress { get; set; }

	public string PostalCode { get; set; }

	public State State { get; set; }

	public City City { get; set; }
}
