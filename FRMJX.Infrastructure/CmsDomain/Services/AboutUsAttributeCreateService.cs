namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class AboutUsAttributeCreateService : IAboutUsAttributeCreateService
{
	private readonly DatabaseContext databaseContext;

	public AboutUsAttributeCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		AboutUsAttributeCreateAndUpdateRequestDto aboutUsAttributeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var aboutUsAttribute = new AboutUsAttribute
		{
			CultureLcid = aboutUsAttributeCreateAndUpdateDto.CultureLcid,
			IsActive = aboutUsAttributeCreateAndUpdateDto.IsActive,
			Ordering = aboutUsAttributeCreateAndUpdateDto.Ordering,
			Title = aboutUsAttributeCreateAndUpdateDto.Title,
			Description = aboutUsAttributeCreateAndUpdateDto.Description,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.AboutUsAttributes.Add(aboutUsAttribute);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = aboutUsAttribute.Id;

		return serviceResult;
	}
}
