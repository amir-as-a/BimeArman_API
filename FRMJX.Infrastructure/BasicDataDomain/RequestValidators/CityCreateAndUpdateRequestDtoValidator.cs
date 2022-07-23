namespace FRMJX.Infrastructure.BasicDataDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.BaseDataDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

internal class CityCreateAndUpdateRequestDtoValidator : AbstractValidator<CityCreateAndUpdateRequestDto>
{
	public CityCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull()
			.MaximumLength(ModelSettings.NameMaxLength);

		RuleFor(entity => entity.Description)
			.MaximumLength(ModelSettings.DescriptionMaxLength);
	}
}
