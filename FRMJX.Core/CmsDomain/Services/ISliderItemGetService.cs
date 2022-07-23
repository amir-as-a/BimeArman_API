namespace FRMJX.Core.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface ISliderItemGetService
{
	Task<ServiceResult<SliderItemGetResponseDto>> GetById(int id, CancellationToken cancellationToken);

	Task<ServiceResult<List<SliderItemGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<SliderItemGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken);

	Task<ServiceResult<List<SliderItemGetResponseDto>>> GetAboutUsSlider(int cultureLcid, CancellationToken cancellationToken);
}
