namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		builder.ToTable("Addresses", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.Addresses)
			.HasForeignKey(entity => entity.StateId);

		builder.HasOne(entity => entity.City)
			.WithMany(other => other.Addresses)
			.HasForeignKey(entity => entity.CityId);
	}
}
