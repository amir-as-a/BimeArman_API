namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class AddressCreateAndUpdateRequestDtoValidator : AbstractValidator<AddressCreateAndUpdateRequestDto>
{
	public AddressCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.StateId)
			.NotNull();

		RuleFor(entity => entity.CityId)
			.NotNull();
	}
}
