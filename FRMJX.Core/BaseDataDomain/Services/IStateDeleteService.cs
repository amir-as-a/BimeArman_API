namespace FRMJX.Core.BaseDataDomain.Services;

using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IStateDeleteService
{
	Task<ServiceResult> Delete(long id, CancellationToken cancellationToken);
}
