namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SocialMediaCreateService : ISocialMediaCreateService
{
	private readonly DatabaseContext databaseContext;

	public SocialMediaCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SocialMediaCreateAndUpdateRequestDto socialMediaCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var socialMedia = new SocialMedia
		{
			CultureLcid = socialMediaCreateAndUpdateDto.CultureLcid,
			IsActive = socialMediaCreateAndUpdateDto.IsActive,
			Ordering = socialMediaCreateAndUpdateDto.Ordering,
			Title = socialMediaCreateAndUpdateDto.Title,
			Url = socialMediaCreateAndUpdateDto.Url,
			CustomFileId = socialMediaCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.SocialMedia.Add(socialMedia);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = socialMedia.Id;

		return serviceResult;
	}
}
