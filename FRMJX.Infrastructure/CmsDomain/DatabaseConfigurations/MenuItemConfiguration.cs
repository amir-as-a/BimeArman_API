namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
	public void Configure(EntityTypeBuilder<MenuItem> builder)
	{
		builder.ToTable("MenuItems", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.Property(entity => entity.Url)
			.IsRequired();

		builder.HasMany(entity => entity.Childeren)
			.WithOne(other => other.Parent)
			.HasForeignKey(entity => entity.ParentId)
			.IsRequired(false);
	}
}
