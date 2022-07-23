namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IAboutUsCreateService
{
	Task<ServiceResult<int>> Create(AboutUsCreateAndUpdateRequestDto aboutUsCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
