namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class UsefulLinkCreateService : IUsefulLinkCreateService
{
	private readonly DatabaseContext databaseContext;

	public UsefulLinkCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		UsefulLinkCreateAndUpdateRequestDto usefulLinkCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var usefulLink = new UsefulLink
		{
			CultureLcid = usefulLinkCreateAndUpdateDto.CultureLcid,
			IsActive = usefulLinkCreateAndUpdateDto.IsActive,
			Ordering = usefulLinkCreateAndUpdateDto.Ordering,
			Title = usefulLinkCreateAndUpdateDto.Title,
			IconId = usefulLinkCreateAndUpdateDto.IconId,
			FileId = usefulLinkCreateAndUpdateDto.FileId,
			IsRepresention = usefulLinkCreateAndUpdateDto.IsRepresention,
			IsPersonnel = usefulLinkCreateAndUpdateDto.IsPersonnel,
			Url = usefulLinkCreateAndUpdateDto.Url,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.UsefulLinks.Add(usefulLink);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = usefulLink.Id;

		return serviceResult;
	}
}
