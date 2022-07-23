namespace FRMJX.Core.BaseDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IStateUpdateService
{
	Task<ServiceResult> Update(long id, StateCreateAndUpdateRequestDto stateCreateAndUpdateDto, CancellationToken cancellationToken);
}
