namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UsefulLink : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Url { get; set; }

	public int IconId { get; set; }

	public int? FileId { get; set; }

	public bool IsPersonnel { get; set; }

	public bool IsRepresention { get; set; }

	public CustomFile CustomFile { get; set; }
}
