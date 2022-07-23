namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HealthCenterPdfConfiguration : IEntityTypeConfiguration<HealthCenterPdf>
{
	public void Configure(EntityTypeBuilder<HealthCenterPdf> builder)
	{
		builder.ToTable("HealthCenterPdfs", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.State)
			.WithMany(other => other.HealthCenterPdfs)
			.HasForeignKey(entity => entity.StateId);

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.HealthCenterPdfs)
			.HasForeignKey(entity => entity.CustomFileId);

	}
}
