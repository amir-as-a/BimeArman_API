namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RevelationConfiguration : IEntityTypeConfiguration<Revelation>
{
	public void Configure(EntityTypeBuilder<Revelation> builder)
	{
		builder.ToTable("Revelations", ModelSettings.CmsDomainName);

		builder.Property(x => x.Title)
			.IsRequired();

		builder.HasOne(x => x.CustomFile)
			.WithMany(x => x.Revelations)
			.HasForeignKey(x => x.CustomeFileId);
	}
}
