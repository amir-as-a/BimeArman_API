namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SettingFileConfiguration : IEntityTypeConfiguration<SettingFile>
{
	public void Configure(EntityTypeBuilder<SettingFile> builder)
	{
		builder.ToTable("SettingFiles", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Name)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.SettingFiles)
			.HasForeignKey(entity => entity.CustomFileId);
	}
}
