namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SuggustionConfiguration : IEntityTypeConfiguration<Suggustion>
{
	public void Configure(EntityTypeBuilder<Suggustion> builder)
	{
		builder.ToTable("Suggustions", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.FullName)
			.IsRequired();

		builder.Property(entity => entity.MobileNumber)
		.IsRequired();

		builder.Property(entity => entity.Text)
		.IsRequired();
	}
}
