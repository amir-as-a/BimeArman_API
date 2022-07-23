namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using System.Threading.Tasks;

public interface IFaqCreateService
{
	Task<ServiceResult<int>> Create(FaqCreateAndUpdateRequestDto faqCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
