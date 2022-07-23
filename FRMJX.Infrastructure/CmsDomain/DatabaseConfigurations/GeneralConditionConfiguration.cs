namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GeneralConditionConfiguration : IEntityTypeConfiguration<GeneralCondition>
{
	public void Configure(EntityTypeBuilder<GeneralCondition> builder)
	{
		builder.ToTable("GeneralConditions", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
