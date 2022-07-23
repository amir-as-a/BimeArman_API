namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class BlogPostGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Body { get; set; }

	public DateTime InsertTime { get; set; }

	public CustomFileGetResponseDto Picture { get; set; }

	public int BlogTypeId { get; set; }

	public string BlogTypeName { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public List<BlogCategoryGetResponseDto> BlogCategories { get; set; }
}
