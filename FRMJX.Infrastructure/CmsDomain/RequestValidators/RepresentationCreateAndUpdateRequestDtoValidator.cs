namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RepresentationCreateAndUpdateRequestDtoValidator : AbstractValidator<RepresentationCreateAndUpdateRequestDto>
{
	public RepresentationCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.StateId)
			.NotNull();

		RuleFor(entity => entity.CityId)
			.NotNull();
	}
}
