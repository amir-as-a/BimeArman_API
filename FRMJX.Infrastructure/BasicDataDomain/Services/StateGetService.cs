namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class StateGetService : IStateGetService
{
	private readonly DatabaseContext databaseContext;

	public StateGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<StateGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<StateGetResponseDto>();

		var state = await databaseContext.States
			.Where(x => x.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (state != null)
		{
			serviceResult.Result = new StateGetResponseDto
			{
				Id = state.Id,
				Name = state.Name,
				Description = state.Description,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<StateGetResponseDto>>> GetActives(CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<StateGetResponseDto>>();

		var aboutUsAttributes = await databaseContext.States
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUsAttributes
			.Select(current => new StateGetResponseDto
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<StateGetResponseDto>>> GetAll(CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<StateGetResponseDto>>();

		var aboutUsAttributes = await databaseContext.States
			.ToListAsync(cancellationToken);

		serviceResult.Result = aboutUsAttributes
			.Select(current => new StateGetResponseDto
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
			})
			.ToList();

		return serviceResult;
	}
}
