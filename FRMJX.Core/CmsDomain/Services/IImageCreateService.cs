﻿namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public interface IImageCreateService
{
	Task<ServiceResult<int>> Create(ImageCreateAndUpdateRequestDto imageCreateAndUpdateRequestDto, CancellationToken cancellationToken);
}
