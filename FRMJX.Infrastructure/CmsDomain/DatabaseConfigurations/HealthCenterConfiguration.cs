namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HealthCenterConfiguration : IEntityTypeConfiguration<HealthCenter>
{
	public void Configure(EntityTypeBuilder<HealthCenter> builder)
	{
		builder.ToTable("HealthCenters", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.City)
			.WithMany(other => other.HealthCenters)
			.HasForeignKey(entity => entity.CityId);

	}
}
