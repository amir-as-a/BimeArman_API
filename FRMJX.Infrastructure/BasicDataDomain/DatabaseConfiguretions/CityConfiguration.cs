namespace FRMJX.Infrastructure.BasicDataDomain.DatabaseConfiguretions;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
	public void Configure(EntityTypeBuilder<City> builder)
	{
		builder.ToTable("Cities", ModelSettings.BaseDataDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired()
			.HasMaxLength(ModelSettings.NameMaxLength);

		builder.Property(entity => entity.Description)
			.IsRequired()
			.HasMaxLength(ModelSettings.DescriptionMaxLength);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.Cities)
			.HasForeignKey(entity => entity.StateId);
	}
}
