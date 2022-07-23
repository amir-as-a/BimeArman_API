namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class BlogCommentCreateAndUpdateRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public bool ConfirmedByAdmin { get; set; }

	public string Comment { get; set; }

	public int BlogPostId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
