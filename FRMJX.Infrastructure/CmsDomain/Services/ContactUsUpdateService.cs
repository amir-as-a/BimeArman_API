namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class ContactUsUpdateService : IContactUsUpdateService
{
	private readonly DatabaseContext databaseContext;

	public ContactUsUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		ContactUsCreateAndUpdateRequestDto contactUsCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var contactUs = await databaseContext.ContactUs
			.SingleOrDefaultAsync(current => current.Id == id);

		if (contactUs is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "ContactUs not found");
			return serviceResult;
		}

		contactUs.FullName = contactUsCreateAndUpdateDto.FullName;
		contactUs.MobileNumber = contactUsCreateAndUpdateDto.MobileNumber;
		contactUs.Text = contactUsCreateAndUpdateDto.Text;
		contactUs.Ordering = contactUsCreateAndUpdateDto.Ordering;
		contactUs.IsActive = contactUsCreateAndUpdateDto.IsActive;
		contactUs.UpdateDateTime = DateTime.Now;

		databaseContext.Update(contactUs);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
