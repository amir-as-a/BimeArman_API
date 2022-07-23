namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonnelPanelCategoryConfiguration : IEntityTypeConfiguration<PersonnelPanelCategory>
{
	public void Configure(EntityTypeBuilder<PersonnelPanelCategory> builder)
	{
		builder.ToTable("PersonnelPanelCategories", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
