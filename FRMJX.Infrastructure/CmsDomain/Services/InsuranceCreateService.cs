namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class InsuranceCreateService : IInsuranceCreateService
{
	private readonly DatabaseContext databaseContext;

	public InsuranceCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		InsuranceCreateAndUpdateRequestDto insuranceCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var insurance = new Insurance
		{
			CultureLcid = insuranceCreateAndUpdateDto.CultureLcid,
			IsActive = insuranceCreateAndUpdateDto.IsActive,
			Ordering = insuranceCreateAndUpdateDto.Ordering,
			Title = insuranceCreateAndUpdateDto.Title,
			Description = insuranceCreateAndUpdateDto.Description,
			ImageId = insuranceCreateAndUpdateDto.ImageId,
			IconId = insuranceCreateAndUpdateDto.IconId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Insurances.Add(insurance);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = insurance.Id;

		return serviceResult;
	}
}
