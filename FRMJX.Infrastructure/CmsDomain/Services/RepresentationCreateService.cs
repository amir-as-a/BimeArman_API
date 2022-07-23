namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RepresentationCreateService : IRepresentationCreateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		RepresentationCreateAndUpdateRequestDto representationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var representation = new Representation
		{
			BranchName = representationCreateAndUpdateDto.BranchName,
			BranchManager = representationCreateAndUpdateDto.BranchManager,
			PhoneNumber = representationCreateAndUpdateDto.PhoneNumber,
			CultureLcid = representationCreateAndUpdateDto.CultureLcid,
			IsActive = representationCreateAndUpdateDto.IsActive,
			Ordering = representationCreateAndUpdateDto.Ordering,
			CityId = representationCreateAndUpdateDto.CityId,
			StateId = representationCreateAndUpdateDto.StateId,
			ExactAddress = representationCreateAndUpdateDto.ExactAddress,
			PostalCode = representationCreateAndUpdateDto.PostalCode,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Representations.Add(representation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = representation.Id;

		return serviceResult;
	}
}
