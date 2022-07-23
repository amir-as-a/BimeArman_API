namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TextEditorConfiguration : IEntityTypeConfiguration<TextEditor>
{
	public void Configure(EntityTypeBuilder<TextEditor> builder)
	{
		builder.ToTable("TextEditors", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.PageTitle)
			.IsRequired();

		builder.Property(entity => entity.HtmlDocument)
			.IsRequired();
	}
}
