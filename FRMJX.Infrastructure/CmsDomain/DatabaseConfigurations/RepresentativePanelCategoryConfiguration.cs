namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RepresentativePanelCategoryConfiguration : IEntityTypeConfiguration<RepresentativePanelCategory>
{
	public void Configure(EntityTypeBuilder<RepresentativePanelCategory> builder)
	{
		builder.ToTable("RepresentativePanelCategories", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
