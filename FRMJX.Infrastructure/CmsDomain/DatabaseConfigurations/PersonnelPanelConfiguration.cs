namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonnelPanelConfiguration : IEntityTypeConfiguration<PersonnelPanel>
{
	public void Configure(EntityTypeBuilder<PersonnelPanel> builder)
	{
		builder.ToTable("PersonnelPanels", ModelSettings.CmsDomainName);

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.PersonnelPanels)
			.HasForeignKey(entity => entity.CustomFileId);

		builder.HasOne(entity => entity.PersonnelPanelCategory)
			.WithMany(other => other.PersonnelPanels)
			.HasForeignKey(entity => entity.PanelCategoryId);
	}
}
