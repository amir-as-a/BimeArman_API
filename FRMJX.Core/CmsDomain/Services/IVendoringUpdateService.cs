namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

public interface IVendoringUpdateService
{
	Task<ServiceResult> Update(int id, VendoringCreateAndUpdateRequestDto vendoringCreateAndUpdateDto, CancellationToken cancellationToken);
}
