namespace FRMJX.Infrastructure.SecurityDomain.DatabaseConfiguretions;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder.ToTable("Roles", ModelSettings.SecurityDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired()
			.HasMaxLength(ModelSettings.NameMaxLength);

		builder.Property(entity => entity.Description)
			.IsRequired()
			.HasMaxLength(ModelSettings.DescriptionMaxLength);
	}
}
