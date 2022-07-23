namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class PdfCreateAndUpdateRequestDtoValidator : AbstractValidator<PdfCreateAndUpdateRequestDto>
{
	public PdfCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
