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
		private const string CorrectPassword = "Pasword1234!";
		public EditUserService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto Execute(int UserId, string FullName, string Email)
		{
			try
			{
				// check new information with Flunet Validatores
				// Password and RePass will set as granteed 
				RegisterUserValidatore validationRules = new();
				var validationResult = validationRules.Validate(new RequestRegisterUserDto()
					{
						FullName = FullName,
						Email = Email,
						Password = CorrectPassword,
						RePassword = CorrectPassword,
					}
				);

				if(validationResult.IsValid == false)
				{
					return new ResultDto()
					{
						IsSuccess = false,
						Message = validationResult.Errors[0].ErrorMessage,
					};
				}

				bool duplicateEmail = _context.Users.Any(u => u.Email == Email);
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
