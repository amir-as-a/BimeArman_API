namespace FRMJX.Infrastructure;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.CmsDomain.Models;
using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext
{
	public DbSet<State> States { get; set; }

	public DbSet<City> City { get; set; }

	public DbSet<Faq> Faqs { get; set; }

	public DbSet<CustomFile> CustomFiles { get; set; }

	public DbSet<SliderItem> SliderItems { get; set; }

	public DbSet<Image> Images { get; set; }

	public DbSet<Video> Videos { get; set; }

	public DbSet<Pdf> Pdfs { get; set; }

	public DbSet<BlogPost> BlogPosts { get; set; }

	public DbSet<BlogComment> BlogComment { get; set; }

	public DbSet<BlogCategory> BlogCategories { get; set; }

	public DbSet<BlogType> BlogTypes { get; set; }

	public DbSet<BlogPostBlogCategory> BlogPostBlogCategories { get; set; }

	public DbSet<Insurance> Insurances { get; set; }

	public DbSet<Employee> Employees { get; set; }

	public DbSet<TextEditor> TextEditors { get; set; }

	public DbSet<Address> Addresses { get; set; }

	public DbSet<ContactUs> ContactUs { get; set; }

	public DbSet<Suggustion> Suggustions { get; set; }

	public DbSet<Vendoring> Vendorings { get; set; }

	public DbSet<InsuranceInfo> InsuranceInfos { get; set; }

	public DbSet<Representation> Representations { get; set; }

	public DbSet<Setting> Settings { get; set; }

	public DbSet<SettingFile> SettingFiles { get; set; }

	public DbSet<MenuItem> MenuItems { get; set; }

	public DbSet<Vision> Visions { get; set; }

	public DbSet<VisionAttribute> VisionAttributes { get; set; }

	public DbSet<JobPosition> JobPositions { get; set; }

	public DbSet<Revelation> Revelations { get; set; }

	public DbSet<RevelationAttribute> RevelationAttributes { get; set; }

	public DbSet<AboutUsAttribute> AboutUsAttributes { get; set; }

	public DbSet<HealthCenter> HealthCenters { get; set; }

	public DbSet<HealthCenterPdf> HealthCenterPdfs { get; set; }

	public DbSet<AboutUs> AboutUses { get; set; }

	public DbSet<Regulation> Regulations { get; set; }

	public DbSet<SocialMedia> SocialMedia { get; set; }

	public DbSet<RepresentativePanelCategory> RepresentativePanelCategories { get; set; }

	public DbSet<PersonnelPanelCategory> PersonnelPanelCategories { get; set; }

	public DbSet<RepresentativePanel> RepresentativePanels { get; set; }

	public DbSet<PersonnelPanel> PersonnelPanels { get; set; }

	public DbSet<GeneralCondition> GeneralCondition { get; set; }

	public DbSet<GeneralRule> GeneralRule { get; set; }

	public DbSet<ConditionMembership> ConditionMembership { get; set; }

	public DbSet<SaleRule> SaleRules { get; set; }

	public DbSet<RepresentationCondition> RepresentationConditions { get; set; }

	public DbSet<UsefulLink> UsefulLinks { get; set; }

	public DbSet<DamageCenter> DamageCenters { get; set; }
}
