using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System;

namespace Arshia_Store.Application.Serivces.Users.Commands.RemoveUser
{
	public class RemoveUserService : IRemoveUserSerivce
	{
		private readonly IStoreDbContext _context;
		public RemoveUserService(IStoreDbContext context)
		{
			_context = context;
		}

		public ResultDto Execute(int userId)
		{
			try
			{
				var user = _context.Users.Find(userId);

				if(user == null)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "کاربر یافت نشد",
					};
				}

				user.IsRemoved = true;
				user.RemoveTime = DateTime.Now;
				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = "کاربر با موفقیت حذف شد",
				};
			}
			catch(Exception exeption)
			{
				return new ResultDto()
				{
					IsSuccess = true,
					Message = "عملیات ناموفق !",
				};
			}
		}
	}
}
