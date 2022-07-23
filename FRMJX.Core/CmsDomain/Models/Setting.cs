namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class Setting : BaseLocalizedEntity
{
	public string Name { get; set; }

	public string Value { get; set; }
}
