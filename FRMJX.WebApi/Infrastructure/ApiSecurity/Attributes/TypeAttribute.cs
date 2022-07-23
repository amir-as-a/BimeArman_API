namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes
{
	using FRMJX.Core.SecurityDomain.Enums;
	using System;

	[AttributeUsage(AttributeTargets.All)]
	internal class TypeAttribute : Attribute
	{
		internal TypeAttribute(ClaimTypeEnum type)
		{
			Type = type;
		}

		public ClaimTypeEnum Type { get; set; }
	}
}
