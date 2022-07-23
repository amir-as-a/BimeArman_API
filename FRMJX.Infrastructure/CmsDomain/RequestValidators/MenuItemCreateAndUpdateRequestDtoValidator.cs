namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class MenuItemCreateAndUpdateRequestDtoValidator : AbstractValidator<MenuItemCreateAndUpdateRequestDto>
{
	public MenuItemCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.Url)
			.NotNull();
	}
}
