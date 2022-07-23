namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ITextEditorGetService
{
	Task<ServiceResult<TextEditorGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<TextEditorGetResponseDto>>> GetByPageTitle(string pageTitle, CancellationToken cancellationToken);

	Task<ServiceResult<List<TextEditorGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<TextEditorGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);
}
