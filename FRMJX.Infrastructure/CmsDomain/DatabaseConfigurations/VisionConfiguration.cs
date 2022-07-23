namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VisionConfiguration : IEntityTypeConfiguration<Vision>
{
	public void Configure(EntityTypeBuilder<Vision> builder)
	{
		builder.ToTable("Visions", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.Visions)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
