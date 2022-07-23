namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IVideoCreateService
{
	Task<ServiceResult<int>> Create(VideoCreateAndUpdateRequestDto videoCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
