namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SuggustionCreateService : ISuggustionCreateService
{
	private readonly DatabaseContext databaseContext;

	public SuggustionCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SuggustionCreateAndUpdateRequestDto suggustionCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var suggustion = new Suggustion
		{
			CultureLcid = suggustionCreateAndUpdateDto.CultureLcid,
			IsActive = suggustionCreateAndUpdateDto.IsActive,
			Ordering = suggustionCreateAndUpdateDto.Ordering,
			FullName = suggustionCreateAndUpdateDto.FullName,
			MobileNumber = suggustionCreateAndUpdateDto.MobileNumber,
			Text = suggustionCreateAndUpdateDto.Text,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Suggustions.Add(suggustion);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = suggustion.Id;

		return serviceResult;
	}
}
