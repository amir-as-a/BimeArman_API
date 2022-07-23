namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class MenuItemGetResponseDto
{
	public int Id { get; set; }

	public int? ParentId { get; set; }

	public string Title { get; set; }

	public string Url { get; set; }

	public bool OpenInNewTab { get; set; }

	public bool? FirstFooter { get; set; }

	public bool? SecendFooter { get; set; }

	public bool? ThirdFooter { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public List<MenuItemGetResponseDto> Children { get; set; }
}
