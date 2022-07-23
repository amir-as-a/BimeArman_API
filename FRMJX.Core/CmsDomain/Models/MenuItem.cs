namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class MenuItem : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Url { get; set; }

	public bool OpenInNewTab { get; set; }

	public ICollection<MenuItem> Childeren { get; set; }

	public MenuItem Parent { get; set; }

	public int? ParentId { get; set; }

	public bool? FirstFooter { get; set; }

	public bool? SecendFooter { get; set; }

	public bool? ThirdFooter { get; set; }
}
