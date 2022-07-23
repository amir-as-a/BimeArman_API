namespace FRMJX.Infrastructure.SecurityDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.SecurityDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

public class RoleCreateAndUpdateRequestDtoValidator : AbstractValidator<RoleCreateAndUpdateRequestDto>
{
	public RoleCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull()
			.NotEmpty()
			.MaximumLength(ModelSettings.NameMaxLength);

		RuleFor(entity => entity.Description)
			.MaximumLength(ModelSettings.DescriptionMaxLength);
	}
}
