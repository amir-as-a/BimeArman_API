namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;

using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;

[Type(ClaimTypeEnum.Security)]
internal enum SecurityClaimEnum : int
{
	BaseDataModule = 1000,

	[Dependencies(BaseDataModule)]
	BaseDataManage = 1001,

	SecurityModule = 1100,

	[Dependencies(SecurityModule)]
	RoleManage = 1101,

	CmsModule = 1200,

	[Dependencies(CmsModule)]
	CmsManage = 1201,
}
