namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IRepresentationCreateService
{
	Task<ServiceResult<int>> Create(RepresentationCreateAndUpdateRequestDto representationCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
