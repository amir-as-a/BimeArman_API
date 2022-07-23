namespace FRMJX.Infrastructure.SecurityDomain.DatabaseConfiguretions;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users", ModelSettings.SecurityDomainName);

		builder.Property(e => e.AccessLevel).IsRequired();
	}
}
