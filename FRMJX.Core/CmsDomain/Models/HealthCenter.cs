namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HealthCenter : BaseLocalizedExtendedEntity
{
	public string Center { get; set; }

	public string CenterName { get; set; }

	public string PhoneNumber { get; set; }

	public string ExactAddress { get; set; }

	public int CityId { get; set; }

	public City City { get; set; }
}
