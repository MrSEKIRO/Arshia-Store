using Arshia_Store.Application.Serivces.Users.Queries.GetUsers;
using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.Users.Queries.UserLogin
{
	public interface IUserLoginService
	{
		ResultDto<ResultUserLoginDto> Execute(string Email,string Password);
	}
}
