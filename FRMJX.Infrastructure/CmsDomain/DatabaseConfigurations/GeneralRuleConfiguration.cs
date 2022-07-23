namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GeneralRuleConfiguration : IEntityTypeConfiguration<GeneralRule>
{
	public void Configure(EntityTypeBuilder<GeneralRule> builder)
	{
		builder.ToTable("GeneralRules", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
