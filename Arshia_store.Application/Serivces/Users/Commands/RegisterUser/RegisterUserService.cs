using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Application.Validatores;
using Arshia_Store.Common.Dto;
using Arshia_Store.Common.HashPassword;
using Arshia_Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arshia_Store.Application.Serivces.Users.Commands.RegisterUser
{
	public class RegisterUserService : IRegisterUserService
	{
		private readonly IStoreDbContext _context;
		public RegisterUserService(IStoreDbContext storeDbContext)
		{
			_context = storeDbContext;
		}

		public ResultDto<ResultRegisterUser> Execute(RequestRegisterUserDto request)
		{
			try
			{
				RegisterUserValidatore validationRules = new RegisterUserValidatore();
				var validateResult = validationRules.Validate(request);

				if(validateResult.IsValid == false)
				{
					return new ResultDto<ResultRegisterUser>()
					{
						Data = new ResultRegisterUser() { Id = 0 },
						IsSuccess = false,
						Message = validateResult.Errors[0].ErrorMessage,
					};
				}

				var hasSameEmail = _context.Users.Any(u => u.Email == request.Email);
				if(hasSameEmail == true)
				{
					return new ResultDto<ResultRegisterUser>()
					{
						Data = new ResultRegisterUser() { Id = 0 },
						IsSuccess = false,
						Message = "کاربری با این ایمیلا قبلا ثبت نام کرده است",
					};
				}

				var password=HashPassword.Hash(request.Password);

				User user = new User()
				{
					FullName = request.FullName,
					Email = request.Email,
					Password = password,
				};

				List<Role> roles = new List<Role>();

				foreach(var item in request.roles)
				{
					var role = _context.Roles.Find((int)item.Id);
					roles.Add(role);
				}

				user.Roles = roles;

				_context.Users.Add(user);
				_context.SaveChanges();

				return new ResultDto<ResultRegisterUser>()
				{
					Data = new ResultRegisterUser() { Id = user.Id },
					IsSuccess = true,
					Message = "ثبت نام کاربر انجام شد",
				};
			}
			catch(Exception exeption)
			{
				return new ResultDto<ResultRegisterUser>()
				{
					Data = new ResultRegisterUser() { Id = 0 },
					IsSuccess = false,
					Message = "عملیات ناموفق",
				};
			}
		}
	}
}
