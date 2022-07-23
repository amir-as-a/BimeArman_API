namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.SecurityDomain.Dtos.Responses;

public class BlogCommentGetResponseDto
{
	public int Id { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public bool ConfirmedByAdmin { get; set; }

	public int BlogPostId { get; set; }

	public string Comment { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public DateTime InsertDateTime { get; set; }
}
