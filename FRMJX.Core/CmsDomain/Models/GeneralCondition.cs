namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GeneralCondition : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Description { get; set; }
}
