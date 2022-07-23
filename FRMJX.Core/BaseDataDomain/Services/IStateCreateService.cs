namespace FRMJX.Core.BaseDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IStateCreateService
{
	Task<ServiceResult<long>> Create(StateCreateAndUpdateRequestDto stateCreateAndUpdateDto, CancellationToken cancellationToken);
}
