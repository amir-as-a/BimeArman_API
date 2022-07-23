namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ConditionMembershipConfiguration : IEntityTypeConfiguration<ConditionMembership>
{
	public void Configure(EntityTypeBuilder<ConditionMembership> builder)
	{
		builder.ToTable("ConditionMemberships", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(x => x.CustomFile)
			.WithMany(x => x.ConditionMemberships)
			.HasForeignKey(x => x.CustomFileId);
	}
}
