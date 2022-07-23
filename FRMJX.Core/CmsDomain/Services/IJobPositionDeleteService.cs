﻿namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

public interface IJobPositionDeleteService
{
	Task<ServiceResult> Delete(int id, CancellationToken cancellationToken);
}
