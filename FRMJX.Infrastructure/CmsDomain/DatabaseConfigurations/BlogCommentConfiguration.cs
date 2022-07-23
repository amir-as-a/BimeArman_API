namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogCommentConfiguration : IEntityTypeConfiguration<BlogComment>
{
	public void Configure(EntityTypeBuilder<BlogComment> builder)
	{
		builder.ToTable("BlogComments", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Comment)
			.IsRequired();

		builder.Property(entity => entity.FirstName)
		.IsRequired();

		builder.Property(entity => entity.LastName)
		.IsRequired();

		builder.HasOne(entity => entity.BlogPost)
			.WithMany(other => other.BlogComments)
			.HasForeignKey(entity => entity.BlogPostId);
	}
}
