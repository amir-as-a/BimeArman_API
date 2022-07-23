namespace FRMJX.Infrastructure.CmsDomain;

using FRMJX.Infrastructure.CmsDomain.Services;
using FRMJX.Core.CmsDomain.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfiguration
{
	public static void ConfigureCmsDomainServices(this IServiceCollection services)
	{
		services.AddScoped<IFaqCreateService, FaqCreateService>();
		services.AddScoped<IFaqDeleteService, FaqDeleteService>();
		services.AddScoped<IFaqGetService, FaqGetService>();
		services.AddScoped<IFaqUpdateService, FaqUpdateService>();

		services.AddScoped<ICustomFileCreateService, CustomFileCreateService>();
		services.AddScoped<ICustomFileDeleteService, CustomFileDeleteService>();
		services.AddScoped<ICustomFileGetService, CustomFileGetService>();
		services.AddScoped<ICustomFileUpdateService, CustomFileUpdateService>();

		services.AddScoped<ISliderItemCreateService, SliderItemCreateService>();
		services.AddScoped<ISliderItemDeleteService, SliderItemDeleteService>();
		services.AddScoped<ISliderItemGetService, SliderItemGetService>();
		services.AddScoped<ISliderItemUpdateService, SliderItemUpdateService>();

		services.AddScoped<IImageCreateService, ImageCreateService>();
		services.AddScoped<IImageDeleteService, ImageDeleteService>();
		services.AddScoped<IImageGetService, ImageGetService>();
		services.AddScoped<IImageUpdateService, ImageUpdateService>();

		services.AddScoped<IVideoCreateService, VideoCreateService>();
		services.AddScoped<IVideoDeleteService, VideoDeleteService>();
		services.AddScoped<IVideoGetService, VideoGetService>();
		services.AddScoped<IVideoUpdateService, VideoUpdateService>();

		services.AddScoped<IPdfCreateService, PdfCreateService>();
		services.AddScoped<IPdfDeleteService, PdfDeleteService>();
		services.AddScoped<IPdfGetService, PdfGetService>();
		services.AddScoped<IPdfUpdateService, PdfUpdateService>();

		services.AddScoped<IBlogPostCreateService, BlogPostCreateService>();
		services.AddScoped<IBlogPostDeleteService, BlogPostDeleteService>();
		services.AddScoped<IBlogPostGetService, BlogPostGetService>();
		services.AddScoped<IBlogPostUpdateService, BlogPostUpdateService>();

		services.AddScoped<IBlogCommentCreateService, BlogCommentCreateService>();
		services.AddScoped<IBlogCommentDeleteService, BlogCommentDeleteService>();
		services.AddScoped<IBlogCommentUpdateService, BlogCommentUpdateService>();
		services.AddScoped<IBlogCommentGetService, BlogCommentGetService>();

		services.AddScoped<IBlogCategoryCreateService, BlogCategoryCreateService>();
		services.AddScoped<IBlogCategoryDeleteService, BlogCategoryDeleteService>();
		services.AddScoped<IBlogCategoryGetService, BlogCategoryGetService>();
		services.AddScoped<IBlogCategoryUpdateService, BlogCategoryUpdateService>();

		services.AddScoped<IBlogTypeCreateService, BlogTypeCreateService>();
		services.AddScoped<IBlogTypeDeleteService, BlogTypeDeleteService>();
		services.AddScoped<IBlogTypeGetService, BlogTypeGetService>();
		services.AddScoped<IBlogTypeUpdateService, BlogTypeUpdateService>();

		services.AddScoped<IInsuranceCreateService, InsuranceCreateService>();
		services.AddScoped<IInsuranceDeleteService, InsuranceDeleteService>();
		services.AddScoped<IInsuranceGetService, InsuranceGetService>();
		services.AddScoped<IInsuranceUpdateService, InsuranceUpdateService>();

		services.AddScoped<IEmployeeCreateService, EmployeeCreateService>();
		services.AddScoped<IEmployeeDeleteService, EmployeeDeleteService>();
		services.AddScoped<IEmployeeGetService, EmployeeGetService>();
		services.AddScoped<IEmployeeUpdateService, EmployeeUpdateService>();

		services.AddScoped<ITextEditorCreateService, TextEditorCreateService>();
		services.AddScoped<ITextEditorDeleteService, TextEditorDeleteService>();
		services.AddScoped<ITextEditorGetService, TextEditorGetService>();
		services.AddScoped<ITextEditorUpdateService, TextEditorUpdateService>();

		services.AddScoped<IAddressCreateService, AddressCreateService>();
		services.AddScoped<IAddressDeleteService, AddressDeleteService>();
		services.AddScoped<IAddressGetService, AddressGetService>();
		services.AddScoped<IAddressUpdateService, AddressUpdateService>();

		services.AddScoped<IContactUsCreateService, ContactUsCreateService>();
		services.AddScoped<IContactUsDeleteService, ContactUsDeleteService>();
		services.AddScoped<IContactUsGetService, ContactUsGetService>();
		services.AddScoped<IContactUsUpdateService, ContactUsUpdateService>();

		services.AddScoped<ISuggustionCreateService, SuggustionCreateService>();
		services.AddScoped<ISuggustionDeleteService, SuggustionDeleteService>();
		services.AddScoped<ISuggustionGetService, SuggustionGetService>();
		services.AddScoped<ISuggustionUpdateService, SuggustionUpdateService>();

		services.AddScoped<IVendoringCreateService, VendoringCreateService>();
		services.AddScoped<IVendoringDeleteService, VendoringDeleteService>();
		services.AddScoped<IVendoringGetService, VendoringGetService>();
		services.AddScoped<IVendoringUpdateService, VendoringUpdateService>();

		services.AddScoped<IInsuranceInfoCreateService, InsuranceInfoCreateService>();
		services.AddScoped<IInsuranceInfoDeleteService, InsuranceInfoDeleteService>();
		services.AddScoped<IInsuranceInfoGetService, InsuranceInfoGetService>();
		services.AddScoped<IInsuranceInfoUpdateService, InsuranceInfoUpdateService>();

		services.AddScoped<IRepresentationCreateService, RepresentationCreateService>();
		services.AddScoped<IRepresentationDeleteService, RepresentationDeleteService>();
		services.AddScoped<IRepresentationGetService, RepresentationGetService>();
		services.AddScoped<IRepresentationUpdateService, RepresentationUpdateService>();

		services.AddScoped<ISettingCreateService, SettingCreateService>();
		services.AddScoped<ISettingDeleteService, SettingDeleteService>();
		services.AddScoped<ISettingGetService, SettingGetService>();
		services.AddScoped<ISettingUpdateService, SettingUpdateService>();

		services.AddScoped<ISettingFileCreateService, SettingFileCreateService>();
		services.AddScoped<ISettingFileDeleteService, SettingFileDeleteService>();
		services.AddScoped<ISettingFileGetService, SettingFileGetService>();
		services.AddScoped<ISettingFileUpdateService, SettingFileUpdateService>();

		services.AddScoped<IMenuItemCreateService, MenuItemCreateService>();
		services.AddScoped<IMenuItemDeleteService, MenuItemDeleteService>();
		services.AddScoped<IMenuItemUpdateService, MenuItemUpdateService>();
		services.AddScoped<IMenuItemGetService, MenuItemGetService>();

		services.AddScoped<IVisionCreateService, VisionCreateService>();
		services.AddScoped<IVisionDeleteService, VisionDeleteService>();
		services.AddScoped<IVisionUpdateService, VisionUpdateService>();
		services.AddScoped<IVisionGetService, VisionGetService>();

		services.AddScoped<IVisionAttributeCreateService, VisionAttributeCreateService>();
		services.AddScoped<IVisionAttributeDeleteService, VisionAttributeDeleteService>();
		services.AddScoped<IVisionAttributeUpdateService, VisionAttributeUpdateService>();
		services.AddScoped<IVisionAttributeGetService, VisionAttributeGetService>();

		services.AddScoped<IJobPositionCreateService, JobPositionCreateService>();
		services.AddScoped<IJobPositionDeleteService, JobPositionDeleteService>();
		services.AddScoped<IJobPositionUpdateService, JobPositionUpdateService>();
		services.AddScoped<IJobPositionGetService, JobPositionGetService>();

		services.AddScoped<IRevelationCreateService, RevelationCreateService>();
		services.AddScoped<IRevelationDeleteService, RevelationDeleteService>();
		services.AddScoped<IRevelationUpdateService, RevelationUpdateService>();
		services.AddScoped<IRevelationGetService, RevelationGetService>();

		services.AddScoped<IRevelationAttributeCreateService, RevelationAttributeCreateService>();
		services.AddScoped<IRevelationAttributeDeleteService, RevelationAttributeDeleteService>();
		services.AddScoped<IRevelationAttributeUpdateService, RevelationAttributeUpdateService>();
		services.AddScoped<IRevelationAttributeGetService, RevelationAttributeGetService>();

		services.AddScoped<IAboutUsAttributeCreateService, AboutUsAttributeCreateService>();
		services.AddScoped<IAboutUsAttributeDeleteService, AboutUsAttributeDeleteService>();
		services.AddScoped<IAboutUsAttributeGetService, AboutUsAttributeGetService>();
		services.AddScoped<IAboutUsAttributeUpdateService, AboutUsAttributeUpdateService>();

		services.AddScoped<IHealthCenterCreateService, HealthCenterCreateService>();
		services.AddScoped<IHealthCenterDeleteService, HealthCenterDeleteService>();
		services.AddScoped<IHealthCenterGetService, HealthCenterGetService>();
		services.AddScoped<IHealthCenterUpdateService, HealthCenterUpdateService>();

		services.AddScoped<IHealthCenterPdfCreateService, HealthCenterPdfCreateService>();
		services.AddScoped<IHealthCenterPdfDeleteService, HealthCenterPdfDeleteService>();
		services.AddScoped<IHealthCenterPdfUpdateService, HealthCenterPdfUpdateService>();
		services.AddScoped<IHealthCenterPdfGetService, HealthCenterPdfGetService>();

		services.AddScoped<IAboutUsCreateService, AboutUsCreateService>();
		services.AddScoped<IAboutUsDeleteService, AboutUsDeleteService>();
		services.AddScoped<IAboutUsUpdateService, AboutUsUpdateService>();
		services.AddScoped<IAboutUsGetService, AboutUsGetService>();

		services.AddScoped<IRegulationCreateService, RegulationCreateService>();
		services.AddScoped<IRegulationDeleteService, RegulationDeleteService>();
		services.AddScoped<IRegulationUpdateService, RegulationUpdateService>();
		services.AddScoped<IRegulationGetService, RegulationGetService>();

		services.AddScoped<ISocialMediaCreateService, SocialMediaCreateService>();
		services.AddScoped<ISocialMediaDeleteService, SocialMediaDeleteService>();
		services.AddScoped<ISocialMediaUpdateService, SocialMediaUpdateService>();
		services.AddScoped<ISocialMediaGetService, SocialMediaGetService>();

		services.AddScoped<IRepresentativePanelCategoryCreateService, RepresentativePanelCategoryCreateService>();
		services.AddScoped<IRepresentativePanelCategoryDeleteService, RepresentativePanelCategoryDeleteService>();
		services.AddScoped<IRepresentativePanelCategoryUpdateService, RepresentativePanelCategoryUpdateService>();
		services.AddScoped<IRepresentativePanelCategoryGetService, RepresentativePanelCategoryGetService>();

		services.AddScoped<IRepresentativePanelCreateService, RepresentativePanelCreateService>();
		services.AddScoped<IRepresentativePanelDeleteService, RepresentativePanelDeleteService>();
		services.AddScoped<IRepresentativePanelUpdateService, RepresentativePanelUpdateService>();
		services.AddScoped<IRepresentativePanelGetService, RepresentativePanelGetService>();

		services.AddScoped<IPersonnelPanelCreateService, PersonnelPanelCreateService>();
		services.AddScoped<IPersonnelPanelDeleteService, PersonnelPanelDeleteService>();
		services.AddScoped<IPersonnelPanelUpdateService, PersonnelPanelUpdateService>();
		services.AddScoped<IPersonnelPanelGetService, PersonnelPanelGetService>();

		services.AddScoped<IPersonnelPanelCategoryCreateService, PersonnelPanelCategoryCreateService>();
		services.AddScoped<IPersonnelPanelCategoryDeleteService, PersonnelPanelCategoryDeleteService>();
		services.AddScoped<IPersonnelPanelCategoryUpdateService, PersonnelPanelCategoryUpdateService>();
		services.AddScoped<IPersonnelPanelCategoryGetService, PersonnelPanelCategoryGetService>();

		services.AddScoped<IGeneralConditionCreateService, GeneralConditionCreateService>();
		services.AddScoped<IGeneralConditionDeleteService, GeneralConditionDeleteService>();
		services.AddScoped<IGeneralConditionUpdateService, GeneralConditionUpdateService>();
		services.AddScoped<IGeneralConditionGetService, GeneralConditionGetService>();

		services.AddScoped<IGeneralRuleCreateService, GeneralRuleCreateService>();
		services.AddScoped<IGeneralRuleDeleteService, GeneralRuleDeleteService>();
		services.AddScoped<IGeneralRuleUpdateService, GeneralRuleUpdateService>();
		services.AddScoped<IGeneralRuleGetService, GeneralRuleGetService>();

		services.AddScoped<IConditionMembershipCreateService, ConditionMembershipCreateService>();
		services.AddScoped<IConditionMembershipDeleteService, ConditionMembershipDeleteService>();
		services.AddScoped<IConditionMembershipUpdateService, ConditionMembershipUpdateService>();
		services.AddScoped<IConditionMembershipGetService, ConditionMembershipGetService>();

		services.AddScoped<ISaleRuleCreateService, SaleRuleCreateService>();
		services.AddScoped<ISaleRuleDeleteService, SaleRuleDeleteService>();
		services.AddScoped<ISaleRuleUpdateService, SaleRuleUpdateService>();
		services.AddScoped<ISaleRuleGetService, SaleRuleGetService>();

		services.AddScoped<IRepresentationConditionCreateService, RepresentationConditionCreateService>();
		services.AddScoped<IRepresentationConditionDeleteService, RepresentationConditionDeleteService>();
		services.AddScoped<IRepresentationConditionUpdateService, RepresentationConditionUpdateService>();
		services.AddScoped<IRepresentationConditionGetService, RepresentationConditionGetService>();

		services.AddScoped<IUsefulLinkCreateService, UsefulLinkCreateService>();
		services.AddScoped<IUsefulLinkDeleteService, UsefulLinkDeleteService>();
		services.AddScoped<IUsefulLinkUpdateService, UsefulLinkUpdateService>();
		services.AddScoped<IUsefulLinkGetService, UsefulLinkGetService>();

		services.AddScoped<IDamageCenterCreateService, DamageCenterCreateService>();
		services.AddScoped<IDamageCenterDeleteService, DamageCenterDeleteService>();
		services.AddScoped<IDamageCenterUpdateService, DamageCenterUpdateService>();
		services.AddScoped<IDamageCenterGetService, DamageCenterGetService>();

		services.AddScoped<ICommonGetService, CommonGetService>();
	}
}
