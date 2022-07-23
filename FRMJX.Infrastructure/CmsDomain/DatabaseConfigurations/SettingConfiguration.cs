namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
	public void Configure(EntityTypeBuilder<Setting> builder)
	{
		builder.ToTable("Settings", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired();

		builder.Property(entity => entity.Value)
			.IsRequired();

		builder.HasIndex(p => new { p.Name, p.CultureLcid })
			.IsUnique();
	}
}
