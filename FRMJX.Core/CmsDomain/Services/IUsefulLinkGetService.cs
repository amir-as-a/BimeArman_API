namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IUsefulLinkGetService
{
	Task<ServiceResult<UsefulLinkGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetRepresentationLink(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetPersonnelLink(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
