namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class JobPositionCreateService : IJobPositionCreateService
{
	private readonly DatabaseContext databaseContext;

	public JobPositionCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		JobPositionCreateAndUpdateRequestDto jobPositionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var jobPosition = new JobPosition
		{
			CultureLcid = jobPositionCreateAndUpdateDto.CultureLcid,
			IsActive = jobPositionCreateAndUpdateDto.IsActive,
			Ordering = jobPositionCreateAndUpdateDto.Ordering,
			Title = jobPositionCreateAndUpdateDto.Title,
			Category = jobPositionCreateAndUpdateDto.Category,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.JobPositions.Add(jobPosition);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = jobPosition.Id;

		return serviceResult;
	}
}
