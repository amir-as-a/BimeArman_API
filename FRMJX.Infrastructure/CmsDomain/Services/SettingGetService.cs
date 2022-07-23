namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class SettingGetService : ISettingGetService
{
	private readonly DatabaseContext databaseContext;

	public SettingGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<SettingGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SettingGetResponseDto>();

		var setting = await databaseContext.Settings
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (setting != null)
		{
			serviceResult.Result = new SettingGetResponseDto
			{
				Id = setting.Id,
				Value = setting.Value,
				Name = setting.Name,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<SettingGetResponseDto>> GetByName(int cultureLcid, string name, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<SettingGetResponseDto>();

		var setting = await databaseContext.Settings
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.Name.ToLower() == name.ToLower())
			.SingleOrDefaultAsync(cancellationToken);

		if (setting != null)
		{
			serviceResult.Result = new SettingGetResponseDto
			{
				Id = setting.Id,
				Value = setting.Value,
				Name = setting.Name,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingGetResponseDto>>> GetByNames(int cultureLcid, string[] names, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingGetResponseDto>>();

		names = names.Select(d => d.ToLower()).ToArray();

		var settings = await databaseContext.Settings
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => names.Contains(current.Name.ToLower()))
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingGetResponseDto
			{
				Id = current.Id,
				Value = current.Value,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingGetResponseDto>>> Search(int cultureLcid, string q, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingGetResponseDto>>();

		var settings = await databaseContext.Settings
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.Name.ToLower().Contains(q.ToLower()))
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingGetResponseDto
			{
				Id = current.Id,
				Value = current.Value,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<SettingGetResponseDto>>> GetAll(int cultureLcid, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<SettingGetResponseDto>>();

		var settings = await databaseContext.Settings
			.Where(current => current.CultureLcid == cultureLcid)
			.ToListAsync(cancellationToken);

		serviceResult.Result = settings
			.Select(current => new SettingGetResponseDto
			{
				Id = current.Id,
				Value = current.Value,
				Name = current.Name,
			})
			.ToList();

		return serviceResult;
	}
}
