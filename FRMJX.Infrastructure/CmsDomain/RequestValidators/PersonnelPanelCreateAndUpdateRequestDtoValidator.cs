namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class PersonnelPanelCreateAndUpdateRequestDtoValidator : AbstractValidator<PersonnelPanelCreateAndUpdateRequestDto>
{
	public PersonnelPanelCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.Description)
			.NotNull();
	}
}
