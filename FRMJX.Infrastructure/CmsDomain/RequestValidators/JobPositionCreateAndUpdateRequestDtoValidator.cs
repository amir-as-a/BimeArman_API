namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class JobPositionCreateAndUpdateRequestDtoValidator : AbstractValidator<JobPositionCreateAndUpdateRequestDto>
{
	public JobPositionCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
