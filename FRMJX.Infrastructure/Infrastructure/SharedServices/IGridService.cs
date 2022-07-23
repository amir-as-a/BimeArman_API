namespace FRMJX.Infrastructure.Infrastructure.SharedServices;

using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public interface IGridService<TModel, TDto>
{
	Task<(List<TModel> Records, int TotalCount)> ApplyGridFilterAsync(IQueryable<TModel> query, GridFilterDto gridFilterDto, CancellationToken cancellationToken);

	(List<TModel> Records, int TotalCount) ApplyGridFilter(IQueryable<TModel> query, GridFilterDto gridFilterDto);
}
