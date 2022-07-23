namespace FRMJX.Infrastructure.BasicDataDomain.Services;

using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.BaseDataDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class CityCreateService : ICityCreateService
{
	private readonly DatabaseContext databaseContext;

	public CityCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<long>> Create(
		CityCreateAndUpdateRequestDto cityCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<long>();

		var city = new City
		{
			Name = cityCreateAndUpdateDto.Name,
			Description = cityCreateAndUpdateDto.Description,
			StateId = cityCreateAndUpdateDto.StateId,
		};

		databaseContext.City.Add(city);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = city.Id;

		return serviceResult;
	}
}
