namespace FRMJX.Core.Infrastructure.Framework.Extentions;

using System;
using System.ComponentModel;
using System.Linq;

public static class EnumExtensions
{
	public static TAttribute GetAttribute<TAttribute>(this Enum value)
		where TAttribute : Attribute
	{
		var type = value.GetType();
		var name = Enum.GetName(type, value);

		return type.GetField(name)
			.GetCustomAttributes(false)
			.OfType<TAttribute>()
			.SingleOrDefault();
	}

	public static TAttribute GetAttributeFromEnumType<TAttribute>(this Enum value)
	{
		var type = value.GetType();

		return type
			.GetCustomAttributes(false)
			.OfType<TAttribute>()
			.SingleOrDefault();
	}

	public static string GetDescription(this Enum value) =>
		value.GetAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
}
