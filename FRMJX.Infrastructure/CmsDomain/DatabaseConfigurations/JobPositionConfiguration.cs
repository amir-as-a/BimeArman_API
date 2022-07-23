namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
{
	public void Configure(EntityTypeBuilder<JobPosition> builder)
	{
		builder.ToTable("JobPositions", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.Title)
			.IsRequired();
	}
}
