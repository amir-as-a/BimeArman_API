namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class BlogPostBlogCategory : BaseEntity
{
	public BlogPost BlogPost { get; set; }

	public int BlogPostId { get; set; }

	public BlogCategory BlogCategory { get; set; }

	public int BlogCategoryId { get; set; }
}
