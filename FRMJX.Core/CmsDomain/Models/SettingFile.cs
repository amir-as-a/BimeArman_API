namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class SettingFile : BaseLocalizedEntity
{
	public string Name { get; set; }

	public int CustomFileId { get; set; }

	public CustomFile CustomFile { get; set; }
}
