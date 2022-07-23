namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UsefulLinkConfiguration : IEntityTypeConfiguration<UsefulLink>
{
	public void Configure(EntityTypeBuilder<UsefulLink> builder)
	{
		builder.ToTable("UsefulLinks", ModelSettings.CmsDomainName);

		builder.Property(x => x.Title)
			.IsRequired();

		builder.HasOne(x => x.CustomFile)
			.WithMany(x => x.UsefulLinks)
			.HasForeignKey(x => x.FileId)
			.IsRequired(false);

	}
}
