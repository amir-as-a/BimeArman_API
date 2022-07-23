namespace FRMJX.Core.CmsDomain.Dtos.Requests;
public class BlogPostCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public string Body { get; set; }

	public int BlogTypeId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int PictureId { get; set; }

	public int BlogCategoryId { get; set; }
}
