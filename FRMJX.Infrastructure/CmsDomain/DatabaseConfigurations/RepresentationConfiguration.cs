namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RepresentationConfiguration : IEntityTypeConfiguration<Representation>
{
	public void Configure(EntityTypeBuilder<Representation> builder)
	{
		builder.ToTable("Representations", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.Representations)
			.HasForeignKey(entity => entity.StateId);

		builder.HasOne(entity => entity.City)
			.WithMany(other => other.Representations)
			.HasForeignKey(entity => entity.CityId);
	}
}
