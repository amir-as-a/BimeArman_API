namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class TextEditorGetResponseDto
{
	public int Id { get; set; }

	public string PageTitle { get; set; }

	public string HtmlDocument { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
