namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RepresentationConditionCreateAndUpdateRequestDtoValidator : AbstractValidator<RepresentationConditionCreateAndUpdateRequestDto>
{
	public RepresentationConditionCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
