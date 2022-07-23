namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DamageCenterConfiguration : IEntityTypeConfiguration<DamageCenter>
{
	public void Configure(EntityTypeBuilder<DamageCenter> builder)
	{
		builder.ToTable("DamageCenters", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.DamageCenters)
			.HasForeignKey(entity => entity.StateId);

		builder.HasOne(entity => entity.City)
			.WithMany(other => other.DamageCenters)
			.HasForeignKey(entity => entity.CityId);
	}
}
