namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

internal class BlogCategoryCreateAndUpdateRequestDtoValidator : AbstractValidator<BlogCategoryCreateAndUpdateRequestDto>
{
	public BlogCategoryCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull();
	}
}
