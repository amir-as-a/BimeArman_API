namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class ContactUsCreateService : IContactUsCreateService
{
	private readonly DatabaseContext databaseContext;

	public ContactUsCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		ContactUsCreateAndUpdateRequestDto contactUsCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var contactUs = new ContactUs
		{
			CultureLcid = contactUsCreateAndUpdateDto.CultureLcid,
			IsActive = contactUsCreateAndUpdateDto.IsActive,
			Ordering = contactUsCreateAndUpdateDto.Ordering,
			FullName = contactUsCreateAndUpdateDto.FullName,
			MobileNumber = contactUsCreateAndUpdateDto.MobileNumber,
			Text = contactUsCreateAndUpdateDto.Text,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.ContactUs.Add(contactUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = contactUs.Id;

		return serviceResult;
	}
}
