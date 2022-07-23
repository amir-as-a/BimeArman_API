namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RegulationCreateService : IRegulationCreateService
{
	private readonly DatabaseContext databaseContext;

	public RegulationCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RegulationCreateAndUpdateRequestDto regulationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var regulation = new Regulation
		{
			CultureLcid = regulationCreateAndUpdateDto.CultureLcid,
			IsActive = regulationCreateAndUpdateDto.IsActive,
			Ordering = regulationCreateAndUpdateDto.Ordering,
			Title = regulationCreateAndUpdateDto.Title,
			CustomFileId = regulationCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Regulations.Add(regulation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = regulation.Id;

		return serviceResult;
	}
}
