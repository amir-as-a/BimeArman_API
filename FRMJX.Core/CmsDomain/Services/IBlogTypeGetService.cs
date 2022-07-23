namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogTypeGetService
{
	Task<ServiceResult<BlogTypeGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogTypeGetResponseDto>>> GetActives(int cultureLcid, CancellationToken cancellationToken);

	Task<ServiceResult<List<BlogTypeGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken);
}
