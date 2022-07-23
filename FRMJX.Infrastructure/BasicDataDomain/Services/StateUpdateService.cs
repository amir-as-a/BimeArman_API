namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class StateUpdateService : IStateUpdateService
{
	private readonly DatabaseContext databaseContext;

	public StateUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		long id,
		StateCreateAndUpdateRequestDto stateCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var state = await databaseContext.States
			.SingleOrDefaultAsync(x => x.Id == id);

		if (state is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "State not found");
			return serviceResult;
		}

		state.Name = stateCreateAndUpdateDto.Name;
		state.Description = stateCreateAndUpdateDto.Description;

		databaseContext.Update(state);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
