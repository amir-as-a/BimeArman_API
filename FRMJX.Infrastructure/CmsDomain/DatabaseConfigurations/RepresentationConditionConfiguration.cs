namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RepresentationConditionConfiguration : IEntityTypeConfiguration<RepresentationCondition>
{
	public void Configure(EntityTypeBuilder<RepresentationCondition> builder)
	{
		builder.ToTable("RepresentationConditions", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
