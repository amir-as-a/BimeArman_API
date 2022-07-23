namespace FRMJX.Infrastructure.SecurityDomain.Services
{
	using FRMJX.Core.Infrastructure;
	using FRMJX.Core.SecurityDomain.Dtos.Requests;
	using FRMJX.Core.SecurityDomain.Enums;
	using FRMJX.Core.SecurityDomain.Services;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Text;
	using System.Threading.Tasks;

	public class UserUpdateService : IUserUpdateService
	{
		private readonly DatabaseContext databaseContext;

		public UserUpdateService(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<ServiceResult> Update(int id, UserRegisterDto userRegisterDto, CancellationToken cancellationToken)
		{
			var serviceResult = new ServiceResult();

			var user = await databaseContext.Users
				.SingleOrDefaultAsync(current => current.Id == id);

			if (user is null)
			{
				serviceResult.SetStatusCode(HttpStatusCode.NotFound, "User not found");
				return serviceResult;
			}

			user.FirstName = userRegisterDto.FirstName;
			user.LastName = userRegisterDto.LastName;
			user.PhoneNumber = userRegisterDto.PhoneNumber;
			user.UserName = userRegisterDto.UserName;
			user.Email = userRegisterDto.Email;
			user.AccessLevel = (AccessLevelEnum)Enum.ToObject(typeof(AccessLevelEnum), userRegisterDto.AccessLevel);

			databaseContext.Update(user);
			await databaseContext.SaveChangesAsync(cancellationToken);

			return serviceResult;
		}
	}
}
