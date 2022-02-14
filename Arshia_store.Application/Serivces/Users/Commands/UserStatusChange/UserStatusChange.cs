using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System;

namespace Arshia_Store.Application.Serivces.Users.Commands.UserStatusChange
{
	public class UserStatusChange : IUserStatusChange
	{
		private readonly IStoreDbContext _context;
		public UserStatusChange(IStoreDbContext context) 
		{
			_context = context;
		}
		public ResultDto Execute(int UserId)
		{
			try
			{
				var user = _context.Users.Find(UserId);
				if(user == null)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "کاربر موردنظر یافت نشد!",
					};
				}

				string message = string.Empty;
				if(user.IsActive == true)
				{
					message = "کابر غیر فعال شد";
				}
				else
				{
					message = "کاربر فعال شد";
				}
				user.IsActive = !user.IsActive;

				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = message,
				};
			}
			catch(Exception exeption)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "عملیات ناموفق !",
				};
			}
		}
	}
}
