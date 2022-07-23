namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
	public void Configure(EntityTypeBuilder<SocialMedia> builder)
	{
		builder.ToTable("SocialMedias", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.Property(entity => entity.Url)
			.IsRequired();

		builder.HasOne(x => x.CustomFile)
		.WithMany(x => x.SocialMedias)
		.HasForeignKey(x => x.CustomFileId);
	}
}
