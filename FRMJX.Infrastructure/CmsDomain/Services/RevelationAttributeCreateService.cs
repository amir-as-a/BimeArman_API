namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RevelationAttributeCreateService : IRevelationAttributeCreateService
{
	private readonly DatabaseContext databaseContext;

	public RevelationAttributeCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RevelationAttributeCreateAndUpdateRequestDto revelationAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var revelationAttribute = new RevelationAttribute
		{
			CultureLcid = revelationAttributeCreateAndUpdateDto.CultureLcid,
			IsActive = revelationAttributeCreateAndUpdateDto.IsActive,
			Ordering = revelationAttributeCreateAndUpdateDto.Ordering,
			Title = revelationAttributeCreateAndUpdateDto.Title,
			RevelationId = revelationAttributeCreateAndUpdateDto.RevelationId,
			CustomFileId = revelationAttributeCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.RevelationAttributes.Add(revelationAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = revelationAttribute.Id;

		return serviceResult;
	}
}
