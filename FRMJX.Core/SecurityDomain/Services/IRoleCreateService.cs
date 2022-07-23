namespace FRMJX.Core.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IRoleCreateService
{
	Task<ServiceResult<long>> Create(long applicantUserId, Func<List<string>, (bool Result, List<(string Type, string Value)> Claims)> claimsValidator, RoleCreateAndUpdateRequestDto request, CancellationToken cancellationToken);
}
