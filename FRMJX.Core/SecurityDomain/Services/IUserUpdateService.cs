namespace FRMJX.Core.SecurityDomain.Services
{
	using FRMJX.Core.Infrastructure;
	using FRMJX.Core.SecurityDomain.Dtos.Requests;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public interface IUserUpdateService
	{
		Task<ServiceResult> Update(int id, UserRegisterDto userRegisterDto, CancellationToken cancellationToken);
	}
}
