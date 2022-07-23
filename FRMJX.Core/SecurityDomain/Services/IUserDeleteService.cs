namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IUserDeleteService
{
	Task<ServiceResult> Delete(int id, CancellationToken cancellationToken);
}
