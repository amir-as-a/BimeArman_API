namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class BlogType : BaseLocalizedExtendedEntity
{
	public string Name { get; set; }

	public ICollection<BlogPost> BlogPosts { get; set; }
}
