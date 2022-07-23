namespace FRMJX.WebApi.Controllers.V1.CmsDomain;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.WebApi.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// SliderItem controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/cms/sliderItem")]
[ApiExplorerSettings(GroupName = "Cms - SliderItems")]
public class SliderItemsController : BaseController
{
	/// <summary>
	/// Get sliderItem by id
	/// </summary>
	/// <param name="getService">SliderItem get service</param>
	/// <param name="id">SliderItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded sliderItem</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("{id}")]
	[AllowAnonymous]
	public async Task<IActionResult> GetById(
		[FromServices] ISliderItemGetService getService,
		int id,
		CancellationToken cancellationToken) => await getService.GetById(id, cancellationToken);

	/// <summary>
	/// Get all sliderItems
	/// </summary>
	/// <param name="getService">SliderItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded sliderItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> List(
		[FromServices] ISliderItemGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetAll(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get active sliderItems
	/// </summary>
	/// <param name="getService">SliderItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="pageIndex">page index</param>
	/// <param name="pageSize">page size</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active sliderItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("active")]
	[AllowAnonymous]
	public async Task<IActionResult> GetActives(
		[FromServices] ISliderItemGetService getService,
		[FromHeader] int cultureLcid,
		[FromQuery] int pageIndex,
		[FromQuery] int pageSize,
		CancellationToken cancellationToken) => await getService.GetActives(cultureLcid, pageIndex, pageSize, cancellationToken);

	/// <summary>
	/// Get AboutUs sliderItems
	/// </summary>
	/// <param name="getService">SliderItem get service</param>
	/// <param name="cultureLcid">culture lcid</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Active sliderItems</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpGet("AbotUsSlider")]
	[AllowAnonymous]
	public async Task<IActionResult> GetAboutUsSliderItem(
		[FromServices] ISliderItemGetService getService,
		[FromHeader] int cultureLcid,
		CancellationToken cancellationToken) => await getService.GetAboutUsSlider(cultureLcid, cancellationToken);

	/// <summary>
	/// Create sliderItem
	/// </summary>
	/// <param name="createService">SliderItem create service</param>
	/// <param name="sliderItemCreateAndUpdateDto">SliderItem create and update dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Id of created sliderItem</returns>
	[ProducesResponseType((int)HttpStatusCode.Created)]
	[HttpPost]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Create(
		[FromServices] ISliderItemCreateService createService,
		SliderItemCreateAndUpdateRequestDto sliderItemCreateAndUpdateDto,
		CancellationToken cancellationToken) => await createService.Create(sliderItemCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Edit sliderItem
	/// </summary>
	/// <param name="updateService">SliderItem update service</param>
	/// <param name="sliderItemCreateAndUpdateDto">SliderItem create and update dto</param>
	/// <param name="id">SliderItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpPut("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Update(
		[FromServices] ISliderItemUpdateService updateService,
		SliderItemCreateAndUpdateRequestDto sliderItemCreateAndUpdateDto,
		int id,
		CancellationToken cancellationToken) => await updateService.Update(id, sliderItemCreateAndUpdateDto, cancellationToken);

	/// <summary>
	/// Delete sliderItem
	/// </summary>
	/// <param name="deleteService">SliderItem edit service</param>
	/// <param name="id">SliderItem id</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Nothing</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[ProducesResponseType((int)HttpStatusCode.NotFound)]
	[HttpDelete("{id}")]
	[ApiSecurity(SecurityClaimEnum.CmsManage)]
	public async Task<IActionResult> Delete(
		[FromServices] ISliderItemDeleteService deleteService,
		int id,
		CancellationToken cancellationToken) => await deleteService.Delete(id, cancellationToken);
}
