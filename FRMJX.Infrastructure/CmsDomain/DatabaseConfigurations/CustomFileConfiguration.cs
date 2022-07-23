namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomFileConfiguration : IEntityTypeConfiguration<CustomFile>
{
	public void Configure(EntityTypeBuilder<CustomFile> builder)
	{
		builder.ToTable("CustomFiles", ModelSettings.CmsDomainName);

		builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
		builder.Property(e => e.ContentType).IsRequired().HasMaxLength(50);
		builder.Property(e => e.Content).IsRequired();
	}
}
