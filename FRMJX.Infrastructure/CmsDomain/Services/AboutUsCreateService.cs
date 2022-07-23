namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class AboutUsCreateService : IAboutUsCreateService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		AboutUsCreateAndUpdateRequestDto aboutUsCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var aboutUs = new AboutUs
		{
			CultureLcid = aboutUsCreateAndUpdateDto.CultureLcid,
			IsActive = aboutUsCreateAndUpdateDto.IsActive,
			Ordering = aboutUsCreateAndUpdateDto.Ordering,
			Title = aboutUsCreateAndUpdateDto.Title,
			Description = aboutUsCreateAndUpdateDto.Description,
			CustomFileId = aboutUsCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.AboutUses.Add(aboutUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = aboutUs.Id;

		return serviceResult;
	}
}
