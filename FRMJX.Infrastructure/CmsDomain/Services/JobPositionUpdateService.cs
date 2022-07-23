namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class JobPositionUpdateService : IJobPositionUpdateService
{
	private readonly DatabaseContext databaseContext;

	public JobPositionUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		JobPositionCreateAndUpdateRequestDto jobPositionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var jobPosition = await databaseContext.JobPositions
			.SingleOrDefaultAsync(current => current.Id == id);

		if (jobPosition is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "JobPosition not found");
			return serviceResult;
		}

		jobPosition.Title = jobPositionCreateAndUpdateDto.Title;
		jobPosition.Ordering = jobPositionCreateAndUpdateDto.Ordering;
		jobPosition.IsActive = jobPositionCreateAndUpdateDto.IsActive;
		jobPosition.Category = jobPositionCreateAndUpdateDto.Category;
		jobPosition.UpdateDateTime = DateTime.Now;

		databaseContext.Update(jobPosition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
