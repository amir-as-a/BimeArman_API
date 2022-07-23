namespace FRMJX.Infrastructure.CmsDomain.DatabaseConfiguretions;

using FRMJX.Core.CmsDomain.Models;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employees", ModelSettings.CmsDomainName);

		builder.Property(entity => entity.UserName)
			.IsRequired(false);

		builder.Property(entity => entity.Password)
			.IsRequired(false);

		builder.Property(entity => entity.FirstName)
			.IsRequired();

		builder.Property(entity => entity.LastName)
			.IsRequired();

		builder.HasOne(entity => entity.CustomFile)
			.WithMany(other => other.Employees)
			.HasForeignKey(entity => entity.CustomFileId);

		builder.HasOne(entity => entity.JobPosition)
			.WithMany(other => other.Employees)
			.HasForeignKey(entity => entity.JobPositionId)
			.IsRequired(false);
	}
}
