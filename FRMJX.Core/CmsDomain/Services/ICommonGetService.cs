namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ICommonGetService
{
	Task<ServiceResult<SearchResponseDto>> Search(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken, string? title = null);
}
