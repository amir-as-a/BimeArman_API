namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Regulation : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public int CustomFileId { get; set; }

	public CustomFile CustomFile { get; set; }
}
