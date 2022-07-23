namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RepresentativePanelConfiguration : IEntityTypeConfiguration<RepresentativePanel>
{
	public void Configure(EntityTypeBuilder<RepresentativePanel> builder)
	{
		builder.ToTable("RepresentativePanels", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.RepresentativePanels)
			.HasForeignKey(entity => entity.CustomFileId);

		builder.HasOne(entity => entity.RepresentativePanelCategory)
			.WithMany(other => other.RepresentativePanels)
			.HasForeignKey(entity => entity.PanelCategoryId);
	}
}
