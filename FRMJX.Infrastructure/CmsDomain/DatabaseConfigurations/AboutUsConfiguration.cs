namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AboutUsConfiguration : IEntityTypeConfiguration<AboutUs>
{
	public void Configure(EntityTypeBuilder<AboutUs> builder)
	{
		builder.ToTable("AboutUses", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
