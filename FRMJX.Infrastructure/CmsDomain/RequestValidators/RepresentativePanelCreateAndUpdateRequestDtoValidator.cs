namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RepresentativePanelCreateAndUpdateRequestDtoValidator : AbstractValidator<RepresentativePanelCreateAndUpdateRequestDto>
{
	public RepresentativePanelCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.Description)
			.NotNull();
	}
}
