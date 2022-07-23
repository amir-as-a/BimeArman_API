namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class CityUpdateService : ICityUpdateService
{
	private readonly DatabaseContext databaseContext;

	public CityUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		long id,
		CityCreateAndUpdateRequestDto cityCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var city = await databaseContext.City
			.SingleOrDefaultAsync(x => x.Id == id);

		if (city is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "City not found");
			return serviceResult;
		}

		city.Name = cityCreateAndUpdateDto.Name;
		city.Description = cityCreateAndUpdateDto.Description;
		city.StateId = cityCreateAndUpdateDto.StateId;

		databaseContext.Update(city);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
