namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SliderItemConfiguration : IEntityTypeConfiguration<SliderItem>
{
	public void Configure(EntityTypeBuilder<SliderItem> builder)
	{
		builder.ToTable("SliderItems", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.SliderItems)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
