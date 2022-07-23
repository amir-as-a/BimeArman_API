namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
	public void Configure(EntityTypeBuilder<BlogCategory> builder)
	{
		builder.ToTable("BlogCategories", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired();
	}
}
