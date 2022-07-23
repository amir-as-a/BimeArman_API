namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
	public void Configure(EntityTypeBuilder<Faq> builder)
	{
		builder.ToTable("Faqs", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Question)
			.IsRequired();

		builder.Property(entity => entity.Answer)
			.IsRequired();
	}
}
