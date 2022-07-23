namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class SliderItemCreateService : ISliderItemCreateService
{
	private readonly DatabaseContext databaseContext;

	public SliderItemCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		SliderItemCreateAndUpdateRequestDto sliderItemCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var sliderItem = new SliderItem
		{
			CultureLcid = sliderItemCreateAndUpdateDto.CultureLcid,
			IsActive = sliderItemCreateAndUpdateDto.IsActive,
			Ordering = sliderItemCreateAndUpdateDto.Ordering,
			Title = sliderItemCreateAndUpdateDto.Title,
			Description = sliderItemCreateAndUpdateDto.Description,
			CustomFileId = sliderItemCreateAndUpdateDto.CustomFileId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.SliderItems.Add(sliderItem);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = sliderItem.Id;

		return serviceResult;
	}
}
