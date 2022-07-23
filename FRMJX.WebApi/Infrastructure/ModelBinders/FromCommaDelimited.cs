namespace FRMJX.WebApi.Infrastructure.ModelBinders;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

internal class FromCommaDelimited : ModelBinderAttribute, IModelBinder
{
	public FromCommaDelimited()
		: base(typeof(FromCommaDelimited))
	{
	}

	public Task BindModelAsync(ModelBindingContext bindingContext)
	{
		if (bindingContext == null)
		{
			throw new ArgumentNullException(nameof(bindingContext));
		}

		var modelName = bindingContext.ModelName;

		// Try to fetch the value of the argument by name
		var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

		if (valueProviderResult == ValueProviderResult.None)
		{
			return Task.CompletedTask;
		}

		bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

		var value = valueProviderResult.FirstValue;

		// Check if the argument value is null or empty
		if (string.IsNullOrEmpty(value))
		{
			return Task.CompletedTask;
		}

		var elementType = bindingContext.ModelType.GetElementType();

		if (elementType is not null)
		{
			var converter = TypeDescriptor.GetConverter(elementType);

			var values = Array.ConvertAll(
				value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries),
				current => converter.ConvertFromString(current.Trim()));

			var typedValues = Array.CreateInstance(elementType, values.Length);

			values.CopyTo(typedValues, 0);

			bindingContext.Result = ModelBindingResult.Success(typedValues);
		}

		return Task.CompletedTask;
	}
}
