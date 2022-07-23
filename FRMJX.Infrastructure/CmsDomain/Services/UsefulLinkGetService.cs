namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class UsefulLinkGetService : IUsefulLinkGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public UsefulLinkGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<UsefulLinkGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<UsefulLinkGetResponseDto>();

		var usefulLink = await databaseContext.UsefulLinks
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (usefulLink != null)
		{
			serviceResult.Result = new UsefulLinkGetResponseDto
			{
				Id = usefulLink.Id,
				Ordering = usefulLink.Ordering,
				IsActive = usefulLink.IsActive,
				Title = usefulLink.Title,
				IsPersonnel = usefulLink.IsPersonnel,
				IsRepresention = usefulLink.IsRepresention,
				FileId = usefulLink.FileId,
				IconId = usefulLink.IconId,
				Url = usefulLink.Url,
				IconInfo = customFileGetService.GetById(usefulLink.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<UsefulLinkGetResponseDto>>();

		var usefulLinks = await databaseContext.UsefulLinks
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsPersonnel == false && current.IsRepresention == false)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = usefulLinks
			.Select(current => new UsefulLinkGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				IconId = current.IconId,
				FileId = current.FileId,
				IsRepresention = current.IsRepresention,
				IsPersonnel = current.IsPersonnel,
				Url = current.Url,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetPersonnelLink(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<UsefulLinkGetResponseDto>>();

		var usefulLinks = await databaseContext.UsefulLinks
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsPersonnel == true && current.IsRepresention == false)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = usefulLinks
			.Select(current => new UsefulLinkGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				IconId = current.IconId,
				FileId = current.FileId,
				IsRepresention = current.IsRepresention,
				IsPersonnel = current.IsPersonnel,
				Url = current.Url,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetRepresentationLink(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<UsefulLinkGetResponseDto>>();

		var usefulLinks = await databaseContext.UsefulLinks
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsRepresention == true && current.IsPersonnel == false)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = usefulLinks
			.Select(current => new UsefulLinkGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				IconId = current.IconId,
				FileId = current.FileId,
				IsRepresention = current.IsRepresention,
				IsPersonnel = current.IsPersonnel,
				Url = current.Url,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<UsefulLinkGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<UsefulLinkGetResponseDto>>();

		var usefulLinks = await databaseContext.UsefulLinks
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = usefulLinks
			.Select(current => new UsefulLinkGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				IconId = current.IconId,
				FileId = current.FileId,
				IsRepresention = current.IsRepresention,
				IsPersonnel = current.IsPersonnel,
				Url = current.Url,
				IconInfo = customFileGetService.GetById(current.IconId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
