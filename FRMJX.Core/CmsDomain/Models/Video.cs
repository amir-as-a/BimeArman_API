namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class Video : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int CustomFileId { get; set; }

	public CustomFile CustomFile { get; set; }
}
