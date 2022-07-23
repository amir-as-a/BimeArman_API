namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.Infrastructure;

public class Address : BaseLocalizedExtendedEntity
{
	public int StateId { get; set; }

	public int CityId { get; set; }

	public State State { get; set; }

	public City City { get; set; }

	public string ExactAddress { get; set; }
}
