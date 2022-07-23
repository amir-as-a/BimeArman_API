namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IRoleDeleteService
{
	Task<ServiceResult> Delete(long id, long applicantUserId, CancellationToken cancellationToken);
}
