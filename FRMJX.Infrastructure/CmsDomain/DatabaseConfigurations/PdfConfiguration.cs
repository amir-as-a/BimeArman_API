namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PdfConfiguration : IEntityTypeConfiguration<Pdf>
{
	public void Configure(EntityTypeBuilder<Pdf> builder)
	{
		builder.ToTable("Pdfs", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.Pdfs)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
