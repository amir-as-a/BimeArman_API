namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RepresentationUpdateService : IRepresentationUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RepresentationUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RepresentationCreateAndUpdateRequestDto representationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var representation = await databaseContext.Representations
			.SingleOrDefaultAsync(current => current.Id == id);

		if (representation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Representation not found");
			return serviceResult;
		}

		representation.CityId = representationCreateAndUpdateDto.CityId;
		representation.StateId = representationCreateAndUpdateDto.StateId;
		representation.ExactAddress = representationCreateAndUpdateDto.ExactAddress;
		representation.BranchManager = representationCreateAndUpdateDto.BranchManager;
		representation.BranchName = representationCreateAndUpdateDto.BranchName;
		representation.PhoneNumber = representationCreateAndUpdateDto.PhoneNumber;
		representation.PostalCode = representationCreateAndUpdateDto.PostalCode;
		representation.Ordering = representationCreateAndUpdateDto.Ordering;
		representation.IsActive = representationCreateAndUpdateDto.IsActive;
		representation.UpdateDateTime = DateTime.Now;

		databaseContext.Update(representation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
