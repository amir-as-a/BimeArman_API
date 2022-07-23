namespace FRMJX.Infrastructure.BasicDataDomain.DatabaseConfiguretions;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
	public void Configure(EntityTypeBuilder<State> builder)
	{
		builder.ToTable("States", ModelSettings.BaseDataDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired()
			.HasMaxLength(ModelSettings.NameMaxLength);

		builder.Property(entity => entity.Description)
			.IsRequired()
			.HasMaxLength(ModelSettings.DescriptionMaxLength);
	}
}
