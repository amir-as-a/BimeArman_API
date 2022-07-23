namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SuggustionUpdateService : ISuggustionUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SuggustionUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SuggustionCreateAndUpdateRequestDto suggustionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var suggustion = await databaseContext.Suggustions
			.SingleOrDefaultAsync(current => current.Id == id);

		if (suggustion is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Suggustion not found");
			return serviceResult;
		}

		suggustion.FullName = suggustionCreateAndUpdateDto.FullName;
		suggustion.MobileNumber = suggustionCreateAndUpdateDto.MobileNumber;
		suggustion.Text = suggustionCreateAndUpdateDto.Text;
		suggustion.Ordering = suggustionCreateAndUpdateDto.Ordering;
		suggustion.IsActive = suggustionCreateAndUpdateDto.IsActive;
		suggustion.UpdateDateTime = DateTime.Now;

		databaseContext.Update(suggustion);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
