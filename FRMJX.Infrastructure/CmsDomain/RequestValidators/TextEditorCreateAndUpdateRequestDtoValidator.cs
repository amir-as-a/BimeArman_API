namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class TextEditorCreateAndUpdateRequestDtoValidator : AbstractValidator<TextEditorCreateAndUpdateRequestDto>
{
	public TextEditorCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.PageTitle)
			.NotNull();

		RuleFor(entity => entity.HtmlDocument)
			.NotNull();
	}
}
