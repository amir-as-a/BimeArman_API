namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class PersonnelPanelCategoryCreateAndUpdateRequestDtoValidator : AbstractValidator<PersonnelPanelCategoryCreateAndUpdateRequestDto>
{
	public PersonnelPanelCategoryCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
