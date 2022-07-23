namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IVideoGetService
{
	Task<ServiceResult<VideoGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<VideoGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<VideoGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
