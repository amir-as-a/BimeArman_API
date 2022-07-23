namespace FRMJX.Infrastructure.BasicDataDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

internal class StateCreateAndUpdateRequestDtoValidator : AbstractValidator<StateCreateAndUpdateRequestDto>
{
	public StateCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull()
			.MaximumLength(ModelSettings.NameMaxLength);

		RuleFor(entity => entity.Description)
			.MaximumLength(ModelSettings.DescriptionMaxLength);
	}
}
