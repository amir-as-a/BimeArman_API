namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class BlogCategory : BaseLocalizedExtendedEntity
{
	public string Name { get; set; }

	public ICollection<BlogPostBlogCategory> BlogPostBlogCategories { get; set; }
}
