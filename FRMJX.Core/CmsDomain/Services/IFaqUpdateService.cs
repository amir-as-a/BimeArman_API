namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IFaqUpdateService
{
	Task<ServiceResult> Update(int id, FaqCreateAndUpdateRequestDto faqCreateAndUpdateDto, CancellationToken cancellationToken);
}
