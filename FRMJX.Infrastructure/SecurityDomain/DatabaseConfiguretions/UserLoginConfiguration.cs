namespace FRMJX.Infrastructure.SecurityDomain.DatabaseConfiguretions;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
	public void Configure(EntityTypeBuilder<UserLogin> builder) => builder.ToTable("UserLogin", ModelSettings.SecurityDomainName);
}
