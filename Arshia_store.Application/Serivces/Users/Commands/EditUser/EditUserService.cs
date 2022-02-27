using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Validatores;
using Arshia_Store.Common.Dto;
using System;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Users.Commands.EditUser
{
	public class EditUserService : IEditUserService
	{
		private readonly IStoreDbContext _context;
		public EditUserService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto Execute(int UserId, string FullName, string Email)
		{
			try
			{
				// check new information with Flunet Validatores
				RegisterUserValidatore validationRules = new();
				var validationResult = validationRules.Validate(new RequestRegisterUserDto()
				{
					FullName = FullName,
					Email = Email,
				}
				);

				var errors = validationResult.Errors
					.Where(e => e.PropertyName == $"{nameof(RequestRegisterUserDto.FullName)}" || e.PropertyName == $"{nameof(RequestRegisterUserDto.Email)}")
					.ToList();

				if(errors.Count != 0)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = errors[0].ErrorMessage,
					};
				}

				// check if we have a user with same new Email
				bool duplicateEmail = _context.Users.Any(u => u.Id != UserId && u.Email == Email);
				if(duplicateEmail == true)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = "ایمیل تکراری است",
					};
				}

				// save new information
				var user = _context.Users.Find(UserId);

				user.FullName = FullName;
				user.Email = Email;

				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = "اطلاعات با موفقیت ثبت شد",
				};
			}
			catch(Exception exeption)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = "عملیات ناموفق!",
				};
			}
		}
	}
}
