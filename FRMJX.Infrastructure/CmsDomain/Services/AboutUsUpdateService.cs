namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AboutUsUpdateService : IAboutUsUpdateService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		AboutUsCreateAndUpdateRequestDto aboutUsCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var aboutUs = await databaseContext.AboutUses
			.SingleOrDefaultAsync(current => current.Id == id);

		if (aboutUs is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "AboutUs not found");
			return serviceResult;
		}

		aboutUs.Title = aboutUsCreateAndUpdateDto.Title;
		aboutUs.Description = aboutUsCreateAndUpdateDto.Description;
		aboutUs.CustomFileId = aboutUsCreateAndUpdateDto.CustomFileId;
		aboutUs.Ordering = aboutUsCreateAndUpdateDto.Ordering;
		aboutUs.IsActive = aboutUsCreateAndUpdateDto.IsActive;
		aboutUs.UpdateDateTime = DateTime.Now;

		databaseContext.Update(aboutUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
