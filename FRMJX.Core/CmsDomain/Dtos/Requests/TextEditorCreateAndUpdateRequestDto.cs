namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class TextEditorCreateAndUpdateRequestDto
{
	public string PageTitle { get; set; }

	public string HtmlDocument { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
