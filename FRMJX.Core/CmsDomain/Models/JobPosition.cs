namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class JobPosition : BaseLocalizedExtendedEntity
{
	public string Category { get; set; }

	public string Title { get; set; }

	public ICollection<Employee> Employees { get; set; }
}
