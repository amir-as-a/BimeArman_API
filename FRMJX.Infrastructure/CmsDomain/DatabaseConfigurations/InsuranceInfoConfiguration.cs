namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InsuranceInfoConfiguration : IEntityTypeConfiguration<InsuranceInfo>
{
	public void Configure(EntityTypeBuilder<InsuranceInfo> builder)
	{
		builder.ToTable("InsuranceInfos", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();

		builder.HasOne(entity => entity.Insurance)
			.WithMany(other => other.InsuranceInfos)
			.HasForeignKey(entity => entity.InsuranceId);
	}
}
