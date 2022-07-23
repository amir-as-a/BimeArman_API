namespace FRMJX.Core.BaseDataDomain.Models;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.Infrastructure;

public class City : BaseEntity
{
	public State State { get; set; }

	public int StateId { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public ICollection<Address> Addresses { get; set; }

	public ICollection<Vendoring> Vendorings { get; set; }

	public ICollection<Representation> Representations { get; set; }

	public ICollection<DamageCenter> DamageCenters { get; set; }

	public ICollection<HealthCenter> HealthCenters { get; set; }
}
