namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RevelationAttributeConfiguration : IEntityTypeConfiguration<RevelationAttribute>
{
	public void Configure(EntityTypeBuilder<RevelationAttribute> builder)
	{
		builder.ToTable("RevelationAttributes", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.Revelation)
			.WithMany(other => other.RevelationAttributes)
			.HasForeignKey(entity => entity.RevelationId);

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(entity => entity.RevelationAttributes)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
