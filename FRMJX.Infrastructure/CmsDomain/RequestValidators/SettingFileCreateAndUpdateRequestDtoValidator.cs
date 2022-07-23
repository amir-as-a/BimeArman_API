namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class SettingFileCreateAndUpdateRequestDtoValidator : AbstractValidator<SettingFileCreateAndUpdateRequestDto>
{
	public SettingFileCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull();
	}
}
