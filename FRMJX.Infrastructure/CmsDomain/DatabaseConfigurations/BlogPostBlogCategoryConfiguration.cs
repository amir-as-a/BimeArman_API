namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogPostBlogCategoryConfiguration : IEntityTypeConfiguration<BlogPostBlogCategory>
{
	public void Configure(EntityTypeBuilder<BlogPostBlogCategory> builder)
	{
		builder.ToTable("BlogPost_BlogCategory_Mappings", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.BlogPost)
			.WithMany(other => other.BlogPostBlogCategories)
			.HasForeignKey(entity => entity.BlogPostId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(entity => entity.BlogCategory)
			.WithMany(other => other.BlogPostBlogCategories)
			.HasForeignKey(entity => entity.BlogCategoryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
