namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RevelationCreateService : IRevelationCreateService
{
	private readonly DatabaseContext databaseContext;

	public RevelationCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RevelationCreateAndUpdateRequestDto revelationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var revelation = new Revelation
		{
			CultureLcid = revelationCreateAndUpdateDto.CultureLcid,
			IsActive = revelationCreateAndUpdateDto.IsActive,
			Ordering = revelationCreateAndUpdateDto.Ordering,
			CustomeFileId = revelationCreateAndUpdateDto.CustomeFileId,
			Title = revelationCreateAndUpdateDto.Title,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Revelations.Add(revelation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = revelation.Id;

		return serviceResult;
	}
}
