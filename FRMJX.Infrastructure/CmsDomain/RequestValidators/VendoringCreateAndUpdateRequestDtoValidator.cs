namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class VendoringCreateAndUpdateRequestDtoValidator : AbstractValidator<VendoringCreateAndUpdateRequestDto>
{
	public VendoringCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.StateId)
			.NotNull();

		RuleFor(entity => entity.CityId)
			.NotNull();
	}
}
