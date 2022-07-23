namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class EmployeeCreateAndUpdateRequestDtoValidator : AbstractValidator<EmployeeCreateAndUpdateRequestDto>
{
	public EmployeeCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.FirstName)
			.NotNull();

		RuleFor(entity => entity.LastName)
			.NotNull();
	}
}
