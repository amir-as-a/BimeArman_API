namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RevelationAttributeCreateAndUpdateRequestDtoValidator : AbstractValidator<RevelationAttributeCreateAndUpdateRequestDto>
{
	public RevelationAttributeCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
