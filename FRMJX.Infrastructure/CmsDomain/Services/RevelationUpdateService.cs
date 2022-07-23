namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class RevelationUpdateService : IRevelationUpdateService
{
	private readonly DatabaseContext databaseContext;

	public RevelationUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		RevelationCreateAndUpdateRequestDto revelationCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var revelation = await databaseContext.Revelations
			.SingleOrDefaultAsync(current => current.Id == id);

		if (revelation is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Revelation not found");
			return serviceResult;
		}

		revelation.Title = revelationCreateAndUpdateDto.Title;
		revelation.CustomeFileId = revelationCreateAndUpdateDto.CustomeFileId;
		revelation.Ordering = revelationCreateAndUpdateDto.Ordering;
		revelation.IsActive = revelationCreateAndUpdateDto.IsActive;
		revelation.UpdateDateTime = DateTime.Now;

		databaseContext.Update(revelation);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
