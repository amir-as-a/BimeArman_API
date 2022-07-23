namespace FRMJX.Core.BaseDataDomain.Models;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;

public class State : BaseEntity
{
	public string Name { get; set; }

	public string Description { get; set; }

	public ICollection<City> Cities { get; set; }

	public ICollection<Address> Addresses { get; set; }

	public ICollection<Vendoring> Vendorings { get; set; }

	public ICollection<Representation> Representations { get; set; }

	public ICollection<HealthCenterPdf> HealthCenterPdfs { get; set; }

	public ICollection<DamageCenter> DamageCenters { get; set; }
}
