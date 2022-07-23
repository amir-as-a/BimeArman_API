namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.Infrastructure;

public class CustomFile : BaseEntity
{
	public string Name { get; set; }

	public string ContentType { get; set; }

	public byte[] Content { get; set; }

	public long Size { get; set; }

	public ICollection<SliderItem> SliderItems { get; set; }

	public ICollection<AboutUs> AboutUs { get; set; }

	public ICollection<Image> Images { get; set; }

	public ICollection<Video> Videos { get; set; }

	public ICollection<Pdf> Pdfs { get; set; }

	public ICollection<SettingFile> SettingFiles { get; set; }

	public ICollection<BlogPost> BlogPostPictures { get; set; }

	public ICollection<Insurance> Insurances { get; set; }

	public ICollection<Employee> Employees { get; set; }

	public ICollection<Vision> Visions { get; set; }

	public ICollection<Regulation> Regulations { get; set; }

	public ICollection<SocialMedia> SocialMedias { get; set; }

	public ICollection<RepresentativePanel> RepresentativePanels { get; set; }

	public ICollection<PersonnelPanel> PersonnelPanels { get; set; }

	public ICollection<ConditionMembership> ConditionMemberships { get; set; }

	public ICollection<UsefulLink> UsefulLinks { get; set; }

	public ICollection<HealthCenterPdf> HealthCenterPdfs { get; set; }

	public ICollection<Revelation> Revelations { get; set; }

	public ICollection<RevelationAttribute> RevelationAttributes { get; set; }
}
