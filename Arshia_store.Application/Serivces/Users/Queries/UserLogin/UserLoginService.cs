using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Validatores;
using Arshia_Store.Common.Dto;
using Arshia_Store.Common.HashPassword;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Users.Queries.UserLogin
{
	public class UserLoginService : IUserLoginService
	{
		private readonly IStoreDbContext _context;

		public UserLoginService(IStoreDbContext storeDbContext)
		{
			_context = storeDbContext;
		}
		public ResultDto<ResultUserLoginDto> Execute(string Email, string Password)
		{
			// check validation of Email and Password
			List<ValidationFailure> errors = ValidateLoginRequest(Email, Password);

			if(errors.Count != 0)
			{
				return new ResultDto<ResultUserLoginDto>()
				{
					IsSuccess = false,
					Message = errors.First().ErrorMessage,
					Data = new ResultUserLoginDto(),
				};
			}

			var user = _context.Users
				.Include(u => u.Roles)
				.Where(u => u.Email == Email && u.IsActive == true)
				.FirstOrDefault();

			if(user == null)
			{
				return new ResultDto<ResultUserLoginDto>()
				{
					IsSuccess = false,
					Message = "کابری با این ایمیل ثبت نام نکرده است",
					Data = new ResultUserLoginDto(),
				};
			}

			if(HashPassword.Verify(Password, user.Password) == true)
			{
				ResultUserLoginDto resultUserLoginDto = new ResultUserLoginDto()
				{
					FullName = user.FullName,
					UserId = user.Id,
					Roles = user.Roles.Select(r => r.Name).Aggregate((s1, s2) => s1 += s2),
				};

				return new ResultDto<ResultUserLoginDto>()
				{
					Data = resultUserLoginDto,
					IsSuccess = true,
					Message = "ورود موفق",
				};
			}
			else
			{
				return new ResultDto<ResultUserLoginDto>()
				{
					IsSuccess = false,
					Message = "رمز عبور یا ایمیل اشتباه وارد شده است",
					Data = new ResultUserLoginDto(),
				};
			}
		}

		private static List<ValidationFailure> ValidateLoginRequest(string Email, string Password)
		{
			RequestRegisterUserDto userDto = new RequestRegisterUserDto()
			{
				Email = Email,
				Password = Password,
			};

			RegisterUserValidatore validations = new RegisterUserValidatore();
			var errors = validations.Validate(userDto).Errors;
			errors = errors
				.Where(e => e.PropertyName == $"{nameof(userDto.Email)}" || e.PropertyName == $"{nameof(userDto.Password)}")
				.ToList();

			return errors;
		}
	}
}
