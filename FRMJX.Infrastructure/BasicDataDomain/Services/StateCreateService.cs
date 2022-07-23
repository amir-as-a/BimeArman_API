namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class StateCreateService : IStateCreateService
{
	private readonly DatabaseContext databaseContext;

	public StateCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<long>> Create(
		StateCreateAndUpdateRequestDto stateCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<long>();

		var state = new State
		{
			Name = stateCreateAndUpdateDto.Name,
			Description = stateCreateAndUpdateDto.Description,
		};

		databaseContext.States.Add(state);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = state.Id;

		return serviceResult;
	}
}
