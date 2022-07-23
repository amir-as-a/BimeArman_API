namespace FRMJX.Infrastructure.SecurityDomain.DatabaseConfiguretions;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
	public void Configure(EntityTypeBuilder<UserRole> builder)
	{
		builder.ToTable("UserRoles", ModelSettings.SecurityDomainName);

		builder.HasOne(entity => entity.Role)
			.WithMany(other => other.UserRoles)
			.HasForeignKey(entity => entity.RoleId);
	}
}
