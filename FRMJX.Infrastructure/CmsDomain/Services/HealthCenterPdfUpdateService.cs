namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class HealthCenterPdfUpdateService : IHealthCenterPdfUpdateService
{
	private readonly DatabaseContext databaseContext;

	public HealthCenterPdfUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		HealthCenterPdfCreateAndUpdateRequestDto healthCenterPdfCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var healthCenterPdf = await databaseContext.HealthCenterPdfs
			.SingleOrDefaultAsync(current => current.Id == id);

		if (healthCenterPdf is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "HealthCenterPdf not found");
			return serviceResult;
		}

		healthCenterPdf.Title = healthCenterPdfCreateAndUpdateDto.Title;
		healthCenterPdf.CustomFileId = healthCenterPdfCreateAndUpdateDto.CustomFileId;
		healthCenterPdf.StateId = healthCenterPdfCreateAndUpdateDto.StateId;
		healthCenterPdf.Ordering = healthCenterPdfCreateAndUpdateDto.Ordering;
		healthCenterPdf.IsActive = healthCenterPdfCreateAndUpdateDto.IsActive;
		healthCenterPdf.UpdateDateTime = DateTime.Now;

		databaseContext.Update(healthCenterPdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
