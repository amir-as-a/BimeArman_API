namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRoleUpdateService
{
	Task<ServiceResult> Update(long id, long applicantUserId, Func<List<string>, (bool Result, List<(string Type, string Value)> Claims)> claimValidator, RoleCreateAndUpdateRequestDto request, CancellationToken cancellationToken);
}
