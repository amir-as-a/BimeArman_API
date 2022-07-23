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

internal class ContactUsGetService : IContactUsGetService
{
	private readonly DatabaseContext databaseContext;

	public ContactUsGetService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<ContactUsGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<ContactUsGetResponseDto>();

		var contactUs = await databaseContext.ContactUs
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (contactUs != null)
		{
			serviceResult.Result = new ContactUsGetResponseDto
			{
				Id = contactUs.Id,
				Ordering = contactUs.Ordering,
				IsActive = contactUs.IsActive,
				FullName = contactUs.FullName,
				MobileNumber = contactUs.MobileNumber,
				Text = contactUs.Text,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<ContactUsGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<ContactUsGetResponseDto>>();

		var contactUss = await databaseContext.ContactUs
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = contactUss
			.Select(current => new ContactUsGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FullName = current.FullName,
				MobileNumber = current.MobileNumber,
				Text = current.Text,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<ContactUsGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<ContactUsGetResponseDto>>();

		var contactUss = await databaseContext.ContactUs
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = contactUss
			.Select(current => new ContactUsGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				FullName = current.FullName,
				MobileNumber = current.MobileNumber,
				Text = current.Text,
			})
			.ToList();

		return serviceResult;
	}
}
