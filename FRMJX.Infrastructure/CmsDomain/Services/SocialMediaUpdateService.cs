namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SocialMediaUpdateService : ISocialMediaUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SocialMediaUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SocialMediaCreateAndUpdateRequestDto socialMediaCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var socialMedia = await databaseContext.SocialMedia
			.SingleOrDefaultAsync(current => current.Id == id);

		if (socialMedia is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "SocialMedia not found");
			return serviceResult;
		}

		socialMedia.Title = socialMediaCreateAndUpdateDto.Title;
		socialMedia.Url = socialMediaCreateAndUpdateDto.Url;
		socialMedia.CustomFileId = socialMediaCreateAndUpdateDto.CustomFileId;
		socialMedia.Ordering = socialMediaCreateAndUpdateDto.Ordering;
		socialMedia.IsActive = socialMediaCreateAndUpdateDto.IsActive;
		socialMedia.UpdateDateTime = DateTime.Now;

		databaseContext.Update(socialMedia);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
