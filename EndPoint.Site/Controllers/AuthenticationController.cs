using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Serivces.Users.Queries.UserLogin;
using Arshia_Store.Common.Dto;
using Arshia_Store.Common.UserRoles;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace EndPoint.Site.Controllers
{
	public class AuthenticationController : Controller
	{
		IRegisterUserService _registerUserService;
		IUserLoginService _userLoginService;
		public AuthenticationController(IRegisterUserService registerUserService, IUserLoginService userLoginService)
		{
			_registerUserService = registerUserService;
			_userLoginService = userLoginService;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SignUp(string FullName, string Email, string Password, string RePassword, bool Policy)
		{
			// If check box is not checked
			if(Policy == false)
			{
				var result1 = new ResultDto()
				{
					IsSuccess = false,
					Message = "برای ثبت نام باید قوانین فروشگاه را بپذیرید",
				};

				return Json(result1);
			}

			var newUser = new RequestRegisterUserDto()
			{
				FullName = FullName,
				Email = Email,
				Password = Password,
				RePassword = RePassword,
				roles = new List<RolesInRegisterUserDto>()
					{
						new RolesInRegisterUserDto(){Id=(int)UserRoles.Costumer},
					}
			};

			var result = _registerUserService.Execute(newUser);

			if(result.IsSuccess == true)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,result.Data.Id.ToString()),
					new Claim(ClaimTypes.Email,newUser.Email),
					new Claim(ClaimTypes.Name, newUser.FullName),
					new Claim(ClaimTypes.Role,"Costumer"),
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties()
				{
					IsPersistent = true,
				};

				HttpContext.SignInAsync(principal, properties);
			}

			return Json(result);
		}

		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SignIn(string Email, string Password)
		{
			var result = _userLoginService.Execute(Email, Password);

			if(result.IsSuccess == true)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,result.Data.UserId.ToString()),
					new Claim(ClaimTypes.Email,Email),
					new Claim(ClaimTypes.Name, result.Data.FullName),
					new Claim(ClaimTypes.Role,result.Data.Roles),
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties()
				{
					IsPersistent = true,
					ExpiresUtc = DateTime.Now.AddDays(5),
				};

				HttpContext.SignInAsync(principal, properties);
			}

			return Json(result);
		}

		public IActionResult UserSignOut()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");
		}
	}
}
