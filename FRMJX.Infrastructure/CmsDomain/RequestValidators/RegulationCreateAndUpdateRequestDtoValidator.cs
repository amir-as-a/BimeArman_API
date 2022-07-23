namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RegulationCreateAndUpdateRequestDtoValidator : AbstractValidator<RegulationCreateAndUpdateRequestDto>
{
	public RegulationCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
