namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RevelationAttributeUpdateService : IRevelationAttributeUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RevelationAttributeUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RevelationAttributeCreateAndUpdateRequestDto revelationAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var revelationAttribute = await databaseContext.RevelationAttributes
			.SingleOrDefaultAsync(current => current.Id == id);

		if (revelationAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "RevelationAttribute not found");
			return serviceResult;
		}

		revelationAttribute.Title = revelationAttributeCreateAndUpdateDto.Title;
		revelationAttribute.Ordering = revelationAttributeCreateAndUpdateDto.Ordering;
		revelationAttribute.IsActive = revelationAttributeCreateAndUpdateDto.IsActive;
		revelationAttribute.RevelationId = revelationAttributeCreateAndUpdateDto.RevelationId;
		revelationAttribute.CustomFileId = revelationAttributeCreateAndUpdateDto.CustomFileId;
		revelationAttribute.UpdateDateTime = DateTime.Now;

		databaseContext.Update(revelationAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
