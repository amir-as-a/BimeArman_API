namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
	public void Configure(EntityTypeBuilder<Video> builder)
	{
		builder.ToTable("Videos", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.Videos)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
