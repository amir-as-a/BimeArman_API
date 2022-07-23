namespace FRMJX.Infrastructure.SecurityDomain.DatabaseConfiguretions;

using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
	public void Configure(EntityTypeBuilder<UserToken> builder) => builder.ToTable("UserTokens", ModelSettings.SecurityDomainName);
}
