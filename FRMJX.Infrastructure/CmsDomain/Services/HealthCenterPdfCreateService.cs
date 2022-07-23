namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class HealthCenterPdfCreateService : IHealthCenterPdfCreateService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterPdfCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		HealthCenterPdfCreateAndUpdateRequestDto healthCenterPdfCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var healthCenterPdf = new HealthCenterPdf
		{
			CultureLcid = healthCenterPdfCreateAndUpdateDto.CultureLcid,
			IsActive = healthCenterPdfCreateAndUpdateDto.IsActive,
			Ordering = healthCenterPdfCreateAndUpdateDto.Ordering,
			Title = healthCenterPdfCreateAndUpdateDto.Title,
			StateId = healthCenterPdfCreateAndUpdateDto.StateId,
			CustomFileId = healthCenterPdfCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.HealthCenterPdfs.Add(healthCenterPdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = healthCenterPdf.Id;

		return serviceResult;
	}
}
