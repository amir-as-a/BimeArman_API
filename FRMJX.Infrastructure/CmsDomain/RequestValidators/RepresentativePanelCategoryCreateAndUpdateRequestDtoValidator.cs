namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RepresentativePanelCategoryCreateAndUpdateRequestDtoValidator : AbstractValidator<RepresentativePanelCategoryCreateAndUpdateRequestDto>
{
	public RepresentativePanelCategoryCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
