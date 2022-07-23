namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AboutUsAttributeConfiguration : IEntityTypeConfiguration<AboutUsAttribute>
{
	public void Configure(EntityTypeBuilder<AboutUsAttribute> builder)
	{
		builder.ToTable("AboutUsAttributes", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
