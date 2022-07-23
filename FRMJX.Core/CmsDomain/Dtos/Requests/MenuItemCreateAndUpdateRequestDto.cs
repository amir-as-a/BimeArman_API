namespace FRMJX.Core.CmsDomain.Dtos.Requests;
public class MenuItemCreateAndUpdateRequestDto
{
	public int? ParentId { get; set; }

	public string Title { get; set; }

	public string Url { get; set; }

	public bool OpenInNewTab { get; set; }

	public bool? FirstFooter { get; set; }

	public bool? SecendFooter { get; set; }

	public bool? ThirdFooter { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
