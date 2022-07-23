namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

public interface IBlogCommentUpdateService
{
	Task<ServiceResult> Update(int id, BlogCommentCreateAndUpdateRequestDto blogCommentCreateAndUpdateDto, CancellationToken cancellationToken);

	Task<ServiceResult> ApprovalComment(int id, bool isApproval, CancellationToken cancellationToken);
}
