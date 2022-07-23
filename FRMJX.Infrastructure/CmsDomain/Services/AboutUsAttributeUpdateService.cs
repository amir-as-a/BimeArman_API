namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class AboutUsAttributeUpdateService : IAboutUsAttributeUpdateService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsAttributeUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		AboutUsAttributeCreateAndUpdateRequestDto aboutUsAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var aboutUsAttribute = await databaseContext.AboutUsAttributes
			.SingleOrDefaultAsync(current => current.Id == id);

		if (aboutUsAttribute is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "AboutUsAttribute not found");
			return serviceResult;
		}

		aboutUsAttribute.Title = aboutUsAttributeCreateAndUpdateDto.Title;
		aboutUsAttribute.Description = aboutUsAttributeCreateAndUpdateDto.Description;
		aboutUsAttribute.Ordering = aboutUsAttributeCreateAndUpdateDto.Ordering;
		aboutUsAttribute.IsActive = aboutUsAttributeCreateAndUpdateDto.IsActive;
		aboutUsAttribute.UpdateDateTime = DateTime.Now;

		databaseContext.Update(aboutUsAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
