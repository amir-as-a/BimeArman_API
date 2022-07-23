namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VendoringConfiguration : IEntityTypeConfiguration<Vendoring>
{
	public void Configure(EntityTypeBuilder<Vendoring> builder)
	{
		builder.ToTable("Vendorings", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.Vendorings)
			.HasForeignKey(entity => entity.StateId);

		builder.HasOne(entity => entity.City)
			.WithMany(other => other.Vendorings)
			.HasForeignKey(entity => entity.CityId);
	}
}
