namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class HealthCenterPdfCreateAndUpdateRequestDtoValidator : AbstractValidator<HealthCenterPdfCreateAndUpdateRequestDto>
{
	public HealthCenterPdfCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.StateId)
			.NotNull();
	}
}
