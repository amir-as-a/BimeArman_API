namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VisionAttributeConfiguration : IEntityTypeConfiguration<VisionAttribute>
{
	public void Configure(EntityTypeBuilder<VisionAttribute> builder)
	{
		builder.ToTable("VisionAttributes", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
