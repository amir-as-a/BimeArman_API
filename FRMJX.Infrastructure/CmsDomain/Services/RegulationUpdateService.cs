namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RegulationUpdateService : IRegulationUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RegulationUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RegulationCreateAndUpdateRequestDto regulationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var regulation = await databaseContext.Regulations
			.SingleOrDefaultAsync(current => current.Id == id);

		if (regulation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Regulation not found");
			return serviceResult;
		}

		regulation.Title = regulationCreateAndUpdateDto.Title;
		regulation.CustomFileId = regulationCreateAndUpdateDto.CustomFileId;
		regulation.Ordering = regulationCreateAndUpdateDto.Ordering;
		regulation.IsActive = regulationCreateAndUpdateDto.IsActive;
		regulation.UpdateDateTime = DateTime.Now;

		databaseContext.Update(regulation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
