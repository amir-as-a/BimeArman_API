namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class HealthCenterCreateAndUpdateRequestDtoValidator : AbstractValidator<HealthCenterCreateAndUpdateRequestDto>
{
	public HealthCenterCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Center)
			.NotNull();

		RuleFor(entity => entity.CenterName)
			.NotNull();
	}
}
