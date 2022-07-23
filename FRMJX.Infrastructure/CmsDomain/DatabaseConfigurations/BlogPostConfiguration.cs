namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
	public void Configure(EntityTypeBuilder<BlogPost> builder)
	{
		builder.ToTable("BlogPosts", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.Property(entity => entity.Body)
			.IsRequired();

		builder.HasOne(entity => entity.BlogType)
			.WithMany(other => other.BlogPosts)
			.HasForeignKey(entity => entity.BlogTypeId);

		builder.HasOne(entity => entity.Picture)
			.WithMany(other => other.BlogPostPictures)
			.HasForeignKey(entity => entity.PictureId);
	}
}
