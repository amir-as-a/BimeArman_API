namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;
using System.Web.Mvc;

public class TextEditor : BaseLocalizedExtendedEntity
{
	public string PageTitle { get; set; }

	[AllowHtml]
	public string HtmlDocument { get; set; }

	public int CustomFileId { get; set; }
}
