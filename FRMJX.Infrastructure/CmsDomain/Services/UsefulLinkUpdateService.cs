namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class UsefulLinkUpdateService : IUsefulLinkUpdateService
{
	private readonly DatabaseContext databaseContext;

	public UsefulLinkUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		UsefulLinkCreateAndUpdateRequestDto usefulLinkCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var usefulLink = await databaseContext.UsefulLinks
			.SingleOrDefaultAsync(current => current.Id == id);

		if (usefulLink is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "UsefulLink not found");
			return serviceResult;
		}

		usefulLink.Title = usefulLinkCreateAndUpdateDto.Title;
		usefulLink.FileId = usefulLinkCreateAndUpdateDto.FileId;
		usefulLink.IconId = usefulLinkCreateAndUpdateDto.IconId;
		usefulLink.Ordering = usefulLinkCreateAndUpdateDto.Ordering;
		usefulLink.IsActive = usefulLinkCreateAndUpdateDto.IsActive;
		usefulLink.IsRepresention = usefulLinkCreateAndUpdateDto.IsRepresention;
		usefulLink.IsPersonnel = usefulLinkCreateAndUpdateDto.IsPersonnel;
		usefulLink.Url = usefulLinkCreateAndUpdateDto.Url;
		usefulLink.UpdateDateTime = DateTime.Now;

		databaseContext.Update(usefulLink);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
