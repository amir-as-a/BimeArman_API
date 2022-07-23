namespace FRMJX.Core.Infrastructure;

public class BaseExtendedEntity : BaseEntity
{
	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public DateTime InsertDateTime { get; set; }

	public DateTime UpdateDateTime { get; set; }
}
