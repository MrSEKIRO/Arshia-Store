using Arshia_Store.Application.Serivces.Users.Commands.RegisterUser;
using Arshia_Store.Application.Serivces.Users.Commands.RemoveUser;
using Arshia_Store.Application.Serivces.Users.Commands.UserStatusChange;
using Arshia_Store.Application.Serivces.Users.Queries.GetRoles;
using Arshia_Store.Application.Serivces.Users.Queries.GetUsers;
using Arshia_Store.Application.Validatores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IGetUsersService _getUsersService;
		private readonly IGetRolesService _getRolesService;
		private readonly IRegisterUserService _registerUserService;
		private readonly IRemoveUserSerivce _removeUserService;
		private readonly IUserStatusChange _userStatusChange;
		public UserController(IGetUsersService getUsersService
			, IGetRolesService getRolesService
			, IRegisterUserService registerUserService
			, IRemoveUserSerivce removeUserSerivce
			, IUserStatusChange userStatusChange)
		{
			_getUsersService = getUsersService;
			_getRolesService = getRolesService;
			_registerUserService = registerUserService;
			_removeUserService = removeUserSerivce;
			_userStatusChange = userStatusChange;
		}

		public IActionResult Index(string searchKey, int page = 1)
		{
			return View(_getUsersService.Execute(new RequestGetUserDto { SearchKey = searchKey, Page = page }));
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(string FullName, string Email, long RoleId, string Password, string RePassword)
		{
			var result = _registerUserService.Execute(new RequestRegisterUserDto
			{
				FullName = FullName,
				Email = Email,
				roles = new List<RolesInRegisterUserDto>
					{
						new RolesInRegisterUserDto(){Id=RoleId}
					},
				Password = Password,
				RePassword = RePassword,
			});

			return Json(result);
		}

		[HttpPost]
		public IActionResult Delete(long UserId)
		{
			var result = _removeUserService.Execute((int)UserId);

			return Json(result);
		}

		[HttpPost]
		public IActionResult UserStatusChange(long UserId)
		{
			var result = _userStatusChange.Execute((int)UserId);

			return Json(result);
		}
	}
}
