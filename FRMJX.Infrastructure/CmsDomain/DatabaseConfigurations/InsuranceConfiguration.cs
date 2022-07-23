namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
{
	public void Configure(EntityTypeBuilder<Insurance> builder)
	{
		builder.ToTable("Insurances", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.Insurances)
			.HasForeignKey(entity => entity.ImageId)
			.IsRequired(false);
	}
}
