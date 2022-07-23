namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Revelation : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public int CustomeFileId { get; set; }

	public CustomFile CustomFile { get; set; }

	public ICollection<RevelationAttribute> RevelationAttributes { get; set; }
}
