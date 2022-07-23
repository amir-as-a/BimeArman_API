namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class DamageCenterCreateAndUpdateRequestDtoValidator : AbstractValidator<DamageCenterCreateAndUpdateRequestDto>
{
	public DamageCenterCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.StateId)
			.NotNull();

		RuleFor(entity => entity.BranchManager)
			.NotNull();

		RuleFor(entity => entity.ExactAddress)
			.NotNull();

	}
}
