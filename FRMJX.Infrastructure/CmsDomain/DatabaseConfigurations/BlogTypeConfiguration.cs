namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogTypeConfiguration : IEntityTypeConfiguration<BlogType>
{
	public void Configure(EntityTypeBuilder<BlogType> builder)
	{
		builder.ToTable("BlogTypes", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired()
			.HasMaxLength(ModelSettings.NameMaxLength);
	}
}
