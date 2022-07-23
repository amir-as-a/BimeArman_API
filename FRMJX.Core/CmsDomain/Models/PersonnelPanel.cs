namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PersonnelPanel : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int PanelCategoryId { get; set; }

	public int CustomFileId { get; set; }

	public PersonnelPanelCategory PersonnelPanelCategory { get; set; }

	public CustomFile CustomFile { get; set; }
}
