namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class BlogPost : BaseLocalizedExtendedEntity
{
	public string Title { get; set; }

	public string Body { get; set; }

	public int PictureId { get; set; }

	public CustomFile Picture { get; set; }

	public BlogType BlogType { get; set; }

	public int BlogTypeId { get; set; }

	public ICollection<BlogPostBlogCategory> BlogPostBlogCategories { get; set; }

	public ICollection<BlogComment> BlogComments { get; set; }
}
