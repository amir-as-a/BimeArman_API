namespace FRMJX.Core.Infrastructure;

public class ServiceResult<TResult> : ServiceResult
{
	public TResult Result { get; set; }
}
